using System.Collections;
using UnityEngine;

public class CharacterTransition : MonoBehaviour
{
    [SerializeField] Transform m_outPosition;
    [SerializeField] Transform m_inPosition;

    [SerializeField] float m_transitionInDuration = 1.2f;
    [SerializeField] float m_transitionOutDuration = 2.4f;
    [SerializeField] float m_waitDuration = 8f;

    [SerializeField] Transform[] m_characters;

    [SerializeField] AnimationCurve m_animCurveIn;
    [SerializeField] AnimationCurve m_animCurveOut;

    Transform m_currentCharactrer = null;
    void Start()
    {
        foreach(var character in m_characters){
            character.gameObject.SetActive(false);
        }
        StoryParser.Instance.CharacterChangeEvent += OnChange;
    }

    private void OnChange(CharacterTransitionData characterData)
    {
        StartCoroutine( CharacterAppear( m_characters[characterData.characterIndex],characterData ) );
    }

    
    IEnumerator CharacterAppear(Transform character,CharacterTransitionData characterData)
    {
        if(m_currentCharactrer){
            yield return Transition(m_inPosition,m_outPosition,m_currentCharactrer,m_transitionOutDuration,m_animCurveOut);
            m_currentCharactrer.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(m_waitDuration);

        character.gameObject.SetActive(true);
        yield return Transition(m_outPosition,m_inPosition,character,m_transitionInDuration,m_animCurveIn);
        m_currentCharactrer = character;
        characterData.complete = true;
    }

    IEnumerator Transition(Transform startTransform, Transform endTransform, Transform target, float duration, AnimationCurve animCurve)
    {
        float elapsed = 0;
        target.position = startTransform.position;
        while(elapsed<1){
            yield return null;
            elapsed+=Time.deltaTime/duration;
            if(elapsed>1){
                elapsed=1;
            }
            //Debug.Log(elapsed);
            target.position = Vector3.LerpUnclamped(startTransform.position,endTransform.position,animCurve.Evaluate(elapsed));
            target.rotation = Quaternion.Lerp(startTransform.rotation,endTransform.rotation,animCurve.Evaluate(elapsed));

        }
    }

}
