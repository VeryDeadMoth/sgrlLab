using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class RetourAuMenu : MonoBehaviour
{
    public Toggle[] tgs;
    public TMP_Text[] TMProToggle;
    public TextAsset asset;
    private void Awake()
    {

        //TextAsset asset = (TextAsset)Resources.Load(path);
        string[] names = asset.text.Split(';');
        int i = 0;
        foreach(TMP_Text tm in TMProToggle)
        {
            tm.text = names[i];
            i++; 
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool reusite = true;
        foreach (Toggle tg in tgs)
        {
            if (!tg.isOn)
            {
                reusite = false;
            }
        }
        if (reusite)
        {
            SceneManager.LoadScene(0);
        }
    }
}
