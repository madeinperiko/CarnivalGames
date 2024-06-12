using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviotaScript : MonoBehaviour
{
    #region var
    public Transform PointA; // punto A
    public Transform PointB; // punto B
    public float Speed = 5f; // velocidad de movimiento del enemigo
    public GameManager isPaused;
    private BoxCollider boxCollider;
    public float RotationSpeed = 90f;

    AudioSource HitSound;
    #endregion
    #region methods
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
    private void OnCollisionEnter(Collision collision)
    {
        ScoreManagerPirates.scoreInstanceP.AddPoints(2);
        HitSound.Play();
        boxCollider.enabled = false;
        StartCoroutine(RotateAndDestroy());
        
    }
    public IEnumerator RotateAndDestroy()
    {
        float time = 0f;
            while (time < 1f)
            {
                // rota el objeto en el eje X a la velocidad especificada
                transform.Rotate(RotationSpeed * Time.deltaTime, 0f, 0f);
                time += Time.deltaTime;
                yield return null;

            }
        gameObject.SetActive(false);
    }

    #endregion
}
