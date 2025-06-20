using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    private string gacha = "GachaScene";
    private string character = "char";
    private string gachaResult = "Gacha";


    public void GachaScene()
    {
        SceneManager.LoadScene(gacha);
    }

    public void CharScene()
    {
        SceneManager.LoadScene(character);
    }

    public void Gacha()
    {
        SceneManager.LoadScene(gachaResult);
    }
}
