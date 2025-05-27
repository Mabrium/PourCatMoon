using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Firestore;
using Firebase.Extensions;
using Firebase;

public class TestStatUpload : MonoBehaviour
{
    public List<int> number = new List<int> { };
    private FirebaseFirestore db;
    private DocumentReference docRef;

    void Start()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
    }

    void Update()
    {
        
    }

    private void RandomGacha(int gachaCount)
    {
        for (int i = 0; i < gachaCount; i++)
        {

        }
    }

    private void DeleteData()
    {

    }

    private void CreateData()
    {

    }


}
