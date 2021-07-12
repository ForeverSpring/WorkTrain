using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbbageController : MonoBehaviour
{
    Rigidbody rb;
    public float speed_move = 10.0f;
    public gameController_carry mainController;
    bool isCarring;
    // Start is called before the first frame update
    void Start()
    {
        isCarring = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
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

    void OnTriggerEnter(Collider other) {
        if (other.tag == "desk_src" && !isCarring){
            Debug.Log("get item");
            isCarring = true;
            rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (other.tag == "desk_des" && isCarring) {
            Debug.Log("put item");
            mainController.add_score();
            isCarring = false;
            rb.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
