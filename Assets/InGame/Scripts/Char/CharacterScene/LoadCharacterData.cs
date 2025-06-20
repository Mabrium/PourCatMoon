using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Firebase.Extensions;
using Firebase.Firestore;
using Firebase;

public class LoadCharacterData : MonoBehaviour
{
    private FirebaseFirestore db;
    private DocumentReference doRef;
    private CharacterData characterData;

    [SerializeField] private TextMeshProUGUI[] tmp;
    [SerializeField] private string patName;

    public int atk;
    public int def;
    public int hp;
    public int speed;

    void Start()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        LoadData();
    }

    void Update()
    {
        
    }

    private void LoadData()
    {
        //Debug.Log(FirebaseString.PlayerID);
        //Debug.Log(Manager.userID);
        //Debug.Log(FirebaseString.CharacterData);
        //Debug.Log(patName);
        Debug.Log(patName + characterData.characterNumber);
        Debug.Log(patName + characterData.characterNumber + "Data");
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

        TMPChange();
    }

    private void TMPChange()
    {
        tmp[0].text = atk.ToString();
        tmp[1].text = def.ToString();
        tmp[2].text = hp.ToString();
        tmp[3].text = speed.ToString();
    }
}
