using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]GameObject _startScreen;
    [SerializeField]GameObject _gameScreen;
    [SerializeField] Text gameText;
    [SerializeField] Text Hit;

    private GameObject _currentScreen;


    [SerializeField] GameObject _droidWars;
    [SerializeField] GameObject _pool;

    [SerializeField] Camera _mcamera;

    void Start()
    {
        _startScreen.SetActive(true);
        _currentScreen = _startScreen;
        
    }

    public void DroidWrasButton()
    {
        _startScreen.SetActive(false);
        _mcamera.gameObject.SetActive(false);
        _gameScreen.SetActive(true); 
        _droidWars.SetActive(true);
        gameText.gameObject.SetActive(true);
    }

    public void PoolGameButton()
    {
        _startScreen.SetActive(false);
        _mcamera.gameObject.SetActive(false);
        _gameScreen.SetActive(true);
        _pool.SetActive(true);
    }

    public void ExitButton(GameObject state)
    {
        if(_currentScreen != null)
        {
            _currentScreen.SetActive(false);
            state.SetActive(true);
            _currentScreen = state;
            _droidWars.SetActive(false);
            _pool.SetActive(false);
            _mcamera.gameObject.SetActive(true);
            gameText.gameObject.SetActive(false);
            Hit.gameObject.SetActive(false);
            

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
