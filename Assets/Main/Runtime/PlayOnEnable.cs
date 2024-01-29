using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class PlayOnEnable : MonoBehaviour
{
	[FMODUnity.EventRef(MigrateTo ="playEventRef"), SerializeField]
	private string toPlay;
	[SerializeField] EventReference playEventRef;
	private EventInstance instance;

	private void OnEnable()
	{
		MusicController.Instance.Mute();
		instance = AudioSystem.Instance.CreateInstance(playEventRef);
		instance.start();
	}

	private void OnDisable()
	{
		instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
}
