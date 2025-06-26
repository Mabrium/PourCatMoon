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

    protected override void StatisticsUp()
    {
        atk += Random.Range(2, 5);
        def += Random.Range(3, 5);
        maxHp += Random.Range(31, 33);
        speed += Random.Range(1, 3);
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
