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
        characterData = GetComponent<CharacterData>();
    }

    void Update()
    {
        
    }

    public void RandomStatistics()
    {
        characterData.atk = Random.Range(4, 6);
        characterData.def = Random.Range(3, 6);
        characterData.hp = Random.Range(14, 17);
    }

}
