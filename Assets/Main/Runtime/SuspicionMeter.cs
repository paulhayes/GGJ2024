using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SuspicionMeter : MonoBehaviour
{
	public float punchDuration = .2f;
	public float shakeIntensity = 2f;

	private Slider slider;
	private int curSuspicion = 0;

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
			int diff = value - curSuspicion;
			float mult = Mathf.Clamp01(diff * .1f);
			transform.DOPunchPosition(new Vector3(.5f, 1f, .5f) * mult, punchDuration, diff, .5f);
			//transform.DOPunchRotation(new Vector3(0,0,75) * mult, punchDuration, diff, .5f);
			DOTween.Shake(() => transform.rotation.eulerAngles, x =>
			{
				var rotation = transform.rotation;
				rotation.eulerAngles = Vector3.forward * x.x;
				transform.rotation = rotation;
			}, punchDuration, diff * shakeIntensity, 8, 0);
		}
		curSuspicion = value;
    }

    public void SetSuspicion(int value)
	{
		slider.value = value;
	}
}
