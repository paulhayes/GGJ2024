using System;
using System.Collections;
using UnityEngine;

public class TypingInput : MonoBehaviour
{
	public event Action<string> OnSuccessfullyTypedWord;
	public event Action OnTimeout;

	private void Start()
	{
		TypePhrases(new[] { "Test" });
	}

	public void TypePhrases(string[] phrases)
    {
        StartCoroutine(TypePhrasesCoroutine(phrases));
    }

	private IEnumerator TypePhrasesCoroutine(string[] phrases)
	{
		var timer = 0;
		int count = phrases.Length;
		int[] idx = new int[count];

		while (timer < 52)
		{
			string input = Input.inputString.ToLower();
			
			for (int i = 0; i < count; i++)
			{
				string phrase = phrases[i].ToLower();
				int index = idx[i];

				foreach (var letter in input)
				{
					print(phrase[index] + "");

					if (phrase[index] == letter) //can go out of bounds
					{
						idx[i] = ++index;
						print(phrase.Substring(0, index));
					}

					if (idx[i] >= phrase.Length)
					{
						OnSuccessfullyTypedWord?.Invoke(phrase);
						print($"Successfully wrote: {phrase}");
						yield break;
					}
				}
			}

			yield return null;
		}

		OnTimeout?.Invoke();
	}
}
