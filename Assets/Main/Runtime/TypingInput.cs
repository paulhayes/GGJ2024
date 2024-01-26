using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingInput : MonoBehaviour
{

    public void TypeWords(string[] phrases)
    {
        StartCoroutine(TypeWordsCoroutine(phrases));
    }

    IEnumerator TypeWordsCoroutine(string[] phrases)
    {
        yield break;
    }
}
