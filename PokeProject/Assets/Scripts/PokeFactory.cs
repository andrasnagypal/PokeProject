using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum SpriteURLIndexEnum :byte
{
    back_default,
    back_female,
    back_shiny,
    back_shiny_female,
    front_default,
    front_female,
    front_shiny,
    front_shiny_female
}


public class PokeFactory : MonoBehaviour
{
    [SerializeField] string basePokeURL = "https://pokeapi.co/api/v2/";
    [SerializeField] int StaminaModifier=2, AttackModifier=3;
     string[] SpriteURLNames=new string[] {
    "back_default",
    "back_female",
    "back_shiny",
    "back_shiny_female",
    "front_default",
    "front_female",
    "front_shiny",
    "front_shiny_female"};
    [SerializeField] TypeCounter TypesList;

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
        yield return null;
        StartCoroutine(FillUpPokeModel(pokeInfo));
        //PokemonDataModel.ListOfPokemons.Add(pokemonIndex, pokeInfo);
        //Debug.Log("Pokes: "+PokemonDataModel.ListOfPokemons.Count);
        //Debug.Log("Index : "+CurrentIndex);
        //if (CurrentIndex < EndIndex)
        //    StartCoroutine(GetPokemAtIndex(CurrentIndex++));
        //else
        //    Debug.Log(PokemonDataModel.ListOfPokemons.Count);
    }

    IEnumerator FillUpPokeModel(JSONNode basicInfoForPoke)
    {
        PokeModel TheData = new PokeModel();
        TheData.PokeName = basicInfoForPoke["name"];
        TheData.IndexOfPoke= basicInfoForPoke["id"];
        JSONNode types = basicInfoForPoke["types"];
        TheData.TypesOfPoke = new string[types.Count];
        for (int i = 0; i < types.Count; i++)
        {
            TheData.TypesOfPoke[i] = types[i]["type"]["name"];
            GetComponent<TypeCounter>().AddToCounter(TheData.TypesOfPoke[i]);
        }
        TheData.DamageRelationsArray = new byte[types["damage_relations"].Count];
        JSONNode damagerelations = types["damage_relations"];
        for (int i = 0; i < types["damage_relations"].Count; i++)
        {
            Debug.Log("VALAMI!!!!");
            TheData.DamageRelationsArray[i] = (byte)TypesList.GetIndexOfType(damagerelations[TypesList.DamageRelationNames[i]]["name"]);
            Debug.Log(TypesList.DamageRelationNames[i] + " " + TypesList.GetNameOfTpye(TheData.DamageRelationsArray[i]));
        }
        Debug.Log("Type number: " + (types.Count + 1));
        JSONNode abilities = basicInfoForPoke["abilities"];
        TheData.AbilitiesOfPoke = new string[abilities.Count];
        for (int i = 0; i < abilities.Count; i++)
        {
            TheData.AbilitiesOfPoke[i] = abilities[i]["ability"]["name"];
        }
        TheData.Lvl = 0;
        TheData.Stamina = types.Count * StaminaModifier;
        TheData.MaxNumberOfAttacks = abilities.Count * AttackModifier;
        TheData.CurrentAttackAmount = TheData.MaxNumberOfAttacks;
        TheData.SpritesOfPoke = new Texture2D[SpriteURLNames.Length];
        for (int i = 0; i < SpriteURLNames.Length; i++)
        {
            string SpriteURL = basicInfoForPoke["sprites"][SpriteURLNames[i]];
            
            StartCoroutine(SetSpriteForPoke(i, SpriteURL, TheData));
           
        }
        yield return null;
       
    }

    IEnumerator SetSpriteForPoke(int index,string url, PokeModel data)
    {
        
        Debug.Log("Index: " + index + " " + url);
        if (!string.IsNullOrEmpty(url) && !string.IsNullOrWhiteSpace(url))
        {
            UnityWebRequest SpriteRequest = UnityWebRequestTexture.GetTexture(url);
            yield return SpriteRequest.SendWebRequest();

            if (SpriteRequest.isNetworkError || SpriteRequest.isHttpError)
            {
                Debug.LogError(SpriteRequest.error);
                yield break;
            }
            data.SpritesOfPoke[index] = DownloadHandlerTexture.GetContent(SpriteRequest);
            data.SpritesOfPoke[index].filterMode = FilterMode.Point;

        }
        else
            data.SpritesOfPoke[index] = null;
        if (index == SpriteURLNames.Length - 1)
            AddPokeToPool(data);
    }


    void AddPokeToPool(PokeModel modelToModify)
    {
        
        GetComponent<PokePool>().AddPoke(modelToModify);
        if (StageOfTheGame.CurrentStateOfTheGame == StateOfTheGame.Loading)
            GetComponent<LoadingManager>().LoadUpPokeUI();
    }
}
