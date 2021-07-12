using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class btn_restart : MonoBehaviour
{
    public GameObject buttonObj;
    private void Start() {
        buttonObj.GetComponent<Button>().onClick.AddListener(click);
    }
    public void click() {
        //restart
        Debug.Log("restart game");
        SceneManager.LoadScene("main");
    }
}
