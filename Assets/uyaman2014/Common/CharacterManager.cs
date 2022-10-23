using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterManager
{
    public static List<GameObject> HinaObjects = new List<GameObject>();
    public static GameObject OyaObject;
    public static void ResetObjects()
    {
        HinaObjects.Clear();
        OyaObject = null;
    }
}
