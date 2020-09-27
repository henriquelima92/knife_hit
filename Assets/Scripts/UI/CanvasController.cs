using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;

    [SerializeField]
    private MainMenuController mainMenu;
    [SerializeField]
    private GameObject defeatMenu;
    [SerializeField]
    private GameObject levelUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        mainMenu.SetMainMenu();
    }

    public void ShowDefeatMenu(int totalLevels)
    {
        defeatMenu.SetActive(true);
        levelUI.SetActive(false);
        DefeatMenuController.Instance.SetLevelsDefeatMenu(totalLevels);
    }
    public void HomeButton()
    {
        defeatMenu.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        mainMenu.SetMainMenu();
    }
    public void RestartButton()
    {
        defeatMenu.SetActive(false);
        levelUI.gameObject.SetActive(true);
        LevelController.Instance.ResetGame();
    }

    public void PlayButton()
    {
        mainMenu.gameObject.SetActive(false);
        levelUI.gameObject.SetActive(true);
        LevelController.Instance.ResetGame();
    }

}
