using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayerController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject cameraHolder;

    [SerializeField]
    float mouseSenitivity;

    [SerializeField]
    float sprintSpeed;

    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float smoothTime;

    [SerializeField]
    Item[] items;

    int itemIndex;
    int previousItemIndex = -1;

    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Rigidbody rb;

    PhotonView pv;

    [SerializeField]
    private float projectileSpeed = 5f;
    [SerializeField]
    private GameObject projectile = null;
    [SerializeField]
    private Transform bulletSpawnPoint = null;

    [SerializeField]
    bool redPlayer; 
    [SerializeField]
    bool bluePlayer;

    Gamemanager gman;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (pv.IsMine)
        {
            EquipItem(0);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gman = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();

            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                redPlayer = true;
            }
            else
            {
                bluePlayer = true;
            }
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
    }

    private void Update()
    {
        if (!pv.IsMine)
            return;

        if (redPlayer && gman.redPlayerTurn || !gman.gameStarted)
        {
            Look();
            Move();
            Jump();
            Shoot();
        }
        else if(bluePlayer && !gman.redPlayerTurn || !gman.gameStarted)
        {
            Look();
            Move();
            Jump();
            Shoot();
        }
        

        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                EquipItem(i);
                break;
            }
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if(itemIndex >= items.Length - 1)
            {
                EquipItem(0);
            }
            else
            {
                EquipItem(itemIndex + 1);
            }
            
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (itemIndex <= 0)
            {
                EquipItem(items.Length - 1);
            }
            else
            {
                EquipItem(itemIndex - 1);
            }
            
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSenitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSenitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            photonView.RPC("FireProjectile", RpcTarget.All);
        }
    }

    void EquipItem(int _index)
    {
        if(_index == previousItemIndex)
        {
            return;
        }

        itemIndex = _index;
        items[itemIndex].itemGameobject.SetActive(true);

        if(previousItemIndex != -1)
        {
            items[previousItemIndex].itemGameobject.SetActive(false);
        }

        previousItemIndex = itemIndex;

        if (pv.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex", itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
       if(!pv.IsMine && targetPlayer == pv.Owner)
        {
            EquipItem((int)changedProps["itemIndex"]);
        }
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    private void FixedUpdate()
    {
        if (!pv.IsMine)
            return;

        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
    }

    [PunRPC]
    private void FireProjectile()
    {
        var projectileInstance = Instantiate(projectile, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        projectileInstance.GetComponent<Rigidbody>().velocity = projectileInstance.transform.forward * projectileSpeed;
    }
}
