using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public int points = 0;
    public string[] powerUps = {"health", "gravity", "shield"};
    private Rigidbody2D victimRB;

    //makes a list of game objects
    public GameObject[] listPlayers;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-3, 3), 0);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //detects collisions
    private void OnTriggerEnter2D(Collider2D col)
    {
        //input all objects with player tag into listPlayers
        listPlayers = GameObject.FindGameObjectsWithTag("Players");

        //interates through each game object in list
        /**foreach (GameObject player in listPlayers)
        {
            Debug.Log(player.name);
        }*/


        //this command returns the name of the object that collides
        //Debug.Log(col.gameObject.name);

        //stores random value 0-3 as a float, it gets rounded down when put inside tempInt, effectively making it 0-2
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-3, 3), 0);

        int tempInt = Random.Range(0, powerUps.Length);

        //runs code based on what number was generated
        if (tempInt == 0)
        {
            //Debug.Log(powerUps[tempInt]);
            giveHealth(col.gameObject);
        }
        else if (tempInt == 1)
        {
            //Debug.Log(powerUps[tempInt]);
            giveGravity(col.gameObject);
        }
        else if (tempInt >= 2) 
        {
            //Debug.Log(powerUps[tempInt]);
            giveShield(col.gameObject);
        }
    }

    void giveGravity(GameObject activator)
    {
        foreach (GameObject player in listPlayers)
        {
            if (player.name != activator.name)
            {
                victimRB = player.GetComponent<Rigidbody2D>();
                //Debug.Log(player.name + " is not activator");
                //apply gravity
                victimRB.gravityScale = 5;
            }

            //else skip
        }
    }

    void giveHealth(GameObject activator)
    {
        activator.GetComponent<powerups>().lives += 1;
        activator.GetComponent<powerups>().healthUpdate();
    }

    void giveShield(GameObject activator)
    {
        activator.GetComponent<powerups>().shieldObject.GetComponent<SpriteRenderer>().enabled = true;
        activator.GetComponent<powerups>().shield = true;
    }


}


