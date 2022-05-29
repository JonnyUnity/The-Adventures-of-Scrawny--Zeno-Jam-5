using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButton : MonoBehaviour
{

    //[SerializeField] private GameEvent _OnButtonActivated;
    //[SerializeField] private GameEvent _OnButtonDeactivated;

    [SerializeField] private EventChannelSO _OnButtonActivated;
    [SerializeField] private EventChannelSO _OnButtonDeactivated;

    [SerializeField] private Sprite _buttonIdle;
    [SerializeField] private Sprite _buttonPressed;
    [SerializeField] private SpriteRenderer _buttonRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _buttonRenderer.sprite = _buttonPressed;
        _OnButtonActivated.RaiseEvent();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _buttonRenderer.sprite = _buttonIdle;
        _OnButtonDeactivated.RaiseEvent();
    }


}