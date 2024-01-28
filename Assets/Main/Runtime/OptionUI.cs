using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class OptionUI : MonoBehaviour
{
	public TextMeshProUGUI typingText;
	public TextMeshProUGUI backgroundText;

	public Option option;
	private Image panel;
	private BoilingLines bl;
	private Image[] panels;

	private void Awake()
	{
		panel = GetComponentInChildren<Image>();
		bl = GetComponent<BoilingLines>();
	}

	private void Start()
	{
		panels = bl.GetImages();
	}

	public void SetOption(Option option)
	{
		this.option = option;

		typingText.text = "";
		backgroundText.text = option.phrase;

		float x = Random.Range(0f, 30f);
		float y = Random.Range(0f, 30f);

		transform.DOMoveX(transform.position.x + 30f-x, Random.Range(3f, 5f))
				 .SetEase(Ease.InOutQuart)
				 .SetLoops(-1, LoopType.Yoyo);

		transform.DOMoveY(transform.position.y + 30f - y, Random.Range(3f, 5f))
				 .SetEase(Ease.InOutQuart)
				 .SetLoops(-1, LoopType.Yoyo);
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

		foreach (var p in panels)
		{
			p.color = panel.color;
		}
	}
}
