using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
    public GameObject cactusObj;
    public GameObject angryLogObj;

    public Animator mAnimatorCactus;
    public Animator mAnimatorAngryLog;

    public static float EPSILON = 0.25F;

    // Start is called before the first frame update
    void Start()
    {
        mAnimatorCactus = cactusObj.GetComponent<Animator>();
        mAnimatorAngryLog = angryLogObj.GetComponent<Animator>();
    }

    void Awake() {
        cactusObj = GameObject.FindGameObjectsWithTag("Cactus")[0];
        angryLogObj = GameObject.FindGameObjectsWithTag("Log")[0];

        cactusObj.transform.LookAt(angryLogObj.transform);
        angryLogObj.transform.LookAt(cactusObj.transform);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(cactusObj.transform.position, angryLogObj.transform.position);

        if (mAnimatorCactus != null && mAnimatorAngryLog != null) 
        {
            if (distance < EPSILON)
            {
                // Start the attack and run animations
                mAnimatorCactus.SetTrigger("CactusTrigger1");
                mAnimatorAngryLog.SetTrigger("AngryLogTrigger1");

                // Make AngryLog turn around and run
                angryLogObj.transform.Rotate(18 0, Time.deltaTime * 30, 0, Space.Self);

                if (distance > (EPSILON / 4)) 
                {
                    float movementSpeed = 1.0F;
                    angryLogObj.transform.position += angryLogObj.transform.forward * Time.deltaTime * movementSpeed;
                }
            }
            else
            {
                // Revert to the idle state
                mAnimatorCactus.SetTrigger("CactusTrigger2");
                angryLogObj.transform.LookAt(cactusObj.transform);

                cactusObj.transform.LookAt(angryLogObj.transform);
                angryLogObj.transform.LookAt(cactusObj.transform);
            }
        }
    }
}
