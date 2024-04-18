using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class powerups : MonoBehaviour
{
    public GameObject syncTo;
    public GameObject hearts;
    public GameObject shieldObject;
    public int lives = 3;
    public bool shield = false;


    // Start is called before the first frame update
    void Start()
    {
        //set the 3 heart sprite to heartsprite
        hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart3").GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lives);
        //sets heart position to 1 above redsquare
        hearts.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);


        //sets shields position to redsquare as long as shield is active
        if (shield)
        {
            shieldObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //removes shield and makes it invisible if active, removes lives otherwise
        //healthUpdate must be on the last line
        if (shield)
        {
            shield = false;
            shieldObject.GetComponent<SpriteRenderer>().enabled = false;
            healthUpdate();

        }
        //doesn't let lives go less than 0
        else if (lives > 0)
        {
            lives -= 1;
            healthUpdate();
        }
        else
        {
            //this is so the health still updates even when it equals 0
            healthUpdate();
        }
        

 



    }
    public void healthUpdate()
    {
        //sets the correct heart sprite for number of lives left
        if (lives == 3)
        {
            hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart3").GetComponent<SpriteRenderer>().sprite;
        }
        else if (lives == 2)
        {
            hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart2").GetComponent<SpriteRenderer>().sprite;
        }
        else if (lives == 1)
        {
            hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart1").GetComponent<SpriteRenderer>().sprite;
        }
        else if (lives == 0)
        {
            hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart0").GetComponent<SpriteRenderer>().sprite;

        }
    }




}
