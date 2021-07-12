using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    float x_max, y_max, x_min, y_min;
    public float speed_bubble_move = 3.0f;
    public GameObject screen;
    private void Start() {
        screen = GameObject.Find("screen_1");
        x_max = screen.transform.position.x + Screen.screen_width;
        x_min = screen.transform.position.x - Screen.screen_width;
        y_max = screen.transform.position.y + Screen.screen_height;
        y_min = screen.transform.position.y - Screen.screen_height;
    }

    void FixedUpdate() {
        transform.position = transform.position + transform.up * speed_bubble_move * Time.fixedDeltaTime;
        transform.up = CheckPos();
    }

    private void OnMouseDown() {
        Debug.Log("is clicked");
        GameObject.Find("GameController_clickbubble").GetComponent<gameController_clickbubble>().add_score();
        Destroy(this.gameObject);
    }

    Vector3 CheckPos() {
        if (transform.position.x < x_min || transform.position.x > x_max) {
            return Vector3.Reflect(transform.up, new Vector3(1f, 0f, 0f));
        }
        if (transform.position.y < y_min || transform.position.y > y_max) {
            return Vector3.Reflect(transform.up, new Vector3(0f, 1f, 0f));
        }
        return transform.up;
    }
}
