using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class TypingInput : Singleton<TypingInput>
{
	public float TimeLeft {  get; private set; }

	public event Action<Option[]> OnStartTyping;
	public event Action<int> OnFinishedTyping;
	public event Action OnMistype;

	public void TypePhrases(string[] phrases)
    {
		var options = phrases.Where((p)=>p.ToLower()!="mistype").Select(p => new Option(p)).ToArray();
		OnStartTyping?.Invoke(options);
		StartCoroutine(TypePhrasesCoroutine(options));
    }

	private IEnumerator TypePhrasesCoroutine(Option[] options)
	{
		TimeLeft = 25;
		while (TimeLeft > 0)
		{
			TimeLeft -= Time.deltaTime;
			string input = Input.inputString.ToLower();
			bool mistype = true;

			if (string.IsNullOrEmpty(input))
			{
				yield return null;
				continue;
			}

			foreach (var option in options)
			{
				bool correct = CheckInput(option, input);

				if (correct)
					mistype = false;

				if (option.IsFinished())
					yield break;
			}

			yield return null;
		}

		OnFinishedTyping?.Invoke(-1);

		bool CheckInput(Option option, string input)
		{
			bool correct = false;

			foreach (var letter in input)
			{
				if (option.GetNext() == letter)
				{
					option.Increment();
					correct = true;
				}
				else
				{
					option.Mistype(letter);
				}

				if (option.IsFinished())
				{
					int phraseIdx = Array.IndexOf(options, option);
					OnFinishedTyping?.Invoke(phraseIdx);
					return true;
				}
			}

			return correct;
		}
	}
}
