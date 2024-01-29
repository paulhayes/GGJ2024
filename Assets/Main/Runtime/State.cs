using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class State : MonoBehaviour
{
    public event Action<string> RequestStateChange;
    public void ChangeState(string name)
    {        
        RequestStateChange?.Invoke(name);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
