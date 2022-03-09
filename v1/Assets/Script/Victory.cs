using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Toggle tog;
    public bool needAnotherVictory = false;
    public Toggle[] tgs;
    public ErrorManager errorManager;


    private void OnTriggerEnter(Collider other)
    {
        
        bool tgst = true;
        foreach(Toggle tg in tgs)
        {
            if (!tg.isOn)
            {
                errorManager.Move();
                tgst = false;
                break;
                
            }
        }
        if (!needAnotherVictory || tgst)
        {
            if (other.CompareTag("interactible"))
            {
                tog.isOn = true;
            }
        }
    }
}
