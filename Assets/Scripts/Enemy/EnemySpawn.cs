using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawn : MonoBehaviour
{

    int posX;
    int posY;

    int maxAmount = 20;

    List<GameObject> enemiesPosition;
    List<GameObject> towersPosition;

    public GameObject[] enemiesPrefab;

    public void SpawnTheEnemies(int baseAmount)
    {
        // Get positions of Towers and Enemies relative to the Grid
        towersPosition = GameObject.FindGameObjectsWithTag("TowerGrid").ToList();
        enemiesPosition = GameObject.FindGameObjectsWithTag("EnemyGrid").ToList();


        // Increase in 1 the amount of units to spawn every round
        int amount = baseAmount + GameObject.FindGameObjectWithTag("GameController").GetComponent<WarController>().CurrentRound - 1;
        if (amount > maxAmount)
            amount = maxAmount;

        for (int i = 0; i < amount; i++)
        {
            posX = Random.Range(0, 9) - 4; // From -4 to +4
            posY = Random.Range(0, 9) - 4; // From -4 to +4

            // Check if it's still possible to spawn another enemy (max amount reached)
            bool availablePosition = true;
            if (!CheckMaxAmountOfEnemies())
            {
                Debug.Log("Max Amount Of Enemies Spawned!");
                return;
            }

            int triedTimes = 0;
            // While the position isn't a valid position, we will try to find one
            while (!CheckDistanceToTowers() || !CheckOccupiedPosition())
            {
                posX = Random.Range(0, 9) - 4; // From -4 to +4
                posY = Random.Range(0, 9) - 4; // From -4 to +4
                if (triedTimes > 1000)
                {
                    availablePosition = false;
                    break;
                }
            }

            if (!availablePosition)
                return;

            // If everything is okay, we will instantiate the enemy in the correct position
            int randomEnemyIndex = Random.Range(0, enemiesPrefab.Length);
            GameObject enemyToSpawn = Instantiate(enemiesPrefab[randomEnemyIndex], new Vector2(posX, posY), Quaternion.identity);
            enemiesPosition.Add(enemyToSpawn);
        }


    }

    public bool CheckMaxAmountOfEnemies()
    {
        return enemiesPosition.Count < maxAmount;
    }

    // Check the distance between enemies and towers
    public bool CheckDistanceToTowers()
    {
        bool validPosition = true;
        foreach (GameObject tower in towersPosition)
        {
            Vector2 position = tower.transform.position;
            if (Mathf.Abs(position.x - posX) <= 1 && Mathf.Abs(position.y - posY) <= 1)
                validPosition = false;
        }
        return validPosition;
    }

    // Check if exists another enemy in this position
    public bool CheckOccupiedPosition()
    {
        bool validPosition = true;
        foreach (GameObject enemy in enemiesPosition)
        {
            Vector2 position = enemy.transform.position;
            if (position.x == posX && position.y == posY)
                validPosition = false;
        }
        return validPosition;
    }

}
