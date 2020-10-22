using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int health;

    public GameObject character;

    public virtual void Death()
    {
        Destroy(character);
    }

    public void Hit()
    {
        health--;

        if (health <= 0) Death();
    }
}

public class PlayerCharacter : Character
{
    public GameManager gameManager;

    public override void Death()
    {
        gameManager.GameOver();
    }
}
