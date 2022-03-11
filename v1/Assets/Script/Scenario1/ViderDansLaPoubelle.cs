using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViderDansLaPoubelle : MonoBehaviour
{
    public Toggle tog;
    public bool needAnotherVictory = false;
    public Toggle[] tgs;
    public ErrorManager errorManager;

    public void Update()
    {
        if (gameObject.GetComponent<AtributeCube>().g == 0)
        {
            bool tgst = true;
            foreach (Toggle tg in tgs)
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
                tog.isOn = true;
            }
        }
    }
}
