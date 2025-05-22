using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] bhButton;
    [SerializeField] private GameObject Nl;
    public Animator animator;

    private string menuAnimationBool = "MenuOn";

    public void ManuClick()
    {
        for(int i = 0; i < bhButton.Length; i++)
        {
            bhButton[i].SetActive(false);
        }
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
        for (int i = 0; i < bhButton.Length; i++)
        {
            bhButton[i].SetActive(true);
        }
    }
}
