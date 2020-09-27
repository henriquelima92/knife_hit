using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject defeatMenu;
    [SerializeField]
    private GameObject levelUI;


    public void PlayButton()
    {
        mainMenu.SetActive(false);
        levelUI.gameObject.SetActive(true);
        LevelController.Instance.ResetGame();
    }

}
