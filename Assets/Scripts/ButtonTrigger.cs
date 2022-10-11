using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    private Renderer renderer;
    private Color oldColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        oldColor = renderer.material.color;
        renderer.material.color = Color.red;
    }

    void OnTriggerExit(Collider other)
    {
        renderer.material.color = oldColor;
    }
}
