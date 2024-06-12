using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piratescript : MonoBehaviour
{
    #region var
    public Transform PointA; // punto A
    public Transform PointB; // punto B
    public float Speed = 5f; // velocidad de movimiento del enemigo

    public float RotationSpeed = 90f;
    public bool IfArriba = false;
    public GameManager isPaused;
    private BoxCollider boxCollider;

    AudioSource HitSound;
    #endregion
    #region Unitymethods

    private void Start()
    {
        // movemos el enemigo hacia el punto A al spawnear
        transform.position = PointA.position;
        ScoreManagerPirates.Singleton = GameObject.Find("Score").GetComponent<ScoreManagerPirates>();
        isPaused = GameObject.Find("GameManager").GetComponent<GameManager>();
        HitSound = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, PointB.position, Speed * Time.deltaTime);

        if (transform.position == PointB.position)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        if (isPaused.isPaused)
            {
                Time.timeScale = 0f;
            }
        else if (isPaused.isPaused == false)
            {
                Time.timeScale = 1f;
            }        
        
       
    }
    #endregion
    #region OwnMethods
    private void OnCollisionEnter(Collision collision)
    {       
         
         if (this.gameObject.CompareTag("aliado"))
         ScoreManagerPirates.scoreInstanceP.AddPoints(-1);
         else
         ScoreManagerPirates.scoreInstanceP.AddPoints(1);
         HitSound.Play();
         boxCollider.enabled = false;

        StartCoroutine(RotateAndDestroy());  
    }

    public IEnumerator RotateAndDestroy()
    {
        float time = 0f;
        if(!IfArriba)
        {
            while (time < 1f)
            {
                // rota el objeto en el eje X a la velocidad especificada
                transform.Rotate(RotationSpeed * Time.deltaTime, 0f, 0f);
                time += Time.deltaTime;
                yield return null;
                
            }  
        }
        else
        {
                while (time < 1f)
            {
                // rota el objeto en el eje X a la velocidad especificada
                transform.Rotate(-RotationSpeed * Time.deltaTime, 0f, 0f);
                time += Time.deltaTime;
                yield return null;
            }
        }
        Desactivar();
    }

    public void Desactivar()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
