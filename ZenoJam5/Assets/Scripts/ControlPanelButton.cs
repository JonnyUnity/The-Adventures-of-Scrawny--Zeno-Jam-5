using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class ControlPanelButton : MonoBehaviour
{
    [SerializeField] private Sprite _buttonNormal;
    [SerializeField] private Sprite _buttonPressed;
    [SerializeField] private EventChannelSO _toggleItem;

    private bool _isDepressed;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Setup(EventChannelSO eventChannel)
    {
        //Button button = GetComponent<Button>();
        //button.onClick.AddListener(action);
        _toggleItem = eventChannel;
    }


    public void ToggleButton()
    {
        _isDepressed = !_isDepressed;
        _button.image.sprite = _isDepressed ? _buttonPressed : _buttonNormal;
        _toggleItem.RaiseEvent();

    }

}
