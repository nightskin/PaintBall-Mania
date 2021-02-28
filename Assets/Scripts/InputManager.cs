using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private InputMaster controls;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        int utils = GameObject.FindGameObjectsWithTag("Util").Length;
        if (utils > 1)
        {
            GameObject[] arr = GameObject.FindGameObjectsWithTag("Util");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                {
                    Destroy(arr[i]);
                }
            }

        }
        controls = new InputMaster();
    }

    void Start()
    {
        PlayerPrefs.SetFloat("r", 0);
        PlayerPrefs.SetFloat("g", 0);
        PlayerPrefs.SetFloat("b", 1);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        //controls.Disable();
    }


    //-----------------------------------------Controls---------------------
    public Vector2 GetMovement()
    {
        return controls.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetAim()
    {
        return controls.Player.Aim.ReadValue<Vector2>();
    }

    public bool Jumped()
    {
        return controls.Player.Jump.triggered;
    }

    public bool Shooting()
    {
        return controls.Player.Shoot.triggered;
    }


    //------------------------------------------Menus-----------------------
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Options");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PrevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Arena 1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Arena 2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("Arena 3");
    }
}
