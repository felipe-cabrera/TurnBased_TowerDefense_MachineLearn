using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public GameObject target;
    public int Life = 2;
    public Animator TowerAnimator;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextRound()
    {
        this.GetComponent<TowerAimShot>().NextRound();
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

        target = targets[0];
        foreach(GameObject tempTarget in targets)
        {
            if((int)this.GetComponent<TowerTypes>().TowerType == (int)tempTarget.GetComponent<EnemyTypes>().ClassifiedEnemyType)
            {
                target = tempTarget;
                break;
            }
        }

        return target;
    }

    // Damage the tower, reducing the life in one
    public void DamageTheTower()
    {
        Life--;
        TowerAnimator.SetInteger("vida", Life);
        if (Life == 0)
            GameObject.Destroy(gameObject);
    }

}
