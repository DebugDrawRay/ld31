using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	public int playerScore;
	public bool endGame;
	public bool startGame;
	public bool gamePaused;
	public float startTime;
	public float gameTime;
	public GameObject flyPower;
	public float spawnTime;
	public float maxSpawnTime;
	public float minSpawnTime;
	void Awake()
	{
		startGame = true;
		endGame = false;
		startTime = Time.time;
		spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
	}
	void Update()
	{
		if (startGame && !endGame)
		{
			gamePaused = true;
		}
		if (!startGame && !endGame)
		{
			gamePaused = false;
			gameTime = (Time.time - startTime) % 60;
			spawnTime -= Time.deltaTime;
			spawnPower();
		}
		if (!startGame && endGame)
		{
			gamePaused = true;
			GameObject.FindGameObjectWithTag("EndScreen").GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
		}
	}

	void spawnPower()
	{
		if(spawnTime <= 0)
		{
			Instantiate(flyPower,new Vector3(Random.Range(-60,60),3, Random.Range(-54,54)),Quaternion.identity);
			spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
		}
	}
}
