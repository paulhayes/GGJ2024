using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTypingInput : MonoBehaviour
{
    [SerializeField] TypingInput m_typingInput;
    private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();

		// TEST
		m_typingInput.OnFinishedTyping += phrase =>
		{
			if (phrase == -1)
				Debug.Log("Timed out!");
			else
				Debug.Log($"Successfully wrote: {phrase}");
		};
		m_typingInput.TypePhrases(new[] { "Test", "Lorem Ipsum", "Depression", "Temple" });
	}
}
