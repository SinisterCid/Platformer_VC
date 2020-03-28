using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickStuff : MonoBehaviour
{

    public GameObject hit;

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Skua")
        {

            Instantiate(hit, col.gameObject.transform.position, Quaternion.identity);
        }
    }
}
