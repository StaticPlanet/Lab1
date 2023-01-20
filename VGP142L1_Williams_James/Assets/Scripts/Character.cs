using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float gravity = 9.81f;
    public float jumpSpeed = 10.0f;

    CharacterController controller;
    Vector3 moveDir;

    int errorCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            controller = GetComponent<CharacterController>();
            if (!controller)
                throw new NullReferenceException("character controller not set");

            controller.minMoveDistance = 0.0f;

            if (moveSpeed <= 0.0f)
            {
                moveSpeed = 10.0f;
                throw new UnassignedReferenceException("Speed not set on " + name + "defaulting to " + moveSpeed.ToString());
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
            errorCounter++;
        }
        catch (UnassignedReferenceException e)
        {
            Debug.Log(e.Message);
            errorCounter++;
        }
        finally
        {
            Debug.Log("The script ran with " + errorCounter.ToString() + "errors.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");


        if (controller.isGrounded)
        {
            moveDir = new Vector3(hInput, 0, vInput) * moveSpeed;
            moveDir = transform.TransformDirection(moveDir);

            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }

        moveDir.y -= gravity;

        controller.Move(moveDir * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Debug.Log("Collided with: " + other.name);
            Destroy(other.gameObject);
        }
    }
}
