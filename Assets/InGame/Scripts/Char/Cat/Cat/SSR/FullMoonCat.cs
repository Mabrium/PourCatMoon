using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMoonCat : CharacterData
{
    //보름달, 만월
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
        atk += Random.Range(3, 6);
        def += Random.Range(4, 6);
        hp += Random.Range(23, 25);
        speed += Random.Range(2, 4);
    }
}
