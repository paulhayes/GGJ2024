using DG.Tweening;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
	public GameObject visuals;
	public TextMeshProUGUI text;
	public float lettersPrSec = 50;

	private void Start()
	{
		StoryParser.Instance.CharacterDialogEvent += WriteDialogue;
		StoryParser.Instance.ConversationChoice	  += HideDialogue;
		StoryParser.Instance.CharacterChangeEvent += _ => HideDialogue();
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
		int idx = 0;

		while (idx <= dialogue.text.Length && !Input.anyKeyDown) // pls fix: this sucks (may skip down frame)
		{
			text.text = dialogue.text.Substring(0, idx++);
			yield return new WaitForSeconds(1f/lettersPrSec);		
		}

		text.text = dialogue.text;
		//yield return new WaitForSeconds(dialogue.text.Split(' ').Length/2);
		yield return null;

		while ( !Input.anyKeyDown ){
			yield return null;
		}
		dialogue.complete=true;
	}
}
