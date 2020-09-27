using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataStorage
{
    public static void SaveIntData(string key, int value)
    {
        if(PlayerPrefs.HasKey(key) == false)
            PlayerPrefs.SetInt(key, value);
        else
        {
            int lastValue = PlayerPrefs.GetInt(key);
            if(value > lastValue)
                PlayerPrefs.SetInt(key, value);
        }
        
    }
    public static int LoadIntData(string key)
    {
        int value = PlayerPrefs.GetInt(key);
        if(PlayerPrefs.HasKey(key) == true)
            return value;
        return 0;
    }

}
