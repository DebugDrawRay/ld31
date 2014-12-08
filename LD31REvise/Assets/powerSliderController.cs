using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class powerSliderController : MonoBehaviour 
{
	void Update () 
	{
		GetComponent<Image>().fillAmount = .01f + GameObject.FindGameObjectWithTag("Player").GetComponent<fly>().currentFlightStrength/GameObject.FindGameObjectWithTag("Player").GetComponent<fly>().maxFlightStrength;
	}
}
