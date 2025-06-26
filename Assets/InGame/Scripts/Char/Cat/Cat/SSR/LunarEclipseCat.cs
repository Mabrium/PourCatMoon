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


    protected override void StatisticsUp()
    {
        atk += Random.Range(2, 4);
        def += Random.Range(6, 8);
        maxHp += Random.Range(28, 31);
        Speedvalue();
    }

    #region Æê ½ºÅ³

    protected override void Skill1_1()
    {

    }

    protected override void Skill1_2()
    {

    }

    protected override void Skill1_3()
    {

    }

    protected override void Skill2_1()
    {

    }

    protected override void Skill2_2()
    {

    }

    protected override void Skill2_3()
    {

    }

    protected override void Skill3_1()
    {

    }

    protected override void Skill3_2()
    {

    }

    protected override void Skill3_3()
    {

    }

    #endregion
}
