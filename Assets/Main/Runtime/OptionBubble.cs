using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionBubble : MonoBehaviour
{
	public TextMeshProUGUI text;
	public RectTransform panel;

	public void Setup(string phrase, bool flip = false)
	{
		text.text = phrase;
		panel.localScale = new Vector3(flip?1:-1, 1,1);
		transform.DOPunchScale(Vector3.one*1.1f, .3f);
		Destroy(gameObject, .65f);
	}
}