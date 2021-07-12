using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickgame_clickbutton : MonoBehaviour
{
    public GameObject buttonObj;
    public gameController_click mainController;
    private void Start() {
        buttonObj.GetComponent<Button>().onClick.AddListener(click);
    }
    public void click() {
        mainController.add_score();
    }

}
