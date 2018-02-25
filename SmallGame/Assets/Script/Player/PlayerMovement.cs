using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Move(hor, ver);
        Animating(hor, ver);
        Turning(hor, ver);
        
    }

    void Move(float hor, float ver)
    {
        movement.Set(hor, 0f, ver);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Animating(float hor, float ver)
    {
        bool walking = hor != 0f || ver != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void Turning(float hor, float ver)
    {
        if (hor == 0f & ver == 0f)
        {
            return;
        }
        movement.Set(hor, 0f, ver);
        Quaternion playerRotatation = Quaternion.LookRotation(movement);
        playerRigidbody.MoveRotation(playerRotatation);
    }
}
