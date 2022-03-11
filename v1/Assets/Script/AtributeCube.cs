using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributeCube : MonoBehaviour
{
    public GameObject HidenPlaceHolder = null;
    public int g = 100;
    // Start is called before the first frame update
    
    public void HidePlaceHolder(GameObject placeHolder)
    {
        HidenPlaceHolder = placeHolder;
        HidenPlaceHolder.SetActive(false);
    }
    public void ShowPlaceHolder()
    {
        if (HidenPlaceHolder != null)
        {
            HidenPlaceHolder.SetActive(true);
            HidenPlaceHolder = null;
        }
        
    }
}
