using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    private int attachedKnifes;
    [SerializeField]
    private Transform wheelHolder;
    [SerializeField]
    private GameObject wheel;
    [SerializeField] 
    private List<LevelAsset> wheelLevels;
    [SerializeField]
    private int levelIndex;

    public int GetLevelsCount()
    {
        return wheelLevels.Count > 0 ? wheelLevels.Count : 0;
    }
    public int GetLevelKnifes(int levelIndex)
    {
        return wheelLevels[levelIndex].knifesCount;
    }
    public void StopWheel(bool destroy)
    {
        StopAllCoroutines();
        if(destroy == true) 
            Destroy(wheel);
    }
    public void StartWheel(int levelIndex)
    {
        this.levelIndex = levelIndex;
        attachedKnifes = 0;
        wheel = Instantiate(wheelLevels[levelIndex].wheelPrefab, transform.position, Quaternion.identity);
        wheel.transform.SetParent(wheelHolder);
        StartCoroutine(Movement(levelIndex));
    }
    public void AttachKnife()
    {
        attachedKnifes += 1;
        if(attachedKnifes == wheelLevels[levelIndex].knifesCount)
        {
            LevelController.Instance.WinLevel();
        }
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
