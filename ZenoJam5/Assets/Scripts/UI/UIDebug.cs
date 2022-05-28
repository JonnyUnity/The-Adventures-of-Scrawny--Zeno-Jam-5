using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDebug : MonoBehaviour
{

    [SerializeField] private GameObject _testObject;

    public void SwivelLightSource()
    {
        _testObject.transform.Rotate(new Vector3(0, 0, 90));

    }


    public void TestHatch()
    {
        var hatch = _testObject.GetComponent<Hatch>();
        hatch.ToggleHatch();
    }

}
