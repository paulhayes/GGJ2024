using FMOD.Studio;
using System.Collections;
using UnityEngine;

public class MusicController : Singleton<MusicController>
{
	[FMODUnity.EventRef, SerializeField]
	private string music, ambience;
	private EventInstance musicInstance, ambienceInstance;

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();

		musicInstance = AudioSystem.Instance.CreateInstance(music);
		ambienceInstance = AudioSystem.Instance.CreateInstance(ambience);

		musicInstance.start();
		ambienceInstance.start();
		//musicInstance.setVolume(.15f);
		//ambienceInstance.setVolume(.5f);

		StoryParser.Instance.CharacterChangeEvent += _ =>
		{
			musicInstance.setParameterByName("PersonEnter", 0);
		};
		StoryParser.Instance.CharacterDialogEvent += _ =>
		{
			musicInstance.setParameterByName("PersonEnter", 1);
		};
	}

	public void Pause()
	{
		musicInstance.setPaused(true);
		ambienceInstance.setPaused(true);
	}

	public void Play()
	{
		musicInstance.setPaused(false);
		ambienceInstance.setPaused(false);
	}
}
