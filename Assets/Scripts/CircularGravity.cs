using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGravity : MonoBehaviour
{
    public float massOfEarth;
    public Transform[] centerofEarths;
    public Transform currentPlanet;
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
            Vector3 distanceVector = transform.position - centerofEarth.transform.position;
            float distanceToPlanet = distanceVector.magnitude;

            if (distanceToPlanet < 2.35f)
            {
                currentPlanet = centerofEarth;
            } 
        }

        distance = Vector3.Distance(currentPlanet.transform.position, transform.position);
        //forceValue = G * (massOfPlayer * massOfEarth) / (distance * distance);
        //Constant Gravity for all planets
        forceValue = 275.0f;
        forceDirection = (currentPlanet.position - transform.position).normalized;
        rb.AddForce(forceValue * forceDirection);

    }
}
