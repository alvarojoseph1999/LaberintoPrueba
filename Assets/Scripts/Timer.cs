using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private int minutes; //Cantidad de minutos iniciales. Esta variable no se modifica durante la ejecución del juego.
	[SerializeField]
	private int seconds; //Cantidad de segundos iniciales. Esta variable no se modifica durante la ejecución del juego.

	private int m,s; //Valores de tiempo actuales. Estas variables se van modificando a medida que el tiempo corre.

	[SerializeField]
	private TMP_Text timerText; //Aqui guardaremos una referencia del elemento texto del Canvas.

	private GameControl gameControl; //Aquí guardamos una referencia de la componente GameControl que está presente en el GameObject Control de la jerarquía.



	void Start () {
		gameControl = gameObject.GetComponent<GameControl> ();//Encontramos la componente GameControl.
	}

	//El siguiente método se encarga de iniciar timer.
	public void startTimer(){
		m = minutes; //Inicializamos los minutos.
		s = seconds; //Inicializamos los segundos
		writeTimer (m, s); //Escribimos los valores de tiempo en el elemento Text del Canvas.
		Invoke ("updateTimer", 1f); //Se hace una invocación al método "updateTimer" luego de que pasa 1 segundo desde este punto.

	}

	//El siguiente método se encarga de detener el timer.
	public void stopTimer(){
		CancelInvoke (); //Detenemos todas las invocaciones que pueden haber quedado pendiente.

	}

	//El siguiente método se encarga de actualizar los valores de tiempo cada un segundo.
	private void updateTimer(){
		s--; //Decrementamos los segundos

		if (s < 0) { //Si esta sentencia es verdadera significa que la variable s valía 0 y pasó a valer -1.

			//Tenemos dos posibilidades, la primera es que la variable minutos se encuentre en 0.
			//Es decir que en el segundo anterior el valor de tiempo sea 0:00, en consecuencia el tiempo se agotó.
			//La segunda posibilidad es que m sea distinto de 0, en ese caso decrementamos un minuto y la variable
			//segundos pasa a valer 59.
			if (m == 0) {
				//El tiempo se ha agotado.
				gameControl.endGame (); //Hago una llamada al método endGame() presente en el Script GameControl.
				return; //Interrumpo la ejecución del método updateTimer().
			} else {
				//El tiempo aún no se ha agotado.
				m--; //Decremento los minutos.
				s = 59; //Asigno a la variable segundos el valor 59.

				//Un ejemplo de lo que puede suceder en este caso es que el timer haga este cambio de estado 1:00 -> 0:59 .
			}

		}

		writeTimer (m, s); //Escribo los nuevos valores de tiempo en la UI.
		Invoke ("updateTimer", 1f); //Hago una invocación al método updateTimer() luego de 1 segundo.

		//Con esta última instrucción logramos que el método updateTimer() se invoque a sí mismo en intervalos de un segundo.

	}

	//El siguiente método se encarga de dar formato a los valores de tiempo y escribirlos en el elemento del Canvas.
	//A diferencia de los métodos que hemos escrito antes, este recibirá dos parámetros: los enteros m y s,
	//los cuales se utilizarán dentro del método para hacer operaciones.
	//Definir el método de esta forma es muy interesante porque nos plantea la siguiente interrogante:
	//Cuando utilizo m y s dentro del método writeTimer(). ¿Estoy usando el m y s definido en la propia clase o estoy usando los parámetros que recibi al momento de la llamada?
	//Cuando estudiemos programación vamos a volver sobre esto.

	private void writeTimer(int m,int s){ 

		if (s < 10) { //Si esto se cumple significa que la variable segundos tiene un solo dígito.
			//En este caso debemos concatenar un 0 a la izquierda de los segundos para conservar el formato,
			//de lo contrario podríamos visualizar el tiempo por ejemplo de esta manera: 1:6 (indicando 1 minuto 6 segundos).

			timerText.text = m.ToString () + ":0" + s.ToString ();

		} else {
			//En este caso la variable segundos tiene 2 dígitos, por lo tanto no se concatena un 0 a la izquierda.
			timerText.text = m.ToString () + ":" + s.ToString (); 

		}


	}



}
