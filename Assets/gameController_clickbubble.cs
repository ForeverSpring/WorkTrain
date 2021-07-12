using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_clickbubble : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject obj_bubble_click;
    public GameObject screen;
    private int game_type = 0;
    public int gamestate = 0;//0:not start 1:running 2:lose 3:win 4:perfect
    public int bubble_per_time = 10;
    int score;
    float x_max, y_max, x_min, y_min;
    public Text text_win;
    public float win_time = 30f, perfect_time = 15f, start_time;
    public mainController sceneMainController;
    public AudioSource bubble_click;
    GameObject[] all_bubble;
    void Start() {
        gamestate = 1;
        start_time = Time.unscaledTime;
        screen = GameObject.Find("screen_1");
        x_max = screen.transform.position.x + Screen.screen_width;
        x_min = screen.transform.position.x - Screen.screen_width;
        y_max = screen.transform.position.y + Screen.screen_height;
        y_min = screen.transform.position.y - Screen.screen_height;
        ini_bubbles();
    }

    // Update is called once per frame
    void Update() {
        if (gamestate == 1) {
            if ((Time.unscaledTime - start_time) > win_time) {
                gameover();
            }
            else {
                if (score == bubble_per_time) {
                    if ((Time.unscaledTime - start_time) < perfect_time) {
                        gameperfect();
                        sceneMainController.report_game_win(game_type, gamestate);
                    }
                    else {
                        gamewin();
                        sceneMainController.report_game_win(game_type, gamestate);
                    }
                }
            }   
        }
    }

    void ini_bubbles() {
        for(int i = 0; i < bubble_per_time; i++) {
            GameObject temp = Instantiate(obj_bubble_click);
            temp.transform.position = new Vector3(Random.Range(x_min, x_max), Random.Range(y_min, y_max), screen.transform.position.z);
            temp.transform.rotation = Quaternion.Euler(temp.transform.forward * Random.Range(0, 360));
        }
    }
    
    public void add_score() {
        if (gamestate == 1) {
            bubble_click.Play();
            score++;
        }
    }

    void gameover() {
        text_win.text = "time out.";
        delete_all_bubble();
        gamestate = 2;
    }

    void gamewin() {
        text_win.text = "win!";
        gamestate = 3;
    }

    void gameperfect() {
        text_win.text = "perfect play!!";
        gamestate = 4;
    }

    void delete_all_bubble() {
        all_bubble = GameObject.FindGameObjectsWithTag("bubble_click");
        foreach(GameObject obj in all_bubble) {
            Destroy(obj);
        }
    }
}
