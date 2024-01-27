using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform dialoguePoint, choicesPoint;
	private Transform target;

	private void Start()
	{
		var story = FindObjectOfType<StoryParser>(); //fuckit

		story.CharacterDialogEvent += _ => MoveCamera(dialoguePoint);
		story.ConversationChoice += ()  => MoveCamera(choicesPoint);
	}

	private void Update()
	{
	}

	private void MoveCamera(Transform point)
	{
		target = point;
	}
}
