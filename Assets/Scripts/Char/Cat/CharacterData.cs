using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int exp;
    public int atk;
    public int def;
    public int hp;
    public float speed;
    private int speedValue;
    public int skillPoint;

    private int expI = 0;
    private int spLvI = 0;
    private int[] skillPointLevel = { 5, 10, 30 };
    private int[] upExp = { 10, 20, 40, 80, 140, 220, 320, 450, 500, 510, 520, 530, 540, 550, 560, 570, 580, 590, 600, 610, 620, 630, 640, 650, 660, 670, 680, 690, 700 };

    

    public void Leveling(int expValue)
    {
        exp += expValue;
        if (exp >= upExp[expI])
        {
            level++;
            StatisticsUp();
            exp = exp - upExp[expI];
            expI++;
            if (level == skillPointLevel[spLvI])
            {
                skillPoint++;
                spLvI++;
            }
            if(level == 20)
            {
                //3레벨 스킬 배우기
            }
        }
        if (level == 30)
        {
            //만렙 달성시 되는 것
        }
    }

    protected virtual void Skill1()
    {

    }

    protected virtual void Skill2()
    {

    }

    protected virtual void Skill3()
    {

    }

    protected virtual void StatisticsUp()
    {

    }

    /// <summary>
    /// 속도값 1, 0.5, 2 나오는것
    /// </summary>
    protected void Speedvalue()
    {
        speedValue = Random.Range(0, 3);
        switch (speedValue)
        {
            case 0: speed += 0;
                break;
            case 1: speed += (float)0.5;
                break;
            case 2: speed += 1;
                break;
        }
    }
}
