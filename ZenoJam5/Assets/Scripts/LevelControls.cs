using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControls : MonoBehaviour
{

    [SerializeField] private EventChannelSO _restartLevel;

    public void RestartLevel()
    {
        _restartLevel.RaiseEvent();
    }

}
