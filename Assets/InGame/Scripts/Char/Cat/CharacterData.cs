using UnityEngine;

using System;
using System.Collections.Generic;

using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class CharacterData : MonoBehaviour
{
    [Header("Name")]
    [SerializeField] private string Name;

    [Space(4f)]
    private FirebaseFirestore db;
    DocumentReference docRef;

    [Header("Statistics")]
    [SerializeField] private int level = 1;
    [SerializeField] private int exp;
    public int atk;
    public int def;
    public int maxHp;
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
        speedValue = UnityEngine.Random.Range(0, 3);
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


    public void DataUpdate()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(Name).Collection(Name + FirebaseInt.GACHAINT).Document(Name + FirebaseInt.GACHAINT + "Data");
        Dictionary<string, object> characterData = new()
        {
            {FirebaseString.LEVEL, level},
            {FirebaseString.EXP, exp},
            {FirebaseString.SKILLPOINT, skillPoint},
            {FirebaseString.ATK, atk},
            {FirebaseString.DEF, def},
            {FirebaseString.MAXHP, maxHp},
            {FirebaseString.SPEED, speed}
        };
        docRef.SetAsync(characterData).ContinueWithOnMainThread(task => { });
        print(FirebaseInt.GACHAINT);
    }

    public void DataLoad()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(Name).Collection(Name + FirebaseInt.GACHAINT).Document(Name + FirebaseInt.GACHAINT + "Data");
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            level = GetValue<int>(Data, FirebaseString.LEVEL);
            exp = GetValue<int>(Data, FirebaseString.EXP);
            skillPoint = GetValue<int>(Data, FirebaseString.SKILLPOINT);
            atk = GetValue<int>(Data, FirebaseString.ATK);
            def = GetValue<int> (Data, FirebaseString.DEF);
            maxHp = GetValue<int>(Data, FirebaseString.MAXHP);
            speed = GetValue<int>(Data, FirebaseString.SPEED);
        });
    }

    T GetValue<T>(Dictionary<string, object> data, string key)
    {
        if (data.ContainsKey(key))
        {
            try
            {
                return (T)Convert.ChangeType(data[key], typeof(T)); // 타입에 맞게 변환
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error converting {key}: {ex.Message}");
            }
        }
        else
        {
            // 키가 없을 경우 경고 메시지 출력
            Debug.LogWarning($"Key {key} not found in Firestore data.");
        }
        return default(T); // 기본값 반환 (값이 없거나 변환 실패 시)
    }
}
