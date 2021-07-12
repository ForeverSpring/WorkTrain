using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbbage_file_controller : MonoBehaviour
{
    Rigidbody rb;
    public float speed_move = 10.0f;
    public gameController mainController;
    public bool canMove;
    // Start is called before the first frame update
    void Start() {
        canMove = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        if (canMove) {
            float moveHorizontal = 0;
            float moveVertical = 0;
            if (Input.GetKey(KeyCode.Q)) {
                moveHorizontal = -1;
            }
            if (Input.GetKey(KeyCode.E)) {
                moveHorizontal = 1;
            }
            rb.velocity = new Vector3(moveHorizontal, moveVertical, 0f) * speed_move;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "garbbage_files") {
            mainController.add_score();
            Destroy(other.gameObject);
        }
    }
}
