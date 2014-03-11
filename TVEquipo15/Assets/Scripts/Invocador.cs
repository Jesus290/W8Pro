using UnityEngine;
using System.Collections;
public class Invocador : MonoBehaviour {
	//Variables publicas
	public GameObject [] plataformas; 
	public float [] medidasAncho;
	public float distanciaPlat;
	public float [] medidasAltura; //aqui debe haber 4 porque las plataforma 3 tiene dos pisos
	public GameObject gusanoActual;
	public GameObject [] obstaculos;
	
	
	
	//private
	float medidaAnterior;
	int aleatorio;
	
	[HideInInspector]
	public bool puedoInstanciar= true; 
	
	
	GameObject plataformaActual;
	
	
	//Gusanos variables
	int gusanoTF;
	int cantidadGusanos; //lo que diga el Random a partir de los max&min gusanos
	public int maxGusanos; //Gusanos maximos por plataforma
	public int minimoGusanos; //Gusanos mínimos por plataforma
	public int distanciaEntreGusanos; //La distancia que va a existir entre un gusano y otro
	public int distanciaExtraPlataforma3; // Es un nombre gigante pero enserio es la distancia extra de la forma 3
	
	
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
					
					gusanoTF = Random.Range (0, 10);
					print ("gusanos: " +gusanoTF);
					
					if (gusanoTF<=5) //VOY A PONER GUSANOS!!!!!!!!!!!!!!!!!!!! AQUÍ VAN LOS GUSANOS!!! DESPUÉS VAN LOS OBSTÁCULOS!!
					{


						cantidadGusanos = Random.Range (minimoGusanos,maxGusanos);

						if (aleatorio == 0 || aleatorio ==1 || aleatorio ==3)
						{
							int posicion=0;
							int primero = 1;
							
							for (int i = 0; i<cantidadGusanos; i++)
							{
								if (primero ==1)
								{
									
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x, medidasAltura[aleatorio] ,0), transform.rotation) as GameObject;
									
									
								}
								if (posicion%2 == 0) //derecha
								{
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x+distanciaEntreGusanos, medidasAltura[aleatorio] ,0), transform.rotation) as GameObject;
									
									
									posicion++;
									
								}
								
								if (posicion%2 != 0) //izquierda
								{
									
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x-distanciaEntreGusanos, medidasAltura[aleatorio] ,0), transform.rotation) as GameObject;
									
									
									distanciaEntreGusanos = distanciaEntreGusanos + distanciaEntreGusanos;
									posicion++;
									
								}
								
							}

						}

						if (aleatorio==2)
						{
							int posicion3=0;
							int primero3 = 1;
							
							for (int i = 0; i<cantidadGusanos; i++)
							{
								if (primero3 ==1)
								{
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x+distanciaExtraPlataforma3, medidasAltura[aleatorio] ,0), transform.rotation) as GameObject;
								}
								if (posicion3%2 == 0) //derecha
								{
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x+distanciaEntreGusanos+distanciaExtraPlataforma3, medidasAltura[aleatorio] ,0), transform.rotation) as GameObject;
									posicion3++;
									
								}
								
								if (posicion3%2 != 0) //izquierda
								{
									
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x-distanciaEntreGusanos+distanciaExtraPlataforma3, medidasAltura[aleatorio] ,0), transform.rotation) as GameObject;
									distanciaEntreGusanos = distanciaEntreGusanos + distanciaEntreGusanos;
									posicion3++;
									
								}
								
							}
						}

						


						}
						
						

					
					medidaAnterior = medidasAncho[aleatorio];
					aleatorio = Random.Range(0, plataformas.Length);
					
				}
			}
			yield return null;
		}
		yield return null; 
		
	}
}








