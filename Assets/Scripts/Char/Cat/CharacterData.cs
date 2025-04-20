using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private int exp;
    public int atk;
    public int def;
    public int hp;

    [SerializeField] private int[] upExp = { 10, 20, 40, 80, 160 };

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected void Leveling(int expValue)
    {
        int i = 0;
        exp += expValue;
        if (exp >= upExp[i])
        {
            level++;
            i++;
        }
    }

    
}
