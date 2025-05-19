using UnityEngine;

[CreateAssetMenu(fileName = "UsingCatData", menuName = "CatData/Cat", order = int.MaxValue)]
public class UsingCat : ScriptableObject
{
    public int Number;
    public string Name;
    public int LEVEL;
    public int EXP;
    public int ATK;
    public int DEF;
    public int MaxHP;
    public int SPEED;
    public int SKILLPOINT;
}
