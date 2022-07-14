using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControls : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private EventChannelSO _restartLevel;
    [SerializeField] private EventChannelSO _reachedGoal;

    [SerializeField] private GameObject _controlPanel;


    private void OnEnable()
    {
        _reachedGoal.OnEventRaised += HideControls;
    }


    private void OnDisable()
    {
        _reachedGoal.OnEventRaised -= HideControls;
    }

    private void HideControls()
    {
        _controlPanel.SetActive(false);
    }

    public void RestartLevel()
    {
        _restartLevel.RaiseEvent();
    }

}
