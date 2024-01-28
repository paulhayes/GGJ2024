using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public Vector3 punch = Vector3.up;
    public float duration = .3f;
    public int vibrato = 0;
    public float elasticity = .1f;

    private Vector3 origPos;

	private IEnumerator Start()
	{
		SurpriseController.Instance.OnSurprised += Surprise;
		SurpriseController.Instance.OnOverIt    += Jump;

		origPos = transform.position;
        float secs = Random.Range(0f, duration);
	
        yield return new WaitForSeconds(secs);
        Jump();
	}

	void Jump()
	{
		float secs = Random.Range(0f, duration * 2f);
        float jump = Random.Range(0.3f, 1f);

        transform.DOPunchPosition(punch * jump, duration * jump, vibrato, elasticity)
            .OnComplete(() => Jump())
            .SetEase(Ease.InBounce)
            .SetDelay(secs);
    }

    void Surprise()
    {
        transform.DOKill();
        transform.position = origPos;
    }
}
