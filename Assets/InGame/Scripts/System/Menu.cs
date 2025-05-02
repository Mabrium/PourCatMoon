using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject Nl;
    public Animator animator;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ManuClick()
    {
        menuButton.SetActive(false);
        Nl.SetActive(true);
        //메뉴창 옆에서 나오는 애니메이션 실행
    }

    public void CloseMenu()
    {
        //임시 사용
        menuButton.SetActive(true);
        Nl.SetActive(false);
        //메뉴창이 다시 들어가는 애니메이션
    }
}
