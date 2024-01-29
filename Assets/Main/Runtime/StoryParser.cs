using System.Collections;
using UnityEngine;
using Ink.Runtime;
using System;
using System.Linq;
#if UNITY_EDITOR
using Ink.UnityIntegration;
#endif

public class StoryParser : Singleton<StoryParser>
{
    public const string SUS_KEY = "suspicion";
    public event Action<CharacterTransitionData> CharacterChangeEvent;
    public event Action<DialogSnippet> CharacterDialogEvent;
    public event Action ConversationChoice;
	public event Action<int> SuspicionChangeEvent;
	public event Action<int> SuspicionAdjustEvent;

	private int curSus = 0;
	[SerializeField] TextAsset m_text;

    Story m_story;

    CharacterTransitionData m_characterChangeData = null;

    void OnEnable()
    {
        m_characterChangeData = null;
        curSus = 0;
        m_story = new Story( m_text.text );

        StartCoroutine(ContinueRoutine());
    }

    public void Start()
    {        
        m_story.ObserveVariable(SUS_KEY,OnSuspicionChanged);
        m_story.ObserveVariable("character",(varName,val)=>{
            Debug.Log($"{varName} changed to {val}");
            m_characterChangeData = new CharacterTransitionData((int)val);
            CharacterChangeEvent?.Invoke(m_characterChangeData);
        });
        
        #if UNITY_EDITOR
        InkPlayerWindow window = InkPlayerWindow.GetWindow(true);
        if(window != null) InkPlayerWindow.Attach(m_story);
        #endif
        
    }

    void OnDisable()
    {
        m_characterChangeData = null;
        curSus = 0;
        m_story = null;
    }

    private void OnSuspicionChanged(string varName, object val)
    {        
        int sus = (int)val;
        int adj = sus-curSus;
        Debug.Log($"{varName} changed to {val} (adj of {adj})");
        
        SuspicionChangeEvent?.Invoke(sus);
        SuspicionAdjustEvent?.Invoke(adj);

        if (sus >= 100) {
            m_story.RemoveVariableObserver(OnSuspicionChanged,SUS_KEY);
            m_story.ChoosePathString("fail");
        }
        
        curSus = sus;
        
    }


    IEnumerator ContinueRoutine(CharacterTransitionData characterTransitionData=null)
    {
        yield return null;
        while(enabled){
            yield return Next();
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator Next(){
        while (m_story.canContinue) {
            Debug.Log (m_story.Continue());
            while(m_characterChangeData !=null && !m_characterChangeData.complete){
                yield return null;
            }
            yield return ShowCurrentText();
        }

        Debug.Log($"CHOICES:{m_story.currentChoices.Count}");
        if(m_story.currentChoices.Count==0){

            GetComponent<State>().ChangeState(GetSuspicion()>=100 ? "FailState" : "WinState");
            yield break;
        }

        ConversationChoice?.Invoke();

		var phrases = m_story.currentChoices.Select<Choice,string>( (choice)=>choice.text.Trim() ).ToArray();
        int? choiceIndex=null;
        Action<int> onFinishedTyping = (index)=>{
            choiceIndex=index;
            if(choiceIndex==-1){
                choiceIndex=phrases.Length-1;
            }
        };
        TypingInput.Instance.OnFinishedTyping += onFinishedTyping;
        TypingInput.Instance.OnMistype += OnMistype;
        TypingInput.Instance.TypePhrases(phrases);

        if( m_story.currentChoices.Count > 0 )
        {
            for (int i = 0; i < m_story.currentChoices.Count; ++i) {
                Choice choice = m_story.currentChoices [i];
                Debug.Log("Choice " + (i + 1) + ". " + choice.text);
            }
        }
        
        while( !choiceIndex.HasValue ){
            yield return null;
        }

        TypingInput.Instance.OnFinishedTyping -= onFinishedTyping;
        TypingInput.Instance.OnMistype -= OnMistype;
        Debug.Log($"user choice is {choiceIndex.Value}");

        //we must have jumped ( fail condition )
        if(m_story.canContinue){
            m_story.Continue();
            yield return ShowCurrentText();
            yield break;
        }
        m_story.ChooseChoiceIndex(choiceIndex.Value);
        m_story.Continue();
    }

    private void OnMistype()
    {
        print("TYPO!");
        //m_story.variablesState["suspicion"] = (int)m_story.variablesState["suspicion"]+2;
        SetSuspicion( GetSuspicion()+2 );
    }

    public int GetSuspicion()
    {
        return (int)m_story.variablesState[SUS_KEY];
    }

    public void SetSuspicion(int value)
    {
        m_story.variablesState[SUS_KEY] = value;
    }


    public IEnumerator ShowCurrentText()
    {
        var shownSnippet = new DialogSnippet(m_story.currentText); 
        CharacterDialogEvent?.Invoke(shownSnippet);
        while(!shownSnippet.complete){
            yield return null;
        }
    }
}
