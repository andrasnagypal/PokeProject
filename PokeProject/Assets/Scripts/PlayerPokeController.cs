using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerPokeController : MonoBehaviour
{
    [SerializeField] PlayerPokeUI PlayerPokeView;
    [SerializeField] StaminaBarController StaminaUI;
    [SerializeField] PlayerPokeTypeDisplay TypeDisplay;
    [SerializeField] PokeAbilityDisplay AbilityDisplay;
    
    public PokeModel PlayerPoke;
    

    public void UpdatePokeUI()
    {
        if (PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]!=null)
        {
            
           
            PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]);
            
        }
        else PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.back_default]);
        if (PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_female] != null)
        {
            
            PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_female]);

        }
        PlayerPokeView.NameThePokeDisplay(PlayerPoke.PokeName);
        for (int i = 0; i < PlayerPoke.Stamina; i++)
        {
            StaminaUI.AddStaminaPointToUI();
        }
        PlayerPokeView.UpdateAttackDisplay(PlayerPoke.MaxNumberOfAttacks);
       

    }


    public void GetAnotherPoke()
    {
        PokeModel newPoke = FindObjectOfType<PokePool>().GivePoke();
        StaminaUI.ResetStaminaBar();
        //TypeDisplay.ResetUI();
        //AbilityDisplay.ResetUI();
        PlayerPoke = newPoke;
        TypeDisplay.SetTypesAndUI(PlayerPoke.TypesOfPoke);
        AbilityDisplay.SetAbilitiesName(PlayerPoke.AbilitiesOfPoke);
        AbilityDisplay.SetAbilityImages(TypeDisplay.GetAbilitySprites());
        UpdatePokeUI();
    }
}
