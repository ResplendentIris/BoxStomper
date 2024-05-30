using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class powerups : MonoBehaviour
{
    private GameObject heartsObject;
    private GameObject hearts;
    public GameObject shieldObject;
    public int lives = 3;
    public bool shield = false;
    private GameObject downArrow;
    public bool gravity = false;
    public bool alive = true;
    public bool lostAllLives;



    // Start is called before the first frame update
    void Start()
    {
        //sets objects to variable so we dont need public variables

        //instantiation makes it so every player can have a new thing
        downArrow = Instantiate(GameObject.Find("down arrow"));
        shieldObject = Instantiate(GameObject.Find("benshield"));
        heartsObject = GameObject.Find("redHeart");
        hearts = Instantiate(heartsObject);
        hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart3").GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

        //sets heart position to 1 above redsquare
        hearts.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        if (gravity)
        {
            downArrow.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

        }


        //sets shields position to redsquare as long as shield is active
        if (shield)
        {
            shieldObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        //sets veloctiy to 0 if player is dead
        if (!alive)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        //removes shield and makes it invisible if active, removes lives otherwise
            if (shield)
            {

                shieldObject.GetComponent<SpriteRenderer>().enabled = false;
                healthUpdate();
                shield = false;

            }
            if (collision.gameObject.tag == "ground")
            {
                //doesn't let lives go less than 0, doesnt let player lose lives until they revive by clicking
                if (lives > 0 && alive)
                {
                    lives -= 1;
                    healthUpdate();
                }
                else
                {
                    //this is so the health still updates even when it equals 0
                    healthUpdate();
                }

                //puts player in dead state after damage is taken
                alive = false;
            }
            else if (collision.gameObject.tag == "Players")
            {
                if (collision.transform.position.y > gameObject.transform.position.y && alive)
                {
                    lives -= 1;
                    healthUpdate();
                    alive = false;
                }
            }

    }
    //Function to update health
    public void healthUpdate()
    {
        Debug.Log(lostAllLives);
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
            //sets lose condition when lives is 0
            lostAllLives = true;
            hearts.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("heart0").GetComponent<SpriteRenderer>().sprite;
        }

    }
}
