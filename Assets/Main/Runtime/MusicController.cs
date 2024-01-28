using FMOD.Studio;
using System;
using System.Collections;
using UnityEngine;

public class MusicController : Singleton<MusicController>
{
	[FMODUnity.EventRef, SerializeField]
	private string music, ambience;
	private EventInstance musicInstance, ambienceInstance;

	[SerializeField] StoryParser m_storyParser;

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();

		musicInstance = AudioSystem.Instance.CreateInstance(music);
		ambienceInstance = AudioSystem.Instance.CreateInstance(ambience);

		musicInstance.start();
		ambienceInstance.start();

		Mute();

		m_storyParser.CharacterChangeEvent += _ =>
		{
			musicInstance.setVolume(1);
			ambienceInstance.setVolume(1);
			musicInstance.setParameterByName("PersonEnter", 0);
		};
		m_storyParser.CharacterDialogEvent += _ =>
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

	public void Mute()
	{
		musicInstance.setVolume(0);
		ambienceInstance.setVolume(0);
	}
}
