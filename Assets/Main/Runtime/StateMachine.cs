using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] State[] m_states;
    [SerializeField] State m_startState;

    StateTransition m_transitionController;

    Coroutine m_currentTransition;
    void Awake()
    {
        m_transitionController = GetComponent<StateTransition>();
        foreach(var state in m_states){
            state.RequestStateChange += ChangeState;
            state.gameObject.SetActive(false);
        }


    }

    void Start()
    {
        ChangeState(m_startState);
    }

    public void ChangeState(string name)
    {
        foreach(var state in m_states){
            if(name==state.name){
                ChangeState(state);
                return;
            }
        }
        Debug.LogWarning($"Conversation state not found {name}");
    }

    public void ChangeState(State state){
        Debug.Log($"Changing to state {state.name}");
        if(m_currentTransition!=null){
            return;
        }
        m_currentTransition=StartCoroutine(ChangeStateRoutine(state));
    }

    public IEnumerator ChangeStateRoutine(State selectedState)
    {
        var transitionPhases= m_transitionController.Transition();
        transitionPhases.MoveNext();
        foreach(var state in m_states){
            if(state==selectedState){
                continue;
            }
            state.gameObject.SetActive(false);
        }
        selectedState.gameObject.SetActive(selectedState);
        transitionPhases.MoveNext();
        yield return transitionPhases;
        m_currentTransition=null;
    }
}
