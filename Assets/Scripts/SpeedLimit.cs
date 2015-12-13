using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SpeedLimit : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 1.0f;
    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LateUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            //rb.velocity = rb.velocity.normalized * maxSpeed;
            rb.velocity *= maxSpeed / rb.velocity.magnitude;
        }
    }
}
