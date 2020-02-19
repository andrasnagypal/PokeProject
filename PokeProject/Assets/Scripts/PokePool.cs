using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PokePool : MonoBehaviour
{
    [SerializeField] int NumberOfPokeShouldBeInPool,IsLessThanThisAmountStartLoadingOtherPokes;
    [SerializeField] List<PokeModel> ListOfPokeModels = new List<PokeModel>();
    [SerializeField] string basePokeURL= "https://pokeapi.co/api/v2/";
    int StartIndexForPokeAPI = 1, EndIndexIndexForPokeAPI = 808;
    private void Awake()
    {
        FindObjectOfType<LoadingBarUI>().MaxAmountOfLoadingTicks = NumberOfPokeShouldBeInPool;
    }
    private void Start()
    {
        if (ListOfPokeModels.Count< IsLessThanThisAmountStartLoadingOtherPokes)
        {
            StartPoolingPokes();
        }
    }


    public void StartPoolingPokes()
    {
        for (int i = ListOfPokeModels.Count; i < NumberOfPokeShouldBeInPool; i++)
        {
            int rnd = Random.Range(StartIndexForPokeAPI, EndIndexIndexForPokeAPI);
            GetPokemon(rnd);
        }
    }

    public void GetPokemon(int indexofPoke)
    {
        StartCoroutine(GetPokemAtIndex(indexofPoke));

    }
    IEnumerator GetPokemAtIndex(int pokemonIndex)
    {
        string pokemonURL = basePokeURL + "pokemon/" + pokemonIndex.ToString();

        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);

        yield return pokeInfoRequest.SendWebRequest();

        if (pokeInfoRequest.isNetworkError || pokeInfoRequest.isHttpError)
        {
            Debug.LogError(pokeInfoRequest.error);
            yield break;
        }

        JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);
        FindObjectOfType<LoadingBarUI>().UpdateLoadingBarUI();
        //PokemonDataModel.ListOfPokemons.Add(pokemonIndex, pokeInfo);
        //Debug.Log("Pokes: "+PokemonDataModel.ListOfPokemons.Count);
        //Debug.Log("Index : "+CurrentIndex);
        //if (CurrentIndex < EndIndex)
        //    StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        //else
        //    Debug.Log(PokemonDataModel.ListOfPokemons.Count);
    }
}
