using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class file_todelete : MonoBehaviour
{
    private Vector3 screenPos;
    private Vector3 offset;
    public GameObject screen;
    float x_max, y_max, x_min, y_min;
    private void Start() {
        screen = GameObject.Find("screen_5");
        x_max = screen.transform.position.x + Screen.screen_width;
        x_min = screen.transform.position.x - Screen.screen_width;
        y_max = screen.transform.position.y + Screen.screen_height;
        y_min = screen.transform.position.y - Screen.screen_height;
    }

    void OnMouseDown() {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);//获取物体的屏幕坐标     
        offset = screenPos - Input.mousePosition;//获取物体与鼠标在屏幕上的偏移量    
    }
    void OnMouseDrag() {
        transform.position = DragRangeLimit(Camera.main.ScreenToWorldPoint(Input.mousePosition + offset));//将拖拽后的物体屏幕坐标还原为世界坐标
    }

    Vector3 DragRangeLimit(Vector3 pos) {
        pos.x = Mathf.Clamp(pos.x, x_min, x_max);
        pos.y = Mathf.Clamp(pos.y, y_min, y_max);
        return pos;
    }

}
