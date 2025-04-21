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
        atk += Random.Range(4, 7);
        def += Random.Range(6, 8);
        hp += Random.Range(30, 33);
    }
}
