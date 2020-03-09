using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] GameObject Grass1, Grass2, Grass3, Land, RiverGrass, River, Trees;
    [SerializeField] Vector3  LandScaleTo, RiverGrassScaleTo, RiverScaleTo, TreeScaleTo,PlayerPokeToScale,EnemyPokeToScale,PokePanelToScale;
    [SerializeField] float MoveUpTime, ScaleUpTime, LoadingBarDisappear;
    [SerializeField] GameObject PlayerPoke, EnemyPoke, PokePanel,LoadingBar;
    [SerializeField] LoadingBarUI LoadingView;
    [SerializeField] PlayerPokeController PPokeController;
    delegate void PokePlay();
   
    IEnumerator OnLoadedLevel()
    {
        yield return new WaitForSeconds(.66f);
        Action temp = PokePlayerMoveIn;
        LeanTween.scale(LoadingBar, Vector3.zero, LoadingBarDisappear).setDestroyOnComplete(true);
        LeanTween.scale(Land, LandScaleTo, ScaleUpTime).setOnComplete(temp);
        //LeanTween.scale(Grass1, vE, .01f);
        //LeanTween.scale(Grass2, Grass2ScaleTo, .01f);
        //LeanTween.scale(Grass3, Grass3ScaleTo, .01f);
        LeanTween.moveLocalY(Grass1, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass2, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass3, 0, MoveUpTime);
       

    }

    void PokePlayerMoveIn()
    {
        PlayerPoke.SetActive(true);
        PokeModel poke = GetComponent<PokePool>().GivePoke();
        /*FindObjectOfType<PlayerPokeController>()*/
        PPokeController.PlayerPoke = poke;
        /*FindObjectOfType<PlayerPokeController>()*/
        PPokeController.UpdatePokeUI();
        //LeanTween.easeInBounce
    }

    public void LoadUpPokeUI()
    {
        LoadingView.UpdateLoadingBarUI();
        if (LoadingView.IsFinishedLoading())
        {
            StageOfTheGame.CurrentStateOfTheGame = StateOfTheGame.ChoseFirstPoke;
            GetComponent<TypeCounter>().WriteOutTypes();
           
           
            StartCoroutine(OnLoadedLevel());
            
            
        }
    }
}
