using UnityEngine;
using System.Collections;

public class Velocidad : MonoBehaviour {

	// Use this for initialization


	bool repite = true;

	public float velocidadIncremento;
	public float velocidadInicial;

	void Start () {

		StartCoroutine ("controlVelocidad");
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3(5*Time.deltaTime*velocidadInicial, 0, 0));

	
	}

	public IEnumerator controlVelocidad ()
	{
		while (repite)
		{
			velocidadInicial = velocidadInicial+velocidadIncremento;

		yield return new WaitForSeconds (3);
		}
		yield return new WaitForSeconds (3);
	}
	
}
