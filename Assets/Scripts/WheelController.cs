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
    private LevelSelector levelSelector;
    [SerializeField]
    private LevelAsset currentLevel;

    public int GetLevelKnifes()
    {
        return currentLevel.knifesCount;
    }
    public void StopWheel(bool destroy)
    {
        StopAllCoroutines();
        if(destroy == true) 
            Destroy(wheel);
    }
    public void StartWheel(int levelIndex)
    {
        currentLevel = levelSelector.GetRandomLevel(levelIndex);
        attachedKnifes = 0;
        wheel = Instantiate(currentLevel.wheelPrefab, transform.position, Quaternion.identity);
        wheel.transform.SetParent(wheelHolder);
        StartCoroutine(Movement());
    }
    public void AttachKnife()
    {
        attachedKnifes += 1;
        if(attachedKnifes == currentLevel.knifesCount)
        {
            LevelController.Instance.WinLevel();
        }
    }
    private IEnumerator Movement()
    {
        float movementTime = 0f;
        while (true)
        {
            movementTime += Time.deltaTime;
            wheel.transform.eulerAngles = new Vector3(0f, 0f, currentLevel.curve.Evaluate(movementTime));
            yield return null;
        }
    }
}
