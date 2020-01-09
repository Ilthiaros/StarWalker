using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGravity : MonoBehaviour
{
    public float massOfEarth;
    public Transform[] centerofEarths;
    public float G;

    float massOfPlayer;
    float distance;
    float forceValue;
    Vector3 forceDirection;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        massOfPlayer = rb.mass;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        foreach (Transform centerofEarth in centerofEarths)
        {
            distance = Vector3.Distance(centerofEarth.transform.position, transform.position);
            forceValue = G * (massOfPlayer * massOfEarth) / (distance * distance);
            forceDirection = (centerofEarth.position - transform.position).normalized;
            rb.AddForce(forceValue * forceDirection);
        }
    }
}
