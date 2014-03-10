using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {

	public bool disminuir; //Indica cuando se disminuye la stamina (casi todo el juegos menos cuando se enfrenta al boss)
	public float cantidadDisminucion; //Disminución de stamina constante a lo largo del juego
	public float cantidadAumenta;
	
	// Use this for initialization
	void Start () {

		StartCoroutine ("Disminuye");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public void Aumenta()
	{
		gameObject.transform.localScale = gameObject.transform.localScale + (new Vector3(cantidadAumenta*Time.deltaTime,0,0));
	}


	public IEnumerator Disminuye()
	{
		while (disminuir)
		{
			print (gameObject.transform.localScale.x);
			if (gameObject.transform.localScale.x>0)
			{
				gameObject.transform.localScale = gameObject.transform.localScale - (new Vector3(cantidadDisminucion*Time.deltaTime,0,0));
			}

			yield return new WaitForSeconds (5);
		}

			
		yield return new WaitForSeconds (5);
	}
	
	
}

