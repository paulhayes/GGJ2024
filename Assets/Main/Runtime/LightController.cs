using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Singleton<LightController>
{
    public GameObject normalLight, partyLight;

	public void PartyLights()
	{
		normalLight.SetActive(false);
		partyLight.SetActive(true);
	}
	public void NormalLights()
	{
		normalLight.SetActive(true);
		partyLight.SetActive(false);
	}
}