using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDialogDisplay : MonoBehaviour
{
    void Start()
    {
        StoryParser.Instance.CharacterDialogEvent += (snippet)=>StartCoroutine( OnDialog(snippet) );
    }

    private IEnumerator OnDialog(DialogSnippet snippet)
    {
        Debug.Log(snippet);
        yield return new WaitForSeconds(2);
        snippet.complete = true;
    }
}
