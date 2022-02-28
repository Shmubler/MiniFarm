using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementKeyboard : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] public VectorValue startingPosition;
    [SerializeField] private float moveSpeed;                       //Default movement speed of the player
    [SerializeField] private float moveSpeedSprint;                 //Movement speed when the player is sprinting
    [NonSerialized] private Vector3 change;                         //Vector3 keeping track of player movement (x-axis, y-axis, z-axis [unused])
    [NonSerialized] private float speed;                            //Multiplier to control player movement speed

    [Space]

    [Header("PlayerTracking")]
    [NonSerialized] public PlayerStates playerState;               //Enum variable used to track the player's state
    private Rigidbody2D myRigidbody;                                //Rigidbody component of player
    //private bool wasMovingVertical;                               //Disabled to allow diagnal movement
    private Animator animator;                                      //Animator object

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
        playerState = PlayerStates.Free;
    }

    // Update is called once per frame
    void Update() {
        //Allow player movement if the player is currently not engaged in dialogue or in a menu
        if (playerState == PlayerStates.Free)
        {
            doMovement();
        }
    }

    void FixedUpdate() 
    {
        //Update player position based on user input calculated in doMovement()
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

    //Function to calculate the player's movement speed and direction based on user input
    void doMovement()
    {
        //If the shift key is pressed... 
        //...move the player at sprinting speed
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift);
        if (isShiftKeyDown) {
            speed = moveSpeedSprint;
        }
        ///...otherwise, move the player at regular speed
        else {
            speed = moveSpeed;
        }

        //Horizontal movement
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        bool isMovingHorizontal = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f;

        //Vertical movement
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        bool isMovingVertical = Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f;

        //Disabled to allow diagnal movement
        /*
        if (isMovingVertical && isMovingHorizontal) {
            if (wasMovingVertical) {
                change.y = 0;
            }
            else {
                change.x = 0;
            }
        }
        else if (isMovingHorizontal) {
            wasMovingVertical = false;
        }
        else if (isMovingVertical) {
            wasMovingVertical = true;
        }
        */

        //Animation
        if (change != Vector3.zero) {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }
    }
}