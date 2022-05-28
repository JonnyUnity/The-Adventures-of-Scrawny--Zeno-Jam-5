using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _interactables;
    [SerializeField] private GameObject _buttonPrefab;
    
    [SerializeField] private GameObject _controlPanel;
    [SerializeField] private Transform _buttonContainer;

    private void Awake()
    {
        BuildControlPanel();
    }


    private void BuildControlPanel()
    {
        foreach (var go in _interactables)
        {
            var buttonObj = Instantiate(_buttonPrefab);

            var interactable = go.GetComponent<Interactable>();

            ControlPanelButton btn = buttonObj.GetComponent<ControlPanelButton>();
            btn.Setup(interactable.ButtonDescription, () => interactable.ControlPanelEventChannel.RaiseEvent());
            
            buttonObj.transform.SetParent(_buttonContainer);

        }
    }
}