using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject leftFlipper;
    [SerializeField]
    private GameObject rightFlipper;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private Vector3 spawnPos;
    public GameObject sphere;
    private Vector3 leftRot;
    private Vector3 rightRot;
    private Vector3 leftTarget;
    private Vector3 rightTarget;
    private float tLeft = 0.0f;
    private float tRight = 0.0f;

    // Use this for initialization
    void Start()
    {
        leftRot = leftFlipper.transform.localEulerAngles;
        rightRot = rightFlipper.transform.localEulerAngles;
        leftTarget = leftFlipper.transform.localEulerAngles;
        leftTarget.y = 0.0f;
        rightTarget = rightFlipper.transform.localEulerAngles;
        rightTarget.y = 360.0f;
    }

    // Update is called once per frame
    void Update()
    {
        tLeft += Time.deltaTime * speed * (Input.GetKey(KeyCode.C) ? 1 : -1);
        tLeft = Mathf.Clamp01(tLeft);
        tRight += Time.deltaTime * speed * (Input.GetKey(KeyCode.M) ? 1 : -1);
        tRight = Mathf.Clamp01(tRight);
        leftFlipper.transform.localEulerAngles = Vector3.Slerp(leftRot, leftTarget, tLeft);
        rightFlipper.transform.localEulerAngles = Vector3.Slerp(rightRot, rightTarget, tRight);
        if (Input.GetKeyDown(KeyCode.Space) && transform.childCount == 0 && GameObject.FindWithTag("GameController").GetComponent<GameManager>().BallCount > 0)
        {
            GameObject ball = GameObject.Instantiate(sphere);
            ball.transform.parent = transform;
            ball.transform.localPosition = spawnPos;
        }
    }
}
