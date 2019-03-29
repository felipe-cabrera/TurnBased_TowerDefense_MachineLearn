using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button ButtonNextRound;

    public Button ButtonNextBattle;

    public Text CanvasRoundText;

    bool battling;

    public void NextRound()
    {
        battling = true;
        StartCoroutine(NextRoundCoroutine());
    }

    IEnumerator NextRoundCoroutine()
    {

        if(battling)
        {
            ButtonNextRound.interactable = false;
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");


            foreach (GameObject tower in towers)
            {
                tower.GetComponent<TowerController>().NextRound();
                if (EnemiesAlive()) // Check if there is any enemy remaining
                    yield return new WaitForSeconds(1.5f);
                else
                    yield return new WaitForSeconds(0.1f);
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (!EnemiesAlive())
            {
                BattleWin();
                battling = false;
                yield break;
            }


            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().NextRound();
                yield return new WaitForSeconds(1.5f);
            }
            ButtonNextRound.interactable = true;


            if (TowersAlive())
                EnemiesAlive();
        }
        
        
    }

    bool EnemiesAlive()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            return false;
        
        return true;
    }

    bool TowersAlive()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        if (towers.Length == 0)
            CanvasRoundText.text = "Você perdeu a guerra :(";
        else
            return true;

        return false;

    }

    void BattleWin()
    {
        CanvasRoundText.text = "Você venceu a batalha!";
        ButtonNextRound.interactable = false;
        ButtonNextBattle.interactable = true;
        ButtonNextBattle.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Proxima Batalha";
        GameObject.FindGameObjectWithTag("GameController").GetComponent<WarController>().ActualRound += 1;
    }

    public void UpdateUI()
    {
        CanvasRoundText.text = "Batalha atual: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<WarController>().ActualRound;
    }
}
