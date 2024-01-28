using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	public float talkHeight;
	public float talkDuration;
	private Vector3 origPos;
	private Vector3 origLocalPos;

	private void Start()
	{
		origPos = transform.position;
		origLocalPos = transform.localPosition;

		TypingInput.Instance.OnType += Instance_OnType;
		TypingInput.Instance.OnMistype += Instance_OnMistype;
	}

	private void Instance_OnType()
	{
		transform.DOKill();
		transform.position = origPos;
		transform.DOPunchPosition(Vector3.up * talkHeight, talkDuration);
	}

	private void Instance_OnMistype()
	{
		//transform.DOKill();
		//transform.position = origPos;
		//transform.DOShakePosition(talkDuration);
	}
}
