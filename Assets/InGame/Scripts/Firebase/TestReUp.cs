using System.Collections.Generic;
using UnityEngine;

public class TestReUp : MonoBehaviour
{
    // 개별 유닛 데이터
    class UnitData
    {
        public string id; // 예: a1, a2
        public int atk;
        public int def;
        public int hp;

        // 복사 생성자
        public UnitData CloneWithNewID(string newID)
        {
            return new UnitData
            {
                id = newID,
                atk = this.atk,
                def = this.def,
                hp = this.hp
            };
        }
    }

    Dictionary<char, List<UnitData>> alphabetData = new Dictionary<char, List<UnitData>>();

    void Start()
    {
        GenerateRandomData(20);
        PrintData();

        // a2 삭제 및 재정렬
        RemoveAndShift('a', "a2");
        PrintData();
    }

    void GenerateRandomData(int count)
    {
        for (int i = 0; i < count; i++)
        {
            AddRandomEntry();
        }
    }

    void AddRandomEntry()
    {
        char randomChar = (char)Random.Range('a', 'z' + 1);

        if (!alphabetData.ContainsKey(randomChar))
            alphabetData[randomChar] = new List<UnitData>();

        int index = alphabetData[randomChar].Count + 1;
        string id = randomChar + index.ToString();

        UnitData newUnit = new UnitData
        {
            id = id,
            atk = Random.Range(10, 100),
            def = Random.Range(5, 50),
            hp = Random.Range(50, 200)
        };

        alphabetData[randomChar].Add(newUnit);
    }

    void RemoveAndShift(char alphabet, string targetId)
    {
        if (!alphabetData.ContainsKey(alphabet)) return;

        List<UnitData> list = alphabetData[alphabet];
        int removeIndex = list.FindIndex(data => data.id == targetId);

        if (removeIndex == -1)
        {
            Debug.LogWarning($"'{targetId}' not found.");
            return;
        }

        list.RemoveAt(removeIndex);

        // 당기기 시작: removeIndex부터 끝까지 id를 다시 부여
        List<UnitData> shiftedList = new List<UnitData>();
        for (int i = 0; i < list.Count; i++)
        {
            string newID = alphabet + (i + 1).ToString();
            shiftedList.Add(list[i].CloneWithNewID(newID));
        }

        alphabetData[alphabet] = shiftedList;
    }

    void PrintData()
    {
        Debug.Log("==== 데이터 목록 ====");
        foreach (var pair in alphabetData)
        {
            Debug.Log($"[{pair.Key}]");

            foreach (var unit in pair.Value)
            {
                Debug.Log($"{unit.id} | ATK: {unit.atk}, DEF: {unit.def}, HP: {unit.hp}");
            }
        }
    }
}