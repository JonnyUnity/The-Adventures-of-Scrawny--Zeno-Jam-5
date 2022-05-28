using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class ControlPanelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void Setup(string description, UnityAction action)
    {
        _buttonText.text = description;
        Button button = GetComponent<Button>();
        button.onClick.AddListener(action);

    }

}
