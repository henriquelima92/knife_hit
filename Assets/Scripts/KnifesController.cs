using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesController : MonoBehaviour
{
    [SerializeField]
    private List<Knife> knifes;
    [SerializeField]
    private int levelKnifesCount;
    [SerializeField]
    private int knifesCount = 0;

    private Knife GetKnifeObject()
    {
        for (int index = 0; index < knifes.Count; index++)
        {
            if (knifes[index].gameObject.activeInHierarchy && knifes[index].GetHasHit() == false)
            {
                return knifes[index];
            }
        }
        return null;
    }
    public void ThrowKnife()
    {
        if(knifesCount < levelKnifesCount)
        {
            StartCoroutine(GetKnifeObject().Throw());
            knifesCount += 1;
        }
    }
    public void SetLevelKnifes(int levelKnifes)
    {
        knifesCount = 0;
        levelKnifesCount = levelKnifes;
        for (int index = 0; index < levelKnifesCount; index++)
        {
            knifes[index].gameObject.SetActive(true);
            knifes[index].transform.SetParent(transform);
            knifes[index].transform.localPosition = Vector3.zero;
            knifes[index].transform.localEulerAngles = Vector3.zero;
            knifes[index].KnifeSetup();
        }
    }
}
