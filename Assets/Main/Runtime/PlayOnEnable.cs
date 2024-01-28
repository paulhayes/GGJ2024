using FMOD.Studio;
using UnityEngine;

public class PlayOnEnable : MonoBehaviour
{
	[FMODUnity.EventRef, SerializeField]
	private string toPlay;
	private EventInstance instance;

	private void OnEnable()
	{
		MusicController.Instance.Mute();
		instance = AudioSystem.Instance.CreateInstance(toPlay);
		instance.start();
	}

	private void OnDisable()
	{
		instance.stop(STOP_MODE.ALLOWFADEOUT);
	}
}
