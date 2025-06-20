using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;


public static class GachaSelect
{
    public static bool gacha10pOption;
}

public class SelectGacha : MonoBehaviour
{
    private FirebaseFirestore db;
    DocumentReference docRef;
    private void Awake()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        GetNumberData();
    }

    public void BoolOnOff(bool onoff)
    {
        GachaSelect.gacha10pOption = onoff;
    }

    public void GetNumberData()
    {
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.SBBMoonCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.SBBMoonCatNumber = TUtil.GetValue<int>(Data, FirebaseString.SBBMoonCat);
            Debug.Log("SBBMoonCat " + FirebaseInt.SBBMoonCatNumber);
        });
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.SolarEclipseCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.SolarEclipseCatNumber = TUtil.GetValue<int>(Data, FirebaseString.SolarEclipseCat);
            Debug.Log("SolarEclipseCatNumber " + FirebaseInt.SolarEclipseCatNumber);
        });
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.FullMoonCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.FullMoonCatNumber = TUtil.GetValue<int>(Data, FirebaseString.FullMoonCat);
            Debug.Log("FullMoonCatNumber " + FirebaseInt.FullMoonCatNumber);
        });
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.SuperMoonCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.SuperMoonCatNumber = TUtil.GetValue<int>(Data, FirebaseString.SuperMoonCat);
            Debug.Log("SuperMoonCatNumber " + FirebaseInt.SuperMoonCatNumber);
        });
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.LunarEclipseCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.LunarEclipseCatNumber = TUtil.GetValue<int>(Data, FirebaseString.LunarEclipseCat);
            Debug.Log("LunarEclipseCatNumber " + FirebaseInt.LunarEclipseCatNumber);
        });
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.BlueMoonCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.BlueMoonCatNumber = TUtil.GetValue<int>(Data, FirebaseString.BlueMoonCat);
            Debug.Log("BlueMoonCatNumber " + FirebaseInt.BlueMoonCatNumber);
        });
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(FirebaseString.BloodMoonCat);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.BloodMoonCatNumber = TUtil.GetValue<int>(Data, FirebaseString.BloodMoonCat);
            Debug.Log("BloodMoonCatNumber " + FirebaseInt.BloodMoonCatNumber);
        });
    }
}