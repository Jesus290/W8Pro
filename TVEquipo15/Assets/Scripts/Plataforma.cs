using UnityEngine;
using System.Collections;

public class Plataforma  : MonoBehaviour {
	

	public float timeAlive;
	float x;
	float velocidad;
	float initTime;

	//Primer parte!!! 
	int ranInt;
	int ranPosc;
	int ranObst;

	//Obstaculos
	public GameObject [] obstaculos;
	public int [] anchoObstaculos;
	public GameObject obstaculoActual;

	//Poscisión obstáculo 3
	public Transform poscObstaculo3;

	//Posición en general!
	public Transform lopongoOrilla;
	public Transform lopongoCentro;


	//Cosas gusaneras
	public GameObject gusanoActual;
	int cantidadGusanos; //lo que diga el Random a partir de los max&min gusanos
	public int maxGusanos; //Gusanos maximos por plataforma
	public int minimoGusanos; //Gusanos mínimos por plataforma
	public float distanciaEntreGusanos; //La distancia que va a existir entre un gusano y otro
	public float distanciaExtraPlataforma3; // Es un nombre gigante pero enserio es la distancia extra de la forma 3

	//Que&Donde para ambos
	int randDonde;
	int randonQue; //que es lo que voy a poner 


	//Cosas Pweroperas 
	public GameObject [] PW; 
	int cualPongo;
	public static int miPW;

	// Tags
	int etiqueta=0;



	void Start () {
		
		initTime = Time.time;
		randonQue = Random.Range(0,19);

			if(randonQue>=0 && randDonde<=5)
		{
			pongoObstaculos();
		}
		

		if (randonQue>=6 && randonQue<=12)
		{
			pongoGusanos();
		}

		if (randonQue>=13 && randonQue<=16)
		{
			//Aqui pongo PW
		}

		if (randonQue>=17 && randonQue<=19)

		{
			//Aqui no pasa absolutamente nada
		}
	
	}
	
	
	void Update () 
	{
		transform.Translate(-5*Time.deltaTime*ClaseMaestra.velocidad,0,0);

		if(Time.time >= (initTime+timeAlive))
			Destroy(this.gameObject);
	}



	public void pongoObstaculos ()
	{
		if (obstaculos.Length>0)
		{
			ranObst = Random.Range(0,obstaculos.Length);
			
			if (obstaculos.Length ==1)
			{
				Instantiate (obstaculos[0], poscObstaculo3.transform.position, Quaternion.identity);
			}
			
			else{
				randDonde = Random.Range (0,1);
				
				if (randDonde ==0)
				{
					Instantiate (obstaculos[ranObst], lopongoCentro.transform.position, Quaternion.identity);
				}
				
				if (randDonde==1)
				{
					Instantiate (obstaculos[ranObst], lopongoOrilla.transform.position, Quaternion.identity);
				}
			}
		}
	}

	void nombreObstaculos(){
		for(int i=0; i<obstaculos.Length; i++){
			etiqueta += 1;
			obstaculos[i].tag = "etiqueta";
		}
	}

	public void pongoGusanos ()
	{
		cantidadGusanos = Random.Range (minimoGusanos,maxGusanos);

		int posicion=0;
		int primero = 1;
		
		for (int i = 0; i<cantidadGusanos; i++)
		{
		
			if (primero ==1)
			{
				
				gusanoActual = Instantiate (gusanoActual,lopongoCentro.transform.position, Quaternion.identity) as GameObject;
				
				
			}
			if (posicion%2 == 0) //derecha
			{
				gusanoActual= Instantiate (gusanoActual,lopongoCentro.transform.position +new Vector3(distanciaEntreGusanos,0,0), Quaternion.identity) as GameObject;
				
				posicion++;
				
			}
			
			if (posicion%2 != 0) //izquierda
			{
				gusanoActual = Instantiate (gusanoActual,lopongoCentro.transform.position-new Vector3 (distanciaEntreGusanos,0,0), Quaternion.identity) as GameObject;
				distanciaEntreGusanos = distanciaEntreGusanos + distanciaEntreGusanos;
				posicion++;
				
			}
			
		}
		
	}


	public void ponerPW()
	{
		cualPongo = Random.Range (0,3);

		Instantiate(PW[cualPongo],lopongoOrilla.transform.position,Quaternion.identity);

	}
}


/**
 * 	gusanoTF = Random.Range (0, 10);
				
					
					if (gusanoTF<=5) //VOY A PONER GUSANOS!!!!!!!!!!!!!!!!!!!! AQUÍ VAN LOS GUSANOS!!! DESPUÉS VAN LOS OBSTÁCULOS!!
					{


						cantidadGusanos = Random.Range (minimoGusanos,maxGusanos);

						if (aleatorio == 0 || aleatorio ==1 || aleatorio ==3)
						{
							int posicion=0;
							int primero = 1;
							
							for (int i = 0; i<cantidadGusanos; i++)
							{
								if (gusanoActual == null)
								{

									gusanoActual= Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;
								}
								if (primero ==1)
								{

									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;
									
									
								}
								if (posicion%2 == 0) //derecha
								{
									gusanoActual= Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x+distanciaEntreGusanos, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;

									posicion++;
									
								}
								
								if (posicion%2 != 0) //izquierda
								{
									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x-distanciaEntreGusanos, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;
									
									
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

									gusanoActual= Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x+distanciaExtraPlataforma3, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;
								}
								if (posicion3%2 == 0) //derecha
								{

									gusanoActual = Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x+distanciaEntreGusanos+distanciaExtraPlataforma3, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;
									posicion3++;
									
								}
								
								if (posicion3%2 != 0) //izquierda
								{
									gusanoActual= Instantiate (gusanoActual,new Vector3(plataformaActual.transform.position.x-distanciaEntreGusanos+distanciaExtraPlataforma3, medidasAltura[aleatorio] ,0), Quaternion.identity) as GameObject;
									distanciaEntreGusanos = distanciaEntreGusanos + distanciaEntreGusanos;
									posicion3++;
									
								}
								
							}
						}

						


						}
						*/


