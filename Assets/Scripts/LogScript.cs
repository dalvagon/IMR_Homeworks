using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    public GameObject log;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello");
        log.GetComponent<Animator>().Play("Run");
        print("HERE " + log.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            log.GetComponent<Animator>().Play("Run");
        }
    }
}
