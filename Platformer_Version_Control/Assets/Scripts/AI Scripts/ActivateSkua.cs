using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSkua : MonoBehaviour
{

    public GameObject Skua;
    public GameObject triggerSpere;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            Skua.SetActive(true);

            Destroy(triggerSpere);
        }
    }
}
