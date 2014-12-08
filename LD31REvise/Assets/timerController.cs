using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerController : MonoBehaviour 
{

	void Update () 
	{
		GetComponent<Text>().text = Mathf.Round(GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().gameTime) + "s";
	}
}
