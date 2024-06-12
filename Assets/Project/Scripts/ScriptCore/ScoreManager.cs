using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region var
    public static ScoreManager scoreInstance { get; private set;}
    public Text scoreText;
    public int actualScore;
    public int ActualHighscore;
    public int RealHighscore;
    #endregion
    #region methods
    public static ScoreManager Singleton
    {
        get
        {

            if (instance == null)
            {
              instance = FindAnyObjectByType(typeof(ScoreManager)) as ScoreManager;
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static ScoreManager instance;
    private void Awake() 
        {
           if(scoreInstance !=null && scoreInstance != this) 
            {
               Destroy(scoreInstance);
            }
           else scoreInstance=this;
        }
    void Start()
        {
            actualScore = 0;
            JSonSave.Singleton.LoadHS();
        }

    public void AddPoints (int newScore)
        {
            actualScore += newScore;
        }

    private void UpdateScore()
        { 
            //Codigo para evitar la puntuación negativa  
            if(actualScore < 0)
                actualScore = 0;
            
            //SCORE
            PlayerPrefs.SetInt("Score", actualScore);

            scoreText.text = "Points " + actualScore;

        }
    void Update()
        {
            UpdateScore();
            SaveHighscore();
        }
    public void SaveHighscore()
           {
                if (Timer.Singleton.endGame == true)

                    {
                        if(actualScore > JSonSave.Singleton.highscorePatos)
                        JSonSave.Singleton.SaveHS();
                    }
                
           }

    public static implicit operator ScoreManager(ScoreManagerPirates v)
    {
        throw new NotImplementedException();
    }
    #endregion
}
