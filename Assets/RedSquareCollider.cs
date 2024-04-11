using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSquareCollider : MonoBehaviour
{
    public Transform redSquareTransform;
    public Transform redSquareColliderTransform;

    void Start()
    {
        redSquareColliderTransform.position = redSquareTransform.position;//Syncing Positions
    }

    void Update()
    {
        if (redSquare.colliding == true)//Syncing the redSquare to Collider so Collider doesn't fall through stuff
        {
            redSquareTransform.position = redSquareColliderTransform.position;
            //redSquareColliderTransform.position = redSquareTransform.position;
        }
        else
        {
            redSquareColliderTransform.position = redSquareTransform.position;//Syncing Positions every frame
        }
    }
}
