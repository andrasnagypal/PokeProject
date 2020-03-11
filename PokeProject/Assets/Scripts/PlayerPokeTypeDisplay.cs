using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPokeTypeDisplay : MonoBehaviour
{
    [SerializeField] List<Image> TypeUI = new List<Image>();
    int CounterForTypes = 0;
    string[] TypesForThisPoke;
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
            item.gameObject.SetActive(false);
           
        }
    }
    public void SetTypesAndUI(string[] types)
    {
        ResetUI();
        TypesForThisPoke = types;
        for (int i = 0; i < TypesForThisPoke.Length; i++)
        {
           Sprite temp= FindObjectOfType<TypeCounter>().GetSpriteForType(TypesForThisPoke[i]);
            SetTypeUIIcon(temp);
        }
        
    }

   public void SetTypeUIIcon(Sprite sprite)
    {
        TypeUI[CounterForTypes].gameObject.SetActive(true);
        TypeUI[CounterForTypes++].sprite = sprite;
    }
    public Sprite[] GetAbilitySprites()
    {
        Sprite[] temp = new Sprite[TypesForThisPoke.Length];
        for (int i = 0; i < TypesForThisPoke.Length; i++)
        {
            temp[i]= FindObjectOfType<TypeCounter>().GetSpriteForType(TypesForThisPoke[i]);
        }
            return temp;
    }
}
