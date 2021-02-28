using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

    public Text startTimerTxt;
    public Text gameTimerTxt;

    public GameObject player;
    public GameObject[] cpus;


    float startTimer = 1;
    float gameTimer = 1;

    public int countdown = 3;
    public int seconds = 0;
    public int minutes = 60;

    void Start()
    {
        cpus = GameObject.FindGameObjectsWithTag("CPU");
        if (seconds <= 9)
        {
            gameTimerTxt.text = minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            gameTimerTxt.text = minutes.ToString() + ":" + seconds.ToString();
        }

    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        startTimer -= Time.deltaTime;
        if(startTimer <= 0)
        {
            countdown--;
            startTimerTxt.text = countdown.ToString();
            startTimer = 1;
        }
        if (countdown <= 0)
        {
            StartGame();
        }
    }

    void UpdateTimeLimit()
    {
        if(seconds <= 0)
        {
            seconds = 59;
            minutes--;
        }
        else
        {
            seconds--;
        }

        if (seconds <= 9)
        {
            gameTimerTxt.text = minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            gameTimerTxt.text = minutes.ToString() + ":" + seconds.ToString();
        }
    }

    void StartGame()
    {
        startTimerTxt.enabled = false;
        transform.Find("Sight").gameObject.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        gameTimer -= Time.deltaTime;
        
        for(int i = 0; i < cpus.Length; i++)
        {
            cpus[i].GetComponent<Cpu>().start = true;
        }

        if (gameTimer <= 0)
        {
            UpdateTimeLimit();
            gameTimer = 1;
        }
    }
}
