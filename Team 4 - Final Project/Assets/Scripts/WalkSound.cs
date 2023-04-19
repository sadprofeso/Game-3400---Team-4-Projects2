using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    [SerializeField]
    public AudioSource walkSource;

    [SerializeField]
    public MovingSphere player;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingSphere>();
        }

        rb = player.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
        if (!player.Swimming)
        {
            if (rb.velocity.magnitude > 0.05 && player.transform.position.y > 2.7)
            {
                if (walkSource.loop == false)
                {
                    walkSource.loop = true;
                    playSound();
                }
                
            }
            else
            {
                Debug.Log("stopped");
                walkSource.Stop();
                walkSource.loop = false;
            }
        }
        else
        {
            walkSource.Stop();
            walkSource.loop = false;
        }
    }

    void playSound()
    {
        walkSource.Play();
    }
}
