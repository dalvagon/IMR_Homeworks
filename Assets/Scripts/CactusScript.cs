using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    public GameObject cactus;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello");
        cactus.GetComponent<Animator>().Play("Idle");
        print("HERE " + cactus.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            cactus.GetComponent<Animator>().Play("Attack");
        }
    }
}
