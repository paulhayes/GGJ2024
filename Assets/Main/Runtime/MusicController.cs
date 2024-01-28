using FMOD.Studio;
using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	[FMODUnity.EventRef, SerializeField]
	private string music, ambience, shock;
	private EventInstance musicInstance, ambienceInstance;

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();

		musicInstance = AudioSystem.Instance.CreateInstance(music);
		ambienceInstance = AudioSystem.Instance.CreateInstance(ambience);

		musicInstance.start();
		ambienceInstance.start();
		musicInstance.setVolume(.15f);
		ambienceInstance.setVolume(.5f);

		StoryParser.Instance.CharacterChangeEvent += _ =>
		{
			musicInstance.setParameterByName("PersonEnter", 0);
		};
		StoryParser.Instance.CharacterDialogEvent += _ =>
		{
			musicInstance.setParameterByName("PersonEnter", 1);
		};
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			Shock();
	}

	public void Shock()
	{
		musicInstance.setPaused(true);
		ambienceInstance.setPaused(true);
		AudioSystem.Instance.PlayOneShot(shock);
	}
}
