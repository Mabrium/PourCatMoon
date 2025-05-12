using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarEclipseCat : CharacterData
{
    //¿ù½Ä
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
        atk += Random.Range(2, 4);
        def += Random.Range(6, 8);
        maxHp += Random.Range(28, 31);
        Speedvalue();
    }
}
