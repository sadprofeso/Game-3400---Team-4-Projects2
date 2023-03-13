using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PitchDown : MonoBehaviour
{

    public AudioSource audioSource;
    public Transform listener;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, listener.position);
        float pitch = Mathf.Lerp(1.0f, 0.4f, distance / audioSource.maxDistance);
        audioSource.pitch = pitch;
    }
}
