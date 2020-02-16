using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] GameObject Grass1, Grass2, Grass3, Land, RiverGrass, River, Trees;
    [SerializeField] Vector3 Grass1ScaleTo, Grass2ScaleTo, Grass3ScaleTo, LandScaleTo, RiverGrassScaleTo, RiverScaleTo, TreeScaleTo,PlayerPokeToScale,EnemyPokeToScale,PokePanelToScale;
    [SerializeField] float MoveUpTime, ScaleUpTime;
    [SerializeField] GameObject PlayerPoke, EnemyPoke, PokePanel;
    private void Start()
    {
        OnLoadedLevel();
    }
    public void OnLoadedLevel()
    {
        LeanTween.moveLocalY(Grass1, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass2, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass3, 0, MoveUpTime);
        LeanTween.scale(Grass1, Grass1ScaleTo, ScaleUpTime);
        LeanTween.scale(Grass2, Grass2ScaleTo, ScaleUpTime);
        LeanTween.scale(Grass3, Grass3ScaleTo, ScaleUpTime);
        LeanTween.scale(Land, LandScaleTo, ScaleUpTime).setOnComplete(LoadUpPokeUI);
    }


    public void LoadUpPokeUI()
    {
        StageOfTheGame.CurrentStateOfTheGame++;
    }
}
