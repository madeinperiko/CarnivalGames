using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNubes : MonoBehaviour
{
    #region var
    public GameManager GMS;
    public float SpawnInterval = 1f; // el tiempo en segundos entre cada generación de enemigos
    private float spawnTimer; // contador de tiempo para controlar la generación de enemigos
    public GameObject Nube01;
    public GameObject Nube02;
    public GameObject Nube03;
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
                if (Random.value < 0.3f)
                {
                    //GameObject Nube1 = Instantiate(Nube01, transform.position, Quaternion.identity);

                    GameObject Nube1 = PiratePool.Instance.RequestNube1();

                    if (this.gameObject.tag == "AbajoN")
                    {
                        Nube1.GetComponent<BoxCollider>().enabled = true;
                        Nube1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        Nube1.GetComponent<CloudMove>().PointA = GameObject.Find("InicioCloud1").transform;
                        Nube1.GetComponent<CloudMove>().PointB = GameObject.Find("FinCloud1").transform;
                        Nube1.GetComponent<CloudMove>().IfArriba = false;
                        Nube1.transform.position = Nube1.GetComponent<CloudMove>().PointA.position;
                    }
                    if (this.gameObject.tag == "ArribaN")
                    {
                        Nube1.GetComponent<BoxCollider>().enabled = true;
                        Nube1.GetComponent<CloudMove>().PointA = GameObject.Find("InicioCloud2").transform;
                        Nube1.GetComponent<CloudMove>().PointB = GameObject.Find("FinCloud2").transform;
                        Nube1.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                        Nube1.GetComponent<CloudMove>().IfArriba = true;
                        Nube1.transform.position = Nube1.GetComponent<CloudMove>().PointA.position;
                    }
                }
                else if (Random.value < 0.3f)
                {
                    // GameObject Nube2 = Instantiate(Nube02, transform.position, Quaternion.identity);
                    GameObject Nube2 = PiratePool.Instance.RequestNube2();

                    if (this.gameObject.tag == "AbajoN")
                    {
                        Nube2.GetComponent<BoxCollider>().enabled = true;
                        Nube2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        Nube2.GetComponent<CloudMove>().PointA = GameObject.Find("InicioCloud1").transform;
                        Nube2.GetComponent<CloudMove>().PointB = GameObject.Find("FinCloud1").transform;
                        Nube2.GetComponent<CloudMove>().IfArriba = false;
                        Nube2.transform.position = Nube2.GetComponent<CloudMove>().PointA.position;
                    }
                    if (this.gameObject.tag == "ArribaN")
                    {
                        Nube2.GetComponent<BoxCollider>().enabled = true;
                        Nube2.GetComponent<CloudMove>().PointA = GameObject.Find("InicioCloud2").transform;
                        Nube2.GetComponent<CloudMove>().PointB = GameObject.Find("FinCloud2").transform;
                        Nube2.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                        Nube2.GetComponent<CloudMove>().IfArriba = true;
                        Nube2.transform.position = Nube2.GetComponent<CloudMove>().PointA.position;
                    }
                }

                else
                {
                    //GameObject Nube3 = Instantiate(Nube03, transform.position, Quaternion.identity);
                    GameObject Nube3 = PiratePool.Instance.RequestNube3();

                    if (this.gameObject.tag == "AbajoN")
                    {
                        Nube3.GetComponent<BoxCollider>().enabled = true;
                        Nube3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        Nube3.GetComponent<CloudMove>().PointA = GameObject.Find("InicioCloud1").transform;
                        Nube3.GetComponent<CloudMove>().PointB = GameObject.Find("FinCloud1").transform;
                        Nube3.GetComponent<CloudMove>().IfArriba = false;
                        Nube3.transform.position = Nube3.GetComponent<CloudMove>().PointA.position;
                    }
                    if (this.gameObject.tag == "ArribaN")
                    {
                        Nube3.GetComponent<BoxCollider>().enabled = true;
                        Nube3.GetComponent<CloudMove>().PointA = GameObject.Find("InicioCloud2").transform;
                        Nube3.GetComponent<CloudMove>().PointB = GameObject.Find("FinCloud2").transform;
                        Nube3.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                        Nube3.GetComponent<CloudMove>().IfArriba = true;
                        Nube3.transform.position = Nube3.GetComponent<CloudMove>().PointA.position;
                    }
                }
            }
         }
     }
    #endregion
}
