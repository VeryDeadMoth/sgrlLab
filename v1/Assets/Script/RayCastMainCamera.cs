using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMainCamera : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    bool hasHit;
    public GameObject interactibleObject;
    public InteractObjectBehavior interactObjectBehavior;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hasHit = Physics.Raycast(ray, out hit);
        if (Input.GetMouseButtonDown(0))
        {
            if (hasHit)
            {
                Debug.Log(hit.transform.name);
                
                if (hit.transform.gameObject.CompareTag("InteractCube"))
                {
                    if(interactibleObject == null)
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
                        MassCube massCube = hit.transform.gameObject.GetComponent<MassCube>();
                        massCube.g += 50;
                        interactObjectBehavior.CallAnimPipette(hit.transform.gameObject);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("PlaceHolder"))
                {
                    if (interactibleObject != null) {
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
            }
        }


    }
}


