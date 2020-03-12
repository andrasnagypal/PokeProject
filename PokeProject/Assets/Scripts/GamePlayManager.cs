using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] PlayerPokeController PPokeController;
    [SerializeField] EnemyPokeController EPokeController;

    public void GetAnotherPokeForPlayer()
    {
        PPokeController.GetAnotherPoke();
    }

    public void StartTheGame()
    {
        EPokeController.gameObject.SetActive(true);
        EPokeController.GetOtherEnemyPoke();
       
    }
}
