using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using System;

public class PokeApiController : MonoBehaviour
{
    
    readonly string basePokeURL = "https://pokeapi.co/api/v2/";
    int StartIndex = 1, EndIndex = 808,CurrentIndex;
    void Start()
    {
        CurrentIndex = StartIndex;
        // StartCoroutine(FillUpList());
        //for (int i = StartIndex; i < EndIndex; i++)
        //{
        //    StartCoroutine(GetPokemAtIndex(i));
        //}
        StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        

    }

    IEnumerator FillUpList()
    {
        for (int i = StartIndex; i < EndIndex; i++)
        {
            yield return new WaitForSeconds(.01f);
            StartCoroutine(GetPokemAtIndex(i));
        }
    }

    IEnumerator GetPokemAtIndex(int pokemonIndex)
    {
        string pokemonURL = basePokeURL + "pokemon/" + pokemonIndex.ToString();
       
        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);
        
        yield return pokeInfoRequest.SendWebRequest();
       
        if (pokeInfoRequest.isNetworkError||pokeInfoRequest.isHttpError)
        {
            Debug.LogError(pokeInfoRequest.error);
            yield break;
        }
       
        JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);
       
        PokemonDataModel.ListOfPokemons.Add(pokemonIndex, pokeInfo);
        //Debug.Log("Pokes: "+PokemonDataModel.ListOfPokemons.Count);
        //Debug.Log("Index : "+CurrentIndex);
        //if (CurrentIndex < EndIndex)
        //    StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        //else
        //    Debug.Log(PokemonDataModel.ListOfPokemons.Count);
    }
   
}
