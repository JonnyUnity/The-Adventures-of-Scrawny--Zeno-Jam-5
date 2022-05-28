using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private GameObject _platform;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pauseBeforeMovingAgain;

    private Vector2 _destination;
    private Transform _transform;
    private Transform _platformTransform;
    private bool _isActive;

    private void Awake()
    {
        _transform = transform;
        _platformTransform = _platform.transform;
        _isActive = true;
        _destination = _endPosition.position;
    }


    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(MovePlatformCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!_isActive)
            return;

        _platformTransform.position = Vector2.MoveTowards(_platformTransform.position, _destination, _moveSpeed * Time.deltaTime);

        if ((Vector2)_platformTransform.position == _destination)
        {
            SetNextDestination();


        }


    }

    public void StopPlatform()
    {
        _isActive = false;
        StopAllCoroutines();

    }

    private IEnumerator MovePlatformCoroutine()
    {

        while (_isActive)
        {
            float dist = Vector2.Distance(_platformTransform.position, _destination);
            float moveTime = dist / _moveSpeed;
            float currentMoveTime = 0;
            Debug.Log(moveTime);


            while (currentMoveTime < moveTime)
            {

                _platformTransform.position = Vector2.Lerp(_platformTransform.position, _destination, currentMoveTime / moveTime);
                //Debug.Log(_platformTransform.position + " " + _destination);
                currentMoveTime += Time.deltaTime;

                yield return null;
            }

            _platformTransform.position = _destination;

            SetNextDestination();
            yield return new WaitForSeconds(_pauseBeforeMovingAgain);


        }




    }


    private void SetNextDestination()
    {
        if (_destination == (Vector2)_startPosition.position)
        {
            _destination = _endPosition.position;
        }
        else
        {
            _destination = _startPosition.position;
        }
    }


}
