using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using System;

public class GachaInt : MonoBehaviour
{
    private FirebaseFirestore db;
    private DocumentReference docRef;

    void Awake()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        LoadData();
    }

    private void LoadData()
    {
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.GACHAINT = TUtil.GetValue<int>(Data, FirebaseString.GACHAINT);
        });
    }


}
