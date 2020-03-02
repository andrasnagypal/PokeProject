using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPokeUI : MonoBehaviour
{
    RawImage TheImage;
    void Awake()
    {
        TheImage = GetComponent<RawImage>();
        
    }

    public void AddImage(Texture2D sprite)
    {
        TheImage.texture = sprite;
    }
}
