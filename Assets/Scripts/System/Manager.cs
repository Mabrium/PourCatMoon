using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    private Stack<string> sceneHistory = new Stack<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴 방지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    #region 씬
    /// <summary>
    /// 다른 씬으로 넘어가는데 전 화면으로 돌아가기가 필요하면 사용
    /// </summary>
    public void LoadScene(string sceneName)
    {
        // 현재 씬 이름 저장
        string currentScene = SceneManager.GetActiveScene().name;
        sceneHistory.Push(currentScene);

        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 현재 씬에서 기존 씬으로 돌아가기
    /// </summary>
    public void GoBack()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop();
            SceneManager.LoadScene(previousScene);
        }
        if (sceneHistory.Count == 0)
        {
            //종료한거냐 묻는 UI 띄우고 OK 누르면 아래 코드로 닫기
            //Application.Quit();
        }
    }
    #endregion
}
