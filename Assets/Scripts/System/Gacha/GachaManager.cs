using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public GameObject[] characterSpawners;
    public List<CharacterSpawner> spawners = new List<CharacterSpawner>();
    void Start()
    {
        PrefabMove();
    }

    void Update()
    {

    }

    private void PrefabMove()
    {

        //크게 바꾸기 이게 실행되면 프리팹 10개의 생성하고 생성할 때 마다 그 데이터를 저장하기

        //10뽑일 때
        if (GachaSelect.gacha10pOption)
        {
            for (int i = 0; i < characterSpawners.Length; i++)
            {
                spawners.Add(characterSpawners[i].GetComponent<CharacterSpawner>());
            }
            Debug.Log("10뽑");
        }
        //1뽑일 때
        else if (!GachaSelect.gacha10pOption)
        {
            spawners.Add(characterSpawners[0].GetComponent<CharacterSpawner>());
            Debug.Log("1뽑");
        }
    }
}
