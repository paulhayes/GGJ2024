using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingUI : MonoBehaviour
{
	public OptionUI optionPrefab;
	public OptionBubble bubblePrefab;
	
	public List<OptionUI> options;
	public RectTransform[] points;

	private void Start()
	{
		optionPrefab.gameObject.SetActive(false);
		bubblePrefab.gameObject.SetActive(false);
		TypingInput.Instance.OnStartTyping += ShowOptions;
		TypingInput.Instance.OnFinishedTyping += FinishTyping;
	}

	private void FinishTyping(int i)
	{
		if (i < 0)
		{
			HideOptions();
			return;
		}

		// Spawn bubble
		var bubble = Instantiate(bubblePrefab, transform);
		bubble.gameObject.SetActive(true);
		bubble.transform.position = points[i].position;
		bubble.Setup(options[i].option.phrase, i == 1 || i == 4);

		HideOptions();
	}

	private void ShowOptions(Option[] optionData)
	{
		for (int i = 0; i < optionData.Length; i++)
		{
			var data = optionData[i];
			var option = GetOptionUI(i);
			option.SetOption(data);
		}
	}

	private void HideOptions()
	{
		foreach (var option in options)
		{
			option.gameObject.SetActive(false);
		}
	}

	public OptionUI GetOptionUI(int i)
	{
		while (i >= options.Count) 
		{
			var newOption = Instantiate(optionPrefab, transform);
			newOption.gameObject.SetActive(true);
			options.Add(newOption);
		}

		var option = options[i];
		option.gameObject.SetActive(true);
		option.transform.position = points[i].position;
		return option;
	}
}
