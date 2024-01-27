using System.Collections;
using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
	public TextMeshProUGUI text;
	public float lettersPrSec = 50;

	private void Start()
	{
		//TEST
		WriteDialogue("Hello, my name is Jerry, I work in Accounting. How about you?");
	}

	public void WriteDialogue(string dialogue)
	{
		StartCoroutine(TextWriter(dialogue));
	}

	IEnumerator TextWriter(string dialogue)
	{
		int idx = 0;

		while (idx <= dialogue.Length) 
		{
			text.text = dialogue.Substring(0, idx++);
			yield return new WaitForSeconds(1f/lettersPrSec);
		}
	}
}
