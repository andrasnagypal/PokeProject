using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] GameObject Grass1, Grass2, Grass3, Land;
    [SerializeField] Vector3 LandScaleTo;
    [SerializeField] float MoveUpTime, ScaleUpTime, LoadingBarDisappear;
    [SerializeField] GameObject PlayerPoke,LoadingBar;
    [SerializeField] LoadingBarUI LoadingView;
    [SerializeField] PlayerPokeController PPokeController;
    delegate void PokePlay();
   
    IEnumerator OnLoadedLevel()
    {
        yield return new WaitForSeconds(.66f);
        Action temp = PokePlayerMoveIn;
        LeanTween.scale(LoadingBar, Vector3.zero, LoadingBarDisappear).setDestroyOnComplete(true);
        LeanTween.scale(Land, LandScaleTo, ScaleUpTime).setOnComplete(temp);
        
        LeanTween.moveLocalY(Grass1, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass2, 0, MoveUpTime);
        LeanTween.moveLocalY(Grass3, 0, MoveUpTime);
       

    }

    void PokePlayerMoveIn()
    {
        PlayerPoke.SetActive(true);
       
       
        PPokeController.GetAnotherPoke();
        
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
