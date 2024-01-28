using System.Collections;
using UnityEngine;
using Ink.Runtime;
using System;
using System.Linq;

public class StoryParser : MonoBehaviour
{
    public event Action<CharacterTransitionData> CharacterChangeEvent;
    public event Action<DialogSnippet> CharacterDialogEvent;
    public event Action ConversationChoice;

    public event Action<int> SuspicionChangeEvent;

    
    [SerializeField] TextAsset m_text;
    

    Story m_story;

    CharacterTransitionData m_characterChangeData = null;

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
            m_characterChangeData = new CharacterTransitionData((int)val);
            CharacterChangeEvent?.Invoke(m_characterChangeData);
        });
        
        #if UNITY_EDITOR
        // InkPlayerWindow window = InkPlayerWindow.GetWindow(true);
        // if(window != null) InkPlayerWindow.Attach(m_story);
        #endif

        yield return null;
        StartCoroutine(ContinueRoutine());
    }

    IEnumerator ContinueRoutine(CharacterTransitionData characterTransitionData=null)
    {
        
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

        ConversationChoice?.Invoke();
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
        
        while( !choiceIndex.HasValue ){
            yield return null;
        }

        TypingInput.Instance.OnFinishedTyping -= onFinishedTyping;

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
