using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Load Event Channel")]
public class LoadEventChannelSO : ScriptableObject
{

    public UnityAction<LevelSO, bool> _OnLoadingRequested;


    public void RaiseEvent(LevelSO levelToLoad, bool fadeScreen = false)
    {
        _OnLoadingRequested?.Invoke(levelToLoad, fadeScreen);
    }

}
