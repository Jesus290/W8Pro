using UnityEngine;
using System.Collections;

public class Guante : MonoBehaviour {

	public static float distanceTraveled;
	public float translation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
		guantes ();
	}

	void guantes(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			while(transform.position.x < 20){
				translation = Time.deltaTime * 2;
				transform.Translate(translation,0,0);
			}
		}
	}
}
