using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupScript : MonoBehaviour
{
    public Camera cam;
    public string phrase;
    public TextMeshPro textMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = phrase;
        textMesh.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit && hit.collider.gameObject == transform.gameObject)
        {
            textMesh.transform.gameObject.SetActive(true);
        }
        else
        {
            textMesh.transform.gameObject.SetActive(false);
        }
    }
}
