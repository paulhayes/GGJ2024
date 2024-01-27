using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SuspicionMeter : MonoBehaviour
{
	public float shakeDuration = .2f;
	public float shakeIntensity = 90;

	private Slider slider;
	private float curSuspicion = 0;

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

		if (value > curSuspicion)
		{
			float diff = value - curSuspicion;
			transform.DOShakeRotation(shakeDuration, shakeIntensity * diff);
			print($"shake: {shakeIntensity * diff}");
		}
		curSuspicion = value;
    }

    public void SetSuspicion(int value)
	{
		slider.value = value;
	}
}
