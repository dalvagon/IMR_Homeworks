using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetTrigger2 : MonoBehaviour
{
    private Renderer renderer;
    private Color oldColor;
    private Vector3 oldPosition;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        oldPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        double distance = Vector3.Distance(oldPosition, gameObject.transform.position);
        if(distance > 1) 
            direction = -1;

        if(distance <= 0.01)
            direction = 1;

         gameObject.transform.position += Vector3.back * Time.deltaTime * direction;
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
