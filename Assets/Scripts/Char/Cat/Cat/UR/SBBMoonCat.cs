using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBBMoonCat : CharacterData
{
    //슈퍼 블루 블러드 문
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
        atk += Random.Range(7, 10);
        def += Random.Range(8, 10);
        hp += Random.Range(32, 35);
        speed += Random.Range(1, 5);
    }
}
