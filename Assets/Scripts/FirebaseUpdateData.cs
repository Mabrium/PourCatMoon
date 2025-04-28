using UnityEngine;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Collections.Generic;
using System;

public class FirebaseUpdateData : MonoBehaviour
{
    private FirebaseFirestore db;

    // 캐릭터 속성
    public int atk = 50;
    public int def = 30;
    public int hp = 100;
    public float speed = 5.5f;
    public int speedValue = 10;

    void Start()
    {
        InitializeFirebase();
    }

    // Firebase 초기화
    void InitializeFirebase()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        TestFirestore();
    }

    // Firestore에 데이터 쓰기 및 읽기 테스트
    void TestFirestore()
    {
        // 예시로 playerId 1, characterId 2를 사용
        int playerId = 1;
        int characterId = 2;

        //WriteCharacterData(playerId, characterId);
        ReadCharacterData(playerId, characterId);
    }

    // 캐릭터 데이터 Firestore에 쓰기
    void WriteCharacterData(int playerId, int characterId)
    {
        // playerId에 맞춰서 "players" 컬렉션을 생성하고 그 아래 "characters" 컬렉션에 "character_{characterId}" 문서를 추가
        DocumentReference docRef = db.Collection("players").Document($"player_{playerId}")
                                       .Collection("characters").Document($"character_{characterId}");

        Dictionary<string, object> character = new()
        {
            { "atk", atk },
            { "def", def },
            { "hp", hp },
            { "speed", speed },
            { "speedValue", speedValue }
        };

        docRef.SetAsync(character).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                // 오류가 발생했을 때만 출력
                Debug.LogError("Error writing character data: " + task.Exception);
            }
        });
    }

    // Firestore에서 캐릭터 데이터 읽기
    void ReadCharacterData(int playerId, int characterId)
    {
        // playerId에 맞춰서 "players" 컬렉션을 생성하고 그 아래 "characters" 컬렉션에 "character_{characterId}" 문서를 조회
        DocumentReference docRef = db.Collection("players").Document($"player_{playerId}")
                                       .Collection("characters").Document($"character_{characterId}");

        // 강제로 서버에서 데이터를 읽어오기
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error getting character data: " + task.Exception);
            }
            else
            {
                var snapshot = task.Result;
                var characterData = snapshot.ToDictionary();

                // 효율적인 데이터 읽기 및 타입 변환
                atk = GetValue<int>(characterData, "atk");
                def = GetValue<int>(characterData, "def");
                hp = GetValue<int>(characterData, "hp");
                speed = GetValue<float>(characterData, "speed");
                speedValue = GetValue<int>(characterData, "speedValue");
            }
        });
    }

    // 제네릭 메소드로 데이터를 읽고, 타입에 맞게 변환
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
