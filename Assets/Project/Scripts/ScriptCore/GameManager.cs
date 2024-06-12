using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region variables
    public GameObject score,botonrecarga,timer,SpawnPoint1,SpawnPoint2,PauseScreen,GameOverScreen,ConfirmationScreen,SettingsScreen,RuleScreen,ScoreBoard,Cargador,Recargando,Reload;

    public Button PauseB,ResumeB,SettingsB,QuitGameB,MainMenuB,RestartB,BackB,RulesB;
  

    public bool isPaused = false;
    public bool gameOver = false;
    public bool CountDownDone = false;

    [SerializeField] private AudioSource GameMusic;

    public SQLite baseDatos;
    #endregion
    #region UnityMethods
    public void Start() 
        {
            
            PauseB.onClick.AddListener(Pause);
            ResumeB.onClick.AddListener(Resume);
            SettingsB.onClick.AddListener(Settings);
            QuitGameB.onClick.AddListener(QuitGame);
            MainMenuB.onClick.AddListener(MainMenu);
            RestartB.onClick.AddListener(Restart);
            BackB.onClick.AddListener(Back);
            

        }
    #endregion
    #region OwnMethods
    public void GameOver()
        {
            GameOverScreen.SetActive(true);
            SpawnPoint1.SetActive(false);
            SpawnPoint2.SetActive(false);
            GameMusic.Pause();
            gameOver = true;

            var timerREND = timer.GetComponent<CanvasRenderer>();
                if (timerREND != null ) 
                    {
                        timerREND.SetAlpha(0);
                    }

            var ScoreREND = score.GetComponent<CanvasRenderer>();
                if (ScoreREND != null)
                    {
                        ScoreREND.SetAlpha(0);
                    }

            var ScoreBoardREND = ScoreBoard.GetComponent<CanvasRenderer>();
                if (ScoreBoardREND != null)
                    {
                        ScoreBoardREND.SetAlpha(0);
                    }

            var botonrecargaREND = botonrecarga.GetComponent<CanvasRenderer>();
                if (botonrecargaREND != null)
                    {
                        botonrecargaREND.SetAlpha(0);
                    }

            var CargadorREND = Cargador.GetComponent<CanvasRenderer>();
                if (CargadorREND != null)
                    {
                        CargadorREND.SetAlpha(0);
                    }

            var PauseREND = PauseB.GetComponent<CanvasRenderer>();
                if (PauseREND != null)
                    {
                        PauseREND.SetAlpha(0);
                    }

            if (SceneManager.GetActiveScene().name == "DuckShots")
                {
                    baseDatos.Introducir("HighScorePatos", ScoreManager.Singleton.actualScore);
                    baseDatos.Select("HighScorePatos");
                }
            if (SceneManager.GetActiveScene().name == "PirateShots")
                {
                    baseDatos.Introducir("HighScorePiratas", ScoreManagerPirates.Singleton.actualScore);
                    baseDatos.Select("HighScorePiratas");
                }
    }
    public void Pause()
        {
            if (!isPaused && !gameOver)
                {
                    PauseScreen.SetActive(true);
                    PauseB.gameObject.SetActive(false);
                    botonrecarga.SetActive(false);
                    timer.SetActive(false);
                    Cargador.SetActive(false);
                    Recargando.SetActive(false);
                    Reload.SetActive(false);
                    isPaused = true;
                    GameMusic.Pause();
                    Time.timeScale = 0f;
                }
        }
    public void Resume()
        {
            if(isPaused)
                {
                    PauseScreen.SetActive(false);
                    PauseB.gameObject.SetActive(true);
                    botonrecarga.SetActive(true);
                    timer.SetActive(true);
                    Cargador.SetActive(true);
                    isPaused = false;
                    GameMusic.Play();
                    Time.timeScale = 1f;
                }
            
            
        }
    public void Settings()
        {
            SettingsScreen.SetActive(true);
            PauseScreen.SetActive(false);
        }
    public void Back()
        {
            SettingsScreen.SetActive(false);
            PauseScreen.SetActive(true);
        }
    public void yes()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(Scene.MainMenu.ToString());
            
        }
    public void no()
        {   
            ConfirmationScreen.gameObject.SetActive(false);
            PauseScreen.gameObject.SetActive(true);
        }
    public void QuitGame()
        {
            ConfirmationScreen.gameObject.SetActive(true);
            PauseScreen.gameObject.SetActive(false);
        }
    public void MainMenu()
        {
            if(gameOver)
            SceneManager.LoadScene(Scene.MainMenu.ToString());
        }
    public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    public void Rules()
        {
            RuleScreen.SetActive(true);
            SettingsScreen.SetActive(false);
        }
    public void understand()
        {
            RuleScreen.SetActive(false);
            SettingsScreen.SetActive(true);
        }
    public enum Scene
    {
        DuckShots,
        PirateShots,
        MainMenu
    }

    #endregion
}
