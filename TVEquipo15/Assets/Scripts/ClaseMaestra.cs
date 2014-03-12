using UnityEngine;
using System.Collections;

public class ClaseMaestra : MonoBehaviour {

	public static float velocidad=1; 
	public static float distancia=0; 
	public static float time = Time.time;
	public static int gusanos;


	public static void SaveScored()
	{
		if (PlayerPrefs.HasKey("userScore"))
		{
			PlayerPrefs.SetFloat("userScore", distancia);
		}

		else{

			PlayerPrefs.SetFloat("userScore", distancia);
		}
	}

	public static void ShowScore ()
	{
		distancia = PlayerPrefs.GetFloat ("userScore");
	}

}
