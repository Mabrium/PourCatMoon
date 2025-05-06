using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleStat[] battleStats = new BattleStat[2];
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TurnManager()
    {
        if (battleStats[0].turnSpeed > battleStats[1].turnSpeed)
        {
            battleStats[0].MyTurnStart();
        }
        else if (battleStats[0].turnSpeed < battleStats[1].turnSpeed)
        {
            battleStats[1].MyTurnStart();
        }
        else if (battleStats[0].turnSpeed == battleStats[1].turnSpeed)
        {
            int rand = Random.Range(0, 2);
            battleStats[rand].MyTurnStart();
        }
    }
}
