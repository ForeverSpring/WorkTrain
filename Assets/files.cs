using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class files : MonoBehaviour
{
    public float drop_speed = 4.0f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(0f,-1f, 0f) * drop_speed;
    }
}
