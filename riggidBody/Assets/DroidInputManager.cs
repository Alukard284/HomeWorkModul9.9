using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroidInputManager : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    private Rigidbody droidRB;

    public float radius;
    public float force;

    public float blastRadius;
    public float blastForce;

    [SerializeField] Text _droidGameText;
    void Start()
    {
        droidRB = GetComponent<Rigidbody>();
        _droidGameText.text = "Move - W,S,A,D \nShoot - Right Mouse \nBadaBoom - Space";
    }

    
    private void FixedUpdate()
    {
       
        MoveDroid();
        DroidBlast();


    }
    //Простенькое управление
    private void MoveDroid()
    {
        

        float moveVertical = Input.GetAxis("Vertical") * speed;
        droidRB.AddRelativeForce(0f, 0f, moveVertical);
        

        float rotateHorizontal = Input.GetAxis("Horizontal") * turnSpeed;
        droidRB.AddRelativeTorque(0f, rotateHorizontal, 0f);
       
        
    }
    //Атака по области
    private void DroidBlast()
    {
        if (Input.GetKey("mouse 1"))
        {
            Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();
            foreach (Rigidbody c in rigidbodies)
            {
                if (Vector3.Distance(transform.position, c.position) < blastRadius)
                {
                    Vector3 derection = c.transform.position - transform.position;
                    c.AddForce(derection.normalized * blastForce * (blastRadius - Vector3.Distance(transform.position, c.transform.position)), ForceMode.Impulse);
                }
            }
        }
    }
   
    //Сравнение враг или нет и удар при положителном вареанте
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Dubnic")
        {
            Vector3 direction = droidRB.transform.forward;
            collision.rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);
        }
    }
    //Радиус атаки по области
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
}
