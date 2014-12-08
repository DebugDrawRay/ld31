using UnityEngine;
using System.Collections;

public class endScreenController : MonoBehaviour 
{
	void Awake()
	{
		transform.position = new Vector3(0,1000,0);
	}
	public void endGame()
	{
		Application.LoadLevel("main");
	}

}
