using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GachaSelect
{
    public static bool gacha10pOption;
}

public class SelectGacha : MonoBehaviour
{
    public void BoolOnOff(bool onoff)
    {
        GachaSelect.gacha10pOption = onoff;
    }
}