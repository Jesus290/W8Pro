using UnityEngine;
using System.Collections;

public class Gusano : MonoBehaviour {
	
	Stamina vidaStamina;//Hace referencia al script de estamina

	int gusanos;
		
		
	void Awake()
	{
		vidaStamina = GameObject.Find("Stamina").GetComponent<Stamina>();
	}
	

	void Update () {
		
	}
	
	void OnCollisionEnter(Collision colisionando) {
		gusanos++;
		vidaStamina.Aumenta();
		Destroy(gameObject);
		
	}
	
}
