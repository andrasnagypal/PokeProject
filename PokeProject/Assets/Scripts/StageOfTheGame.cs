using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateOfTheGame
{
    Loading,
    ChoseFirstPoke,
    FirstCombat,
    EnemyEscaped,
    EnemyCaptured,
    PlayerPokeExhausted,
    Victory,
    Defeat
}

public static class StageOfTheGame 
{
    public static StateOfTheGame CurrentStateOfTheGame = StateOfTheGame.Loading;
}
