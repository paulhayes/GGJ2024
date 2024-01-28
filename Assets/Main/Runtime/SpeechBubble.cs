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
	}

	public void WriteDialogue(DialogSnippet dialogue)
	{
		visuals.SetActive(true);
		StartCoroutine(TextWriter(dialogue));
	}

	public void HideDialogue()
	{
		visuals.SetActive(false);
	}

	IEnumerator TextWriter(DialogSnippet dialogue)
	{
		int idx = 0;

		while (idx <= dialogue.text.Length) 
		{
			text.text = dialogue.text.Substring(0, idx++);
			yield return new WaitForSeconds(1f/lettersPrSec);					
		}
		//yield return new WaitForSeconds(dialogue.text.Split(' ').Length/2);
		while( !Input.anyKeyDown ){
			yield return null;
		}
		dialogue.complete=true;
	}
}
