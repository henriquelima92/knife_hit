using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WheelAsset", order = 1)]
public class WheelAsset : ScriptableObject
{
    public GameObject prefab;
    public AnimationCurve curve;
}
