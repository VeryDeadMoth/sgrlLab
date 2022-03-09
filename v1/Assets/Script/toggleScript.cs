using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleScript : MonoBehaviour
{
    public bool isValid = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.GetChild(1).gameObject.active)
        {
            isValid = true;
        }
    }
}
