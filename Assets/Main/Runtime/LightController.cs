using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject normalLight, partyLight;
    private bool isSurprised = false;

    void Start()
    {
           
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !isSurprised)
        //    Surprise();    
    }

    void Surprise()
    {
		isSurprised = true;
		StartCoroutine(_Surprise());
        IEnumerator _Surprise()
        {
            normalLight.SetActive(true);
			partyLight.SetActive(false);
			yield return new WaitForSeconds(1);
			isSurprised = false;
			normalLight.SetActive(false);
			partyLight.SetActive(true);
		}
	}
}