using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button ButtonNextRound;
    public Text CanvasRoundText;
	public void NextRound()
    {
        StartCoroutine(NextRoundCoroutine());
    }

    IEnumerator NextRoundCoroutine()
    {
        ButtonNextRound.interactable = false;
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        

        foreach (GameObject tower in towers)
        {
            tower.GetComponent<TowerController>().NextRound();
            if(CheckEnemies()) // Check if there is any enemy remaining
                yield return new WaitForSeconds(1.5f);
            else
                yield return new WaitForSeconds(0.1f);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        CheckEnemies();

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().NextRound();
            yield return new WaitForSeconds(1.5f);    
        }
        ButtonNextRound.interactable = true;

        
        if(CheckTowers())
            CheckEnemies();
        
    }

    bool CheckEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            CanvasRoundText.text = "Você venceu a rodada :D ";
        else
            return true;

        return false;
    }

    bool CheckTowers()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        if (towers.Length == 0)
            CanvasRoundText.text = "Você perdeu :(";
        else
            return true;

        return false;

    }
}
