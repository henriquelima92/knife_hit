using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject defeatMenu;
    [SerializeField]
    private GameObject levelUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ShowDefeatMenu(int totalLevels)
    {
        defeatMenu.SetActive(true);
        levelUI.SetActive(false);
        DefeatMenuController.Instance.SetLevelsDefeatMenu(totalLevels + 1);
    }
    public void HomeButton()
    {
        defeatMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void RestartButton()
    {
        defeatMenu.SetActive(false);
        levelUI.gameObject.SetActive(true);
        LevelController.Instance.ResetGame();
    }

    public void PlayButton()
    {
        mainMenu.SetActive(false);
        levelUI.gameObject.SetActive(true);
        LevelController.Instance.ResetGame();
    }

}
