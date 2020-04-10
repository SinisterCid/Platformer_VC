using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSkua : MonoBehaviour
{

    //references
    public GameObject Skua;
    public GameObject triggerSpere;

    

    //when player character enters zone, activate corresponding Skua AI
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            Skua.SetActive(true);

            Destroy(triggerSpere);
        }
    }
}
