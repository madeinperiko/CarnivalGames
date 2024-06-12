using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGaviota : MonoBehaviour
{
    #region var
    public GameManager GMS;
    public GameObject GPrefab;
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

                if (Random.value < 0.6f)
                {
                    GameObject G = PiratePool.Instance.RequestGaviota();
                    G.GetComponent<BoxCollider>().enabled = true;
                    G.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    G.GetComponent<GaviotaScript>().PointA = GameObject.Find("InicioGaviota").transform;
                    G.GetComponent<GaviotaScript>().PointB = GameObject.Find("FinGaviota").transform;
                }
                
            }

        }

    }
    #endregion
}
