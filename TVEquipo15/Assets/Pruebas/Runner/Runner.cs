using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	[HideInInspector]
	public float distanceTraveledY;
	[HideInInspector]
	public static float distanceTraveled;

	
	public float velocidad;  
	float localSpped;

	float distToGround;
	[HideInInspector]
	public float jumpPower;

	[HideInInspector]
	public float timer;
	[HideInInspector]
	public float time2 = 0.0F;

	GameObject personaje;
	[HideInInspector]
	public bool sumaVelocidad = true;


	void Start () {
		localSpped = velocidad;
		personaje = GameObject.Find ("Personaje");
		StartCoroutine("aumenta");
	}

	void Update () {
		distanceTraveled = transform.localPosition.x;

		volar ();
		saltar ();
	}


	void movVertical(){
		float movVertical = Input.GetAxis ("Vertical");

		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		if (movVertical > 0 && transform.position.y < distanceTraveledY ) {
			transform.position = new Vector3(transform.position.x, transform.position.y + (localSpped*.1F), transform.position.z);	
		}
		else if(movVertical < 0){
			transform.position = new Vector3(transform.position.x, transform.position.y - (localSpped*.1F), transform.position.z);
		}
	}

	bool megatimer(){

		float translation = Time.deltaTime * 2;

		if(translation <= 3){
			return true;
		}
		else{
			return false;
		}
	}

	void volar(){
		if(megatimer() == true){
			movVertical();
		}
	}

	public void saltar(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			if(isGrounded()){
				personaje.rigidbody.AddForce(new Vector3(0,10,0), ForceMode.VelocityChange);		
			}
		}	
	}

	bool isGrounded(){
		return Physics.Raycast(transform.position, - Vector3.up, distToGround + 0.1f);
	}

	public IEnumerator aumenta ()
	{
		while (sumaVelocidad){
			ClaseMaestra.velocidad= ClaseMaestra.velocidad +1;
			yield return new WaitForSeconds (3);
			
			
		}
		
		yield return new WaitForSeconds (3);
	}
}
