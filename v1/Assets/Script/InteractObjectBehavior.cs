using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectBehavior : MonoBehaviour 
{
    public bool isHeld = false;
    public GameObject[] placeHolders;
    public GameObject[] cubes;
    public GameObject cubeIHold;
    public RayCastMainCamera rayCastMainCamera;
    public float c;
    void Start()
    {

    }

    void Update()
    {

    }

    public void holdObject(GameObject ObjectIClicked)
    {
        if ((ObjectIClicked.layer==6 && isHeld) || !isHeld)
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
    public void ReloadAllCubePlaceHolder()
    {
        foreach(GameObject placeHolder in placeHolders)
        {
            bool thereIsACube = false;
            foreach(GameObject cube in cubes)
            {
                if (cube.transform.position == placeHolder.transform.position)
                {
                    thereIsACube = true;
                }
            }
            if (!thereIsACube)
            {
                placeHolder.SetActive(true);
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
        
        for (float t = c; t <= 1; t += c)
        {
            targetToMove.transform.position = Vector3.Lerp(a, b, t);
            yield return null;
        }
        rayCastMainCamera.mouseActive = true;
    }
    public IEnumerator SmoothPosForFunc(GameObject targetToMove, Vector3 a, Vector3 b)
    {
        //rayCastMainCamera.mouseActive = false;
        for (float t = c; t <= 1; t += c)
        {
            targetToMove.transform.position = Vector3.Lerp(a, b, t);
            yield return null;
        }
        //rayCastMainCamera.mouseActive = true;
    }

    public IEnumerator AnimPipette(GameObject ObjectIClicked)
    {
        rayCastMainCamera.mouseActive = false;

        //vas au dessus du becher
        Vector3 a = new Vector3(1f, -0.6f, -8f);
        Vector3 b = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y+2, ObjectIClicked.transform.position.z) ; 
        StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
        yield return new WaitForSeconds(0.3f);

        //vas dans le becher
        a = b;
        b = new Vector3(ObjectIClicked.transform.position.x, ObjectIClicked.transform.position.y +1.25f, ObjectIClicked.transform.position.z); 
        StartCoroutine(SmoothPosForFunc(cubeIHold, a, b));
        yield return new WaitForSeconds(0.3f);

        //pipette s'enfonce
        a = cubeIHold.transform.GetChild(0).position;
        b = new Vector3(cubeIHold.transform.GetChild(0).position.x, cubeIHold.transform.GetChild(0).position.y -0.25f, cubeIHold.transform.GetChild(0).position.z);
        StartCoroutine(SmoothPosForFunc(cubeIHold.transform.GetChild(0).gameObject, a, b));
        yield return new WaitForSeconds(0.3f);

        //pipette remonte
        StartCoroutine(SmoothPosForFunc(cubeIHold.transform.GetChild(0).gameObject, b, a));
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
}

