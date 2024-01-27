using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using Ink.UnityIntegration;
using System;
using System.Linq;

public class StoryParser : MonoBehaviour
{
    
    public event Action<int> CharacterChangeEvent;
    public event Action<DialogSnippet> CharacterDialogEvent;

    public event Action<int> SuspicionChangeEvent;

    
    [SerializeField] TextAsset m_text;
    

    Story m_story;

    bool m_characterChanged = false;

    public static StoryParser Instance {
        private set;
        get;
    }

    void Awake()
    {
        Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    public IEnumerator Start()
    {
        m_story = new Story( m_text.text );
        m_story.ObserveVariable("suspicion",(varName,val)=>{
            Debug.Log($"{varName} changed to {val}");
            SuspicionChangeEvent?.Invoke((int)val);
        });
        m_story.ObserveVariable("character",(varName,val)=>{
            Debug.Log($"{varName} changed to {val}");
            CharacterChangeEvent?.Invoke((int)val);
            StartCoroutine(ContinueRoutine());
        });
        
        

        #if UNITY_EDITOR
        InkPlayerWindow window = InkPlayerWindow.GetWindow(true);
        if(window != null) InkPlayerWindow.Attach(m_story);
        #endif

        yield return null;
        StartCoroutine(ContinueRoutine());
    }

    private void OnFinishedTyping(int idx)
    {
        print("INDEX TYPED: "+idx);
    }

    IEnumerator ContinueRoutine()
    {
        while(!m_characterChanged){
            yield return Next();
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator Next(){
        

        while (m_story.canContinue) {
            Debug.Log (m_story.Continue());
            yield return ShowCurrentText();
        }

        var phrases = m_story.currentChoices.Select<Choice,string>( (choice)=>choice.text.Trim() ).ToArray();
        TypingInput.Instance.TypePhrases(phrases);
        int? choiceIndex=null;
        Action<int> onFinishedTyping = (index)=>{
            choiceIndex=index;

            if(choiceIndex==-1){
                choiceIndex=phrases.Length-1;
            }
        };
        TypingInput.Instance.OnFinishedTyping += onFinishedTyping;
        if( m_story.currentChoices.Count > 0 )
        {
            for (int i = 0; i < m_story.currentChoices.Count; ++i) {
                Choice choice = m_story.currentChoices [i];
                Debug.Log("Choice " + (i + 1) + ". " + choice.text);
            }
        }
        TypingInput.Instance.OnFinishedTyping -= onFinishedTyping;

        
        while( !choiceIndex.HasValue ){
            yield return null;
        }
        Debug.Log($"user choice is {choiceIndex.Value}");
        m_story.ChooseChoiceIndex(choiceIndex.Value);
        m_story.Continue();
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
