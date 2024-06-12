using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OldController : MonoBehaviour
{
    //Este controlador tal y como ha quedado el juego ha quedado obsoleto
    //public Joystick joystick;

    public Transform SpawnPoint;
    public GameObject balaPrefab;
    public GameObject Recargando;
    public GameManager gameOver;
    public GameObject Reload;
    
    public float velocidadbala = 10f;
    private GameObject bala;
    public GameObject Cargador;
    public Button botonDisparo;
    public Button botonRecarga;
    public int balasRestantes = 10;
    public float tiempoRecarga = 2f;
    private bool isReloading = false;
    public float delayShoot = 1f;
    public float shootTimer = 0f;
    public float sensitivity ;
    public GameManager Paused;
    public AudioSource shootSound;
    public float GradosX = 0;
    public float GradosY = 0;

    //Cundo pulsas disparo, y sen instancia la primera bala 9/10, canShoot funciona, pero despues deja de funcionar

    void Start() 
        {
            botonDisparo.onClick.AddListener(Shoot);
            botonRecarga.onClick.AddListener(RecargarCargador);
            balasRestantes = 10;
            delayShoot = shootTimer;
            GameManager Paused = GameObject.Find("GameManager").GetComponent<GameManager>();
            GameManager gameOver = GameObject.Find("GameManager").GetComponent<GameManager>();
            shootSound = GetComponent<AudioSource>();
            sensitivity = PlayerPrefs.GetFloat("Sensitivity", 50);


            
        }


    void Update()
        { 
    

            sensitivity = PlayerPrefs.GetFloat("Sensitivity");
            float horizontal = SimpleInput.GetAxis("Horizontal"); 
            float vertical = SimpleInput.GetAxis("Vertical");

            GradosX += -vertical * sensitivity * Time.deltaTime;
            GradosY += horizontal * sensitivity * Time.deltaTime;

            GradosX = Mathf.Clamp(GradosX, -40, 10);
            GradosY = Mathf.Clamp(GradosY, -40, 40);

            Vector3 currentRotation = new Vector3(GradosX, GradosY, 0);
  
            transform.localEulerAngles = currentRotation;

            shootTimer += Time.deltaTime;

                if(Input.GetKeyDown(KeyCode.Space) && balasRestantes != 0 && shootTimer >= delayShoot)
                    {
                        Shoot();
                        shootTimer = 0;   
                    }

                if (Input.GetKeyDown(KeyCode.Escape)) 
                Paused.Pause();

                if (balasRestantes == 0)
                Reload.SetActive(true);

                else if (balasRestantes == 10)
                Reload.SetActive(false);
                if ( gameOver.gameOver)
                Reload.SetActive(false);
                
        }


    public void Shoot()
        {
            if ( balasRestantes > 0 && !isReloading )
            {
                if(bala == null)
                    {
                        bala = Instantiate(balaPrefab, SpawnPoint.position, SpawnPoint.rotation);
                        bala.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * velocidadbala;
                        balasRestantes--;
                        ActualizaCargador();
                        shootTimer = 0;
                        shootSound.Play();
                    }
                
            }
        }
    IEnumerator Wait()
        {
            yield return new WaitForSeconds(shootTimer);
           
        }
    IEnumerator Recargar()
        {   
            isReloading = true;
            yield return new WaitForSeconds(tiempoRecarga);
            Recargando.SetActive(false);
            balasRestantes = 10;
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
            int cargadorUI = Mathf.Clamp(balasRestantes, 0, 10);

            for (int i = 0; i < Cargador.transform.childCount; i++)
            {
                GameObject ImagenBala = Cargador.transform.GetChild(i).gameObject;
                ImagenBala.SetActive(i < cargadorUI);
            }
        }
    
    
}
