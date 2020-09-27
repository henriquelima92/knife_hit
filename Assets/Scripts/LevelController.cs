using System.Collections;
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
    private int totalBonus = 0;
    [SerializeField]
    private KnifesController knifesController;
    [SerializeField]
    private WheelController wheelController;

    private bool hasLost = false;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        totalBonus = DataStorage.LoadIntData("Bonus");
    }

    private void Update()
    {
        Inputs();
    }

    public void SetBonus()
    {
        totalBonus += 1;
        DataStorage.SaveIntData("Bonus", totalBonus);
        PersistenceInfoController.Instance.SetBonus(totalBonus);
    }
    public void ResetGame()
    {
        knifesController.gameObject.SetActive(true);
        wheelController.gameObject.SetActive(true);

        currentLevel = 0;
        totalLevels = 0;
        hasLost = false;
        knifesController.DestroyKnifes();
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
        if(hasLost == false)
        {
            knifesController.Stop();
            StartCoroutine(Utilities.StartMethodWithDelay(2f, NextLevel));
        }
    }
    public void LooseLevel()
    {
        hasLost = true;
        CanvasController.Instance.ShowDefeatMenu(totalLevels+1);
        DataStorage.SaveIntData("Levels", totalLevels + 1);
        wheelController.LooseGame();
        knifesController.DestroyKnifes();
    }
}
