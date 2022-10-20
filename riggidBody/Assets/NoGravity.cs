using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravity : MonoBehaviour
{
    Rigidbody _riggidbody;
    private void OnTriggerEnter(Collider other)
    {
       
        other.GetComponent<Rigidbody>().useGravity = false;
        Debug.Log("Garvity Off");
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent <Rigidbody>().useGravity = true;
        Debug.Log("Garvity On");
    }
}
