using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {


	float initTime;
	GameObject piedra;
	GameObject personaje;
	bool disparar = true;
	public float tiempoDisparos;
	float velocidad; 
	int estado = 1;
	public float aumentoVelocidad;  //Es la velocidad que se va a aumentar
	public float tiempoReproduccion;
	public int duracionBoss;
	int duracionSV; //La duración 
	//podría tener un status de win//loss pero en realidad si piede no puede continuar




	// Use this for initialization
	void Start () {
		initTime = Time.time;
		personaje = GameObject.Find ("PersonajePrincipal");
	
	}
	// Update is called once per frame
	void Update () {
		if (estado ==2)
		{
			moverDuranteunTiempo();
		}

		if (estado==3)
		{
			ClaseMaestra.velocidad = velocidad;
			Destroy (gameObject);
		}
	}


	public IEnumerator balas ()
	{
		while (disparar)
		{ 
			Instantiate (piedra,personaje.transform.position,Quaternion.identity);


			tiempoReproduccion = tiempoReproduccion+tiempoDisparos;
			if (tiempoReproduccion>= duracionBoss)
			{
				disparar=false;
			}
			yield return new WaitForSeconds (tiempoDisparos);
		}

		estado++;

		yield return new WaitForSeconds (tiempoDisparos);
	}


	public void moverDuranteunTiempo()
	{
		initTime = Time.time;
		velocidad = ClaseMaestra.velocidad;
		ClaseMaestra.velocidad = ClaseMaestra.velocidad *aumentoVelocidad;

		while (Time.time<initTime+duracionSV)
		{}
		estado++;

	}


	}

