using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private CharacterData characterData;

    void Awake()
    {
        characterData = GetComponent<CharacterData>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RandomStatistics()
    {
        characterData.hp = Random.Range(14, 17);
        characterData.atk = Random.Range(4, 6);
        characterData.def = Random.Range(3, 6);
    }
}
