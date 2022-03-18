using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoInteractObject : MonoBehaviour
{
    public bool isHeld = false;
    public GameObject[] placeHolders;
    public GameObject[] cubes;
    public GameObject cam;
    public GameObject cubeIHold;
    public NeoRayCastMainCamera rayCastMainCamera;
    public float animationDuration = 2.0f;
    public AnimationCurve animationCurve;
    public float c;

    private Vector3 baseCamPos;
    void Awake()
    {
        baseCamPos = cam.transform.position;
    }

    public void holdObject(GameObject ObjectIClicked)
    {
        if ((ObjectIClicked.layer == 6 && isHeld) || !isHeld)
        {

            isHeld = !isHeld;
            if (isHeld)
            {
                StopAllCoroutines();
                Vector3 a = ObjectIClicked.transform.position;
                Vector3 b = new Vector3(1f, -0.6f, -8f);
                cubeIHold = ObjectIClicked;
                StartCoroutine(SmoothPos(ObjectIClicked, a, b));

                //ObjectIClicked.transform.position = new Vector3(1f, -0.6f, -8f);
            }
            else
            {
                StopAllCoroutines();
                Vector3 a = cubeIHold.transform.position;
                Vector3 b = ObjectIClicked.transform.position;
                StartCoroutine(SmoothPos(cubeIHold, a, b));
                cubeIHold = null;
            }
        }

    }
    public void CallAnimPipette(GameObject ObjectIClicked)
    {
        StopAllCoroutines();
        StartCoroutine(AnimPipette(ObjectIClicked));
    }

    public IEnumerator SmoothPos(GameObject targetToMove, Vector3 a, Vector3 b)
    {
        rayCastMainCamera.mouseActive = false;

        float startTime = Time.realtimeSinceStartup;
        float currentTimePercentage = (animationDuration > 0.0f) ? ((Time.realtimeSinceStartup - startTime) / animationDuration) : (1.0f);
        while (currentTimePercentage <= 1.0f)
        {
            targetToMove.transform.position = Vector3.Lerp(a, b, animationCurve.Evaluate(currentTimePercentage));
            yield return null;
            currentTimePercentage = (animationDuration > 0.0f) ? ((Time.realtimeSinceStartup - startTime) / animationDuration) : (1.0f);
        }

        rayCastMainCamera.mouseActive = true;
    }
    public IEnumerator SmoothPosForFunc(GameObject targetToMove, Vector3 a, Vector3 b)
    {
        float startTime = Time.realtimeSinceStartup;
        float currentTimePercentage = (animationDuration > 0.0f) ? ((Time.realtimeSinceStartup - startTime) / animationDuration) : (1.0f);
        while (currentTimePercentage <= 1.0f)
        {
            targetToMove.transform.position = Vector3.Lerp(a, b, animationCurve.Evaluate(currentTimePercentage));
            yield return null;
            currentTimePercentage = (animationDuration > 0.0f) ? ((Time.realtimeSinceStartup - startTime) / animationDuration) : (1.0f);
        }
    }

    public IEnumerator AnimPipette(GameObject ObjectIClicked)
    {
        rayCastMainCamera.mouseActive = false;
        //vas au dessus du becher
        Vector3 a = new Vector3(1f, -0.6f, -8f);
        Vector3 b = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y + 2, ObjectIClicked.transform.position.z);
        StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
        yield return new WaitForSeconds(animationDuration);

        //vas dans le becher
        a = b;
        b = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y + 1.25f, ObjectIClicked.transform.position.z);
        StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
        yield return new WaitForSeconds(animationDuration);

        //zoom
        a = cam.transform.position;
        b = new Vector3(cubeIHold.transform.GetChild(0).position.x, cubeIHold.transform.GetChild(0).position.y, cubeIHold.transform.GetChild(0).position.z - 2);
        StartCoroutine(SmoothPosForFunc(cam, a, b));
        yield return new WaitForSeconds(animationDuration);

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray;
                RaycastHit hit;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool hasHit = Physics.Raycast(ray, out hit);
                if (hasHit)
                {
                    //pipette s'enfonce
                    a = cubeIHold.transform.GetChild(0).position;
                    b = new Vector3(cubeIHold.transform.GetChild(0).position.x, cubeIHold.transform.GetChild(0).position.y - 0.25f, cubeIHold.transform.GetChild(0).position.z);
                    StartCoroutine(SmoothPosForFunc(cubeIHold.transform.GetChild(0).gameObject, a, b));
                    yield return new WaitForSeconds(animationDuration);
                    //masse s'ajoute
                    AtributeCube massCube = ObjectIClicked.GetComponent<AtributeCube>();
                    massCube.g += 50;
                    //pipette remonte
                    StartCoroutine(SmoothPosForFunc(cubeIHold.transform.GetChild(0).gameObject, b, a));
                    yield return new WaitForSeconds(animationDuration);

                    //dezoom
                    a = cam.transform.position;
                    b = baseCamPos;
                    StartCoroutine(SmoothPosForFunc(cam, a, b));
                    yield return new WaitForSeconds(animationDuration);

                    //sors du becher
                    a = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y + 1.25f, ObjectIClicked.transform.position.z);
                    b = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y + 2, ObjectIClicked.transform.position.z);
                    StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
                    yield return new WaitForSeconds(animationDuration);

                    //revient dans la main
                    a = b;
                    b = new Vector3(1f, -0.6f, -8f);
                    StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
                    rayCastMainCamera.mouseActive = true;


                }
                else
                {

                    //dezoom
                    a = cam.transform.position;
                    b = baseCamPos;
                    StartCoroutine(SmoothPosForFunc(cam, a, b));
                    yield return new WaitForSeconds(0.3f);

                    //sors du becher
                    a = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y + 1.25f, ObjectIClicked.transform.position.z);
                    b = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y + 2, ObjectIClicked.transform.position.z);
                    StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
                    yield return new WaitForSeconds(0.3f);

                    //revient dans la main
                    a = b;
                    b = new Vector3(1f, -0.6f, -8f);
                    StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
                    rayCastMainCamera.mouseActive = true;
                }
                yield break;
            }
            yield return null;
        }

    }
}
