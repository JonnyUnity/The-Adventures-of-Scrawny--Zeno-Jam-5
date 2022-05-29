using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour
{

    [SerializeField] private GameObject _controlPanel;
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private GameObject _button3;

    public void HideControlPanel()
    {
        _controlPanel.SetActive(false);
    }

    public void BuildControlPanel(bool showButton1, bool showButton2, bool showButton3)
    {
        _controlPanel.SetActive(true);

        _button1.SetActive(showButton1);
        _button2.SetActive(showButton2);
        _button3.SetActive(showButton3);

    }

}