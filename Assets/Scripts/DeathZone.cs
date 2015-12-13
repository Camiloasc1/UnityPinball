﻿using UnityEngine;
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
            GameObject.Destroy(other.gameObject,0.5f);
        }
    }
}
