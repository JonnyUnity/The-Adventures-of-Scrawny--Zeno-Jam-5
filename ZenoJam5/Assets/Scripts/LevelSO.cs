using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Level Data/Level")]
public class LevelSO : ScriptableObject
{
    public AssetReference _sceneReference;
    public List<InteractableSO> _interactables;

}
