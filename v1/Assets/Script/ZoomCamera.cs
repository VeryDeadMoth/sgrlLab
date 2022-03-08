using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{

    float defaultZoom;
    float dep;
    float arr;
    bool isZoomedIn;
    float durationMove = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        defaultZoom = Camera.main.fieldOfView;
        dep = defaultZoom;
        arr = dep / 2;
        isZoomedIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomedIn = !isZoomedIn;
            StopAllCoroutines();

            if (isZoomedIn)
            {
                StartCoroutine(MoveCamera(Camera.main.fieldOfView, dep));
               
            }
            else
            {
                StartCoroutine(MoveCamera(Camera.main.fieldOfView, arr));
            }
        }

    }

    IEnumerator MoveCamera(float targetDep, float targetArr)
    {
        float timeSince = 0;
        while (timeSince < durationMove)
        {
            defaultZoom = Mathf.Lerp(targetDep, targetArr, timeSince / durationMove);
            timeSince += Time.deltaTime;
            Camera.main.fieldOfView = (defaultZoom);
            //Debug.Log(defaultZoom);
            yield return null;
        }
        defaultZoom = targetArr;
    }
}