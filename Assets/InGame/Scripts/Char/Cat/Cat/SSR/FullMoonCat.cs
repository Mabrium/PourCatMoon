using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMoonCat : CharacterData
{
    //������, ����
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void StatisticsUp()
    {
        atk += Random.Range(3, 6);
        def += Random.Range(4, 6);
        maxHp += Random.Range(23, 25);
        speed += Random.Range(2, 4);
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
