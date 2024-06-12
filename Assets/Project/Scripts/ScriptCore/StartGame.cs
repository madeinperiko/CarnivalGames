using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    #region var
    private GameManager GMS;
    public GameObject press;
    public GameObject Countdown;
    public GameObject score;
    public GameObject botonrecarga;
    public GameObject timer;
    public GameObject pause;
    public GameObject ScoreBoard;
    public GameObject cargador;
    #endregion
    #region methods
    void Update()
    {
        GMS = GameObject.Find ("GameManager").GetComponent<GameManager>();
        
            if (Input.anyKeyDown)
            {
                press.SetActive(false);
                Countdown.SetActive(true);
                score.SetActive(true);
                ScoreBoard.gameObject.SetActive(true);
                botonrecarga.SetActive(true);
                timer.SetActive(true);
                pause.SetActive(true);
                cargador.SetActive(true);
                Debug.Log("comienza el juego");
            }

    }
    #endregion
}
