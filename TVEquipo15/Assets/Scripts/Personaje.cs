using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

	// Velocidad global
	bool sumaVelocidad = true;

	// Acciones
	float distToGround;
	GameObject personaje;

	// Power Ups
	public GameObject guante;
	public float velocidad;
	public float distanceTraveledY;
	public float distanceTraveledX;
	public float tiempoPwUp;
	GameObject obsTempo;
	//float distanceTraveledX=0;
	float localSpped;
	float distToGroundX;
	bool PowerUP = true;
	bool puedesVolar;
	bool disparar;
	int tiempoPW=0;
	int tipo=3;

	void Start () {
		localSpped = velocidad;
		personaje = GameObject.Find ("personaje");
		distToGround = gameObject.collider.bounds.extents.y;
		distToGroundX = gameObject.collider.bounds.extents.x;
		//guante = Instantiate(guante, transform.position, transform.rotation) as GameObject;

		StartCoroutine("aumenta");
	}

	void Update () {

		// Velocidad Global
		ClaseMaestra.distancia = ClaseMaestra.velocidad*Time.time;
		ClaseMaestra.time = Time.time;

		// Acciones
		saltar ();
		movHorizontal ();
		//descender ();

		// PowerUp Volar 
		if (puedesVolar == true) {

			//print ("entre");
			//rigidbody.useGravity = false; 	 	
			movVertical();
			kinematic ();
		}
		else{
			rigitbody();
		}
	}

	void movHorizontal(){
		
		float movVertical = Input.GetAxis ("Horizontal");
		
		if (movVertical > 0) {
			transform.position = new Vector3(transform.position.x + (localSpped*.1F), transform.position.y, transform.position.z);	
		}
		else if(movVertical < 0){
			transform.position = new Vector3(transform.position.x - (localSpped*.1F), transform.position.y, transform.position.z);
		}
	}

	// <---------------------------------- Global --------------------------------------->

	public IEnumerator aumenta (){
		while (sumaVelocidad){
			ClaseMaestra.velocidad= ClaseMaestra.velocidad +1;
			yield return new WaitForSeconds (3);
		}
		yield return new WaitForSeconds (3);
	}

	public void rigitbody(){
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
		rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
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
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			collider.isTrigger = false;	
		}
	}

	// <---------------------------------- PowerUps ------------------------------------->

		// <----- PowerUp Volar ----------------------------------->

	void movVertical(){
		
		float movVertical = Input.GetAxis ("Vertical");

		if (movVertical > 0 && transform.position.y < distanceTraveledY) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (localSpped * .1F), transform.position.z);
		}
		else if(movVertical < 0){
			transform.position = new Vector3(transform.position.x, transform.position.y - (localSpped*.1F), transform.position.z);
		}
	}

	void kinematic(){
		if(Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
			rigidbody.isKinematic = false;
			rigidbody.useGravity = false;
		}
		if(Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)){
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
		}
	}

	public IEnumerator volando (){
		while (PowerUP){
			puedesVolar = true;
			tiempoPW += 3;
			if(tiempoPW == tiempoPwUp){
				PowerUP = false;
			}
			yield return new WaitForSeconds (3);
		}
		puedesVolar = false;
		rigidbody.useGravity = true;
		yield return null;
	}

	bool isGroundedX(){
		return Physics.Raycast(transform.position, Vector3.right, distToGroundX + 0.1f);
	}

		// <----- PowerUp Huevo Gigante ----------------------------------->

	public IEnumerator destruir (){
		while (PowerUP){
			puedesVolar = true;
			tiempoPW += 1/4;
			if(tiempoPW == tiempoPwUp){
				PowerUP = false;
			}
			yield return new WaitForSeconds (1/4);
		}
		puedesVolar = false;
		yield return null;
	}

	void OnCollisionEnter (Collision colisionador)
	{
		
		if (tipo==1) //HuevoGigante
		{
			if(colisionador.gameObject.tag == "Obstaculo"){
				obsTempo = GameObject.FindWithTag ("Obstaculo");
				obsTempo.collider.isTrigger = true;
			}
		}
		
		if (tipo == 2)
		{
			// particulas de punos!!!! 
		}
		
		if (tipo == 3)
		{
			if (colisionador.gameObject.tag == "Obstaculo")
			{
				//Aquí mueres
			}
			
			if (colisionador.gameObject.tag == "Volar")
			{
				//print ("colisione");
				StartCoroutine ("volando");
			}
			
			if (colisionador.gameObject.tag == "HuevoGigante")
			{
				print ("huevoGigante");
				StartCoroutine ("destruir");
			}
			
			if (colisionador.gameObject.tag == "Punos")
			{
				//Aqui lanza
			}
			
			//Aqui vamos a poner los tags de todos los PW 
			
		}
	}

	/*
	public IEnumerator balas (){
		while (PowerUP) { 
			Instantiate (guante, personaje.transform.position, Quaternion.identity);
			if(tiempoPW == tiempoPwUp){
				PowerUP = false;
			}
			yield return new WaitForSeconds (tiempoDisparos);
		}
		yield return null;
	}
	*/
}
