using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private GameObject ReinforceUI;

    public void UpgradeSkill()
    {
        ReinforceUI.SetActive(false);
        //��ȭ ��ƼŬ ����
        //��ȭ�� ��ų ��� �����ֱ�

    }

    public void CancelSkill()
    {
        ReinforceUI.SetActive(false);
    }
}
