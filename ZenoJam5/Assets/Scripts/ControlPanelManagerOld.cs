using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelManagerOld : MonoBehaviour
{

    [SerializeField] private GameObject[] _interactables;
    [SerializeField] private GameObject _buttonPrefab;
    
    [SerializeField] private GameObject _controlPanel;
    [SerializeField] private Transform _buttonContainer;

    private List<GameObject> _controlButtons = new List<GameObject>();

    //private void Awake()
    //{
    //    BuildControlPanel();
    //}
    public void HideControlPanel()
    {
        _controlPanel.SetActive(false);
    }

    public void BuildControlPanel(GameObject[] interactables)
    {
        _controlPanel.SetActive(true);

        // empty out existing buttons
        foreach (GameObject controlButton in _controlButtons)
        {
            Destroy(controlButton);
        }
        
        foreach (var go in interactables)
        {
            var buttonObj = Instantiate(_buttonPrefab);

            var interactable = go.GetComponent<Interactable>();

            ControlPanelButton btn = buttonObj.GetComponent<ControlPanelButton>();
            btn.Setup(interactable.ControlPanelEventChannel);
            //btn.Setup(interactable.ButtonDescription, () => interactable.ControlPanelEventChannel.RaiseEvent());
            
            buttonObj.transform.SetParent(_buttonContainer);

            _controlButtons.Add(buttonObj);
        }
    }
}