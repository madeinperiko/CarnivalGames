using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class RiflePointNClick : MonoBehaviour
{

    //public Joystick joystick;
    #region variables
    public Transform SpawnPoint;
    public GameObject balaPrefab;
    public GameObject Recargando;
    public GameManager gameOver;
    public GameObject Reload;
    public GameObject Countdown;
    
    //public float velocidadbala = 10f;
    private GameObject bala;
    public GameObject Cargador;
    public Button botonRecarga;
    //public int balasRestantes = 10;
    //public float tiempoRecarga = 2f;
    private bool isReloading = false;
    //public float delay = 1f;
    public float timeShoot = 0f;
    public GameManager Paused;
    public AudioSource shootSound;

    public Camera miCamara;
    public Transform punteroArma;

    public bool TouchUI = false;

    public FlyWeight FlyW;
    #endregion
    #region UnityMethods
    void Start() 
        {
            //botonDisparo.onClick.AddListener(Shoot);
            botonRecarga.onClick.AddListener(RecargarCargador);
            FlyW.balasRestantes = 10;
            GameManager Paused = GameObject.Find("GameManager").GetComponent<GameManager>();
            GameManager gameOver = GameObject.Find("GameManager").GetComponent<GameManager>();
            shootSound = GetComponent<AudioSource>();
        }

    void Update()
        {
        
        if (Input.touchCount > 0 /*&& !EventSystem.current.IsPointerOverGameObject()*/)
            {
                //Lanza un rayo hacia la posicion del dedo que esta tocando la pantalla respecto de la camara del jugador
                Ray ray = miCamara.ScreenPointToRay(Input.GetTouch(0).position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    Vector3 direccion = hit.point - punteroArma.position;
                    //direccion.z = 0f;
                    punteroArma.rotation = Quaternion.LookRotation(direccion);
                }

                if (timeShoot >= FlyW.delay)
                {
                    Shoot();
                }
            }
            //punteroArma.rotation = Quaternion.Lerp(punteroArma.rotation, Quaternion.LookRotation(UltimaDireccion), velocidadRotacion * Time.deltaTime);

            timeShoot += Time.deltaTime;

                    if(Input.GetKeyDown(KeyCode.Space) && FlyW.balasRestantes != 0 )
                        {
                            Shoot();  
                        }

                    if (Input.GetKeyDown(KeyCode.Escape)) 
                    Paused.Pause();

                    if (FlyW.balasRestantes == 0)
                    Reload.SetActive(true);

                    else if (FlyW.balasRestantes == 10)
                    Reload.SetActive(false);
                    if ( gameOver.gameOver)
                    Reload.SetActive(false);   
        }

    #endregion
    #region OwnMethods
    public void Shoot()
        {
            if ( FlyW.balasRestantes > 0 && !isReloading && timeShoot >= FlyW.delay)
            {
                if(bala == null)
                    {
                        bala = Instantiate(balaPrefab, SpawnPoint.position, SpawnPoint.rotation);
                        bala.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * FlyW.velocidadbala;
                        FlyW.balasRestantes--;
                        ActualizaCargador();
                        timeShoot = 0;
                        shootSound.Play();
                    }
                
            }
        }
    
    IEnumerator Wait()
        {
            yield return new WaitForSeconds(timeShoot);  
        }
    IEnumerator Recargar()
        {   
            isReloading = true;
            yield return new WaitForSeconds(FlyW.tiempoRecarga);
            Recargando.SetActive(false);
            FlyW.balasRestantes = 10;
            isReloading = false;
            ActualizaCargador();  
        }
    void FixedUpdate() 
        {
            if (bala == null ) 
            StartCoroutine(Wait()); 
        }
    public void RecargarCargador()
        {
            if(!isReloading)
                {   
                 StartCoroutine(Recargar());
                 Recargando.SetActive(true);
                }
        }

    private void ActualizaCargador()
        {
            int cargadorUI = Mathf.Clamp(FlyW.balasRestantes, 0, 10);
            for (int i = 0; i < Cargador.transform.childCount; i++)
            {
                GameObject ImagenBala = Cargador.transform.GetChild(i).gameObject;
                ImagenBala.SetActive(i < cargadorUI);
            }
        }

    #endregion
}
