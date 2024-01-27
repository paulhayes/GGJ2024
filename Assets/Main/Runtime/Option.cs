using System;

public class Option
{
	public int idx;
	public string phrase;

	public event Action OnIncremented;
	public event Action<char> OnMistyped;

	public Option(string phrase)
	{
		idx = 0;
		this.phrase = phrase.ToLower();
	}

	public char GetNext() => phrase[idx];
	public string GetTyped() => phrase.Substring(0, idx);
	public bool IsFinished() => idx >= phrase.Length;

	public void Increment()
	{
		idx++;
		OnIncremented?.Invoke();
	}
	
	public void Mistype(char letter)
	{
		OnMistyped?.Invoke(letter);
	}
}