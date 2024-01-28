using FMOD.Studio;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	[FMODUnity.EventRef, SerializeField]
	private string music;
	private EventInstance musicInstance;

	private void Start()
	{
		musicInstance = AudioSystem.Instance.CreateInstance(music);	
		musicInstance.start();

		StoryParser.Instance.CharacterChangeEvent += _ =>
		{
			musicInstance.setParameterByName("PersonEnter", 1);
		};
		StoryParser.Instance.CharacterDialogEvent += _ =>
		{
			musicInstance.setParameterByName("PersonEnter", 0);
		};
	}
}
