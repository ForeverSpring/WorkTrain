using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveball : MonoBehaviour
{
    Rigidbody rb_ball;
    public float ball_move_speed = 5f;
    public bool canBeshot;
    public float shotforce=10f;
    public bool slip;
    int toward = 1;
    public GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Camera_2");
        Debug.Log("ball creat");
        slip = true;
        canBeshot = true;
        rb_ball = GetComponent<Rigidbody>();
    }

    public void shot() {
        Debug.Log("ball be shot.");
        canBeshot = false;
        rb_ball.velocity = new Vector3(0, 0, 0);
        rb_ball.AddForce(new Vector3(0, 9, 7), ForceMode.Impulse);
        rb_ball.useGravity = true;
    }

    private void FixedUpdate() {
        if (rb_ball.transform.position.x > camera.transform.position.x+4) {
            toward = -1;
        }
        if (rb_ball.transform.position.x < camera.transform.position.x - 4) {
            toward = 1;
        }
        if (slip) {
            rb_ball.transform.position += new Vector3(toward, 0, 0) * ball_move_speed * Time.deltaTime;
        }
    }
}
