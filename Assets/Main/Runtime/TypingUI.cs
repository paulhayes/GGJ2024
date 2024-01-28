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
			SpawnBubble(points[0], "...");
		else
			SpawnBubble(i);

		HideOptions();
	}

	private void SpawnBubble(int i)
	{
		SpawnBubble(points[i], options[i].option.phrase, i == 1 || i == 4);
	}

	private void SpawnBubble(Transform point, string phrase, bool flip = false)
	{
		var bubble = Instantiate(bubblePrefab, transform);
		bubble.gameObject.SetActive(true);
		bubble.transform.position = point.position;
		bubble.Setup(phrase, flip);
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
