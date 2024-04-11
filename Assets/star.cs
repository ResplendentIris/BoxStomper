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
        int tempInt = Random.Range(0, powerUps.Length);

        //runs code based on what number was generated
        if (tempInt == 0)
        {
            //Debug.Log(powerUps[tempInt]);
            //health();
            gravity(col.gameObject);
        }
        else if (tempInt == 1)
        {
            //Debug.Log(powerUps[tempInt]);
            gravity(col.gameObject);
        }
        else if (tempInt >= 2) 
        {
            //Debug.Log(powerUps[tempInt]);
            gravity(col.gameObject);
        }
    }

    void gravity(GameObject activator)
    {
        foreach (GameObject player in listPlayers)
        {
            if (player.name != activator.name)
            {
                victimRB = player.GetComponent<Rigidbody2D>();
                Debug.Log(player.name + " is not activator");
                //apply gravity
                victimRB.gravityScale += 5;
            }

            //else skip
        }
    }
}

 
        