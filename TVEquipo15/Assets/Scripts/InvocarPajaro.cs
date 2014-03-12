using UnityEngine;
using System.Collections;

public class InvocarPajaro : MonoBehaviour {
	
	//poner privador para el implementador es importante
	[HideInInspector]
	public bool puedoInstanciar= true;  //Ponerle true o false si el personaje agarra el Power-up

	public float alturaMinima; //altura mínima a la que puede volar el pájaro
	public float alturaMaxima; //altura máxima a la que puede volar el pájaro
	public int tiempoMinimo; //tiempo mínimo a esperar entre un pájaro y otro 
	public int tiempoMaximo; //a esperar entre un pajáro y otro
	public int duracionPower; // cuanto tiempo va a durar el power


	public GameObject pajaroActual;

	void Start () {
		StartCoroutine ("crearPajaros");
	
	}


	void Update () {
	
	}

	public IEnumerator crearPajaros()
	{
		int sumaTiempos=0;
		while (puedoInstanciar == true)
		{
			if (pajaroActual == null)
			{
				float aleatorio = Random.Range(alturaMinima,alturaMaxima);
				pajaroActual = Instantiate (pajaroActual, new Vector3(transform.position.x, aleatorio,transform.position.z),  Quaternion.identity) as GameObject;

			}

			else
			{
				float aleatorio = Random.Range(alturaMinima,alturaMaxima);
				pajaroActual = Instantiate (pajaroActual, new Vector3(transform.position.x,aleatorio,transform.position.z),  Quaternion.identity) as GameObject;
			}


			int tiempoAleatorio = Random.Range (tiempoMinimo,tiempoMaximo); // se elegirá el tiempo de forma aleatoria para que no sea tan predecible

			sumaTiempos = sumaTiempos+tiempoAleatorio; //Va sumando los tiempo

		

			if (sumaTiempos>=duracionPower) //compara lo que llevamos de tiempo y lo que debe durar el power (para que deje de hacer pajaros)
			{
				puedoInstanciar = false; //Le decimos que ya no & deja de repetirse :)
			}
			yield return new WaitForSeconds (tiempoAleatorio); //es aleatorio para que sea más interesante 

		}

		int tiempoAleatorios = Random.Range (tiempoMinimo,tiempoMaximo); // se elegirá el tiempo de forma aleatoria para que no sea tan predecible
		
		yield return new WaitForSeconds (tiempoAleatorios);


	}


}
