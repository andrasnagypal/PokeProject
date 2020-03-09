using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPokeUI : MonoBehaviour
{
    [SerializeField] RawImage TheImage;
    [SerializeField] TextMeshProUGUI NameOfThePoke;
    [SerializeField] TextMeshProUGUI AttackDisplay;
   

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
