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

    void Start()
    {
        //Randomize start position
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-3, 3), 0);
    }

    //detects collisions
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        //input all GameObjects with player tag into listPlayers
        listPlayers = GameObject.FindGameObjectsWithTag("Players");

        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-3, 3), 0);

        //Gets a random ability in ability
        int tempInt = Random.Range(0, powerUps.Length);
        string ability = powerUps[tempInt];
        Debug.Log(ability);

        //runs code based on what ability it randomized to 
        if (ability == "health")
        {
            giveHealth(col.gameObject);
        }
        else if (ability == "gravity")
        {
            giveGravity(col.gameObject);
        }
        else if (ability == "shield") 
        {
            giveShield(col.gameObject);
        }
    }

    //Apply Gravity to everyone else except for the activator
    void giveGravity(GameObject activator)
    {
        //loops through all players
        foreach (GameObject player in listPlayers)
        {
            //Checking if the player is the one who activated the ability
            if (player.name != activator.name)
            {
                victimRB = player.GetComponent<Rigidbody2D>();
                //Applying gravity
                victimRB.gravityScale = 5;
                victimRB.GetComponent<powerups>().gravity = true;

            }
        }
    }

    //Giving health to the player who activated the ability
    void giveHealth(GameObject activator)
    {
        activator.GetComponent<powerups>().lives += 1;
        activator.GetComponent<powerups>().healthUpdate();
    }
//Giving a shield to the player who activated the ability
    void giveShield(GameObject activator)
    {
        activator.GetComponent<powerups>().shieldObject.GetComponent<SpriteRenderer>().enabled = true;
        activator.GetComponent<powerups>().shield = true;
    }
}


