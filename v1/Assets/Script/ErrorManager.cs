using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{

    float duration = 0.5f;
    public GameObject errorMessage;
    Vector3 right;
    Vector3 left;
    
    // Start is called before the first frame update
    void Start()
    {
        
        right = new Vector3(-150.65f, 2.70f, 86.11f);
        left = new Vector3(right.x + 150, right.y, right.z);
        errorMessage.transform.position = right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Where(Vector3 where)
    {
        float time = 0;
        Vector3 startPos = errorMessage.transform.position;
        while (time < duration)
        {
            errorMessage.transform.position = Vector3.Lerp(startPos, where, time / duration);
            time += Time.deltaTime;

            //continue next frame
            yield return null;
        }
        errorMessage.transform.position = where;
        
        Debug.Log("1");
    }
    IEnumerator DontBeDumb()
    {
        StartCoroutine(Where(left));
        yield return new WaitForSeconds(2);
        StartCoroutine(Where(right));
    }
    public void Move()
    {

        StopAllCoroutines();
        StartCoroutine(DontBeDumb());
    }
}
