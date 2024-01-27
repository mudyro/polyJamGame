using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    
    [SerializeField]
    float playerSpeed = 10;

    [SerializeField] private AudioSource testSFX;

    bool isPlayerMovementKeyPressed;
    bool isSoundPlayed;

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
            if(!isSoundPlayed)
            {
                StartCoroutine(PlayStepSound());
            }
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.down);
            isPlayerMovementKeyPressed = true;
            if(!isSoundPlayed)
            {
                StartCoroutine(PlayStepSound());
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.left);
            isPlayerMovementKeyPressed = true;
            if(!isSoundPlayed)
            {
                StartCoroutine(PlayStepSound());
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(playerSpeed * Vector2.right);
            isPlayerMovementKeyPressed = true;

            if(!isSoundPlayed)
            {
                StartCoroutine(PlayStepSound());
            }
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

    IEnumerator PlayStepSound()
    {
        testSFX.Play();
        isSoundPlayed = true;
        yield return new WaitForSeconds(0.3f);
        isSoundPlayed = false;
    }
}

