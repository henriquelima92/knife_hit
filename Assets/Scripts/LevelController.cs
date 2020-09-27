using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private int currentLevel = 0;
    [SerializeField]
    private KnifesController knifesController;
    [SerializeField]
    private WheelController wheelController;

    private void Start()
    {
        SetupLevel();
    }
    private void Update()
    {
        Inputs();
    }
    private void SetupLevel()
    {
        wheelController.StartWheel(currentLevel);
        knifesController.SetLevelKnifes(wheelController.GetLevelKnifes(currentLevel));
    }
    private void NextLevel()
    {
        wheelController.StopWheel(currentLevel);
        if (currentLevel < wheelController.GetLevelsCount()-1)
        {
            currentLevel += 1;
            SetupLevel();
        }
    }
    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knifesController.ThrowKnife();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            NextLevel();
        }
    }
}
