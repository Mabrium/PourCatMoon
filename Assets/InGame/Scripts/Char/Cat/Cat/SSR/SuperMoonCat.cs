using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMoonCat : CharacterData
{
    //���۹�
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void StatisticsUp()
    {
        atk += Random.Range(2, 5);
        def += Random.Range(7, 9);
        maxHp += Random.Range(26, 29);
        speed += Random.Range(1, 3);
    }

    #region �� ��ų

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
