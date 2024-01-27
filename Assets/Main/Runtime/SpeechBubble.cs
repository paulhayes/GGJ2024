using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
	public TextMeshProUGUI text;
	public float lettersPrSec = 50;

	private void Start()
	{
		StoryParser.Instance.CharacterDialogEvent += WriteDialogue;
	}

	public void WriteDialogue(DialogSnippet dialogue)
	{
		StartCoroutine(TextWriter(dialogue));
	}

	IEnumerator TextWriter(DialogSnippet dialogue)
	{
		int idx = 0;

		while (idx <= dialogue.text.Length) 
		{
			text.text = dialogue.text.Substring(0, idx++);
			yield return new WaitForSeconds(1f/lettersPrSec);			
		}
		yield return new WaitForSeconds(dialogue.text.Split(' ').Length/2);
		dialogue.complete=true;
	}
}
