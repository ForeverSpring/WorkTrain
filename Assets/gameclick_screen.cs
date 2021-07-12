using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameclick_screen : MonoBehaviour
{
    public gameController_click mainController;
    private void OnMouseDown() {
        Debug.Log("screen clicked");
        mainController.add_score();
    }
}
