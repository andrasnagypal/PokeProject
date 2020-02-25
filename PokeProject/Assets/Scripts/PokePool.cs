using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PokePool : MonoBehaviour
{
    [SerializeField] int NumberOfPokeShouldBeInPool,IsLessThanThisAmountStartLoadingOtherPokes;
    /*[SerializeField]*/ public List<PokeModel> ListOfPokeModels = new List<PokeModel>();
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
        GetComponent<PokeFactory>().GetPokemon(indexofPoke);

    }
   

    public void AddPoke(PokeModel poke)
    {
        ListOfPokeModels.Add(poke);
    }

}
