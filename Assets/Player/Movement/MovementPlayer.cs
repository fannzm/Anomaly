using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
   

    public CharacterController controller;

    public float speed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    float lockPos = 0;
    private float movementMultiplier = 1f;

    void Update()
    {

        transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal") * movementMultiplier;
        float z = Input.GetAxis("Vertical") * movementMultiplier;


        if (!isGrounded)
        {
            x = 0;
            if (z < 0) { z = 0; }
        }


        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;



        controller.Move(velocity * Time.deltaTime);


    }


public void SetInversion(bool active)
    {
        movementMultiplier = active ? -1f : 1f;
    }


}
