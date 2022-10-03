using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
    public GameObject cactusObj;
    public GameObject logObj;

    public Animator mAnimator;

    public static float EPSILON = 0.25F;


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = cactusObj.GetComponent<Animator>();
    }

    void Awake() {
        cactusObj = GameObject.FindGameObjectsWithTag("Cactus")[0];
        logObj = GameObject.FindGameObjectsWithTag("Log")[0];
    }

    // Update is called once per frame
    void Update()
    {
        cactusObj.transform.LookAt(logObj.transform);
        logObj.transform.LookAt(cactusObj.transform);

        float distance = UnityEngine.Vector3.Distance(cactusObj.transform.position, logObj.transform.position);

        if (mAnimator != null) 
        {
            if (distance < EPSILON)
            {
                mAnimator.SetTrigger("Tr1");
            }
            else
            {
                mAnimator.SetTrigger("Tr2");
            }
        }
    }
}
