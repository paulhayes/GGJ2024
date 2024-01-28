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
		TypingInput.Instance.OnFinishedTyping += _ => HideTimer();
	}

	private void Update()
	{
		if (!text.gameObject.activeInHierarchy)
			return;

		float time = TypingInput.Instance.TimeLeft;
		float t = 1f - Mathf.Clamp01(time / 15f);

		text.text = time.ToString("F2");
		text.color = Color.Lerp(Color.white, Color.red, t);
		text.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 3.5f, t);
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
