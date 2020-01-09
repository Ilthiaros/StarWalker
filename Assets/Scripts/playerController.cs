using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float force = 10.0f;
    public float moveSpeed = 10.0f;
    private float moveInput;
    public Rigidbody2D rb;
    public GameObject planet;
    float maxVelocityChange = 10.0f;
    float walkspeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        planet = GameObject.FindGameObjectWithTag("PlanetTest");
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
        // Orient player upright
        var down = (planet.transform.position - transform.position).normalized;
        var forward = Vector3.Cross(transform.right, down);
        transform.rotation = Quaternion.LookRotation(-forward, -down);
    }
}
