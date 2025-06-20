using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMoonCat : CharacterData
{
    //½´ÆÛ¹®
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
        atk += Random.Range(2, 5);
        def += Random.Range(7, 9);
        maxHp += Random.Range(26, 29);
        speed += Random.Range(1, 3);
    }
}
