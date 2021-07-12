using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restgame_clickbutton : MonoBehaviour
{
    public GameObject buttonObj;
    public gameController_getrest mainController;
    private void Start() {
        buttonObj.GetComponent<Button>().onClick.AddListener(click);
    }
    public void click() {
        mainController.click();
    }
}
