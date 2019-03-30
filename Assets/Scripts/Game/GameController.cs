using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Button ButtonNextRound;

    public Button ButtonNextBattle;

    public Button NewGame;

    public Text CanvasRoundText;

    public Text TurnStatus;

    public Text CanvasScoreText;
    bool battling;

    public void NextRound()
    {
        battling = true;
        StartCoroutine(NextRoundCoroutine());
    }

    IEnumerator NextRoundCoroutine()
    {

        if (battling)
        {
            ButtonNextRound.interactable = false;
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");


            Debug.Log("Towers Turn:");
            TurnStatus.text = "Let's your turn begin";
            yield return new WaitForSeconds(1f);
            foreach (GameObject tower in towers)
            {
                // Check if there is any enemy remaining
                if (EnemiesAlive())
                {
                    TurnStatus.text = tower.GetComponent<TowerController>().NextRound();
                    yield return new WaitForSeconds(1.5f);
                }
                else
                    yield return new WaitForSeconds(0.02f);
            }
            TurnStatus.text = "Waiting the end of your turn";
            yield return new WaitForSeconds(1.5f);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


            if (isBattleEnd())
            {
                battling = false;
                yield break;
            }

            TurnStatus.text = "Let's your Enemy turn begin";
            foreach (GameObject enemy in enemies)
            {
                if (TowersAlive())
                {
                    TurnStatus.text = enemy.GetComponent<EnemyController>().NextRound();
                    yield return new WaitForSeconds(1.5f);

                }
                else
                    yield return new WaitForSeconds(0.02f);
            }


            if (isBattleEnd())
            {
                battling = false;
                yield break;
            }
            else
            {
                ButtonNextRound.interactable = true;
                ButtonNextRound.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Next Turn";
            }

            Debug.Log("End of Enemies Turn!");

        }


    }

    bool isBattleEnd()
    {
        if (!TowersAlive())
        {
            BattleLose();
            TurnStatus.text = "You Lost! Please start a new game";
            return true;
        }
        else if (!EnemiesAlive())
        {
            BattleWin();
            TurnStatus.text = "You Won! Please start a new battle";
            return true;
        }

        return false;
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
            return false;

        return true;

    }

    void BattleWin()
    {
        CanvasRoundText.text = "You won the battle!";
        ButtonNextRound.interactable = false;
        ButtonNextBattle.interactable = true;
        ButtonNextBattle.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Next Battle";
        GameObject.FindGameObjectWithTag("GameController").GetComponent<WarController>().CurrentRound += 1;
    }

    void BattleLose()
    {
        CanvasRoundText.text = "You lost the war!";
        ButtonNextBattle.gameObject.SetActive(false);
        NewGame.gameObject.SetActive(true);

    }

    public void UpdateUI()
    {
        CanvasRoundText.text = "Current Battle: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<WarController>().CurrentRound;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Score()
    {
        GetComponent<WarController>().Score++;
        CanvasScoreText.text = "Current Score: " + GetComponent<WarController>().Score;

    }
}
