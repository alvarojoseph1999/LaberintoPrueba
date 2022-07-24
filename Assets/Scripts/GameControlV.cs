using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControlV : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private string tag; //Variable de texto para encontrar los puntos de aparición.

	[SerializeField]
	private GameObject playerPrefab; //Esto va a guardar el prefab del personaje.

	private GameObject player; //Esto va a guardar la instancia del personaje que coloquemos en la jerarquía.

	[SerializeField]
	private GameObject[] spawnPoints; //En este vector estarán todos los Spawn Points que coloquemos en la escena.

	[SerializeField]
	private GameObject selectedSpawnPoint; //Esto va a guardar uno de los puntos de aparición del vector.

	[SerializeField]
	private GameObject menuCamera; //Aquí colocaremos la referencia de la cámara que estará activa inicialmente

	[SerializeField]
	private GameObject menuUI; //Esto guardará la referencia del empty GameObject que contiene los elementos de la UI del menú

	[SerializeField]
	private GameObject gameUI; //Esto guardará la referencia del empty GameObject que contiene los elementos de la UI del juego


	void Start () {

		menuCamera.SetActive (true); //Cámara del menú activa.
		menuUI.SetActive (true); //Interfaz de usuario del menú activa.
		gameUI.SetActive (false); //Interfaz de usuario del juego inactiva.




	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) { //En cada frame se verifica si la tecla R fue pulsada..


			SceneManager.LoadScene (0); //Cargamos la escena 0. Hasta ahora tenemos solo una escena.

		}

		if (Input.GetKeyDown (KeyCode.Escape)) { //En cada frame se verifica si la tecla Escape fue pulsada.


			endGame (); //Cuando se presiona la tecla Escape se hace una llamada al método endGame.

		}


	}

	public void startGame(){

		menuCamera.SetActive (false); //Cámara del menú inactiva.
		menuUI.SetActive (false); //Interfaz de usuario del menú inactiva.
		gameUI.SetActive (true); //Interfaz de usuario del juego activa.

		placePlayerRandomly (); //Hacemos una llamada al método placePlayerRandomly.


	}

	private void endGame(){
		menuCamera.SetActive (true); //Cámara del menú activa.
		menuUI.SetActive (true); //Interfaz de usuario del menú activa.
		gameUI.SetActive (false); //Interfaz de usuario del juego inactiva.

		Destroy (player); //Elimino la instancia del personaje de la jerarquía.

		Cursor.lockState = CursorLockMode.None; //Se desbloquea el cursor.
		Cursor.visible = true; //Se hace visible el cursor

	}



	private void placePlayerRandomly(){

		spawnPoints = GameObject.FindGameObjectsWithTag (tag); //Encuentro todos los objetos de la jerarquía que tienen el tag indicado y lo asigno al vector spawnPoints.

		int rand = Random.Range (0, spawnPoints.Length); //Defino un número aleatorio que puede valor entre 0 y el tamaño de spawnPoints menos 1.

		selectedSpawnPoint = spawnPoints [rand]; //Asigno el punto de aparición aleatorio a la variable selectedSpawnPoint.

		player = Instantiate (playerPrefab, selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.rotation); //Genero una instancia del GameObject playerPrefab y lo asigno a player.


	}

}
