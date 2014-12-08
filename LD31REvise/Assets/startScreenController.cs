using UnityEngine;
using System.Collections;

public class startScreenController : MonoBehaviour {

	public void startGame()
	{
		GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().startGame = false;
		transform.position = new Vector3 (0, 1000, 0);
	}
}
