using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;
//using System;

using System.Collections.Generic;

using UnityEngine;

public class GachaManager : MonoBehaviour
{
    private FirebaseFirestore db;
    DocumentReference docRef;

    private GameObject cat;
    public GameObject[] prefabObject;
    public GameObject alpha;
    [SerializeField] private RectTransform rectTransform;

    public List<CharacterSpawner> spawners = new List<CharacterSpawner>();

    private int i = 0;

    private void Awake()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        CheckGachaInt();
        PrefabMove();
    }

    void Update()
    {

    }

    private void PrefabMove()
    {
        //10ªÃ¿œ ∂ß
        int num = 0;
        int ma = 300;
        if (GachaSelect.gacha10pOption)
        {
            for (i = 1; i < 11; i++)
            {
                RandomSpawn();
                cat.transform.localPosition = new Vector3(-700f + (num * 350f), ma, 0);
                num++;
                if(i == 5)
                {
                    num = 0;
                    ma = -165;
                }
            }
        }
        //1ªÃ¿œ ∂ß
        else if (!GachaSelect.gacha10pOption)
        {
            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        int value = Random.Range(0, 1001);
        if(value < 5)
        {
            Spawn(0);
        }
        else if (value >= 5 &&  value < 400)
        {
            int a = Random.Range(1, 4);
            Spawn(a);
        }
        else if(value >= 400 &&  value <= 1000)
        {
            int b = Random.Range(4, 7);
            Spawn(b);
        }
    }

    private void Spawn(int spawnNumber)
    {
        cat = Instantiate(prefabObject[spawnNumber], rectTransform.anchoredPosition, Quaternion.identity, rectTransform.transform);
        CharacterSpawner PrefabScript = cat.GetComponent<CharacterSpawner>();
        spawners.Add(PrefabScript);
    }

    private void CheckGachaInt()
    {
        docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task =>
        {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.GACHAINT = TUtil.GetValue<int>(Data, FirebaseString.GACHAINT);
        });
    }


    public void TouchCard()
    {
        alpha.SetActive(!alpha.activeSelf);
    }

}
