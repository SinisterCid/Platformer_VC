using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickStuff : MonoBehaviour
{

    //grab 3d fx
    public GameObject hit;

    private void OnCollisionEnter(Collision col)
    {
        
        //if stick hits skua, instantiate fx
        if (col.gameObject.tag == "Skua")
        {

            Instantiate(hit, col.gameObject.transform.position, Quaternion.identity);
        }
    }
}
