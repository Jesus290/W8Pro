using UnityEngine;
using System.Collections;
public class Invocador : MonoBehaviour {
	//Variables publicas
	public GameObject [] plataformas; 
	public float [] medidasAncho;
	public float distanciaPlat;
	public float [] medidasAltura; //aqui debe haber 4 porque las plataforma 3 tiene dos pisos

	public GameObject [] obstaculos;
	public float [] anchoPasto;


	
	
	
	//private
	float medidaAnterior;
	int aleatorio;
	
	[HideInInspector]
	public bool puedoInstanciar= true; 
	
	
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
				medidaAnterior = medidasAncho[aleatorio];
			}
			else if (plataformaActual!= null)
			{
				if (Vector3.Distance(plataformaActual.transform.position, transform.position)>=((medidaAnterior/2) + (medidasAncho[aleatorio]/2))) //Le puedo poner this
				{
					plataformaActual = Instantiate (plataformas[aleatorio],transform.position, transform.rotation) as GameObject; 

					medidaAnterior = medidasAncho[aleatorio];
					aleatorio = Random.Range(0, plataformas.Length);
					
				}
			}
			yield return null;
		}
		yield return null; 
		
	}

	
}
