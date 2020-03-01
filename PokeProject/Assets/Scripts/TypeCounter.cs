using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypesOfPoke
{

}

public class TypeCounter : MonoBehaviour
{

    public string[] TypesOfPoke;
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

    public void WriteOutTypes()
    {
        foreach (var item in TypeCounterDict)
        {
            Debug.Log("Key: " + item.Key + " value: " + item.Value);
        }
    }
    
}
