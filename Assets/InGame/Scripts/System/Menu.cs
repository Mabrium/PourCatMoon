using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject Nl;
    public Animator animator;

    private string menuAnimationBool = "MenuOn";
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
        animator.SetBool(menuAnimationBool, true);
    }

    public void CloseMenu()
    {
        Nl.SetActive(false);
        animator.SetBool(menuAnimationBool, false);
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(0.5f);
        menuButton.SetActive(true);
    }
}
