using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] GameObject Grass1, Grass2, Grass3, Land, RiverGrass, River, Trees;
    [SerializeField] Vector3 Grass1ScaleTo, Grass2ScaleTo, Grass3ScaleTo, LandScaleTo, RiverGrassScaleTo, RiverScaleTo, TreeScaleTo,PlayerPokeToScale,EnemyPokeToScale,PokePanelToScale;
    [SerializeField] float MoveUpTime, ScaleUpTime;
    [SerializeField] GameObject PlayerPoke, EnemyPoke, PokePanel,LoadingBar;
    [SerializeField] LoadingBarUI LoadingView;
    private void Start()
    {
        //OnLoadedLevel();
    }
    public void OnLoadedLevel()
    {
        LeanTween.scale(Land, LandScaleTo, ScaleUpTime);
        LeanTween.scale(Grass1, Grass1ScaleTo, .01f);
        LeanTween.scale(Grass2, Grass2ScaleTo, .01f);
        LeanTween.scale(Grass3, Grass3ScaleTo, .01f);
        LeanTween.moveLocalY(Grass1, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass2, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass3, 0, MoveUpTime);
        
       
    }


    public void LoadUpPokeUI()
    {
        LoadingView.UpdateLoadingBarUI();
        if (LoadingView.IsFinishedLoading())
        {
            StageOfTheGame.CurrentStateOfTheGame = StateOfTheGame.ChoseFirstPoke;
            LoadingBar.SetActive(false);
            OnLoadedLevel();
            
        }
    }
}
