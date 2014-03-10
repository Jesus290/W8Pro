using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour {
	
	public float velocidad; 
	public float jumpPower;
	bool canJump;
	float distToGround;
	float localSpeed; 
	
	// Use this for initialization
	// No se puede saber que es lo que entra primero (Hacer corrutinas) 
	void Start () {
		
		distToGround = collider.bounds.extents.y;
		localSpeed = velocidad; 
		
	}
	
	// Update is called once per frame
	//Input float
	void Update () {
		
		float movHorizontal = Input.GetAxis ("Horizontal");  //Derecha Izquierda 
		if (movHorizontal > 0) {
			//tranform.position.x = tranform.position.x + 1; //JAVA SCRIPT
			transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0)); //Rotaciones vienen así :) 
			transform.position = new Vector3 (transform.position.x + (localSpeed*.1f), transform.position.y, transform.position.z);
			localSpeed = localSpeed*1.01f; 
		} 
		else if (movHorizontal < 0) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, -90, 0));
			transform.position = new Vector3 (transform.position.x - (localSpeed*.1f), transform.position.y, transform.position.z);
			localSpeed = localSpeed*1.01f; 
		}
		else {
			localSpeed = velocidad;
			
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded())
		{
			rigidbody.AddForce (new Vector3(0,jumpPower*100,0));
		}
		
	}
	
	bool isGrounded()
	{
		return Physics.Raycast (transform.position, -Vector3.up, distToGround +0.001f);
	}
}