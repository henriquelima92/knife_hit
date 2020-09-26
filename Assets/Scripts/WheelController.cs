using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    private Transform wheelHolder;
    [SerializeField]
    private GameObject wheel;
    [SerializeField] 
    private List<WheelAsset> wheelLevels;
    [SerializeField]
    private int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            StopLevel();
            if (currentLevel + 1 < wheelLevels.Count)
            {
                currentLevel += 1;
                StartLevel(currentLevel);
            }
        }
    }
    private void StopLevel()
    {
        StopAllCoroutines();
        Destroy(wheel);
    }

    private void StartLevel(int levelIndex)
    {
        wheel = Instantiate(wheelLevels[levelIndex].prefab, Vector3.zero, Quaternion.identity);
        wheel.transform.SetParent(wheelHolder);
        StartCoroutine(Movement(levelIndex));
    }
    private IEnumerator Movement(int levelIndex)
    {
        float movementTime = 0f;
        while (true)
        {
            movementTime += Time.deltaTime;
            wheel.transform.eulerAngles = new Vector3(0f, 0f, wheelLevels[levelIndex].curve.Evaluate(movementTime));
            yield return null;
        }
    }
}
