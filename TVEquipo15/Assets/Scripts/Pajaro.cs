using UnityEngine;
using System.Collections;

public class Pajaro : MonoBehaviour {

	public float timeAlive;
	float initTime;

	
	float angulo =60;
	public float amplituDeOnda;
	Vector3 posicion;


	void Start () {
		initTime = Time.time;

	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(-6f*Time.deltaTime, Mathf.Cos(angulo * amplituDeOnda) * Time.deltaTime,0f);
		angulo++;

		if(Time.time >= initTime+timeAlive)
		{
			Destroy(gameObject);
		}

	
	}
	
}
