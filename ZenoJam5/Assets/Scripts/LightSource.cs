using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{

    [SerializeField] private Transform _destination;


    public Vector2 Destination
    {
        get
        {
            return _destination.position;
        }
    }


}