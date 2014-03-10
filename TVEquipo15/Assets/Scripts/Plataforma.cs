using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour {


	public float velocidadInicial;
	public float velocidadIncremento;
	public float timeAlive;

	float initTime;



	void Start () {

		initTime = Time.time;
		StartCoroutine ("Velocidad");

	
	}
	

	void Update () 
	{

		transform.Translate (new Vector3(5*Time.deltaTime*velocidadInicial, 0, 0));


		if(Time.time >= (initTime+timeAlive))
		{
			Destroy(this.gameObject);
		}
	
	}

	public IEnumerator Velocidad() 
	{ 
		velocidadInicial = velocidadInicial + velocidadIncremento;

		
		yield return new WaitForSeconds(3);
	}



}
