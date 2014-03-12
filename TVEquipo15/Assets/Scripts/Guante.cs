using UnityEngine;
using System.Collections;

public class Guante : MonoBehaviour {

	public static float distanceTraveled;
	//public float translation;

	public GameObject guante;
	GameObject personaje;

	bool disparo;
	bool sigueDisparo;

	int posicionX=0;
	int posicionR=0;

	// Use this for initialization
	void Start () {
		StartCoroutine ("gun");
		personaje = GameObject.Find ("cool");
	}
	
	// Update is called once per frame
	void Update () { 
		guantes();
	}

	public void guantes(){
		if (Input.GetKeyDown (KeyCode.X)) {
			Instantiate(guante, new Vector3(personaje.transform.position.x, personaje.transform.position.y,0), Quaternion.identity);
		}
	}

	public IEnumerator gun (){
		while (disparo){
			sigueDisparo = true;
			posicionX += 1;
			if(posicionX == 20){
				disparo = false;
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				Instantiate(guante);
			}
			yield return new WaitForSeconds (2);
		}
		sigueDisparo = false;
		yield return null;
	}
}
