using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driftToTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public PickupController pickUp;
    float pitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(pickUp == null)
        {
            pickUp = GetComponent<PickupController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.equipped)
        {
            if(target == null)
            {
                return;
            }

            Vector3 toTarget = (target.transform.position - player.transform.position).normalized;
            Quaternion targetRot = Quaternion.LookRotation(toTarget, Camera.main.transform.up);

            Camera.main.transform.rotation = Quaternion.Slerp(
            Camera.main.transform.rotation,
            targetRot,
            5 * Time.deltaTime
        );
        }
    }
}
