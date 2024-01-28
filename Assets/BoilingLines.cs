using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilingLines : MonoBehaviour
{
    [SerializeField] Image[] m_images;
    [SerializeField] int fps;
    int index = 0;
    float m_elapsed;
    void Update(){
        m_elapsed+=Time.deltaTime;
        if(m_elapsed<1f/fps){
            return;
        }
        m_elapsed=0;
        m_images[index++].enabled=false;
        if(index>=m_images.Length){
            index=0;
        }
        m_images[index].enabled=true;
    }

    public Image[] GetImages() => m_images;
}
