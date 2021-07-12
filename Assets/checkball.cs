using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkball : MonoBehaviour
{
    public gameController_shot mainController;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "ball_shot") {
            Destroy(other.gameObject);
            mainController.canSpawn = true;
            mainController.add_score();
        }
    }
}
