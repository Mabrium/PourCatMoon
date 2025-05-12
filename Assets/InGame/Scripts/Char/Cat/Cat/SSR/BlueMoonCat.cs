using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMoonCat : CharacterData
{
    //Ã»¿ù
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
        def += Random.Range(3, 5);
        maxHp += Random.Range(31, 33);
        speed += Random.Range(1, 3);
    }
}
