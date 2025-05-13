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

    void Start()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
    }

    private void LoadData()
    {
        DocumentReference docRef = db.Collection(FirebaseString.PlayerID).Document(Manager.userID);
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task => {
            var snapshot = task.Result;
            var Data = snapshot.ToDictionary();
            FirebaseInt.GACHAINT = GetValue<int>(Data, FirebaseString.GACHAINT);

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
