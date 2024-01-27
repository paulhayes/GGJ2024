using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform dialoguePoint, choicesPoint;
	public float transitionDuration = 0.2f;

	private Camera cam;

	private void Start()
	{
		StoryParser.Instance.CharacterDialogEvent += _ => MoveCamera(dialoguePoint);
		StoryParser.Instance.ConversationChoice  += () => MoveCamera(choicesPoint);
		cam = Camera.main;
	}

	private void MoveCamera(Transform point)
	{
		cam.transform.DOMove(point.position, transitionDuration);
		cam.transform.DORotate(point.eulerAngles, transitionDuration);
	}
}
