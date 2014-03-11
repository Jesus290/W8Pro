using UnityEngine;
using System.Collections;

public class Gusano : ClasePrincipal {
	
	Stamina vidaStamina;//Hace referencia al script de estamina

	ClasePrincipal vel = new ClasePrincipal();

	
	int gusanos;

	public float timeAlive;

	
	float initTime;
	float velocidad;



	void Start () {
		
		initTime = Time.time;
	}
	
	
	void Awake()
	{
		vidaStamina = GameObject.Find("Stamina").GetComponent<Stamina>();

	}
	
	
	void Update () {

		
		transform.Translate(5*Time.deltaTime*vel.getVelocidad(),0,0);

		
		if(Time.time >= (initTime+timeAlive))
		{
			Destroy(this.gameObject);
		}
		
	}
	
	void OnCollisionEnter(Collision colisionando) {
		gusanos++;
		vidaStamina.Aumenta();
		Destroy(gameObject);
		
	}
	

	
}