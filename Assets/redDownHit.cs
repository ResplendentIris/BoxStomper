using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redDownHit : MonoBehaviour
{
    static public bool downHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        downHit = true;
    }
}
