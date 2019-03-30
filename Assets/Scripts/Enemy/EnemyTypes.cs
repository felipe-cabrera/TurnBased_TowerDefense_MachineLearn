using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTypes : MonoBehaviour
{

    [System.Serializable]
    public enum Types
    {
        Blue,
        Yellow,
        Green,
        Purple,
        Orange
    }

    public Vector2 AttackInterval;
    public Vector2 DefenseInterval;

    public Types RealEnemyType; // The type of this Enemy

    [Header("Auto-Generated. Don't fill it!")]
    public int Attack;
    [Header("Auto-Generated. Don't fill it!")]
    public int Defense;

    [Header("Value Classified By AI")]
    public Types ClassifiedEnemyType;

    private void Start()
    {
        UnityEngine.Random.seed = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomSeed>().GenerateSeed();
        Attack = UnityEngine.Random.Range((int)AttackInterval.x, (int)AttackInterval.y);
        Defense = UnityEngine.Random.Range((int)DefenseInterval.x, (int)DefenseInterval.y);
        Classify();
    }

    public void Classify()
    {
        ClassifiedEnemyType = RealEnemyType;
    }
}

