using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] 
    private List<WheelMotion> motions;
    [SerializeField]
    private int currentMotionIndex = 0;
    [SerializeField]
    private bool isMoving = true;
    [SerializeField]
    private float movementTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Movement()
    {
        while(isMoving == true)
        {
            movementTime += Time.deltaTime;
            transform.eulerAngles = new Vector3(0f, 0f, motions[currentMotionIndex].curve.Evaluate(movementTime));
            yield return null;
        }
    }
}
