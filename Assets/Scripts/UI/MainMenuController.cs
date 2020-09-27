using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Text maxLevel;
    [SerializeField]
    private Text maxScore;
    
    public void SetMainMenu()
    {
        maxLevel.text = "STAGE " + DataStorage.LoadIntData("Levels").ToString();
        maxScore.text = "SCORE " + DataStorage.LoadIntData("Knifes").ToString();
    }
}
