using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSound : MonoBehaviour
{

    public MovingSphere player;
    public AudioSource swimsound;

    private float timer;
    float randomNumber;


    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingSphere>();
        }
        timer = Time.fixedTime;
        randomNumber = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Swimming)
        {
            
            if (Time.fixedTime - timer > randomNumber)
            {
                swimsound.Play();
                timer = Time.fixedTime;
                randomNumber = Random.Range(3f, 6f);
            }
        }
        else
        {
            swimsound.Stop();
        }
    }
}
