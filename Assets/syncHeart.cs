using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class syncHeart : MonoBehaviour
{
    public GameObject syncTo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(syncTo.transform.position.x, syncTo.transform.localPosition.y + 1, syncTo.transform.position.z);
        transform.position = newPos;
    }
}
