using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    private int randFight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ç®½£¿¡ ´ê¾ÒÀ» ¶§ ·£´ý ÀçÈ¸
    private void OnTriggerEnter2D(Collider2D collision)
    {
        randFight = Random.Range(0, 100);
        if(randFight >= 90)
        {
            Fight();
        }
    }

    private void Fight()
    {
        Debug.Log("Fight");
    }
}
