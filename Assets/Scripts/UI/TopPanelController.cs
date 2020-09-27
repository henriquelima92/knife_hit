using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanelController : MonoBehaviour
{
    public static TopPanelController Instance;

    [SerializeField]
    private Text totalKnifesHit;
    [SerializeField]
    private Text totalBonusHit;
    
    [SerializeField]
    private List<Toggle> levels;
    [SerializeField]
    private Text levelText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetLevelText(int currentLevel)
    {
        levelText.text = "STAGE " + currentLevel.ToString();
    }
    public void SetBossLevelText(string bossName)
    {
        levelText.text = "BOSS " + bossName.ToUpper();
    }
    public void SetLevels(int currentLevel)
    {
        for (int index = 0; index < levels.Count; index++)
        {
            levels[index].isOn = false;
        }
        for (int index = 0; index < currentLevel; index++)
        {
            levels[index].isOn = true;
        }
    }
    public void SetTotalKnifesHit(int knifesHit)
    {
        totalKnifesHit.text = knifesHit.ToString();
    }
    public void SetTotalBonusHit(int bonusHit)
    {
        totalBonusHit.text = bonusHit.ToString();
    }
}
