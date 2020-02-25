using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBarUI : MonoBehaviour
{
    [SerializeField] Image  LoadingBar;
    [SerializeField] int MaxLoad,CurrentLoad=0;
    public int MaxAmountOfLoadingTicks { get
        { return MaxLoad; }
        set
        {
            MaxLoad += value;
        } }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdateLoadingBarUI();
        }
    }


    public bool IsFinishedLoading()
    {
        return CurrentLoad == MaxAmountOfLoadingTicks;
    }
    public void UpdateLoadingBarUI()
    {



        if (CurrentLoad < MaxAmountOfLoadingTicks)
        {
            Debug.Log("Increase");
            LoadingBar.fillAmount = (float)CurrentLoad++ / MaxAmountOfLoadingTicks;
        }
        if (CurrentLoad == MaxAmountOfLoadingTicks)
        {
            LoadingBar.fillAmount = 1f;
            Debug.Log("Loaded");
        }
    }
}
