using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WheelAsset", order = 1)]
public class WheelAsset : ScriptableObject
{
    public Color color;
    public Sprite sprite;
    public AnimationCurve curve;
}
