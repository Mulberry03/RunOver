using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jump;
    public float playerSpeed;
    public Camera cam;

    private Vector3 playerInput;
    private Vector3 movePlayer;
    private Animator animator;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove,0,verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1); 

        camDirec();

        movePlayer =playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerJump();

        player.Move(movePlayer * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);

        animator.SetFloat("Mag",playerSpeed);
        
    }

    public void PlayerJump()
    {
        if(player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jump;
            movePlayer.y = fallVelocity;
            animator.SetFloat("Saltar",jump);
        }

        
    }


    void SetGravity()
    {
        
        if(player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }else{
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }
    
    void camDirec()
    {
        camForward = cam.transform.forward;
        camRight = cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
