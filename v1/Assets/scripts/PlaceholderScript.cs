using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceholderScript : MonoBehaviour
{
    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractCube"))
        {
            float a = other.gameObject.GetComponent<CubeScript>().poids;
            if (a < 10)
            {
                txt.GetComponent<TMPro.TextMeshProUGUI>().text = "0"+a+"g";
            }
            else
            {
                //txt.GetComponent<TMPro.TextMeshProUGUI>().text = a+"g";
                txt.text= a + "g";
                Debug.Log(txt.text);
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        txt.text = "00,0g";
    }
}
