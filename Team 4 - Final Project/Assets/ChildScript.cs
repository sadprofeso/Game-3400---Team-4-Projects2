using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildScript : MonoBehaviour
{
    public GameObject player;
    public Transform exitDestination;
    public Transform grabPoint;
    bool eventTriggered;
    NavMeshAgent agent;
    Animator anim;
    float waitTime = 0;
    int scriptStage;
    GameObject eventObject;
    // Start is called before the first frame update
    void Start()
    {
        eventTriggered = false;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (eventTriggered)
        {
            if(scriptStage == 0)
            {
                waitTime -= Time.deltaTime;
                if(waitTime <= 0)
                {
                    agent.stoppingDistance = 1;
                    anim.SetInteger("state", 2);
                    scriptStage = 1;

                }
            }
            else if (scriptStage == 1 && Vector3.Distance(player.transform.position, transform.position) < 1.05)
            {
                scriptStage = 2;
                anim.SetInteger("state", 1);
                waitTime = 12;
            }
            else if(scriptStage == 2)
            {
                waitTime -= Time.deltaTime;
                if(waitTime <= 0)
                {
                    scriptStage = 3;
                    eventObject.GetComponent<Rigidbody>().isKinematic = true;
                    eventObject.GetComponent<BoxCollider>().isTrigger = true;
                    eventObject.transform.parent = grabPoint.transform;
                    eventObject.transform.localPosition = Vector3.zero;
                    eventObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    eventObject.transform.localScale /= 2;



                    agent.SetDestination(exitDestination.position);
                    agent.speed = 1;
                    anim.SetInteger("state", 2);
                    Invoke("endEvent", 1f);
                }
            }
        }
    }

    void startEvent()
    {
        eventTriggered = true;
        agent.SetDestination(player.transform.position);
        agent.stoppingDistance = 2.5f;
        waitTime = 2.0f;
        
    }

    void endEvent()
    {
        player.GetComponent<MovingSphere>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EventObject") && eventTriggered == false)
        {
            eventObject = other.gameObject;
            other.GetComponent<StableFloatingRigidbody>().enabled = false;
            other.GetComponent<PickupController>().Drop();
            player.GetComponent<MovingSphere>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            startEvent();
        }
    }
}
