using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class TypingInput : Singleton<TypingInput>
{
	public float TimeLeft {  get; private set; }

	public event Action<Option[]> OnStartTyping;
	public event Action<string> OnFinishedTyping;

	public void TypePhrases(string[] phrases)
    {
		var options = phrases.Select(p => new Option(p)).ToArray();
		OnStartTyping?.Invoke(options);
		StartCoroutine(TypePhrasesCoroutine(options));
    }

	private IEnumerator TypePhrasesCoroutine(Option[] options)
	{
		TimeLeft = 5;
		while (TimeLeft > 0)
		{
			TimeLeft -= Time.deltaTime;
			string input = Input.inputString.ToLower();

			foreach (var option in options)
			{
				CheckInput(option, input);

				if (option.IsFinished())
					yield break;
			}

			yield return null;
		}

		OnFinishedTyping?.Invoke(null);

		void CheckInput(Option option, string input)
		{
			foreach (var letter in input)
			{
				if (option.GetNext() == letter)
					option.Increment();

				if (option.IsFinished())
				{
					OnFinishedTyping?.Invoke(option.phrase);
					return;
				}
			}
		}
	}
}
