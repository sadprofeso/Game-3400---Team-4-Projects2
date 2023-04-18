using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lowpass : MonoBehaviour
{
    [SerializeField]
    public GameObject[] listOfSources;
    [SerializeField]
    public int cutoffFreq;
    public MovingSphere player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GetComponent<MovingSphere>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in listOfSources)
        {
            if (player.Swimming)
            {
                g.GetComponent<AudioLowPassFilter>().cutoffFrequency = cutoffFreq;
            }
            else
            {
                g.GetComponent<AudioLowPassFilter>().cutoffFrequency = 20000;
            }
            
        }
    }
}
