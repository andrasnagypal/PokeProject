using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerPokeController : MonoBehaviour
{
    [SerializeField] PlayerPokeUI PlayerPokeView;
    [SerializeField] StaminaBarController StaminaUI;
    [SerializeField] PlayerPokeTypeDisplay TypeDisplay;
    //PokeModel TheData;

    //private void Awake()
    //{
    //    TheData = new PokeModel();
    //}
    public PokeModel PlayerPoke;
    //{
    //    get { return TheData; }  set
    //    {
    //        TheData = value;
    //        //for (int i = 0; i < TheData.SpritesOfPoke.Length; i++)
    //        //{
    //        //    Debug.Log(TheData.SpritesOfPoke[i]);
    //        //    if(TheData.SpritesOfPoke[i]!=null)
    //        //        PlayerPokeView.AddImage(TheData.SpritesOfPoke[i]);
    //        //}
    //        PlayerPokeView.AddImage(TheData.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]);
    //    }
    //}

    public void UpdatePokeUI()
    {
        if (PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]!=null)
        {
            //exture2D temp = Instantiate(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]);
           
            PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]);
            
        }
        else PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.back_default]);
        if (PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_female] != null)
        {
            //exture2D temp = Instantiate(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]);
            PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_female]);

        }
        PlayerPokeView.NameThePokeDisplay(PlayerPoke.PokeName);
        for (int i = 0; i < PlayerPoke.Stamina; i++)
        {
            StaminaUI.AddStaminaPointToUI();
        }
        PlayerPokeView.UpdateAttackDisplay(PlayerPoke.MaxNumberOfAttacks);
        Debug.Log("StaminaPoints: " + PlayerPoke.Stamina);
        Debug.Log("Attack: " + PlayerPoke.MaxNumberOfAttacks);

    }


    public void GetAnotherPoke()
    {
        PokeModel newPoke = FindObjectOfType<PokePool>().GivePoke();
        StaminaUI.ResetStaminaBar();
        PlayerPoke = newPoke;
        UpdatePokeUI();
    }
}
