using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.mousePosition.x > Screen.width - 200 || Input.mousePosition.x < 200) && (Input.mousePosition.x < Screen.width - 1 && Input.mousePosition.x > 0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            if (transform.rotation.y > -20.0f && transform.rotation.y < 20.0f)
            {
                transform.Rotate(0.0f, mouseX, 0.0f);
            }
        }
    }
}
