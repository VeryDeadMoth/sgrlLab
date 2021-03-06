using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceholderScript : MonoBehaviour
{
    //public TMP_Text txt;
    public GameObject balance;
    float a=0;
    
    // Start is called before the first frame update

    public void resetA()
    {
        a = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (balance.GetComponent<BalanceScript>().isOn)
        {
            if (other.gameObject.CompareTag("InteractCube"))
            {
                a = other.gameObject.GetComponent<CubeScript>().poids;
                balance.GetComponent<BalanceScript>().updatePoids(a);
                //txt.text = balance.GetComponent<BalanceScript>().currentPoids + "g";
                //Debug.Log(txt.text);
                

            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (balance.GetComponent<BalanceScript>().isOn)
        {
            balance.GetComponent<BalanceScript>().updatePoids(-a);
            //txt.text = balance.GetComponent<BalanceScript>().currentPoids + "g";
            
        }
    }

}
