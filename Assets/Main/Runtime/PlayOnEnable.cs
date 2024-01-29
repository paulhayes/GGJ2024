using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class PlayOnEnable : MonoBehaviour
{
	[SerializeField] EventReference playEventRef;
	private EventInstance instance;

	void Awake()
	{
	}

	private void OnEnable()
	{	

		if( instance.hasHandle() ){
			PlayAudio();
		}
		else {
			StartCoroutine( PlayAfterLoad() );			
		}
	}

	IEnumerator PlayAfterLoad()
	{
		Debug.Log("PlayAfterLoad");
		yield return new WaitWhile( ()=>!RuntimeManager.HaveAllBanksLoaded );
		instance = AudioSystem.Instance.CreateInstance(playEventRef);					
		PlayAudio();
	}

	void PlayAudio()
	{
		MusicController.Instance.Mute();
		instance.start();
	}

	private void OnDisable()
	{
		instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
}
