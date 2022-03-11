using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ActivPanel;
    public AudioSource audioSource;
    public AudioClip ooh;

    public void openMyPanel(GameObject myPanel)
    {
        
        ActivPanel.SetActive(false);
        myPanel.SetActive(true);
        ActivPanel = myPanel;
    }
    public void TaskCompleted()
    {
        audioSource.PlayOneShot(ooh);
    }
}
