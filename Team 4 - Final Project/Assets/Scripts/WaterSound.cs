using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WaterSound : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public GameObject player;

    public float maxDistance = 10f;
    public float rollOffFactor = 1f;

    private Transform transformObject;

    // Start is called before the first frame update
    void Start()
    {
       transformObject = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromX = Mathf.Abs(transformObject.position.z - 57f);
	    float volume = (Mathf.Clamp01(1f - (distanceFromX / maxDistance) * rollOffFactor)) / 2;
	    audioSource.volume = volume;
        //Debug.Log(volume);
    }
}
