using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer wheelSpriteRenderer;
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
    }

    private void StartLevel(int levelIndex)
    {
        wheelSpriteRenderer.transform.eulerAngles = Vector3.zero;
        wheelSpriteRenderer.color = wheelLevels[levelIndex].color;
        wheelSpriteRenderer.sprite = wheelLevels[levelIndex].sprite;
        StartCoroutine(Movement(levelIndex));
    }
    private IEnumerator Movement(int levelIndex)
    {
        float movementTime = 0f;
        while (true)
        {
            movementTime += Time.deltaTime;
            wheelSpriteRenderer.transform.eulerAngles = new Vector3(0f, 0f, wheelLevels[levelIndex].curve.Evaluate(movementTime));
            yield return null;
        }
    }
}
