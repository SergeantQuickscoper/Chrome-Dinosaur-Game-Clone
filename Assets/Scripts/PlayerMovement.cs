using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D charController2D;
    public Animator anim;
    private ScoreManager scoreManager;
    public float HorizontalValue = 0f;
    public float runSpeed = 20f;
    private bool isStarted = false;
    bool isJump = false;
    bool isCrouch = false;
    bool isDead = false;
    private GameMaster gameMasterInstance;
    private PlayerMovement Player;
    public float SpeedMutliplier = 1.25f;
    public float SpeedMilestone = 100;
    private float SpeedMilestoneCount = 0;


    // Start is called before the first frame update
    void Awake()
    {
        gameMasterInstance = GameObject.FindObjectOfType<GameMaster>();
        Player = GameObject.FindObjectOfType<PlayerMovement>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x > SpeedMilestoneCount)
        {
            SpeedMilestoneCount += SpeedMilestone;
            SpeedMilestone = SpeedMilestone * SpeedMutliplier;
            runSpeed = runSpeed * SpeedMutliplier;
        }
        
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
        
        if(isDead == false && isStarted == true)
        {
            scoreManager.isScoreIncreasing = true;
        }
        else
        {
            
            scoreManager.isScoreIncreasing = false;
            
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
