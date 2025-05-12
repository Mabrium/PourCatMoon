using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarEclipseCat : CharacterData
{
    //ÀÏ½Ä
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void Skill1()
    {
        
    }

    protected override void Skill2()
    {
        
    }

    protected override void Skill3()
    {

    }

    protected override void StatisticsUp()
    {
        atk += Random.Range(5, 8);
        def += Random.Range(2, 4);
        maxHp += Random.Range(21, 23);
        speed += Random.Range(1, 3);
    }
}
