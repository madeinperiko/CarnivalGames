using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patoscript : MonoBehaviour
{
    #region var
    public Transform PointA; 
    public Transform PointB; 

    public bool IfArriba = false;
    public GameManager isPaused;
    private BoxCollider boxCollider;

    AudioSource HitSound;

    public FlyWeight FlyW;
    #endregion
    #region UnityMethods

    private void Start()
    {
        transform.position = PointA.position;
        ScoreManager.Singleton = GameObject.Find("Score").GetComponent<ScoreManager>();
        isPaused = GameObject.Find("GameManager").GetComponent<GameManager>();
        HitSound = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, PointB.position, FlyW.Speed * Time.deltaTime);

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
         if (this.gameObject.CompareTag("especial"))
         ScoreManager.scoreInstance.AddPoints(2);
         else if (this.gameObject.CompareTag("rana"))
         ScoreManager.scoreInstance.AddPoints(-1);
         else
         ScoreManager.scoreInstance.AddPoints(1);
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
                transform.Rotate(FlyW.RotationSpeed * Time.deltaTime, 0f, 0f);
                time += Time.deltaTime;
                yield return null;
            }  
        }
        else
        {
                while (time < 1f)
            {
                transform.Rotate(-FlyW.RotationSpeed * Time.deltaTime, 0f, 0f);
                time += Time.deltaTime;
                yield return null;
            }
        }

        //Destroy(gameObject, 1f);
        DesactivarPato();
        
    }

    private void DesactivarPato()
    {
        gameObject.SetActive(false);  
    }
    #endregion
}
