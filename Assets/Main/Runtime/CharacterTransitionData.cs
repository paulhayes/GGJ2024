using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterTransitionData 
{
    public CharacterTransitionData(int index)
    {
        characterIndex = index;
    }


    public int characterIndex;
    public bool complete = false;
}
