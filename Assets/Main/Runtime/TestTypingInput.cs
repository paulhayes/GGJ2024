using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTypingInput : MonoBehaviour
{
    [SerializeField] TypingInput m_typingInput;
    private void Start()
	{
		// TEST
		m_typingInput.OnFinishedTyping += phrase =>
		{
			if (phrase == null)
				Debug.Log("Timed out!");
			else
				Debug.Log($"Successfully wrote: {phrase}");
		};
		m_typingInput.TypePhrases(new[] { "Test", "Lorem Ipsum", "Depression", "Temple" });
	}
}
