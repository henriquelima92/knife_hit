using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanelController : MonoBehaviour
{
    public static BottomPanelController Instance;
    [SerializeField]
    private List<Toggle> knifes;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetNewAttachedKnife()
    {
        for (int index = 0; index < knifes.Count; index++)
        {
            if(knifes[index].gameObject.activeInHierarchy == true && knifes[index].isOn == false)
            {
                knifes[index].isOn = true;
                return;
            }
        }
    }
    public void SetKnifes(int count)
    {
        for (int index = 0; index < knifes.Count; index++)
        {
            knifes[index].isOn = false;
            knifes[index].gameObject.SetActive(false);
        }
        for (int index = 0; index < count; index++)
        {
            knifes[index].gameObject.SetActive(true);
        }
    }
}
