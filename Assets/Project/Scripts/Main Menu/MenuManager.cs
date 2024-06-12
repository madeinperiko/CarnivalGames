using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{

    #region variables
    public GameObject PressAny;
    public GameObject SettingsScreen;
    public GameObject ConfirmationScreen;
    public GameObject Title;
    public GameObject glow;
    public GameObject RuleScreen;
    public GameObject LevelSelector;
    public Button RulesB;
    public Button GotItB;
    public Button StartGameB;
    public Button StartDucksB;
    public Button StartPiratesB;
    public Button SettingsB;
    public Button QuitGameB;
    public Button BackB;
    public Button BackLSB;
    [SerializeField] private float highscore;

    public AudioMixer Background;
    public AudioMixer SoundsC;
    public float volumeBack;
    public float SoundsCont;

    public JSonSave save;
    public Text HighscorePatos;
    public Text HighscorePiratas;
    #endregion
    #region UnityMethods
    void Start() 
        {
            Time.timeScale = 1f;
            StartGameB.onClick.AddListener(LevelSelect);
            StartDucksB.onClick.AddListener(StartDuck);
            StartPiratesB.onClick.AddListener(StartPirates);
            SettingsB.onClick.AddListener(Settings);
            QuitGameB.onClick.AddListener(QuitGame);
            BackB.onClick.AddListener(Back);
            GotItB.onClick.AddListener(GotIt);
            RulesB.onClick.AddListener(RulesScreen);
            BackLSB.onClick.AddListener(BackMainMenu);
            JSonSave.Singleton.LoadHS();
            Background.GetFloat("BackGroundSounds",out volumeBack);
            //SoundsC.GetFloat("sound", out SoundsCont);
        
        }

    void Update()
    {
        HighscorePatos.text = "Highscore " + JSonSave.Singleton.highscorePatos;
        HighscorePiratas.text = "Highscore " + JSonSave.Singleton.highscorePiratas;
    }
    #endregion
    #region OwnMethods
    public void PresAny()
    {
            PressAny.gameObject.SetActive(false);
            StartGameB.gameObject.SetActive(true);
            SettingsB.gameObject.SetActive(true);
            QuitGameB.gameObject.SetActive(true);
            BackB.gameObject.SetActive(true);
    }
    
    public enum Scene
        {
            DuckShots, PirateShots
        }
    public void StartDuck()
        {
            SceneManager.LoadScene(Scene.DuckShots.ToString());
        }
    public void StartPirates()
        {
            SceneManager.LoadScene(Scene.PirateShots.ToString());
        }
    public void Settings()
        {
            StartGameB.gameObject.SetActive(false);
            SettingsB.gameObject.SetActive(false);
            QuitGameB.gameObject.SetActive(false);
            BackB.gameObject.SetActive(true);
            glow.SetActive(false);
            SettingsScreen.SetActive(true);
            Title.SetActive(false);
        }
    public void VolumeBack(float volume)
        {
             Background.SetFloat("BackGroundSounds", volume);   
        }
    public void SoundsControl(float volumeS)
        {
             SoundsC.SetFloat("sounds", volumeS);   
        }
    public void RulesScreen()
        {
            SettingsScreen.SetActive(false);
            RuleScreen.SetActive(true);
        }
    public void GotIt()
        {
           SettingsScreen.SetActive(true);
           RuleScreen.SetActive(false);
        }
    public void Back()
        {
            SettingsScreen.SetActive(false);
            StartGameB.gameObject.SetActive(true);
            SettingsB.gameObject.SetActive(true);
            BackB.gameObject.SetActive(true);
            QuitGameB.gameObject.SetActive(true);
            glow.SetActive(true);
            Title.SetActive(true);
        }
    public void QuitGame()
        {
            SettingsScreen.SetActive(false);
            ConfirmationScreen.SetActive(true);
            StartGameB.gameObject.SetActive(false);
            SettingsB.gameObject.SetActive(false);
            QuitGameB.gameObject.SetActive(false);
            glow.SetActive(false);
            Title.SetActive(false);
        }
    public void yes()
        {
            Application.Quit();
        }
    public void no()
        {   
            ConfirmationScreen.SetActive(false);
            StartGameB.gameObject.SetActive(true);
            SettingsB.gameObject.SetActive(true);
            QuitGameB.gameObject.SetActive(true);
            BackB.gameObject.SetActive(true);
            glow.SetActive(true);
            Title.SetActive(true);
            QuitGameB.gameObject.SetActive(true);
        }
    public void LevelSelect()
        {
            StartGameB.gameObject.SetActive(false);
            SettingsB.gameObject.SetActive(false);
            QuitGameB.gameObject.SetActive(false);
            BackLSB.gameObject.SetActive(true);
            glow.SetActive(false);
            LevelSelector.SetActive(true);
            Title.SetActive(false);
        }
    public void BackMainMenu()
        {
            StartGameB.gameObject.SetActive(true);
            SettingsB.gameObject.SetActive(true);
            QuitGameB.gameObject.SetActive(true);
            BackLSB.gameObject.SetActive(false);
            glow.SetActive(true);
            LevelSelector.SetActive(false);
            Title.SetActive(true);
        }
    #endregion

}
