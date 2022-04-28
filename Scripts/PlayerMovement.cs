using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movement;
    Animator anim;
    float rotateSpeed = 20f;
    Quaternion rotation;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        anim.SetBool("isWalking", isWalking);

        Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, movement, rotateSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(rotateDirection);
    }


    void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * anim.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}

