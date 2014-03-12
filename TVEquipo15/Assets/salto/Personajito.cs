using UnityEngine;
using System.Collections;

public class Personajito : MonoBehaviour {

	GameObject personaje;
	public static int saltos=0;

	float distToGround;
	float distToGroundX;
	
	public float distanceTraveledY;
	float localSpped;
	public float velocidad; 
	
	bool vuela = true;
	int tiempoPW=0;
	bool puedesVolar;

	GameObject suelo;
	bool abajo;
	
	void Start () {
		localSpped = velocidad;
		personaje = GameObject.Find ("personaje");
		suelo = GameObject.Find ("suelo");
		distToGround = gameObject.collider.bounds.extents.y;
		distToGroundX = gameObject.collider.bounds.extents.x;
		StartCoroutine ("volando");
		//StartCoroutine ("desvanecer");
	}

	void Update () {

		// Acciones
		saltar ();
		descender ();
		movHorizontal ();

		// PowerUp Volar
		if (puedesVolar == true && isGroundedX() == true) {
			movVertical();		
		}
	}

	void movHorizontal(){
		
		float movVertical = Input.GetAxis ("Horizontal"); 
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		if (movVertical > 0) {
			transform.position = new Vector3(transform.position.x + (localSpped*.1F), transform.position.y, transform.position.z);	
		}
		else if(movVertical < 0){
			transform.position = new Vector3(transform.position.x - (localSpped*.1F), transform.position.y, transform.position.z);
		}
	}

	// <---------------------------------- Acciones ------------------------------------->
	
	// <---------- Saltar ------------------------------------->

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

	// <-------- Descender ------------------------------------>

	public void descender(){
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(isGrounded()){
				collider.isTrigger = true;	
			}
		}	
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			collider.isTrigger = false;	
		}
	}

	public IEnumerator desvanecer ()
	{
		while (abajo){

			if(tiempoPW == 1){
				abajo = false;
			}
			tiempoPW += 1;
			yield return new WaitForSeconds (1);
		}
		yield return null;
	}

	// <---------------------------------- PowerUps ------------------------------------->

	// <----- PowerUp Volar ----------------------------------->

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

	public IEnumerator volando (){
		while (vuela){
			puedesVolar = true;
			tiempoPW += 3;
			if(tiempoPW == 30){
				vuela = false;
			}
			yield return new WaitForSeconds (3);
		}
		puedesVolar = false;
		yield return null;
	}

	bool isGroundedX(){
		return Physics.Raycast(transform.position, Vector3.right, distToGroundX + 0.1f);
	}
}
