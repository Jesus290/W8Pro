using UnityEngine;
using System.Collections;

public class PorwerUps : MonoBehaviour {

	GameObject obstaculo;
	float timeAlive;
	float initTime;

	void Start () {
		initTime = Time.time;
	
	}

	void Update () {

		if(Time.time >= (initTime+timeAlive))
			Destroy(this.gameObject);
	
	}
}
