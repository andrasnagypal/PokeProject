using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TypesOfPoke
{

}

public class TypeCounter : MonoBehaviour, IPointerEnterHandler
{

    public string[] TypesOfPoke,DamageRelationNames=new string[] {
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
}
