using DG.Tweening;
using FMOD.Studio;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
	public GameObject visuals;
	public TextMeshProUGUI text;
	public float lettersPrSec = 50;

	[FMODUnity.EventRef, SerializeField]
	private string[] talk;
		//talkSarah,
		//talkJerry,
		//talkJimmy,
		//talkMargaret,
		//talkJames,
		//talkBradley,
		//talkRebbeca,
		//talkGiles,
		//talkMiriam,
		//talkTim,
		//talkBenedict;

	private EventInstance talkInstance;
	
	private void Start()
	{
		StoryParser.Instance.CharacterDialogEvent += WriteDialogue;
		StoryParser.Instance.ConversationChoice	  += HideDialogue;
		StoryParser.Instance.CharacterChangeEvent += _ => HideDialogue();
		StoryParser.Instance.CharacterChangeEvent += ChangeTalk;
	}

	private void ChangeTalk(CharacterTransitionData data)
	{
		talkInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		talkInstance.release();
		talkInstance = AudioSystem.Instance.CreateInstance(talk[data.characterIndex]);
	}

	public void WriteDialogue(DialogSnippet dialogue)
	{
		visuals.SetActive(true);
		visuals.transform.DOScale(Vector3.one, .67f).SetEase(Ease.OutElastic, 1f);
		StartCoroutine(TextWriter(dialogue));
	}

	public void HideDialogue()
	{
		visuals.transform.DOKill();
		visuals.transform.localScale = Vector3.one*.1f;
		visuals.SetActive(false);
	}

	IEnumerator TextWriter(DialogSnippet dialogue)
	{
		talkInstance.start();

		int idx = 0;

		while (idx <= dialogue.text.Length && !Input.anyKeyDown) // pls fix: this sucks (may skip down frame)
		{
			text.text = $"{dialogue.text.Substring(0, idx)}<color=#00000080>{dialogue.text.Substring(idx++)}</color>";
			yield return new WaitForSeconds(1f/lettersPrSec);		
		}

		text.text = dialogue.text;
		//yield return new WaitForSeconds(dialogue.text.Split(' ').Length/2);
		yield return null;

		talkInstance.stop(STOP_MODE.ALLOWFADEOUT);

		while ( !Input.anyKeyDown ){
			yield return null;
		}
		dialogue.complete=true;
	}
}
