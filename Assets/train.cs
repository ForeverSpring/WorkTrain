using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{
    Rigidbody rb;
    public float speed_train = 5f;
    public bool canMove, move_back;
    private void Start() {
        canMove = false;
        move_back = false;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        if (canMove) {
            rb.transform.position += new Vector3(1, 0, 0) * speed_train * Time.fixedDeltaTime;
        }
        if (move_back) {
            rb.transform.position += new Vector3(-1, 0, 0) * speed_train * Time.fixedDeltaTime;
        }
    }

    public void turnback() {
        rb.transform.Rotate(new Vector3(0, -180, 0));
    }
}
