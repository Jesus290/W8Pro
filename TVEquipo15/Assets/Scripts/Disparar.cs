using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {

	public float Velocidad;
	
	void Update () {

		transform.Translate (Velocidad*0.1f,0,0);
		if(transform.position.x > 40){
			print("Entre");
			Guante.Destroy(gameObject);
		}
	
	}


}
