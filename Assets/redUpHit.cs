using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redUpHit : MonoBehaviour
{
    static public bool upHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        upHit = true;

    }
}
