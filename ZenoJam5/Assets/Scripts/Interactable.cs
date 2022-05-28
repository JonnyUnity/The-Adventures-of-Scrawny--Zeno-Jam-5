using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Generic Interactable Detail")]
    [SerializeField] private string _buttonDescription;
    [SerializeField] private EventChannelSO _eventChannelForControlPanel;

    public string ButtonDescription
    {
        get
        {
            return _buttonDescription;
        }
    }

    public EventChannelSO ControlPanelEventChannel
    {
        get
        {
            return _eventChannelForControlPanel;
        }
    }


    //// Start is called before the first frame update
    //protected virtual void Start()
    //{

    //}

    //// Update is called once per frame
    //protected virtual void Update()
    //{

    //}
}
