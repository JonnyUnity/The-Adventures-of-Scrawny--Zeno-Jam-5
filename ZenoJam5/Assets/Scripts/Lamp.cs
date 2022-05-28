using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{

    [SerializeField] private Transform _lightStart;
    [SerializeField] private GameObject _light;

    private List<GameObject> _lightPaths;


    private bool _lightOn = true;


    private LineRenderer _lineRenderer;
    [SerializeField] private int _maxReflections;
    [SerializeField] private float _maxLightDistance;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }


    private void Start()
    {
        _lightPaths = new List<GameObject>();
        DrawLight();
    }


    private void DrawLightDebug()
    {
        Vector2 lightPosition = _lightStart.position;
        Vector2 lightDirection = -transform.up;

        int reflectionCount = 0;
        //RaycastHit2D rayCastHit;
        float lightDistanceRemaining = _maxLightDistance;

        List<RaycastHit2D> results = new List<RaycastHit2D>();
        ContactFilter2D cf = new ContactFilter2D();
        cf.NoFilter();

        while (reflectionCount < _maxReflections)
        {

            RaycastHit2D hit = Physics2D.Raycast(lightPosition, lightDirection, lightDistanceRemaining);

            Debug.DrawLine(lightPosition, hit.point, Color.red);
            lightDistanceRemaining -= hit.distance;


            var collider = hit.collider;
            if (collider == null)
            {
                Debug.DrawLine(lightPosition, lightDirection * lightDistanceRemaining, Color.green);
                break;
            }


            if (collider.CompareTag("Reflective"))
            {
                Vector2 incVec = hit.point - lightPosition;
                lightPosition = hit.point;
                lightDirection = Vector2.Reflect(incVec, hit.normal);

                //Debug.DrawLine(rayCastHit.point, lightDirection, Color.green);

            }
            else
            {
                break;
            }

            //if (hit)
            //{

            //    Debug.DrawLine(lightPosition, hit.point, Color.red);
            //    lightDistanceRemaining -= hit.distance;


            //    var collider = hit.collider;
            //    if (collider == null)
            //    {
            //        Debug.DrawLine(lightPosition, lightDirection * lightDistanceRemaining, Color.green);
            //        break;
            //    }


            //    if (collider.CompareTag("Reflective"))
            //    {
            //        Vector2 incVec = (Vector2)hit.point - lightPosition;
            //        lightPosition = hit.point;
            //        lightDirection = Vector2.Reflect(incVec, hit.normal);

            //        //Debug.DrawLine(rayCastHit.point, lightDirection, Color.green);

            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //else
            //{
            //    Debug.Log("No hits!");
            //}

            //int blah = Physics2D.Raycast(lightPosition, lightDirection, cf, results, lightDistanceRemaining);


            //if (results.Count == 0)
            //{
            //    Debug.Log("No hits!");
            //}

            //Debug.DrawLine(lightPosition, rayCastHit.point, Color.red);
            //lightDistanceRemaining -= rayCastHit.distance;


            //var collider = rayCastHit.collider;
            //if (collider == null)
            //{
            //    Debug.DrawLine(lightPosition, lightDirection * lightDistanceRemaining, Color.green);
            //    break;
            //}


            //if (collider.CompareTag("Reflective"))
            //{
            //    Vector2 incVec = rayCastHit.point - lightPosition;
            //    lightPosition = rayCastHit.point;
            //    lightDirection = Vector2.Reflect(incVec, rayCastHit.normal);

            //    //Debug.DrawLine(rayCastHit.point, lightDirection, Color.green);

            //}
            //else
            //{
            //    break;
            //}




            reflectionCount++;
        }

    }

    private void DrawLight()
    {
        RaycastHit2D rayCastHit;

        if (_lightOn)
        {

            int reflectionCount = 0;
            //Debug.DrawRay(_lightStart.position, transform.up * -10f);

            Vector2 lightPosition = _lightStart.position;
            Vector2 lightDirection = -transform.up;

            //_lineRenderer.positionCount++;
            //_lineRenderer.SetPosition(0, lightPosition);
            float lightDistanceRemaining = _maxLightDistance;

            while (reflectionCount < _maxReflections)
            {
                
                rayCastHit = Physics2D.Raycast(lightPosition, lightDirection, lightDistanceRemaining);
                //Debug.DrawRay(lightPosition, lightDirection * rayCastHit.distance, Color.red);
                Debug.DrawLine(lightPosition, rayCastHit.point, Color.red);

                var collider = rayCastHit.collider;
                if (collider == null)
                {
                    break;
                }

                //_lineRenderer.positionCount++;
                //_lineRenderer.SetPosition(reflectionCount + 1, rayCastHit.point);

                // create lightpath
                Quaternion rotation = Quaternion.LookRotation(rayCastHit.normal);

                Vector2 lightRayPos = (lightPosition + rayCastHit.point) / 2;
                var lightRay = Instantiate(_light, lightRayPos, rotation);

                //lightRay.transform.position = lightRayPos;
                
                Vector2 incVec = rayCastHit.point - lightPosition;
                //lightRay.transform.LookAt(rayCastHit.point, Vector2.up);
                Debug.Log(incVec);
                lightRay.transform.up = incVec;
                //lightRay.transform.rotation = Quaternion.Euler(incVec.x, incVec.y, 0);

                lightRay.transform.localScale = new Vector2(lightRay.transform.localScale.x, rayCastHit.distance);

                _lightPaths.Add(lightRay);
                lightDistanceRemaining -= rayCastHit.distance;


                if (collider.CompareTag("Reflective"))
                {
                    lightPosition = rayCastHit.point;
                    lightDirection = Vector2.Reflect(incVec, rayCastHit.normal);

                }
                else
                {
                    break;
                }


                reflectionCount++;
            }



        }
        else
        {
            _lightPaths.ForEach(f => Destroy(f));
        }
    }

    private void Update()
    {
        DrawLightDebug();
    }


    public void ToggleLamp()
    {
        _lightOn = !_lightOn;
        DrawLight();
    }



}
