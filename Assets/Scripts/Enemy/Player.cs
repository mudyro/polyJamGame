using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    
    [SerializeField]
    float playerSpeed = 10;

    bool isPlayerMovementKeyPressed;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.up);
            isPlayerMovementKeyPressed = true;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.down);
            isPlayerMovementKeyPressed = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.left);
            isPlayerMovementKeyPressed = true;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.right);
            isPlayerMovementKeyPressed = true;
        }
        else
        {
            isPlayerMovementKeyPressed = false;
        }

        if(!isPlayerMovementKeyPressed)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
