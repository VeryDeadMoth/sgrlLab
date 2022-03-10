using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoPlaceholderScript : MonoBehaviour
{
    public GameObject balance;
    public float a = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetA()
    {
        a = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hi");
        if (balance.GetComponent<BalanceScript>().isOn)
        {
            //Debug.LogWarning(other);
            if (other.gameObject.CompareTag("InteractCube"))
            {
                //Debug.Log("fuck off");
                a = other.gameObject.GetComponent<MassCube>().g;
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
