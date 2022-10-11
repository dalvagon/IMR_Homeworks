using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTrigger : MonoBehaviour
{
    private Renderer renderer;
    private Color oldColor;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject finishButton;

    public GameObject canvas;
    public GameObject scoreText;

    TextMeshProUGUI textMesh_scoreText;
    Vector3 leftHand_initialPosition;
    Vector3 rightHand_initialPosition;

    float SCORE_MULTIPLIER = 100;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        canvas.SetActive(false);
    }

    void Awake()
    {
        canvas = GameObject.FindGameObjectsWithTag("Canvas")[0];
        scoreText = GameObject.FindGameObjectsWithTag("Score text")[0];
        textMesh_scoreText = scoreText.GetComponent<TextMeshProUGUI>();

        leftHand = GameObject.FindGameObjectsWithTag("LeftHand")[0];
        leftHand_initialPosition = leftHand.transform.position;
        rightHand = GameObject.FindGameObjectsWithTag("RightHand")[0];
        rightHand_initialPosition = rightHand.transform.position;
        finishButton = GameObject.FindGameObjectsWithTag("Finish")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        oldColor = renderer.material.color;
        renderer.material.color = Color.red;

        // Calculate score
        float distance = 0;
        if (leftHand.transform.position != leftHand_initialPosition)
        {
            distance = Vector3.Distance(leftHand.transform.position, finishButton.transform.position);
        } else if (rightHand.transform.position != rightHand_initialPosition)
        {
            distance = Vector3.Distance(rightHand.transform.position, finishButton.transform.position);
        }
        float score = distance * SCORE_MULTIPLIER;

        textMesh_scoreText.text = "Score: " + score.ToString();
        canvas.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        renderer.material.color = oldColor;
        canvas.SetActive(false);
    }
}
