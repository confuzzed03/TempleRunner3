using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerControl : MonoBehaviour
{

    public GameControlScript control;
    CharacterController controller;
    bool isGrounded = true;
    public float speed = 6.0f;
    public float jumpSpeed = 0.5f;
    public float gravity = 100000f;
    private Vector3 moveDirection = Vector3.zero;

    //start 
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            controller.GetComponent<Animation>().Play("HumanoidRun");            //play "run" animation if spacebar is not pressed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
            
            //moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
            moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 

            if (Input.GetButton("Jump"))
            {          //play "Jump" animation if character is grounded and spacebar is pressed
                GetComponent<Animation>().Stop("HumanoidRun");
                GetComponent<Animation>().Play("HumanoidIdleJumpUp");
                moveDirection.y = jumpSpeed;         //add the jump height to the character
            }

            if (isGrounded)           //set the flag isGrounded to true if character is grounded
                isGrounded = true;
        }

        moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity

        //if (moveDirection.y < -1.6f)
        //{
        //    moveDirection.y = -2f;
        //}
        transform.rotation = new Quaternion();
        controller.Move(moveDirection * Time.deltaTime);      //Move the controller
        Debug.Log(moveDirection.y);
    }

    //check if the character collects the powerups or the snags
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Powerup(Clone)")
        {
            control.PowerupCollected();
        }
        else if (other.gameObject.name == "Obstacle(Clone)" && isGrounded == true)
        {
            control.AlcoholCollected();
        }
        Destroy(other.gameObject);            //destroy the snag or powerup if colllected by the player

    }
}