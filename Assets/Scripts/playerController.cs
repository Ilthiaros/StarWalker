using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float force = 10.0f;
    public float moveSpeed = 10.0f;
    private float moveInput;
    public Rigidbody2D rb;
    public GameObject[] planets;
    public GameObject currentPlanet;
    float maxVelocityChange = 10.0f;
    float walkspeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {   

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        planets = GameObject.FindGameObjectsWithTag("Planet");
        currentPlanet = GameObject.Find("InitialPlanet");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("e"))
        {
            //rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        }

        // Calculate how fast we should be moving
        var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= walkspeed;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = rb.velocity;
        var velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocityChange, maxVelocityChange);
        rb.AddForce(velocityChange, ForceMode2D.Impulse);


    }


    void Update()
    {

        // Orient player upright on nearest planet
        foreach (GameObject planet in planets)
        {

            CircleCollider2D collider = planet.GetComponent<CircleCollider2D>();
            Vector3 distanceVector = transform.position - planet.transform.position;
            float distance = distanceVector.magnitude;
            Debug.Log("Distance: " + distance);

            if (distance < 2.25f)
            {
                currentPlanet = planet;
            }
        }


        var down = (currentPlanet.transform.position - transform.position).normalized;
        var forward = Vector3.Cross(transform.right, down);
        transform.rotation = Quaternion.LookRotation(-forward, -down);

    }
}
