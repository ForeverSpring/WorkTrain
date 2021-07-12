using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbbage_file : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="file_todelete") {
            Destroy(other.gameObject);
            GameObject.Find("GameController_filedelete").GetComponent<gameController_filedelete>().add_score();
        }
    }
}
