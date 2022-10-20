using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CueController : MonoBehaviour
{
    [SerializeField] Rigidbody _poolCue;
    [SerializeField] Rigidbody _redBall;
    [SerializeField] Text _poolText;
    [SerializeField] Text _hitText;

    private float moveInput;
    private float rotateInput;
    private float distanse;

    public float moveSpeed;
    public float rotateSpeed;
    public float forceHit;
    void Start()
    {
        _poolCue = GetComponent<Rigidbody>();
        _poolText.gameObject.SetActive(true);
        _poolText.text = "Move - W,S \nRotate - A,D \n" + "Hit - Space";
        _hitText.gameObject.SetActive(true);
    }

    
    void Update()
    {   //Просчитываю дистанцию
        distanse = Vector3.Distance(_poolCue.position, _redBall.position);
        //Считываю ввод
        moveInput = Input.GetAxis("Vertical") * moveSpeed;
        rotateInput = Input.GetAxis("Horizontal") *rotateSpeed;
        SpeedStoper();
        HitIndikator();
    }
    private void FixedUpdate()
    {
        HitOnRedBall();
        CueInput();
    }

    //Проверяю могу ли я ударить
    private void HitOnRedBall()
    {
        if(distanse <= 15)
        {
            if(Input.GetKey("space")) 
            { 
            Vector3 derection = _poolCue.transform.forward;
            _redBall.AddForce(derection.normalized * forceHit, ForceMode.Impulse);
                Debug.Log("Spase");
            }
            Debug.Log(distanse);
        }
    }

    //Проверяю не слишком ли близко
    private void SpeedStoper()
    {
        if(distanse <= 15)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 1000;
        }
        
    }
    //Управление Кием
    private void CueInput()
    {
        _poolCue.AddRelativeForce(0f, 0f, moveInput);
        _poolCue.transform.LookAt(_redBall.transform);
        _poolCue.transform.RotateAround(_redBall.transform.position, Vector3.up, rotateInput * Time.deltaTime);
    }

    private void HitIndikator()
    {
        if(distanse <= 15)
        {
            _hitText.color = Color.red;
            _hitText.text = "HIT!";
        }
        else
        {
            _hitText.color = Color.white;
            _hitText.text = "Hit";
        }
    }
}
