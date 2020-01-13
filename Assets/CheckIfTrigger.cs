using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfTrigger : MonoBehaviour
{

    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
