using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DeathZone : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameObject.Destroy(other.gameObject);
            GameManager gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            gm.BallCount -= 1;
            if (gm.BallCount == 0)
            {
                gm.EndGame();
            }
        }
    }
}
