using FMODUnity;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class TypingInput : Singleton<TypingInput>
{
	public float TimeLeft {  get; private set; }

	public event Action<Option[]> OnStartTyping;
	public event Action<int> OnFinishedTyping;
	public event Action OnType;
	public event Action OnMistype;

	[FMODUnity.EventRef, SerializeField]
	private string typeSFX, mistypeSFX;

	public void TypePhrases(string[] phrases)
    {
		var options = phrases.Where((p)=>p.ToLower()!="mistype").Select(p => new Option(p)).ToArray();
		OnStartTyping?.Invoke(options);
		StartCoroutine(TypePhrasesCoroutine(options));
    }

	private IEnumerator TypePhrasesCoroutine(Option[] options)
	{
		TimeLeft = 15;
		while (TimeLeft > 0)
		{
			TimeLeft -= Time.deltaTime;
			string input = Input.inputString.ToLower();
			bool mistype = true;
			bool finished= false;

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
				{
					finished = true;
					break;
				}
			}

			if (mistype)
			{
				print("TYPO!");
				OnMistype?.Invoke();
				AudioSystem.Instance.PlayOneShot(mistypeSFX);
			}
			else
			{
				OnType?.Invoke();
				AudioSystem.Instance.PlayOneShot(typeSFX);
			}

			if (finished)
				yield break;

			yield return null;
		}

		OnFinishedTyping?.Invoke(-1);

		bool CheckInput(Option option, string input)
		{
			bool correct = false;

			foreach (var letter in input)
			{
				var nextLetter = Char.ToLower(option.GetNext());

				if (nextLetter == letter)
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
