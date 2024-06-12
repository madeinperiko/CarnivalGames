using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour
{
     private GameManager GMS;
     public GameObject Countdown;
    void Start() 
        {
            GMS = GameObject.Find ("GameManager").GetComponent<GameManager>();  
        }
    public void SetCountDownNow()
        { 
            GMS.CountDownDone = true;
        }
}
