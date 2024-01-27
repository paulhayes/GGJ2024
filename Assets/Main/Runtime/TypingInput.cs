using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TypingInput : Singleton<TypingInput>
{
	public event Action<string> OnSuccessfullyTypedWord;
	public event Action OnTimeout;
	public event Action<Option[]> OnStartTyping;

	private void Start()
	{
		// TEST
		TypePhrases(new[] { "Test", "Lorem Ipsum", "Depression", "Temple" });
		OnSuccessfullyTypedWord += phrase => Debug.Log($"Successfully wrote: {phrase}");
		OnTimeout += () => Debug.Log($"Timed out!");
	}

	public void TypePhrases(string[] phrases)
    {
		var options = phrases.Select(p => new Option(p)).ToArray();
		OnStartTyping?.Invoke(options);
		StartCoroutine(TypePhrasesCoroutine(options));
    }

	private IEnumerator TypePhrasesCoroutine(Option[] options)
	{
		float timer = 0;
		while (timer < 52)
		{
			timer += Time.deltaTime;
			string input = Input.inputString.ToLower();

			foreach (var option in options)
			{
				CheckInput(option, input);

				if (option.IsFinished())
					yield break;
			}

			yield return null;
		}

		OnTimeout?.Invoke();

		void CheckInput(Option option, string input)
		{
			foreach (var letter in input)
			{
				if (option.GetNext() == letter)
					option.Increment();

				if (option.IsFinished())
				{
					OnSuccessfullyTypedWord?.Invoke(option.phrase);
					return;
				}
			}
		}
	}
}
