using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPirates : MonoBehaviour
{
    #region var
    public GameManager GMS;
    public GameObject EnemyPrefab;
    public GameObject FriendPrefab;
    public float SpawnInterval = 1f; 
    private float spawnTimer;
    #endregion
    #region methods

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
                
             if (Random.value < 0.4f )
                {
                    GameObject Piratescript2 = PiratePool.Instance.RequestAliado();

                    if (this.gameObject.tag == "Abajo")
                        {
                            Piratescript2.GetComponent<BoxCollider>().enabled = true;
                            Piratescript2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            Piratescript2.GetComponent<Piratescript>().PointA = GameObject.Find("InicioA").transform;
                            Piratescript2.GetComponent<Piratescript>().PointB = GameObject.Find("FinA").transform;
                            Piratescript2.GetComponent<Piratescript>().IfArriba = false;
                            Piratescript2.transform.position = Piratescript2.GetComponent<Piratescript>().PointA.position;
                        }
                    if (this.gameObject.tag == "Arriba")
                        {
                            Piratescript2.GetComponent<BoxCollider>().enabled = true;
                            Piratescript2.GetComponent<Piratescript>().PointA = GameObject.Find("InicioB").transform;
                            Piratescript2.GetComponent<Piratescript>().PointB = GameObject.Find("FinB").transform;
                            Piratescript2.transform.rotation = Quaternion.Euler(0f,-180f,0f);
                            Piratescript2.GetComponent<Piratescript>().IfArriba = true;
                            Piratescript2.transform.position = Piratescript2.GetComponent<Piratescript>().PointA.position;
                        }
                }
             else 
                {
                    GameObject Piratescript3 = PiratePool.Instance.RequestPirata();

                    if (this.gameObject.tag == "Abajo")
                        {
                            Piratescript3.GetComponent<BoxCollider>().enabled= true;
                            Piratescript3.transform.rotation = Quaternion.Euler(-0f, 0f, 0f);   
                            Piratescript3.GetComponent<Piratescript>().PointA = GameObject.Find("InicioA").transform;
                            Piratescript3.GetComponent<Piratescript>().PointB = GameObject.Find("FinA").transform;
                            Piratescript3.GetComponent<Piratescript>().IfArriba = false;
                            Piratescript3.transform.position = Piratescript3.GetComponent<Piratescript>().PointA.position;
                        }
                    if (this.gameObject.tag == "Arriba")
                        {
                            Piratescript3.GetComponent<BoxCollider>().enabled = true;
                            Piratescript3.GetComponent<Piratescript>().PointA = GameObject.Find("InicioB").transform;
                            Piratescript3.GetComponent<Piratescript>().PointB = GameObject.Find("FinB").transform;
                            Piratescript3.transform.rotation = Quaternion.Euler(0f,-180f,0f);
                            Piratescript3.GetComponent<Piratescript>().IfArriba = true;
                            Piratescript3.transform.position = Piratescript3.GetComponent<Piratescript>().PointA.position;
                        }
                }
            }

        }
        
    }
    #endregion
}
