using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPokeController : MonoBehaviour
{
    [SerializeField] PlayerPokeController EnemyPoke;


    public void GetOtherEnemyPoke()
    {
        EnemyPoke.GetAnotherPoke();
    }
}
