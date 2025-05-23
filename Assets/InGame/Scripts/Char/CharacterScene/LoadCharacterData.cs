using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Extensions;
using Firebase.Firestore;
using Firebase;

public class LoadCharacterData : MonoBehaviour
{
    private FirebaseFirestore db;
    private DocumentReference doRef;
    private CharacterData characterData;

    [SerializeField] private string patName;

    public int atk;
    public int def;
    public int hp;
    public int speed;

    void Start()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
    }

    void Update()
    {
        
    }

    private void LoadData()
    {
        doRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID).Collection(FirebaseString.CharacterData).Document(patName).Collection(patName + characterData.characterNumber).Document(patName + characterData.characterNumber + "Data");
        doRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();

            atk = TUtil.GetValue<int>(Data, FirebaseString.ATK);
            def = TUtil.GetValue<int>(Data, FirebaseString.DEF);
            hp = TUtil.GetValue<int>(Data, FirebaseString.MAXHP);
            speed = TUtil.GetValue<int>(Data, FirebaseString.SPEED);

        });
    }
}
