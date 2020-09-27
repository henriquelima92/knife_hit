using UnityEngine;

[System.Serializable]
public class LevelSelector
{
    [SerializeField]
    private Level level1;
    [SerializeField]
    private Level level2;
    [SerializeField]
    private Level level3;
    [SerializeField]
    private Level level4;
    [SerializeField]
    private Level level5;

    public LevelAsset GetRandomLevel(int levelIndex)
    {
        switch(levelIndex)
        {
            case 0:
                return level1.levels.PickRandom();
            case 1:
                return level2.levels.PickRandom();
            case 2:
                return level3.levels.PickRandom();
            case 3:
                return level4.levels.PickRandom();
            case 4:
                return level5.levels.PickRandom();
        }
        return null;
    }
}
