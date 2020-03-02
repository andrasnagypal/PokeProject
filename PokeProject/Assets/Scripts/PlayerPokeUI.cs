using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPokeUI : MonoBehaviour
{
    RawImage TheImage;
    [SerializeField] TextMeshProUGUI NameOfThePoke;
    [SerializeField] TextMeshProUGUI AttackDisplay;
    void Awake()
    {
        TheImage = GetComponent<RawImage>();
        
    }

    public void AddImage(Texture2D sprite)
    {
        TheImage.texture = sprite;
    }

    public void NameThePokeDisplay(string thename)
    {
        NameOfThePoke.text = thename;
    }

    public void UpdateAttackDisplay(int number)
    {
        AttackDisplay.text = number.ToString();
    }
}
