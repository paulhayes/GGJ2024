using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
    public IEnumerator Transition()
    {
        //start transition
        yield return new WaitForSeconds(1);
        Debug.Log("Midtransition");
        yield return new WaitForSeconds(1);
        //end transition
    }
}
