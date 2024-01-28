using System;
using System.Linq;

public class Option
{
	public float CompletionPct => idx / (float)phrase.Length;

	public int idx;
	public string phrase;

	public event Action OnIncremented;
	public event Action<char> OnMistyped;

	private char[] charsToSkip = new[] { ' ', '\'', '?', '!', '.' };

	public Option(string phrase)
	{
		idx = 0;
		this.phrase = phrase;
	}

	public char GetNext() => phrase[idx];
	public string GetTyped() => phrase.Substring(0, idx);
	public bool IsFinished() => idx >= phrase.Length;

	public void Increment()
	{
		idx++;
		OnIncremented?.Invoke();

		if (IsFinished())
			return;

		var next = GetNext();
		if (charsToSkip.Contains(next))
			Increment();
	}
	
	public void Mistype(char letter)
	{
		OnMistyped?.Invoke(letter);
	}
}