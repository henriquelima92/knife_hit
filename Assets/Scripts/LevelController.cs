﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance; 
    [SerializeField]
    private int currentLevel = 0;
    [SerializeField]
    private int totalLevels = 0;
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
        ResetGame();
    }
    private void Update()
    {
        Inputs();
    }

    private void ResetGame()
    {
        currentLevel = 0;
        totalLevels = 0;
        knifesController.ResetGame();
        wheelController.ResetGame();
        SetupLevel();
    }
    private void SetupLevel()
    {
        wheelController.StartWheel(currentLevel);
        knifesController.Setup(wheelController.GetLevelKnifes());
        if (currentLevel != 4)
            TopPanelController.Instance.SetLevelText(totalLevels + 1);
        else
            TopPanelController.Instance.SetBossLevelText(wheelController.GetBossLevelName());
        TopPanelController.Instance.SetLevels(currentLevel + 1);
    }
    private void NextLevel()
    {
        wheelController.StopWheel(true);
        if (currentLevel < 4)
            currentLevel += 1;
        else
            currentLevel = 0;

        totalLevels += 1;
        SetupLevel();
    }
    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knifesController.ThrowKnife();
        }
    }

    public void WinLevel()
    {
        knifesController.Stop();
        StartCoroutine(Utilities.StartMethodWithDelay(2f, NextLevel));
    }
    public void LooseLevel()
    {
        wheelController.StopWheel(false);
        knifesController.Stop();
        StartCoroutine(Utilities.StartMethodWithDelay(2f, ResetGame));
    }
}
