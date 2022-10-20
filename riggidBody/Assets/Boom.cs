using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float radius;
    public float force;
    void Start()
    {
       
    }

    
    void Update()
    {
        BadaBoom();
    }
    //ќтрисовка рдиуса взрыва
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    //ќпредел€ю все rigidbody в радиусе и придаю силы при нажатии space
    private void BadaBoom()
    {
        if (Input.GetKey("space"))
        {
            Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();
            foreach (Rigidbody c in rigidbodies)
            {
                if (Vector3.Distance(transform.position, c.position) < radius)
                {
                    Vector3 derection = c.transform.position - transform.position;
                    c.AddForce(derection.normalized * force * (radius - Vector3.Distance(transform.position,c.transform.position)), ForceMode.Impulse);
                }
            }
        }
    }
}
