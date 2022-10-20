using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Debug.Log("Enter");
    }
}
