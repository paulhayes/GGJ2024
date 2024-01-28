using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTransition : MonoBehaviour
{
    [SerializeField] Transform m_outPosition;
    [SerializeField] Transform m_inPosition;

    [SerializeField] float m_duration;

    [SerializeField] Transform[] m_characters;

    [SerializeField] AnimationCurve m_animCurveIn;
    [SerializeField] AnimationCurve m_animCurveOut;

    Transform currentCharactrer;
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
        if(currentCharactrer){
            Transition(m_inPosition,m_outPosition,character,m_duration,m_animCurveOut);
            currentCharactrer.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(8f);

        character.gameObject.SetActive(true);
        yield return Transition(m_outPosition,m_inPosition,character,m_duration,m_animCurveIn);
        currentCharactrer = character;
        characterData.complete = true;
    }

    IEnumerator Transition(Transform startTransform, Transform endTransform, Transform target, float duration, AnimationCurve animCurve)
    {
        float elapsed = 0;
        while(elapsed<1){
            yield return null;
            elapsed+=Time.deltaTime/duration;
            if(elapsed>1){
                elapsed=1;
            }
            Debug.Log(elapsed);
            target.position = Vector3.Lerp(startTransform.position,endTransform.position,animCurve.Evaluate(elapsed));
            target.rotation = Quaternion.Lerp(startTransform.rotation,endTransform.rotation,animCurve.Evaluate(elapsed));

        }
    }

}
