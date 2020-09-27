using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    private Transform wheelHolder;
    [SerializeField]
    private GameObject wheel;
    [SerializeField] 
    private List<LevelAsset> wheelLevels;

    public int GetLevelsCount()
    {
        return wheelLevels.Count > 0 ? wheelLevels.Count : 0;
    }
    public int GetLevelKnifes(int levelIndex)
    {
        return wheelLevels[levelIndex].knifesCount;
    }
    public void StopWheel(int levelIndex)
    {
        StopAllCoroutines();
        Destroy(wheel);
    }
    public void StartWheel(int levelIndex)
    {
        wheel = Instantiate(wheelLevels[levelIndex].wheelPrefab, Vector3.zero, Quaternion.identity);
        wheel.transform.SetParent(wheelHolder);
        StartCoroutine(Movement(levelIndex));
    }
    private IEnumerator Movement(int levelIndex)
    {
        float movementTime = 0f;
        while (true)
        {
            movementTime += Time.deltaTime;
            wheel.transform.eulerAngles = new Vector3(0f, 0f, wheelLevels[levelIndex].curve.Evaluate(movementTime));
            yield return null;
        }
    }
}
