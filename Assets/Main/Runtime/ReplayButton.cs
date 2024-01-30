using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OptionUI))]
public class ReplayButton : MonoBehaviour
{
	public State myState;
	private OptionUI optionUI;
	private Option option;

	private void Awake()
	{
		optionUI = GetComponent<OptionUI>();
		option = new Option("Replay?");
	}

	private void Start()
	{
		optionUI.SetOption(option);
		StartCoroutine(TypingInput.Instance.TypePhrasesCoroutine(new[] { option }));
		option.OnIncremented += Replay;
	}

	private void Replay()
	{
		if (!option.IsFinished())
			return;
		if (!gameObject.activeInHierarchy)
			return;

		print("Replay");
		TypingInput.Instance.StopAllCoroutines();
		myState.Reload();
	}
}
