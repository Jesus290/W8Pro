using UnityEngine;
using System.Collections;

public class Invocador : MonoBehaviour {

	//Variables publicas

	public GameObject [] plataformas; 
	public float [] medidas;
	public float distanciaPlat;
	float medidaAnterior;
	int aleatorio;

	//Variables públicas pero privadas para el implementador 
	public bool puedoInstanciar= true; 

	//Variables privadas

	GameObject plataformaActual;

	

	void Start () {

		StartCoroutine ("CrearPlataformas");

	
	}
	

	void Update () {

	
	}

	public IEnumerator CrearPlataformas() 
	{ 
		while(puedoInstanciar == true) //También le puedo dejar sin igual a true
		{

			if (plataformaActual==null)
			{
				aleatorio = Random.Range(0, plataformas.Length);
				plataformaActual = Instantiate (plataformas[aleatorio], transform.position, transform.rotation) as GameObject; //Origen: Vector3.Zero Rotation 0,0,0 = Quaternion.identity
				Debug.Log(plataformaActual);
				medidaAnterior = medidas[aleatorio];
			

			}

			else 
			{
				if (Vector3.Distance(plataformaActual.transform.position, transform.position)>=((medidaAnterior/2) + (medidas[aleatorio]/2))) //Le puedo poner this
				    {

					plataformaActual = Instantiate (plataformas[aleatorio],transform.position, transform.rotation) as GameObject; 


					medidaAnterior = medidas[aleatorio];
					aleatorio = Random.Range(0, plataformas.Length);



				}

			}
			yield return null;

		}

		yield return null; 
		

	}

}
