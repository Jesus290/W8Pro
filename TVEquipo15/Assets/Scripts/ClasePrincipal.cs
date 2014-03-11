using UnityEngine;
using System.Collections;

public class ClasePrincipal : MonoBehaviour {


	public float velocidad=1;

	public float velocidadIncremento=2;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator controlVelocidad ()
	{
			velocidad = velocidad+velocidadIncremento;
			
			yield return new WaitForSeconds (3);
	
	}

	public float getVelocidad ()
	{
		return velocidad;
	}
}
