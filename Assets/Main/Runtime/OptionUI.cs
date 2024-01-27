using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
	public TextMeshProUGUI typingText;
	public TextMeshProUGUI backgroundText;
	
	private Option option;
	private Image panel;

	private void Awake()
	{
		panel = GetComponentInChildren<Image>();
	}

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

		float pct = option.CompletionPct;
		float opacity = Mathf.Lerp(.5f, 1f, pct);
		float scale = Mathf.Lerp(1, 1.3f, pct);

		transform.localScale = Vector3.one * scale;
		panel.color = new Color(1,1,1,opacity);
	}
}
