using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    #region var
    public GameManager GMS;
    public GameObject EnemyPrefab;
    public GameObject EnemyPrefab2;
    public GameObject FriendPrefab;
    public float SpawnInterval = 1f; // el tiempo en segundos entre cada generación de enemigos
    private float spawnTimer; // contador de tiempo para controlar la generación de enemigos
    #endregion
    #region Methods

    void Start() 
    {
      GMS = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }
    private void Update()
    {
        // actualizamos el contador de tiempo
        spawnTimer += Time.deltaTime;

        // si el contador supera el intervalo de tiempo deseado
        if (spawnTimer >= SpawnInterval)
        {
            spawnTimer = 0f;
            
            if (GMS.CountDownDone == true)
            {
                
             if (Random.value < 0.2f )
                {
                    //GameObject PatoEspecial = Instantiate(EnemyPrefab2, transform.position , Quaternion.identity);
                    GameObject PatoEspecial = PatoPool.Instance.RequestPatoEspecial();

                    if (this.gameObject.tag == "Abajo")
                        {   
                            PatoEspecial.GetComponent<BoxCollider>().enabled = true;
                            PatoEspecial.GetComponent<Patoscript>().PointA = GameObject.Find("InicioA").transform;
                            PatoEspecial.GetComponent<Patoscript>().PointB = GameObject.Find("FinA").transform;
                            PatoEspecial.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            PatoEspecial.GetComponent<Patoscript>().IfArriba = false;
                            PatoEspecial.transform.position = PatoEspecial.GetComponent<Patoscript>().PointA.position;
                    }
                    if (this.gameObject.tag == "Arriba")
                        {
                            PatoEspecial.GetComponent<BoxCollider>().enabled = true;
                            PatoEspecial.GetComponent<Patoscript>().PointA = GameObject.Find("InicioB").transform;
                            PatoEspecial.GetComponent<Patoscript>().PointB = GameObject.Find("FinB").transform;
                            PatoEspecial.transform.rotation = Quaternion.Euler(0f,-180f,0f);
                            PatoEspecial.GetComponent<Patoscript>().IfArriba = true;
                            PatoEspecial.transform.position = PatoEspecial.GetComponent<Patoscript>().PointA.position;
                    }
                }
             else if (Random.value < 0.4f )
                {
                    //GameObject Rana = Instantiate(FriendPrefab, transform.position , Quaternion.identity);
                    GameObject Rana = PatoPool.Instance.RequestRana();

                    if (this.gameObject.tag == "Abajo")
                        {
                            Rana.GetComponent<BoxCollider>().enabled = true;
                            Rana.GetComponent<Patoscript>().PointA = GameObject.Find("InicioA").transform;
                            Rana.GetComponent<Patoscript>().PointB = GameObject.Find("FinA").transform;
                            Rana.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            Rana.GetComponent<Patoscript>().IfArriba = false;
                            Rana.transform.position = Rana.GetComponent<Patoscript>().PointA.position;
                    }
                    if (this.gameObject.tag == "Arriba")
                        {
                            Rana.GetComponent<BoxCollider>().enabled = true;
                            Rana.GetComponent<Patoscript>().PointA = GameObject.Find("InicioB").transform;
                            Rana.GetComponent<Patoscript>().PointB = GameObject.Find("FinB").transform;
                            Rana.transform.rotation = Quaternion.Euler(0f,-180f,0f);
                            Rana.GetComponent<Patoscript>().IfArriba = true;
                            Rana.transform.position = Rana.GetComponent<Patoscript>().PointA.position;
                    }
                }
             
             else 
                {
                    //GameObject PatoNormal = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
                    GameObject PatoNormal = PatoPool.Instance.RequestPatoNormal();

                    if (this.gameObject.tag == "Abajo")
                        {
                            PatoNormal.GetComponent<BoxCollider>().enabled = true;
                            PatoNormal.GetComponent<Patoscript>().PointA = GameObject.Find("InicioA").transform;
                            PatoNormal.GetComponent<Patoscript>().PointB = GameObject.Find("FinA").transform;
                            PatoNormal.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            PatoNormal.GetComponent<Patoscript>().IfArriba = false;
                            PatoNormal.transform.position = PatoNormal.GetComponent <Patoscript>().PointA.position;
                    }
                    if (this.gameObject.tag == "Arriba")
                        {
                            PatoNormal.GetComponent<BoxCollider>().enabled = true;
                            PatoNormal.GetComponent<Patoscript>().PointA = GameObject.Find("InicioB").transform;
                            PatoNormal.GetComponent<Patoscript>().PointB = GameObject.Find("FinB").transform;
                            PatoNormal.transform.rotation = Quaternion.Euler(0f,-180f,0f);
                            PatoNormal.GetComponent<Patoscript>().IfArriba = true;
                            PatoNormal.transform.position = PatoNormal.GetComponent<Patoscript>().PointA.position;
                    }
                }
              
            }

        }
        
    }
    #endregion
}
