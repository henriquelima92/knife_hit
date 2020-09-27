using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance; 
    [SerializeField]
    private int currentLevel = 0;
    [SerializeField]
    private KnifesController knifesController;
    [SerializeField]
    private WheelController wheelController;

    private void Awake()
    {
        Instance = this;
    }
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
        knifesController.Setup(wheelController.GetLevelKnifes(currentLevel));
    }
    private void NextLevel()
    {
        wheelController.StopWheel(true);
        if (currentLevel < wheelController.GetLevelsCount()-1)
        {
            currentLevel += 1;
            SetupLevel();
        }
    }
    public void WinLevel()
    {
        knifesController.Stop();
        NextLevel();
    }
    public void LooseLevel()
    {
        wheelController.StopWheel(false);
        knifesController.Stop();
    }
    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knifesController.ThrowKnife();
        }
    }
}
