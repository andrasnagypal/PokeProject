using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;
public class PlayerPokeController : MonoBehaviour
{
    public GameObject PlayerPokeView;
    public RawImage RawImageOfPokemon;
    JSONNode PlayerPokeData;

    private void Awake()
    {
        GetComponent<PokeApiController>().GetPokemon(25);
    }

    private void Start()
    {
        if (PokemonDataModel.ListOfPokemons.Count>0)
        {
            PlayerPokeData = PokemonDataModel.ListOfPokemons[25];
            GetComponent<PokeApiController>().GetPokemonTexture(PlayerPokeData, RawImageOfPokemon);
        }
    }

    private void Update()
    {
        if (PokemonDataModel.ListOfPokemons.Count > 0)
        {
            PlayerPokeData = PokemonDataModel.ListOfPokemons[25];
            GetComponent<PokeApiController>().GetPokemonTexture(PlayerPokeData, RawImageOfPokemon);
            PokemonDataModel.ListOfPokemons.Clear();
            
        }
    }
}
