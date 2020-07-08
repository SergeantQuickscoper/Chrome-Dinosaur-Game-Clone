﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D charController2D;
    public Animator anim;
    public float HorizontalValue = 0f;
    public float runSpeed = 20f;
    private bool isStarted = false;
    bool isJump = false;
    bool isCrouch = false;
    

    bool isDead = false;

    private GameMaster gameMasterInstance;
    private PlayerMovement Player;

    // Start is called before the first frame update
    void Awake()
    {
        gameMasterInstance = GameObject.FindObjectOfType<GameMaster>();
        Player = GameObject.FindObjectOfType<PlayerMovement>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(isDead ==false)
        {

        if (isStarted == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                anim.SetBool("IsJump", true);

            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                isCrouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isCrouch = false;
            }

        }

        if (isStarted == false && Input.GetKeyDown(KeyCode.Space))
        {
            isStarted = true;

        }
        }

        if(isDead == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gameMasterInstance.RespawnPlayer(isDead, Player);
            }
        }
        
    }

     void FixedUpdate()
    {
        if (isStarted == true)
        {
            if(isDead == false)
            {
            HorizontalValue = 1f;
            charController2D.Move(HorizontalValue * runSpeed * Time.fixedDeltaTime, isCrouch, isJump);
            isJump = false;
            anim.SetFloat("Speed", HorizontalValue);
            }
        }
    }

    public void OnLanding()
    {
        anim.SetBool("IsJump", false);
    }

    public void OnCrouch(bool isCrouching)
    {
        anim.SetBool("IsCrouch", isCrouching);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            isDead = true;
            anim.SetBool("IsDead", isDead);
        }
    }
}
