using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingUI : MonoBehaviour
{
	public OptionUI optionPrefab;
	
	public List<OptionUI> options;
	public RectTransform[] points;

	private void Start()
	{
		TypingInput.Instance.OnStartTyping += ShowOptions;
		TypingInput.Instance.OnTimeout += HideOptions;
		TypingInput.Instance.OnSuccessfullyTypedWord += _ => HideOptions();
	}

	public void ShowOptions(Option[] optionData)
	{
		for (int i = 0; i < optionData.Length; i++)
		{
			var data = optionData[i];
			var option = GetOptionUI(i);
			option.SetOption(data);
		}
	}

	public void HideOptions()
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
			options.Add(newOption);
		}

		var option = options[i];
		option.gameObject.SetActive(true);
		option.transform.position = points[i].position;
		return option;
	}
}
