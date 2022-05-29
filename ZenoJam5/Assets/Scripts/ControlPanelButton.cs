using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System;

public class ControlPanelButton : MonoBehaviour
{
    [SerializeField] private Sprite _buttonNormal;
    [SerializeField] private Sprite _buttonPressed;
    [SerializeField] private AudioClip _buttonPressedClip;

    [SerializeField] private EventChannelSO _toggleItem;
    [SerializeField] private EventChannelSO _reachedGoal;
    [SerializeField] private EventChannelSO _loadLevel; 

    private bool _isDepressed;
    private Button _button;
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _reachedGoal.OnEventRaised += DisableButton;
        _loadLevel.OnEventRaised += EnableButton;
        
    }

    private void OnDisable()
    {
        _reachedGoal.OnEventRaised -= DisableButton;
        _loadLevel.OnEventRaised -= EnableButton;
    }

    private void EnableButton()
    {
        _button.interactable = true;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Setup(EventChannelSO eventChannel)
    {
        //Button button = GetComponent<Button>();
        //button.onClick.AddListener(action);
        _toggleItem = eventChannel;
    }


    public void ToggleButton()
    {
        _audioSource.PlayOneShot(_buttonPressedClip);

        _isDepressed = !_isDepressed;
        _button.image.sprite = _isDepressed ? _buttonPressed : _buttonNormal;
        _toggleItem.RaiseEvent();

    }

    private void DisableButton()
    {
        _button.interactable = false;
    }

}
