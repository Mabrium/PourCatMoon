using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    private GameObject cat;
    public GameObject[] prefabObject;
    public GameObject alpha;
    [SerializeField] private RectTransform rectTransform;

    public List<CharacterSpawner> spawners = new List<CharacterSpawner>();

    private int i = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

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
        int num = 0;
        int ma = 300;
        if (GachaSelect.gacha10pOption)
        {
            for (i = 1; i < 11; i++)
            {
                RandomSpawn();
                cat.transform.localPosition = new Vector3(-700f + (num * 350f), ma, 0);
                num++;
                if(i == 5)
                {
                    num = 0;
                    ma = -165;
                }
            }
        }
        //1뽑일 때
        else if (!GachaSelect.gacha10pOption)
        {
            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        int value = Random.Range(0, 1001);
        print(value);
        if(value < 10)
        {
            Spawn(0);
        }
        else if (value >= 10 &&  value < 400)
        {
            int a = Random.Range(1, 4);
            Spawn(a);
        }
        else if(value >= 400 &&  value <= 1000)
        {
            int b = Random.Range(4, 7);
            Spawn(b);
        }
    }

    private void Spawn(int spawnNumber)
    {
        cat = Instantiate(prefabObject[spawnNumber], rectTransform.anchoredPosition, Quaternion.identity, rectTransform.transform);
        CharacterSpawner PrefabScript = cat.GetComponent<CharacterSpawner>();
        spawners.Add(PrefabScript);
    }


    public void TouchCard()
    {
        alpha.SetActive(!alpha.activeSelf);
    }

}
