using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void b_start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void b_credit()
    {
        p.SetActive(true);
    }
    public void b_creditClose()
    {
        p.SetActive(false);
    }

    public void b_quit()
    {
        Application.Quit();
    }
    public void b_return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void b_loadLevel(int i)
    {
        SceneManager.LoadScene(i+1);
    }
}
