using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPokeTypeDisplay : MonoBehaviour
{
    [SerializeField] List<Image> TypeUI = new List<Image>();
    int CounterForTypes = 0;

    private void Awake()
    {
        ResetUI();
    }

    public void AddImage(Sprite sprite)
    {
        TypeUI[CounterForTypes++].sprite = sprite;
    }

    public void ResetUI()
    {
        CounterForTypes = 0;
        foreach (Image item in TypeUI)
        {
            item.sprite = null;
           
        }
    }
}
