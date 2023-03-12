using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float walkDistance = 10f;
    public float gravity = 15f;

    Vector3 startingPosition;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, startingPosition) < walkDistance)
        {
            Vector3 moveDirection = transform.forward * moveSpeed;
            moveDirection.y = 0;

            moveDirection.y -= gravity * Time.deltaTime;

            controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up * 180);
            startingPosition = transform.position;
        }
    }
}
