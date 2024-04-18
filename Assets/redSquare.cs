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
    
      
    // Start is called before the first frame update
    void Start()
    {
        redSquareRigid.velocity = new Vector2(redVelocityX, redSquareRigid.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        //this code was taken from internet, it checks every keycode to see which matches the key pressed
        foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                pressedKey = kcode;

        }

        if(pressedKey == jumpKey)//jump when key assigned in jumpKey is pressed
        {
            Debug.Log("matching");
            tempVelocityX = redSquareRigid.velocity.x;
            redSquareRigid.velocity = Vector2.up * redJump;
            redSquareRigid.velocity = new Vector2(tempVelocityX, redSquareRigid.velocity.y);
            pressedKey = 0;
        }

        if (gameObject.transform.position.x > 8.5)//Right Bound
        {
            redSquareRigid.velocity = new Vector2(-(redVelocityX), redSquareRigid.velocity.y);
            
        }

        if (gameObject.transform.position.x < -8.5)//Left Bound
        {
            redSquareRigid.velocity = new Vector2((redVelocityX), redSquareRigid.velocity.y);
            
        }

        //Upper - Lower Bound
        if (gameObject.transform.position.y < -4.5 || gameObject.transform.position.y > 4.5)
        {
            //Temperarily Reset to center of screen
            gameObject.transform.position = new Vector2(0, 0);
        }
    }
    
    private void FixedUpdate()
    {
        //Rotating if not colliding
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
                rotationSpeed = -(rotationMultiplyer * redSquareRigid.velocity.y);//Rotation speed based on y-velocity and multiplyer
                transform.rotation = Quaternion.Euler(0, 0, rotationSpeed);//changing rotation
            }
        }
    }
}
