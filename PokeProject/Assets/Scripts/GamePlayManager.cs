using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameTurnState :byte
{
    Attack,
    EnemyTurn,
    Captured,
    SelectOtherPoke,
    Lose,
    Win

}
public class GamePlayManager : MonoBehaviour
{
    [SerializeField] PlayerPokeController PPokeController;
    [SerializeField] EnemyPokeController EPokeController;
    [SerializeField] InfoBarController InfoBar;
    [SerializeField] GameObject PokeInventoryPanel;
    static GameTurnState StateOfTheGame = GameTurnState.Attack;

    string[] InfoBarTags = new string[]
    {
        "Select an ability to Attack!",
        "Enemy Poke's turn",
        "Poke Captured",
        "Select an other Poke to fight with",
        "You Lost!",
        "You Won!" };
    public void GetAnotherPokeForPlayer()
    {
        PPokeController.GetAnotherPoke();
    }

    public void StartTheGame()
    {
        EPokeController.gameObject.SetActive(true);
        EPokeController.GetOtherEnemyPoke();
        PokeInventoryPanel.SetActive(true);
        InfoBar.gameObject.SetActive(true);
        InfoBar.ChangeInfoBar(InfoBarTags[(int)GameTurnState.Attack]);
        ChangeState(GameTurnState.Attack);
    }

    public static void ChangeState(GameTurnState state)
    {
        StateOfTheGame = state;
    }
}
