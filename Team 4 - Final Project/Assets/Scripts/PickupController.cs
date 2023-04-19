using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public GameObject player;
    public Transform pickupPoint;
    public float pickupRange = 2.0f;
    public bool equipped;
    public static bool mouthFull;
    public AudioClip pickupSFX;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if(pickupPoint == null)
            {
                pickupPoint = GameObject.FindGameObjectWithTag("PickupPoint").transform;
            }
            
        }
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
            mouthFull = false;
        }
        else
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            mouthFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) && !mouthFull)
        {
            PickUp();
        }
        if(equipped && Input.GetKeyDown(KeyCode.Q))
        {
            //Drop();
        }
    }

    public void PickUp()
    {
        equipped = true;
        mouthFull = true;

        transform.SetParent(pickupPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        rb.isKinematic = true;
        coll.isTrigger = true;

        if(pickupSFX != null)
        {
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
        }

    }

    public void Drop()
    {
        equipped = false;
        mouthFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        rb.useGravity = true;
        coll.isTrigger = false;

        if (pickupSFX != null)
        {
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
        }
    }
}
