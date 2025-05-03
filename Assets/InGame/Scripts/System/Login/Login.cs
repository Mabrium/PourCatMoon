using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using System;
using System.Collections.Generic;

using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;


public class Login : MonoBehaviour
{
    private FirebaseFirestore db;
    [SerializeField] private TMP_InputField[] inputField;
    public string UserID;
    public string Password;

    private string MainScene = "MainScene";
    public int RememberYesNo;
    void Start()
    {
        db = FirebaseFirestore.GetInstance(FirebaseApp.DefaultInstance);
        RememberYesNo = PlayerPrefs.GetInt("YesNo", RememberYesNo);
        if(RememberYesNo == 1)
        {
            inputField[0].text = PlayerPrefs.GetString("ID");
            inputField[1].text = PlayerPrefs.GetString ("PW");
        }
    }

    private void UserSignUp()
    {
        DocumentReference docRef = db.Collection($"{FirebaseString.PlayerID}").Document(UserID).Collection($"{FirebaseString.Profile}").Document($"{UserID}IDPW");
        Dictionary<string, object> UserData = new()
        {
            { FirebaseString.UserID, UserID },
            { FirebaseString.Password, Password }
        };
        docRef.SetAsync(UserData).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error writing character data: " + task.Exception);
            }
        });
    }

    public void UserLogin()
    {
        IDPW();
        string readID;
        string readPW;
        DocumentReference docRef = db.Collection($"{FirebaseString.PlayerID}").Document(UserID).Collection($"{FirebaseString.Profile}").Document($"{UserID}IDPW");
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error getting character data: " + task.Exception);
            }
            else
            {
                var snapshot = task.Result;
                if (!snapshot.Exists)
                {
                    Debug.Log("잘못 되었거나 없습니다");
                    return;
                }
                var Data = snapshot.ToDictionary();
                readID = GetValue<string>(Data, FirebaseString.UserID);
                readPW = GetValue<string>(Data, FirebaseString.Password);

                if (UserID == readID && Password == readPW)
                {
                    Debug.Log("같음");
                    SceneManager.LoadScene(MainScene);
                }
                else if(UserID != readID || Password != readPW)
                {
                    Debug.Log("다름");
                }
            }
        });
    }

    public void IDPW()
    {
        UserID = inputField[0].GetComponent<TMP_InputField>().text;
        Password = inputField[1].GetComponent<TMP_InputField>().text;
    }

    public void IDCheck()
    {
        string readID;
        IDPW();
        DocumentReference docRef = db.Collection($"{FirebaseString.PlayerID}").Document(UserID).Collection($"{FirebaseString.Profile}").Document($"{UserID}IDPW");
        docRef.GetSnapshotAsync(Source.Server).ContinueWithOnMainThread(task => {
            var snapshot = task.Result;
            if (!snapshot.Exists)
            {
                UserSignUp();
            }
            var Data = snapshot.ToDictionary();
            readID = GetValue<string>(Data, FirebaseString.UserID);
            if (UserID == readID)
            {
                Debug.Log("안돼");
            }
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
