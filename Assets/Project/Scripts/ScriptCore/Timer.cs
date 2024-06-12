using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region var
    public Text timeText;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public bool endGame = false;
    public bool timeOver = false;
    public GameManager GMS;
    public GameManager GameOver;
    #endregion
    #region methods
    public static Timer Singleton
    {
        get
        {

            if (instance == null)
            {
                //Rellenamos la referencia del Singleton
                instance = FindAnyObjectByType(typeof(Timer)) as Timer;
            }
            //Nos devuelve la información de la instancia
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static Timer instance;
    void Start()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameOver = GameObject.Find("GameManager").GetComponent<GameManager>();
        endGame = false;
    }
    void Update()
    {
        if (GMS.CountDownDone == true)
            timerIsRunning = true;
        
        if (timerIsRunning)
            {
            
                if (timeRemaining > 0)
                    {
                        timeRemaining -= Time.deltaTime;
                    }
                else
                    {
                        Debug.Log("Time has run out!");
                        timeRemaining = 0;
                        timerIsRunning = false;
                        endGame = true;
                        GameOver.GameOver();
                    }
            }
        DisplayTime(timeRemaining);
    }
    // Update is called once per frame
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    #endregion
}
