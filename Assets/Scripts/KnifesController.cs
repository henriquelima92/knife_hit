using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesController : MonoBehaviour
{
    [SerializeField]
    private bool canThrow = false;
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private int levelKnifesCount;
    [SerializeField]
    private int knifesCount = 0;

    private GameObject currentKnifeObject;
    private Knife currentKnife;

    private void InstantiateKnife()
    {
        currentKnifeObject = Instantiate(knife, transform.position, Quaternion.identity);
        currentKnife = currentKnifeObject.GetComponent<Knife>();
    }
    public void ResetGame()
    {
        if (currentKnifeObject != null)
            Destroy(currentKnifeObject);
    }
    public void Setup(int count)
    {
        levelKnifesCount = count;
        knifesCount = 0;
        canThrow = true;
        InstantiateKnife();
    }
    public void Stop()
    {
        canThrow = false;
    }
    public void ThrowKnife()
    {
        if((knifesCount < levelKnifesCount) && canThrow == true)
        {
            StartCoroutine(currentKnife.Throw());
            knifesCount += 1;
            if(knifesCount < levelKnifesCount)
                InstantiateKnife();
        }
    }
}
