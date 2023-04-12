using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeWater : MonoBehaviour
{
    public MovingSphere player;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GetComponent<MovingSphere>();
        }
        if(canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas != null)
        {
            if(player.Swimming)
            {
                canvas.SetActive(true);
            }
            else
            {
                canvas.SetActive(false);
            }
        }
    }
}
