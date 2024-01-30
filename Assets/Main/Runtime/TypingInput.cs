using FMODUnity;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class TypingInput : Singleton<TypingInput>
{
	public float TimeLeft {  get; private set; }

	public event Action<Option[]> OnStartTyping;
	public event Action<int> OnFinishedTyping;
	public event Action OnType;
	public event Action OnMistype;

	[FMODUnity.EventRef(MigrateTo="typeSFXEventRef"), SerializeField]
	private string typeSFX;
	[FMODUnity.EventRef(MigrateTo ="mistypeSFXEventRef"), SerializeField]
	private string mistypeSFX;

	[SerializeField] EventReference typeSFXEventRef;
	[SerializeField] EventReference mistypeSFXEventRef;

	public void TypePhrases(string[] phrases)
    {
		var options = phrases.Where((p)=>p.ToLower()!="mistype").Select(p => new Option(p)).ToArray();
		OnStartTyping?.Invoke(options);
		StartCoroutine(TypePhrasesCoroutine(options));
    }

	public IEnumerator TypePhrasesCoroutine(Option[] options, float time = 12)
	{
		TimeLeft = time;
		while (TimeLeft > 0)
		{
			TimeLeft -= Time.deltaTime;
			string input = Input.inputString.ToLower();
			
			bool mistype = true;
			bool finished= false;

			FilterKeys(ref input);
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
				
				OnMistype?.Invoke();
				AudioSystem.Instance.PlayOneShot(mistypeSFXEventRef);
			}
			else
			{
				OnType?.Invoke();
				AudioSystem.Instance.PlayOneShot(typeSFXEventRef);
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

    private void FilterKeys(ref string input)
    {
        if(string.IsNullOrEmpty(input)){
			return;
		}
		if(input.Length==1){
			if(!char.IsLetterOrDigit(input[0])){
				input = string.Empty;
			}		
			return;
		}

		StringBuilder filteredKeys = new StringBuilder();
		for(int i=0;i<input.Length;i++){
			if( char.IsLetterOrDigit(input[i])){
				filteredKeys.Append(input[i]);
			}
		}
		input=filteredKeys.ToString();
    }

}
