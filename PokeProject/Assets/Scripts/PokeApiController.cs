using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class PokeApiController : MonoBehaviour
{
    
    readonly string basePokeURL = "https://pokeapi.co/api/v2/";
    int StartIndex = 1, EndIndex = 808,CurrentIndex;
    JSONNode pokeInfo;
    string pokeTextureURL;
    void Start()
    {
        CurrentIndex = StartIndex;
        // StartCoroutine(FillUpList());
        //for (int i = StartIndex; i < EndIndex; i++)
        //{
        //    StartCoroutine(GetPokemAtIndex(i));
        //}
        //StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        

    }

    IEnumerator FillUpList()
    {
        for (int i = StartIndex; i < EndIndex; i++)
        {
            yield return new WaitForSeconds(.01f);
            StartCoroutine(GetPokemAtIndex(i));
        }
    }

    public void GetPokemon(int indexofPoke)
    {
        StartCoroutine(GetPokemAtIndex(indexofPoke));
       
    }

    IEnumerator GetPokemAtIndex(int pokemonIndex )
    {
        string pokemonURL = basePokeURL + "pokemon/" + pokemonIndex.ToString();
       
        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);
        
        yield return pokeInfoRequest.SendWebRequest();
       
        if (pokeInfoRequest.isNetworkError||pokeInfoRequest.isHttpError)
        {
            Debug.LogError(pokeInfoRequest.error);
            yield break;
        }
       
         pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);
       
        PokemonDataModel.ListOfPokemons.Add(pokemonIndex, pokeInfo);
        //Debug.Log("Pokes: "+PokemonDataModel.ListOfPokemons.Count);
        //Debug.Log("Index : "+CurrentIndex);
        //if (CurrentIndex < EndIndex)
        //    StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        //else
        //    Debug.Log(PokemonDataModel.ListOfPokemons.Count);
    }
    public void GetPokemonTexture(JSONNode pokenode, RawImage PokeImage)
    {
        StartCoroutine(GetPokemTexture(pokenode, PokeImage));
    }
    IEnumerator GetPokemTexture(JSONNode pokenode, RawImage PokeImage)
    {
        pokeTextureURL = pokenode["sprites"]["front_default"];

        UnityWebRequest SpriteRequest = UnityWebRequestTexture.GetTexture(pokeTextureURL);

        yield return SpriteRequest.SendWebRequest();

        if (SpriteRequest.isNetworkError || SpriteRequest.isHttpError)
        {
            Debug.LogError(SpriteRequest.error);
            yield break;
        }

        PokeImage.texture = DownloadHandlerTexture.GetContent(SpriteRequest);
        PokeImage.texture.filterMode = FilterMode.Point;
        //Debug.Log("Pokes: "+PokemonDataModel.ListOfPokemons.Count);
        //Debug.Log("Index : "+CurrentIndex);
        //if (CurrentIndex < EndIndex)
        //    StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        //else
        //    Debug.Log(PokemonDataModel.ListOfPokemons.Count);
    }

}
