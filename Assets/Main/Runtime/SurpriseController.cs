using System;
using System.Collections;
using UnityEngine;

public class SurpriseController : Singleton<SurpriseController>
{
	public event Action OnSurprised;
	public event Action OnOverIt;

	[FMODUnity.EventRef, SerializeField]
	private string surprise;

	private void Start()
	{
		StoryParser.Instance.SuspicionAdjustEvent += adj => 
		{
			if (adj >= 10)
				Surprise(); 
		};
	}

	//public void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.Space))
	//		Surprise();
	//}

	public void Surprise()
	{
		OnSurprised?.Invoke();
		MusicController.Instance.Pause();
		LightController.Instance.NormalLights();
		AudioSystem.Instance.PlayOneShot(surprise);

		StopAllCoroutines();
		StartCoroutine(_Shock());
		IEnumerator _Shock()
		{
			yield return new WaitForSeconds(2f);
			LightController.Instance.PartyLights();
			MusicController.Instance.Play();
			OnOverIt?.Invoke();
		}
	}
}
