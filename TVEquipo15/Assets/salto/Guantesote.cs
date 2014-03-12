using UnityEngine;
using System.Collections;

public class Guantesote : MonoBehaviour {

	public static float distanceTraveled;
	public float translation;

	public GameObject thePrefab;

	bool disparo;
	bool sigueDisparo;

	int posicionX=0;

	// Use this for initialization
	void Start () {
		StartCoroutine ("gun");
	}
	
	// Update is called once per frame
	void Update () { 
		//guantes ();
		if(sigueDisparo){
			guantes();
			transform.Translate(5f * Time.deltaTime, 0f, 0f);
		}
	}

	void guantes(){
		if (Input.GetKeyDown (KeyCode.X)) {
			GameObject instance = Instantiate(thePrefab, transform.position, transform.rotation) as GameObject;
		}
	}

	public IEnumerator gun (){
		while (disparo){
			sigueDisparo = true;
			posicionX += 1;
			if(posicionX == 10){
				disparo = false;
			}
			yield return new WaitForSeconds (3);
		}
		sigueDisparo = false;
		yield return null;
	}
}
