using System;
using TMPro;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
	public TextMeshProUGUI typingText;
	public TextMeshProUGUI backgroundText;
	
	private Option option;

	public void SetOption(Option option)
	{
		this.option = option;

		typingText.text = "";
		backgroundText.text = option.phrase;
	}

	private void Update()
	{
		if (option == null)
			return;

		typingText.fontSize = backgroundText.fontSize;
		typingText.text = option.GetTyped();
    }
}
