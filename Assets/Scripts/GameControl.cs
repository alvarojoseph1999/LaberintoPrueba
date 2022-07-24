using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    [SerializeField]
    private string tag;
    [SerializeField]
    private GameObject playerPrefab;

    private GameObject player;
    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]

    private GameObject selectedSpawnPoint;

    [SerializeField]
    private GameObject gameUI; //Esto guardará la referencia del empty GameObject que contiene los elementos de la UI del juego

    //[SerializeField]
    //private GameObject menuCamera; //Aquí colocaremos la referencia de la cámara que estará activa inicialmente

    //[SerializeField]
    //private GameObject menuUI; //Esto guardará la referencia del empty GameObject que contiene los elementos de la UI del menú


    private Timer timer;
    void Start()
    {
        //timer = gameObject.GetComponent<Timer>();
        //placePlayerRandomLy();
        //gameUI.SetActive(false); //Interfaz de usuario del juego inactiva.
        
        timer = gameObject.GetComponent<Timer>();
        //menuCamera.SetActive(true); //Cámara del menú activa.
       // menuUI.SetActive(true); //Interfaz de usuario del menú activa.
        gameUI.SetActive(true); //Interfaz de usuario del juego inactiva.

        placePlayerRandomLy();
        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        { //En cada frame se verifica si la tecla Escape fue pulsada.


            endGame(); //Cuando se presiona la tecla Escape se hace una llamada al método endGame.

        }

    }
    public void startGame()
    {
        timer.startTimer();
        //menuCamera.SetActive(false); //Cámara del menú inactiva.
        //menuUI.SetActive(false); //Interfaz de usuario del menú inactiva.
        gameUI.SetActive(true); //Interfaz de usuario del juego activa.

        placePlayerRandomLy(); //Hacemos una llamada al método placePlayerRandomly.
    }
    public void endGame()
    {
        timer.stopTimer();
        //menuCamera.SetActive(true); //Cámara del menú activa.
        //menuUI.SetActive(true); //Interfaz de usuario del menú activa.
        gameUI.SetActive(false); //Interfaz de usuario del juego inactiva.

        Destroy(playerPrefab); //Elimino la instancia del personaje de la jerarquía.

        Cursor.lockState = CursorLockMode.None; //Se desbloquea el cursor.
        Cursor.visible = true; //Se hace visible el cursor
        SceneManager.LoadScene("MainMenu");

    }
    private void placePlayerRandomLy()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(tag);

        int rand = Random.Range(0, spawnPoints.Length);

        selectedSpawnPoint = spawnPoints[rand];

        //player = Instantiate(playerPrefab, selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.localRotation);
        //player = Instantiate(playerPrefab, selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.rotation);
        playerPrefab.transform.position = selectedSpawnPoint.transform.position;
    }


}
