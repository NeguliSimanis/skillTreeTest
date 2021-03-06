﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody2D;
    //UserInterfaceManager userInterfaceManager;

    public bool inFriendZone = false; // spēlētājam atrodoties friend zone, viņam iespējams iegūt jaunu draugu.

    #region movement data
    public bool isGrounded;
    public bool allowJump = false;
    public bool allowWalk = true;
    private float jumpForce = 500f;
    private float moveForce = 200f;
    #endregion

    #region animation data
    public Animator playerAnimator;
    #endregion

    void Start()
    {
        isGrounded = false;
        allowJump = false;
        allowWalk = false;
        playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        StartGame();
    }

    public void StartGame()
    {
        allowJump = true;
        allowWalk = true;
        //userInterfaceManager = GameManager.instance.gameObject.GetComponent<UserInterfaceManager>();
    }

    void Update()
    {
        CheckPlayerInput();
    }

    private void LateUpdate()
    {
        // update animations
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    private void CheckPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && allowJump && isGrounded)
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            //PlayerStats.current.currentJumpID++;
            //GameManager.instance.audioManager.PlayJumpSFX();
            //if (PlayerStats.current.gainConfidenceOnJump)
            //    GainLifeOnJump();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && allowWalk)
        {
            playerRigidbody2D.AddForce(Vector2.right * moveForce);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && allowWalk)
        {
            playerRigidbody2D.AddForce(Vector2.left * moveForce);
        }
    }

    private void GainLifeOnJump()
    {
        //if (PlayerStats.current.currentJumpID >= PlayerStats.current.jumpConfidenceGainFrequency &&
        //    PlayerStats.current.currentLives > 0)
        //{
        //    PlayerStats.current.currentJumpID = -1;
        //    userInterfaceManager.AddLife(1);
        //}
    }
}
