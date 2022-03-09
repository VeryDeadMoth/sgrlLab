using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class BalanceScript : MonoBehaviour
{
    public float currentPoids=0;
    public bool isOn = false;
    public TMP_Text txt;
    public UnityEvent resetWeightA;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvertIsOn()
    {
        isOn = !isOn;
        if (!isOn)
        {
            currentPoids = 0;
            txt.text = currentPoids + "g";
            //can remove for TARE
            //resetWeightA.Invoke();
        }
    }

    public void updatePoids(float p)
    {
        currentPoids += p;
        txt.text = currentPoids + "g";
    }

    public void TARE()
    {
        currentPoids = 0;
        txt.text = currentPoids + "g";
    }
}
