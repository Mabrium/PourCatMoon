using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class CharacterSpawner : MonoBehaviour
{
    private FirebaseFirestore db;
    DocumentReference docRef;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private GachaManager gachaManager;


    void Awake()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        StartRandomStatistics();
    }

    //나중에 캐릭터의 속성(달)에 따라 다르게 들어가는 수치로 바꾸기
    public void StartRandomStatistics()
    {
        characterData.atk = Random.Range(3, 6);
        characterData.def = Random.Range(4, 6);
        characterData.maxHp = Random.Range(23, 25);
        characterData.speed = Random.Range(10, 12);
    }

    public void SaveStatistics()
    {
        FirebaseInt.GACHAINT++;
        SwitchNumber(characterData.patName);
        characterData.DataUpdate();
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID);
        Dictionary<string, object> gachaInt = new()
        {{FirebaseString.GACHAINT, FirebaseInt.GACHAINT}};
        docRef.SetAsync(gachaInt).ContinueWithOnMainThread(task => { });
    }

    private void SwitchNumber(string name)
    {
        switch (name)
        {
            case "FirstQuarterCat": characterData.characterNumber = FirebaseInt.FirstQuarterCatNumber; break;
            case "NewMoonCat": characterData.characterNumber = FirebaseInt.NewMoonCatNumber; break;
            case "OldMoonCat": characterData.characterNumber = FirebaseInt.OldMoonCatNumber; break;
            case "ThirdQuarterCat": characterData.characterNumber = FirebaseInt.ThirdQuarterCatNumber; break;
            case "WCMoonCat": characterData.characterNumber = FirebaseInt.WCMoonCatNumber; break;
            case "WGMoonCat": characterData.characterNumber = FirebaseInt.WGMoonCatNumber; break;
            case "BloodMoonCat": characterData.characterNumber = FirebaseInt.BloodMoonCatNumber; break;
            case "BlueMoonCat": characterData.characterNumber = FirebaseInt.BlueMoonCatNumber; break;
            case "FullMoonCat": characterData.characterNumber = FirebaseInt.FullMoonCatNumber; break;
            case "LunarEclipseCat": characterData.characterNumber = FirebaseInt.LunarEclipseCatNumber; break;
            case "SolarEclipseCat": characterData.characterNumber = FirebaseInt.SolarEclipseCatNumber; break;
            case "SuperMoonCat": characterData.characterNumber = FirebaseInt.SuperMoonCatNumber; break;
            case "SBBMoonCat": characterData.characterNumber = FirebaseInt.SBBMoonCatNumber; break;
        }
    }

    //private List<string> AddNumberedSuffixes(List<string> input)
    //{
    //    Dictionary<string, int> countDict = new Dictionary<string, int>();
    //    List<string> output = new List<string>();

    //    foreach (string item in input)
    //    {
    //        if (!countDict.ContainsKey(item))
    //        {
    //            countDict[item] = 1;
    //        }
    //        else
    //        {
    //            countDict[item]++;
    //        }
    //        output.Add(item + countDict[item]);
    //    }
    //}
}