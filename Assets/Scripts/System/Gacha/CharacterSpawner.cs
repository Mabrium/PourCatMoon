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
        //characterData = GetComponent<CharacterData>();
    }

    void Update()
    {
        
    }

    //나중에 캐릭터의 속성(달)에 따라 다르게 들어가는 수치로 바꾸기
    public void RandomStatistics()
    {
        characterData.atk = Random.Range(4, 6);
        characterData.def = Random.Range(3, 6);
        characterData.hp = Random.Range(14, 17);
        characterData.speed = Random.Range(10, 11);
    }

}
