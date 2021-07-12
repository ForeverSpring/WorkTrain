using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class btn_exit : MonoBehaviour
{
    public GameObject buttonObj;
    private void Start() {
        buttonObj.GetComponent<Button>().onClick.AddListener(click);
    }
    public void click() {
        //exit to main menu
        Debug.Log("exit to main menu");
        SceneManager.LoadScene("MenuScene");
    }
}
