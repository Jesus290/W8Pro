using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {


	public float distanceTraveledY;
	public static float distanceTraveled;

	
	public float velocidad;  
	float localSpped;

	float distToGround;
	public float jumpPower;

	public float timer;
	public float time2 = 0.0F;

	GameObject personaje;

	void Start () {
		localSpped = velocidad;
		personaje = GameObject.Find ("Personaje");
	}

	void Update () {

		if (Input.GetKeyUp (KeyCode.Space)) {
			personaje.rigidbody.AddForce(new Vector3(0,10,0), ForceMode.VelocityChange);
		}

		distanceTraveled = transform.localPosition.x;
		//distToGround = gameObject.collider.bounds.extents.y;
		//brincar ();

		volar ();

		//transform.Translate(5f * Time.deltaTime, 0f,0f);

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

		// Move the object 10 meters per second!
		float translation = Time.deltaTime * 2;

		/*
		if (Time.time == time2) {
			time2=Time.time;
			var guiTime = Time.time - time2;
			while(timer>0){
				timer -= Time.deltaTime;
			}
		}
		*/

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

	/*
	void brincar(){
		if (Input.GetKeyDown (KeyCode.Space)){
			transform.position = new Vector3(0,jumpPower*10,0);
		}
	}
	*/

	bool isGrounded(){
		return Physics.Raycast(transform.position, - Vector3.up, distToGround + 0.1f);
	}
}
