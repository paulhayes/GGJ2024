using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StoryParser : MonoBehaviour
{
    [SerializeField] TextAsset m_text;

    Story m_story;

    public void Start()
    {
        m_story = new Story( m_text.text );
        StartCoroutine(Main());
    }

    IEnumerator Main()
    {
        while(enabled){
            yield return Next();
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator Next(){
        
        while (m_story.canContinue) {
            Debug.Log (m_story.Continue ());
        }

        if( m_story.currentChoices.Count > 0 )
        {
            for (int i = 0; i < m_story.currentChoices.Count; ++i) {
                Choice choice = m_story.currentChoices [i];
                Debug.Log("Choice " + (i + 1) + ". " + choice.text);
            }
        }

        int choiceIndex = -1;
        while( choiceIndex==-1 ){
            yield return null;
            if(Input.anyKeyDown && Input.inputString.Length>0){
                int.TryParse( Input.inputString, out choiceIndex );                
            }
        }
        m_story.ChooseChoiceIndex(choiceIndex-1);
    }
}
