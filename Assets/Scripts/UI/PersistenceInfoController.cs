using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistenceInfoController : MonoBehaviour
{
    public static PersistenceInfoController Instance;
    [SerializeField]
    private Text totalBonus;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        totalBonus.text = DataStorage.LoadIntData("Bonus").ToString();
    }

    public void SetBonus(int bonus)
    {
        totalBonus.text = bonus.ToString();
    }
}
