using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelAsset", order = 1)]
public class LevelAsset : ScriptableObject
{
    public GameObject wheelPrefab;
    public AnimationCurve curve;
    public int knifesCount;
    public string bossName;
}
