using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
	public TextMeshProUGUI text;

	private void Start()
	{
		TypingInput.Instance.OnStartTyping += _ => ShowTimer();
		TypingInput.Instance.OnSuccessfullyTypedWord += _ => HideTimer();
		TypingInput.Instance.OnTimeout += HideTimer;
	}

	private void Update()
	{
		text.text = TypingInput.Instance.TimeLeft.ToString("F2");
	}

	public void ShowTimer()
	{
		text.gameObject.SetActive(true);
	}

	public void HideTimer()
	{
		text.gameObject.SetActive(false);
	}
}
