using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject EnemyGrid;

    public GameObject NearestTower;

    public Animator EnemyAnimator;

    public int Life = 2;
    // Use this for initialization
    void Start()
    {
        NearestTower = FindNearestTower();
        AimToTarget();

    }

    public string NextRound()
    {
        Vector3 lastPos = EnemyGrid.transform.position;
        NearestTower = FindNearestTower();
        if (NearestTower.transform.position.x != EnemyGrid.transform.position.x)
        {
            if (NearestTower.transform.position.x > EnemyGrid.transform.position.x)
                EnemyGrid.transform.position = new Vector2(EnemyGrid.transform.position.x + 1, EnemyGrid.transform.position.y);
            else
                EnemyGrid.transform.position = new Vector2(EnemyGrid.transform.position.x - 1, EnemyGrid.transform.position.y);
        }
        else if (NearestTower.transform.position.y != EnemyGrid.transform.position.y)
        {
            if (NearestTower.transform.position.y > EnemyGrid.transform.position.y)
                EnemyGrid.transform.position = new Vector2(EnemyGrid.transform.position.x, EnemyGrid.transform.position.y + 1);
            else
                EnemyGrid.transform.position = new Vector2(EnemyGrid.transform.position.x, EnemyGrid.transform.position.y - 1);
        }
        else
        {
            Debug.Log("Reached the tower");
        }

        NearestTower = FindNearestTower();
        AimToTarget();

        return (string.Format("Enemy[{0},{1}] is moving to [{2},{3}]", lastPos.x, lastPos.y, EnemyGrid.transform.position.x, EnemyGrid.transform.position.y));

    }

    // Ger the nearest tower by Manhattan Distance
    GameObject FindNearestTower()
    {
        // Collection of all TowerGrids (Tower objects with position relative to the grid)
        GameObject[] towers = GameObject.FindGameObjectsWithTag("TowerGrid");

        // Default Values
        float distance = float.MaxValue;


        GameObject nearest = null;

        if (towers.Length > 0 && towers[0] != null)
            nearest = towers[0];

        // Get the nearest tower
        foreach (GameObject tower in towers)
        {
            float tempDistance = Mathf.Abs(tower.transform.position.x - EnemyGrid.transform.position.x) + Mathf.Abs(tower.transform.position.y - EnemyGrid.transform.position.y);
            if (tempDistance < distance)
            {
                distance = tempDistance;
                nearest = tower;
            }
        }

        return nearest;
    }

    void AimToTarget()
    {
        if (NearestTower != null)
        {
            // Rotate our Tower to the taget 
            Quaternion neededRotation = Quaternion.LookRotation(Vector3.forward,
                        NearestTower.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, 1f);
        }
    }

    // When touch some object
    void OnTriggerEnter2D(Collider2D col)
    {

        // If it's a tower
        if (col.gameObject.tag.Equals("Tower"))
        {
            Destroy(gameObject);
            col.GetComponent<TowerController>().DamageTheTower();
        }
    }

    public void DamageTheEnemy(bool trueType)
    {
        Life--;
        if (trueType)
            Life--;
        EnemyAnimator.SetInteger("vida", Life);
        if (Life <= 0)
        {
            GameObject.Destroy(gameObject.transform.parent.gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Score();
        }

    }
}
