using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginRemember : MonoBehaviour
{
    public Login login;
    [SerializeField] private Toggle toggle;

    int yes = 0;
    void Awake()
    {
        yes = PlayerPrefs.GetInt("YesNo", login.RememberYesNo);
        if (yes == 1)
        {
            toggle.isOn = true;
        }
    }
    public void RememberLogin()
    {
        login.IDPW();
        PlayerPrefs.SetString("ID", login.userID);
        PlayerPrefs.SetString("PW", login.password);
        if (toggle.isOn)
        {
            login.RememberYesNo = 1;
            PlayerPrefs.SetInt("YesNo", login.RememberYesNo);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
