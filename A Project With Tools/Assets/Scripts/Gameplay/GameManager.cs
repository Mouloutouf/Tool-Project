using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public FloatVariable score;

    public Text scoreDisplay;

    public List<GameObject> enemies;
    public GameObject player;

    public GameObject MenuInterface;
    public GameObject GameInterface;

    public void GameOver()
    {
        // Display menu, replay option. Stop game.

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        Destroy(player);

        MenuInterface.SetActive(true);
        GameInterface.SetActive(false);
    }

    public void UpdateScore()
    {
        scoreDisplay.text = score.Value.ToString() + " : SCORE";
    }
}
