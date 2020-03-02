using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerPokeController : MonoBehaviour
{
    public PlayerPokeUI PlayerPokeView;
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
            Texture2D temp = Instantiate(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.front_default]);
            PlayerPokeView.AddImage(temp);
        }
        else PlayerPokeView.AddImage(PlayerPoke.SpritesOfPoke[(int)SpriteURLIndexEnum.back_default]);
    }

}
