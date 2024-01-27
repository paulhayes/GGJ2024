using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SuspicionMeter : MonoBehaviour
{
	private Slider slider;


	private void Awake()
	{
		slider = GetComponent<Slider>();
		SetSuspicion(0);
	}

	void Start()
	{
		StoryParser.Instance.SuspicionChangeEvent += OnSuspicionChanges;
	}

    private void OnSuspicionChanges(int value)
    {
        SetSuspicion(value);
    }

    public void SetSuspicion(int value)
	{
		slider.value = value;
	}
}
