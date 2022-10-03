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
    }

    // Update is called once per frame
    void Update()
    {
        cactusObj.transform.LookAt(angryLogObj.transform);
        angryLogObj.transform.LookAt(cactusObj.transform);

        float distance = Vector3.Distance(cactusObj.transform.position, angryLogObj.transform.position);

        if (mAnimatorCactus != null && mAnimatorAngryLog != null) 
        {
            if (distance < EPSILON)
            {
                mAnimatorCactus.SetTrigger("CactusTrigger1");
                mAnimatorAngryLog.SetTrigger("AngryLogTrigger1");
                float movementSpeed = 1.0F;
                angryLogObj.transform.position += angryLogObj.transform.forward * Time.deltaTime * movementSpeed;
            }
            else
            {
                mAnimatorCactus.SetTrigger("CactusTrigger2");
            }
        }
    }
}
