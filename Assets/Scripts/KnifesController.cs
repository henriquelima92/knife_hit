using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesController : MonoBehaviour
{
    [SerializeField]
    private List<Knife> knifes;
    [SerializeField]
    private int currentKnife = -1;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            if(currentKnife+1 < knifes.Count)
            {
                currentKnife += 1;
                StartCoroutine(knifes[currentKnife].Throw());
            }
        }
    }
}
