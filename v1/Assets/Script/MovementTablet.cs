using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTablet : MonoBehaviour
{
    public Camera cam;
    bool isThere = false;
    [SerializeField]
    float duration = 0.5f;

    public Vector3 down = new Vector3(-0.44f, 0.4f, -7.0f);
    public Vector3 up = new Vector3(-1.4f, -1.3f, -7.0f);

    IEnumerator Where(Vector3 where) {
        float time = 0;
        Vector3 startPos = transform.position;
        while (time < duration) {
            transform.position = Vector3.Lerp(startPos, where, time / duration);
            time += Time.deltaTime;

            //continue next frame
            yield return null;
        }
        transform.position = where;
    
    }
    
    void Move() {
        
        StopAllCoroutines();
        if (!isThere)
        {
            StartCoroutine(Where(up));
        }
        else {
            StartCoroutine(Where(down));
        }

        isThere = !isThere;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            bool hasHit = Physics.Raycast(ray, out hit);


            if (hasHit && hit.collider.gameObject.tag == "tab")
            {
                Move();
            }
        }
    }
}
