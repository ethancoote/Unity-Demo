using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVel;
    public float speed = 5f;
    public bool grounded;
    public float grav = -9.8f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
    }

    // recieve inputs from input manager
    public void ProcessMove(Vector2 input) 
    {
        // movement
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);

        // gravity
        playerVel.y += grav * Time.deltaTime;
        if (grounded && playerVel.y < 0) {
            playerVel.y = -2f;
        }        
        controller.Move(playerVel * Time.deltaTime);
    }

    // jump
    public void Jump() {
        if (grounded) {
            playerVel.y = Mathf.Sqrt(jumpHeight * -3f * grav);
        }
    }
}
