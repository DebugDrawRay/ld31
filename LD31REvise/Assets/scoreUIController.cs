using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreUIController : MonoBehaviour {
	
	void Update () 
	{
		GetComponent<Text>().text = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().playerScore + "\n Fly-Points";
	}
}
