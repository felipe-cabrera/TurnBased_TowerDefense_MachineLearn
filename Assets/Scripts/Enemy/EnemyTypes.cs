using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTypes : MonoBehaviour
{

    [System.Serializable]
    public enum Types
    {
        Voador = 0,
        Quadrupede = 1,
        Bipede = 2,
        Rastejante = 3,
        Subterraneo = 4
    }

    public int Life = 10;
    public int Defense = 10;

    public Types RealEnemyType; // The type of this Enemy

    public Types ClassifiedEnemyType;

    private void Start()
    {
        RealEnemyType = (Types)Random.Range(0, 5);
        Life = Random.Range(1, 30);
        Defense = Random.Range(1, 30);
        Classify();
    }

    public void Classify()
    {
        ClassifiedEnemyType = RealEnemyType;
    }
}

