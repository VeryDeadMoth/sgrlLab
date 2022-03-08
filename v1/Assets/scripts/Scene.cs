using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public int nbScene;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("nb"))
        {
            nbScene = 1;
            PlayerPrefs.SetInt("nb", nbScene);
        }

    }

    public void nextScene()
    {
        nbScene = PlayerPrefs.GetInt("nb");
        nbScene +=1;
        if (nbScene <= 3)
        {
            Debug.Log(nbScene);
            SceneManager.LoadScene(nbScene.ToString());
            PlayerPrefs.SetInt("nb", nbScene);

        }
        else
        {
            nbScene = 1;
            SceneManager.LoadScene(nbScene.ToString());
            PlayerPrefs.SetInt("nb", nbScene);
        }
    }
}
