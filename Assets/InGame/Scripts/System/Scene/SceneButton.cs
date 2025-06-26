using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    private string gachaScene = "GachaScene";
    private string character = "char";
    private string gacha = "Gacha";


    public void GachaScene()
    {
        SceneManager.LoadScene(gachaScene);
    }

    public void CharScene()
    {
        SceneManager.LoadScene(character);
    }

    public void Gacha()
    {
        SceneManager.LoadScene(gacha);
    }
}
