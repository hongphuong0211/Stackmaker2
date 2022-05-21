using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager : MonoBehaviour
{
    public enum DataType
    {
        Integer,
        Float,
        String
    }

    public enum NumberUI
    {
        MainMenu,
        Shop,
        Settings,
        GamePlay,
        Pause,
        Results
    }
}
