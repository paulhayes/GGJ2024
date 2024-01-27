using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SuspicionMeter : MonoBehaviour
{
	private Slider slider;

	private void Awake()
	{
		slider = GetComponent<Slider>();
	}

	public void SetSuspicion(int value)
	{
		slider.value = value;
	}
}
