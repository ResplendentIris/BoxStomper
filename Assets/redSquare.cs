using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class redSquare : MonoBehaviour
{
    public Rigidbody2D redSquareRigid;
    public float redJump = 10, redVelocityX = 4, rotationSpeed = 0;
    private float rotationMultiplyer = 5, tempVelocityX;
    static public bool colliding = false;
    public UnityEngine.KeyCode jumpKey;
    private UnityEngine.KeyCode pressedKey;
    private bool goingRight;
      
    // Start is called before the first frame update
    void Start()
    {
        //moves player when game first starts
        redSquareRigid.velocity = new Vector2(redVelocityX, redSquareRigid.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(redSquareRigid.velocity.x);
        //sets if player is going right or not
        if (GetComponent<powerups>().alive)
        {
            if (redSquareRigid.velocity.x > 0)
            {
                goingRight = true;
            }
            else
            {
                goingRight = false;
            }
        }


        //this code was taken from internet, it checks every keycode to see which matches the key pressed
        //https://forum.unity.com/threads/find-out-which-key-was-pressed.385250/
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                pressedKey = kcode;

        }

        //jump when key assigned in jumpKey is pressed
        if (pressedKey == jumpKey)
        {
            //Debug.Log("matching");
            tempVelocityX = redSquareRigid.velocity.x;
            redSquareRigid.velocity = Vector2.up * redJump;
            redSquareRigid.velocity = new Vector2(tempVelocityX, redSquareRigid.velocity.y);
            pressedKey = 0;
            
            //resets velocity when player gets off the ground
            if (!GetComponent<powerups>().alive)
            {
                GetComponent<powerups>().alive = true;
                //sets the new velocity correctly based on what direction the player should move in
                if (goingRight)
                {
                    redSquareRigid.velocity = new Vector2(Math.Abs(redVelocityX), redSquareRigid.velocity.y);
                }
                else
                {
                    redSquareRigid.velocity = new Vector2(-Math.Abs(redVelocityX), redSquareRigid.velocity.y);

                }
            }
        }

        //Right Boundary of screen, changing direction of player
        if (gameObject.transform.position.x > 8.5)
        {
            redSquareRigid.velocity = new Vector2(-(Mathf.Abs(redSquareRigid.velocity.x)), redSquareRigid.velocity.y);
            //Debug.Log(gameObject.name + ":  has hit right wall");

        }

        //Left Boundary of screen, changing direction of player
        if (gameObject.transform.position.x < -8.5)
        {
            redSquareRigid.velocity = new Vector2(Mathf.Abs(redSquareRigid.velocity.x), redSquareRigid.velocity.y);

        }

        //Upper Boundary of screen, returns player to center of the screen
        if (gameObject.transform.position.y > 4.5)
        {
            //Reset to center of screen
            gameObject.transform.position = new Vector2(0, 0);
        }


    }

        private void FixedUpdate()
    {
        //Rotating player if not colliding
        if (!colliding)
        {
            //Changing rotation based on which direction the square is moving
            if (redSquareRigid.velocity.x > 0)
            {
                //Rotation speed based on y-velocity and multiplyer
                rotationSpeed = rotationMultiplyer * redSquareRigid.velocity.y;
                //changing rotation
                transform.rotation = Quaternion.Euler(0, 0, rotationSpeed);
            }
            else
            {
                //Rotation speed based on y-velocity and multiplyer
                rotationSpeed = -(rotationMultiplyer * redSquareRigid.velocity.y);
                //changing rotation
                transform.rotation = Quaternion.Euler(0, 0, rotationSpeed);
            }
        }
    }
}
