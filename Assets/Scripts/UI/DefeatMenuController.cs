using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatMenuController : MonoBehaviour
{
    public static DefeatMenuController Instance;

    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text hitKnifesText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SetKnifesDefeatMenu(int knifes)
    {
        hitKnifesText.text = (knifes-1).ToString();
    }
    public void SetLevelsDefeatMenu(int level)
    {
        levelText.text = "STAGE " + level.ToString();
    }
}
