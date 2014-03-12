using UnityEngine;
using System.Collections;

public class CrearObjetos : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	/*void Start () {
		for (int i = 0; i < 5; i++) {
			Instantiate(enemy);
		}
	}*/
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.X)) {
			Instantiate(enemy);
		}
	}
}
