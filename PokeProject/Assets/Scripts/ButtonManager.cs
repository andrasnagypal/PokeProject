using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject StartButton, GetPokeButton;
    
    public void GetAnotherPokeForPlayer()
    {
        GetComponent<GamePlayManager>().GetAnotherPokeForPlayer();
    }

    public void StartTheGame()
    {
        GetComponent<GamePlayManager>().StartTheGame();
        Destroy(StartButton);
        Destroy(GetPokeButton);
    }
}
