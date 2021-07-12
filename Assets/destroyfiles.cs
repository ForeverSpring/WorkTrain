using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyfiles : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag== "garbbage_files") {
            Destroy(other.gameObject);
        }
    }
}
