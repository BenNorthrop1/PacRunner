using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    Vector3 playerVelocity;
    bool groundedPlayer;
    

    public CharacterController charController;
    public float gravity = -20f;
    public float playerSpeed;
    

    private void Start() 
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        groundedPlayer = charController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charController.Move(move * Time.deltaTime * playerSpeed);



        playerVelocity.y += gravity * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);
    }
}
