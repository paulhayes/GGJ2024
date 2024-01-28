using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightAnimator : MonoBehaviour
{
	public Color[] colors;
	public float timeToSwitchColor = 5;
	public float rotSpeed = 20;

	private float timer = 0f;
	private Light light;

	private void Start()
	{
		light = GetComponent<Light>();

		float timeOffset = timeToSwitchColor * .1f;
		float rotOffset = rotSpeed * .2f;

		timeToSwitchColor += Random.Range(-timeOffset, timeOffset);
		rotSpeed += Random.Range(-rotOffset, rotOffset);
	}

	private void Update()
	{
		transform.RotateAround(transform.position, Vector3.up, rotSpeed * Time.deltaTime);

		timer += Time.deltaTime;
		if (timer > timeToSwitchColor)
		{
			timer = 0f;
			SwitchColor();
		}
	}

	private void SwitchColor()
	{
		var color = colors[Random.Range(0, colors.Length - 1)];
		light.color = color;
	}
}
