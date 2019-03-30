using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerController : MonoBehaviour
{

    public GameObject target;
    public int Life = 2;
    public Animator TowerAnimator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string NextRound()
    {
        return this.GetComponent<TowerAimShot>().NextRound();
    }

    public GameObject UpdateTarget()
    {
        // Update our target to the first target with the tag Target
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        // If there is no more enemies Alive
        if (targets.Length < 1)
        {
            target = null;
            return null;
        }

        if (targets.Length > 0)
            target = targets[0];

        List<GameObject> sameTypes = new List<GameObject>();

        foreach (GameObject tempTarget in targets)
        {
            if ((int)this.GetComponent<TowerTypes>().TowerType == (int)tempTarget.GetComponent<EnemyTypes>().ClassifiedEnemyType)
            {
                sameTypes.Add(tempTarget);
            }
        }

        if (sameTypes.Count > 0)
        {
            target = FindNearestEnemy(sameTypes);
        }
        else
        {
            target = FindNearestEnemy(targets.ToList());
        }

        return target;
    }

    // Ger the nearest enemy by Manhattan Distance
    GameObject FindNearestEnemy(List<GameObject> enemies)
    {
        // Collection of all TowerGrids (Tower objects with position relative to the grid)
        

        // Default Values
        float distance = float.MaxValue;


        GameObject nearest = null;

        if (enemies.Count > 0 && enemies[0] != null)
            nearest = enemies[0];

        // Get the nearest tower
        foreach (GameObject enemy in enemies)
        {
            float tempDistance = Mathf.Abs(enemy.transform.parent.transform.position.x - transform.parent.transform.parent.transform.position.x) + Mathf.Abs(enemy.transform.parent.transform.position.y - transform.parent.transform.parent.transform.position.y);
            if (tempDistance < distance)
            {
                distance = tempDistance;
                nearest = enemy;
            }
        }

        return nearest;
    }




    // Damage the tower, reducing the life in one
    public void DamageTheTower()
    {
        Life--;
        TowerAnimator.SetInteger("vida", Life);
        if (Life == 0)
            GameObject.Destroy(gameObject.transform.parent.transform.parent.gameObject);
    }



}
