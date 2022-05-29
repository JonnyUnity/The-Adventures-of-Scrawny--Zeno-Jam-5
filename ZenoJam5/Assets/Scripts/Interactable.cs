using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Generic Interactable Detail")]
    [SerializeField] private Sprite _numberSprite;
    [SerializeField] protected EventChannelSO _eventChannelForControlPanel;

    [SerializeField] private SpriteRenderer _numberRenderer;

    public EventChannelSO ControlPanelEventChannel
    {
        get
        {
            return _eventChannelForControlPanel;
        }
    }

    
    protected virtual void Awake()
    {
        _numberRenderer.sprite = _numberSprite;
    }


}