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
    public bool mouseActive = true;
    public SpinSquare spinSquare;
    public GameObject spin;

    public AudioSource audioSource;
    public AudioClip amoi;
    public AudioClip yeet;
    public AudioClip aaah;
    void Update()
    {
        
        if (mouseActive && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                Debug.Log(hit.transform.name);
                
                if (hit.transform.gameObject.CompareTag("InteractCube"))
                {
                    if(interactibleObject == null)
                    {
                        interactibleObject = hit.transform.gameObject;
                        spin.SetActive(true);
                        spinSquare.fiole = interactibleObject;
                        //Debug.Log("you can interact with me");
                        audioSource.PlayOneShot(amoi);
                        interactObjectBehavior.holdObject(interactibleObject);
                        interactibleObject.GetComponent<AtributeCube>().ShowPlaceHolder();
                        interactibleObject.layer = 2;
                    }
                    else if (interactibleObject.CompareTag("pipette"))
                    {
                        /*MassCube massCube = hit.transform.gameObject.GetComponent<MassCube>();
                        massCube.g += 50;*/

                        interactObjectBehavior.CallAnimPipette(hit.transform.gameObject);
                        audioSource.PlayOneShot(aaah);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("PlaceHolderBecher"))
                {
                    if (interactibleObject != null && interactibleObject.CompareTag("InteractCube"))
                    {
                        spin.SetActive(false);
                        spinSquare.fiole = null;
                        interactibleObject.layer = 0;
                        //interactibleObject.transform.position = hit.transform.position;
                        interactObjectBehavior.holdObject(hit.transform.gameObject);
                        interactibleObject.GetComponent<AtributeCube>().HidePlaceHolder(hit.transform.gameObject);
                        interactibleObject = null;
                    }

                }
                else if (hit.transform.gameObject.CompareTag("PlaceHolderPipette"))
                {
                    if (interactibleObject != null && interactibleObject.CompareTag("pipette")) {
                        interactibleObject.layer = 0;
                        //interactibleObject.transform.position = hit.transform.position;
                        interactObjectBehavior.holdObject(hit.transform.gameObject);
                        interactibleObject.GetComponent<AtributeCube>().HidePlaceHolder(hit.transform.gameObject);
                        interactibleObject = null;
                    }
                    
                }
                else if (hit.transform.CompareTag("pipette") && interactibleObject == null)
                {
                    audioSource.PlayOneShot(amoi);
                    interactibleObject = hit.transform.gameObject;
                    interactObjectBehavior.holdObject(interactibleObject);
                    interactibleObject.GetComponent<AtributeCube>().ShowPlaceHolder();
                }
                else if (hit.transform.CompareTag("bin"))
                {
                    if (interactibleObject.CompareTag("InteractCube"))
                    {
                        audioSource.PlayOneShot(yeet);
                        AtributeCube massCube = interactibleObject.GetComponent<AtributeCube>();
                        massCube.g = 0;
                    }
                }
            }
        }
    }
}


