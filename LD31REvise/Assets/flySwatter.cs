using UnityEngine;
using System.Collections;

public class flySwatter : MonoBehaviour 
{

	public Vector3 neutralFloat;
	public Quaternion neutralRotation;
	public Quaternion targetRotation;
	public int slammedScore;
	public float slamSpeed;
	public float cooldownMax;
	public float cooldownMin;
	public float cooldownReductionFactor;
	public float waitMax;
	public float playerDistance;
	private bool runCycle;
	private bool slammed;
	private bool lockedPlayerPos;
	public float cooldownTime;
	public float waitTime;
	public float warnFactor;
	void Start()
	{
		runCycle = false;
		slammed = false;
		lockedPlayerPos = false;
		cooldownTime = cooldownMax;
		waitTime = 0;
	}
	void Update () 
	{
		if(!GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().gamePaused)
		{
			runTimers();
			stateControl();
			slamWarningControl();
			if (cooldownMax < cooldownMin)
			{
				cooldownMax = cooldownMin;
			}
		}
	}

	void slamWarningControl()
	{
		if(cooldownTime <= cooldownMax/warnFactor && !lockedPlayerPos)
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, 0, GameObject.FindGameObjectWithTag("Player").transform.position.z - 108);
			GameObject.FindGameObjectWithTag("WarningTarget").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, 0, GameObject.FindGameObjectWithTag("Player").transform.position.z);
			lockedPlayerPos = true;
		}
		if (cooldownTime <= cooldownMax/warnFactor)
		{
			GameObject.FindGameObjectWithTag("WarningTarget").GetComponent<SpriteRenderer>().enabled = true;
		}
		else
		{
			GameObject.FindGameObjectWithTag("WarningTarget").GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	void runTimers()
	{
		if(!slammed)
		{
			cooldownTime -= Time.deltaTime;
		}

		if(slammed)
		{
			waitTime -= Time.deltaTime;
		}
	}

	void stateControl()
	{
		if (cooldownTime <= 0)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * slamSpeed);
			if(!slammed)
			{
				audio.Play ();
				waitTime = waitMax;
				slammed = true;
			}
		}

		if (waitTime <= 0)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, neutralRotation, Time.deltaTime * slamSpeed);
			if(slammed)
			{
				GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().playerScore += slammedScore;
				cooldownMax = cooldownMax/cooldownReductionFactor;
				cooldownTime = cooldownMax;
				slammed = false;
				lockedPlayerPos = false;
			}
		}
	}

}
