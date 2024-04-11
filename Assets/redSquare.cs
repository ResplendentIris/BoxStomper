using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class redSquare : MonoBehaviour
{
    public Rigidbody2D redSquareRigid;
    public float redJump, redVelocityX = 4, rotationSpeed = 0, rotationMultiplyer = 1, tempVelocityX;
    static public bool colliding = false;
    public string jumpKey;
    public UnityEngine.KeyCode pressedKey;
    
      
    // Start is called before the first frame update
    void Start()
    {
        redSquareRigid.velocity = new Vector2(redVelocityX, redSquareRigid.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        //this code was stolen
        foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                Debug.Log("Keycode: " + kcode);
            Debug.Log(pressedKey.GetType().ToString());
        }

        if (Input.GetKeyDown(KeyCode.Space))//Jump w/ space
        {
            tempVelocityX = redSquareRigid.velocity.x;
            redSquareRigid.velocity = Vector2.up * redJump;
            redSquareRigid.velocity = new Vector2(tempVelocityX, redSquareRigid.velocity.y);
            /**redSquareRigid.velocity = new Vector2(redSquareRigid.velocity.x, redJump)*/
        }

        if (gameObject.transform.position.x > 8.5)//Right Bound
        {
            redSquareRigid.velocity = new Vector2(-(redVelocityX), redSquareRigid.velocity.y);
            
        }

        if (gameObject.transform.position.x < -8.5)//Left Bound
        {
            redSquareRigid.velocity = new Vector2((redVelocityX), redSquareRigid.velocity.y);
            
        }
        
        if (gameObject.transform.position.y < -4.5 || gameObject.transform.position.y > 4.5)//Upper - Lower Bound
        {
            gameObject.transform.position = new Vector2(0, 0);//Temperarily Reset to center of screen
        }
    }
    
    private void FixedUpdate()
    {
        if (redUpHit.upHit || redDownHit.downHit) 
        {
            colliding = true;
        }

        if (!colliding)//Rotating if not colliding
        {
            if (redSquareRigid.velocity.x > 0)//Changing rotation based on which direction the square is moving
            {
                rotationSpeed = rotationMultiplyer * redSquareRigid.velocity.y;//Rotation speed based on y-velocity and multiplyer
                transform.rotation = Quaternion.Euler(0, 0, rotationSpeed);//changing rotation
            }
            else
            {
                rotationSpeed = -(rotationMultiplyer * redSquareRigid.velocity.y);//Rotation speed based on y-velocity and multiplyer
                transform.rotation = Quaternion.Euler(0, 0, rotationSpeed);//changing rotation
            }
        }
    }
}
