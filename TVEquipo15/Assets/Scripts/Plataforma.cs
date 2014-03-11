using UnityEngine;
using System.Collections;

public class Plataforma  : ClasePrincipal {
	

	public float timeAlive;
	ClasePrincipal vel = new ClasePrincipal();
	
	
	float initTime;


	
	
	
	void Start () {
		
		initTime = Time.time;
		
		
	}
	
	
	void Update () 
	{

		transform.Translate(5*Time.deltaTime*vel.getVelocidad(),0,0);
		if(Time.time >= (initTime+timeAlive))
			Destroy(this.gameObject);
		}
		
	}
	

	

