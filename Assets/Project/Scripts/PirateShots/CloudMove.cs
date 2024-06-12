using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    #region var
    public Transform PointA;
    public Transform PointB;
    public float Speed = 5f;


    public bool IfArriba = false;
    public GameManager isPaused;
    private BoxCollider boxCollider;
    #endregion
    #region Methods
    private void Start()
    {
        transform.position = PointA.position;
        isPaused = GameObject.Find("GameManager").GetComponent<GameManager>();
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
}
