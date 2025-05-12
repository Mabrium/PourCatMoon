using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;

    void Awake()
    {

    }

    void Start()
    {
        StartRandomStatistics();
    }

    void Update()
    {
        
    }

    //나중에 캐릭터의 속성(달)에 따라 다르게 들어가는 수치로 바꾸기
    public void StartRandomStatistics()
    {
        characterData.atk = Random.Range(3, 6);
        characterData.def = Random.Range(4, 6);
        characterData.maxHp = Random.Range(23, 25);
        characterData.speed = Random.Range(10, 12);
    }

    public void SaveStatistics()
    {

    }

}
