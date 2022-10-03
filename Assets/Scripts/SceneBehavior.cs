using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
    public GameObject cactusObj;
    public GameObject angryLogObj;

    public Animator cactusAnimator;
    public Animator angryLogAnimator;

    public static float EPSILON = 0.15F;
    public static float SPEED = 0.06F;

    // Start is called before the first frame update
    void Start()
    {
        cactusAnimator = cactusObj.GetComponent<Animator>();
        angryLogAnimator = angryLogObj.GetComponent<Animator>();
    }

    void Awake() {
        cactusObj = GameObject.FindGameObjectsWithTag("Cactus")[0];
        angryLogObj = GameObject.FindGameObjectsWithTag("Log")[0];
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(cactusObj.transform.position, angryLogObj.transform.position);

        cactusObj.transform.LookAt(angryLogObj.transform);
        angryLogObj.transform.LookAt(cactusObj.transform);

        if (cactusAnimator != null && angryLogAnimator != null) 
        {
            if (distance < EPSILON)
            {
                // Start the attack and run animations
                cactusAnimator.SetTrigger("CactusTrigger1");
                angryLogAnimator.SetTrigger("AngryLogTrigger1");
            }
            else
            {
                // Move the angry log object
                if (cactusObj.GetComponent<Renderer>().isVisible) 
                {
                    angryLogObj.transform.position += angryLogObj.transform.forward * Time.deltaTime * SPEED;
                }

                // Revert to the idle state
                cactusAnimator.SetTrigger("CactusTrigger2");
                angryLogAnimator.SetTrigger("AngryLogTrigger2");
            }
        }
    }
}
