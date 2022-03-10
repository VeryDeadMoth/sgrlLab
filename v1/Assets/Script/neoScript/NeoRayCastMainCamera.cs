using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoRayCastMainCamera : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    bool hasHit;
    
    public GameObject interactibleObject;
    public NeoInteractObject interactObjectBehavior;
    public bool mouseActive = true;

    float durationMove = 0.5f;
    float defaultZoom;
    float dep;
    float arr;
    bool isZoomedIn = false;
    public GameObject balance;
    public GameObject placeholderBalance;
    Vector3 init;

void Start(){
        defaultZoom = Camera.main.fieldOfView;
        dep = defaultZoom;
        arr = dep / 1.5f;
    }

void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hasHit = Physics.Raycast(ray, out hit);
        if (Input.GetMouseButtonDown(0) && mouseActive)
        {
            if (hasHit)
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.gameObject.CompareTag("InteractCube"))
                {
                    if (interactibleObject == null)
                    {
                        interactibleObject = hit.transform.gameObject;
                        //Debug.Log("you can interact with me");
                        {
                            interactObjectBehavior.holdObject(interactibleObject);
                            interactObjectBehavior.ReloadAllCubePlaceHolder();
                            interactibleObject.layer = 2;
                        }
                    }
                    else if (interactibleObject.CompareTag("pipette"))
                    {
                        //CHGMENT MASS CUBE
                        //get placeholder in public val
                        //modify a by new weight
                        MassCube massCube = hit.transform.gameObject.GetComponent<MassCube>();
                        massCube.g += 50;
                        if (balance.GetComponent<BalanceScript>().isOn)
                        {
                            balance.GetComponent<BalanceScript>().updatePoids(50);
                            //pb here
                            placeholderBalance.GetComponent<NeoPlaceholderScript>().a += massCube.g;
                        }
                        
                        interactObjectBehavior.CallAnimPipette(hit.transform.gameObject);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("PlaceHolderBecher"))
                {
                    if (interactibleObject != null && interactibleObject.CompareTag("InteractCube"))
                    {
                        interactibleObject.layer = 0;
                        //interactibleObject.transform.position = hit.transform.position;
                        interactObjectBehavior.holdObject(hit.transform.gameObject);
                        hit.transform.gameObject.SetActive(false);
                        interactibleObject = null;
                    }

                }
                else if (hit.transform.gameObject.CompareTag("PlaceHolderPipette"))
                {
                    if (interactibleObject != null && interactibleObject.CompareTag("pipette"))
                    {
                        interactibleObject.layer = 0;
                        //interactibleObject.transform.position = hit.transform.position;
                        interactObjectBehavior.holdObject(hit.transform.gameObject);
                        hit.transform.gameObject.SetActive(false);
                        interactibleObject = null;
                    }

                }
                else if (hit.transform.CompareTag("pipette") && interactibleObject == null)
                {
                    interactibleObject = hit.transform.gameObject;
                    interactObjectBehavior.holdObject(interactibleObject);
                    interactObjectBehavior.ReloadAllCubePlaceHolder();
                }
                else if (hit.transform.CompareTag("bin"))
                {
                    if (interactibleObject.CompareTag("InteractCube"))
                    {
                        MassCube massCube = interactibleObject.GetComponent<MassCube>();
                        massCube.g = 0;
                    }
                }
                else if (hit.transform.CompareTag("balance")&&!isZoomedIn)
                {
                    isZoomedIn = true;
                    //call coroutine
                    StopAllCoroutines();
                    init = new Vector3(balance.transform.position.x, 0, Camera.main.transform.position.z);
                    StartCoroutine(MoveCamera(Camera.main.fieldOfView, arr,Camera.main.transform.position,init));
                    
                }
            }
            if (isZoomedIn&&!hasHit)
            {
                isZoomedIn = false;
                StopAllCoroutines();
                init = new Vector3(0.73f, 1, Camera.main.transform.position.z);
                StartCoroutine(MoveCamera(Camera.main.fieldOfView, dep, Camera.main.transform.position, init));
            }
        }


    }

    IEnumerator MoveCamera(float targetDep, float targetArr, Vector3 initPos, Vector3 endPos)
    {
        float timeSince = 0;
        while (timeSince < durationMove)
        {
            defaultZoom = Mathf.Lerp(targetDep, targetArr, timeSince / durationMove);
            Camera.main.transform.position= Vector3.Lerp(initPos,endPos,timeSince/durationMove);
            timeSince += Time.deltaTime;
            Camera.main.fieldOfView = (defaultZoom);
            //Debug.Log(defaultZoom);
            yield return null;
        }
        Camera.main.transform.position = endPos;
        defaultZoom = targetArr;
    }
}
