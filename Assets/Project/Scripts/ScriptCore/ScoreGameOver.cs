using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
    #region var
    public Text scoreText;
    public Text recordText;
    int Score;
    
    public JSonSave load;
    #endregion
    #region methods
    void Start()
    {
        
        Score= PlayerPrefs.GetInt("Score");
        load.LoadHS();
    }

    void Update()
        {

        if (SceneManager.GetActiveScene().name == "DuckShots")
        {
            scoreText.text = "Total Score: " + Score + " Points";
            recordText.text = "Highscore: " + load.highscorePatos + " Points";
        }
        if (SceneManager.GetActiveScene().name == "PirateShots")
        {
            scoreText.text = "Total Score: " + Score + " Points";
            recordText.text = "Highscore: " + load.highscorePiratas + " Points";
        }
        
        }
    #endregion
}
