using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public float scoreValue;

    public FloatVariable scoreData;

    public GameEvent scoreEvent;

    public override void Death()
    {
        scoreData.Value += scoreValue;
        scoreEvent.Raise();



        base.Death();
    }
}
