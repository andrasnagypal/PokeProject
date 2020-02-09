using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;


public class PokeApiController : MonoBehaviour
{
    
    readonly string basePokeURL = "https://pokeapi.co/api/v2/";
    int StartIndex = 1, EndIndex = 808;
    void Start()
    {
        for (int i = StartIndex; i < EndIndex; i++)
        {

        }
    }

    IEnumerator GetPokemAtIndex(int pokemonIndex)
    {
        string pokemonURL = basePokeURL + "pokemon/" + pokemonIndex.ToString();

        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);
    }
   
}
