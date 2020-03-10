using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum TypesOfPoke
{

}

public class TypeCounter : MonoBehaviour, IPointerEnterHandler
{
    public List<Sprite> ListOfTypeImages = new List<Sprite>();
    public string[] TypesOfPoke = new string[]
    {
        "psychic",
        "fairy",
        "water",
        "poison",
        "bug",
        "fighting",
        "grass",
        "fire",
        "ice",
        "dragon",
        "ghost",
        "electric",
        "flying",
        "ground",
        "dark",
        "steel",
        "normal",
        "rock"
    },
        
        DamageRelationNames=new string[] {
    "no_damage_to",
    "half_damage_to",
    "double_damage_to",
    "no_damage_from",
    "half_damage_from",
    "double_damage_from"};
    Dictionary<string, int> TypeCounterDict = new Dictionary<string, int>();

    public void AddToCounter(string poketype)
    {
        if (TypeCounterDict.ContainsKey(poketype))
            TypeCounterDict[poketype]++;
        else
        {
            TypeCounterDict.Add(poketype, 1);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void WriteOutTypes()
    {
        foreach (var item in TypeCounterDict)
        {
            Debug.Log("Key: " + item.Key + " value: " + item.Value);
        }
    }
    public int GetIndexOfType(string type)
    {
        return TypeCounterDict[type];
    }
    public string GetNameOfTpye(int type)
    {
        return TypesOfPoke[type];
    }

    public Sprite GetSpriteForType(string typename)
    {
        Sprite temp=null;
        for (int i = 0; i < TypesOfPoke.Length; i++)
        {
            if(TypesOfPoke[i]==typename)
            {
                temp = ListOfTypeImages[i];
                break;
            }
        }

        return temp;
    }
}
