using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bala : MonoBehaviour
{
    #region var
    public float vida = 3;
    public float tiempoDestruccion = 3;
    #endregion
    #region methods
    void Awake()
    {
        Destroy(gameObject, vida); 
    }
    private void OnCollisionEnter(Collision collision)  
    {   
        Destroy(gameObject);
    }
    #endregion

}
