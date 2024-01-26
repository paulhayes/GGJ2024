using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class TypingInput : Singleton<TypingInput>
{
	public event Action<string> OnSuccessfullyTypedWord;
	public event Action OnTimeout;

	private void Start()
	{
		TypePhrases(new[] { "Test" });
	}

	public void TypePhrases(string[] phrases)
    {
		var options = phrases.Select(p => new Option(p)).ToArray();
        StartCoroutine(TypePhrasesCoroutine(options));
    }

	private IEnumerator TypePhrasesCoroutine(Option[] options)
	{
		var timer = 0;

		while (timer < 52)
		{
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
				if (option.GetNext() == letter) //can go out of bounds
				{
					option.Increment();
					print(option.GetTyped());
				}

				if (option.IsFinished())
				{
					OnSuccessfullyTypedWord?.Invoke(option.phrase);
					print($"Successfully wrote: {option.phrase}");
				}
			}
		}
	}
}
