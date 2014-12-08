using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour 
{
	public float maxFlightStrength;
	public float minFlightStrength;
	public float flightFillRate;
	public float currentFlightStrength;
	private bool flightButtonHeld;
	public string flightInput;
	public bool flightButton;
	public Vector3 mousePos;
	public Vector3 targetDir;
	public int powerScore;
	public AudioClip pickUp;

	void Start()
	{
		flightButtonHeld = false;
		currentFlightStrength = 0;
	}
	void Update () 
	{
		if(!GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().gamePaused)
		{
			inputListener();
			flightController();
		}
	}
	void inputListener()
	{
		flightButton = Input.GetButton(flightInput);
	}
	void flightController()
	{
		if (flightButton)
		{
			rigidbody.velocity -= Vector3.zero;
			flightButtonHeld = true;
			transform.LookAt(new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z));
			if(currentFlightStrength < maxFlightStrength)
			{
				currentFlightStrength += flightFillRate;
			}
		}
		if (!flightButton)
		{
			if(flightButtonHeld)
			{
				if(currentFlightStrength > minFlightStrength)
				{
					rigidbody.AddForce(transform.forward * currentFlightStrength);
					audio.Play();
				}
				else
				{
					rigidbody.AddForce(transform.forward * currentFlightStrength/4);
				}
				currentFlightStrength = 0;
				flightButtonHeld = false;
			}
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().endGame = true;
			Destroy(this.gameObject);
		}
		if (other.gameObject.tag == "FlyPower")
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().playerScore += powerScore;
			AudioSource.PlayClipAtPoint(pickUp, other.gameObject.transform.position);
			Destroy(other.gameObject);
		}
	}
}
