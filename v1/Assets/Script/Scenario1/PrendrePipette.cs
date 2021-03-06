using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrendrePipette : MonoBehaviour
{
    public Toggle tog;
    public bool needAnotherVictory = false;
    public Toggle[] tgs;
    public ErrorManager errorManager;

    public void Update()
    {
        if (transform.position == new Vector3(1f, -0.6f, -8f))
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
