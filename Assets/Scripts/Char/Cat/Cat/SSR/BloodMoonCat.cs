using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMoonCat : CharacterData
{
    //Àû¿ù
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
        def += Random.Range(3, 7);
        hp += Random.Range(24, 27);
        speed += Random.Range(1, 3);
    }
}
