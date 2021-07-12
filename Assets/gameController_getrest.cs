using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_getrest : MonoBehaviour
{
    public int window_state;//0:stop 1:running 2:win 3:perfect_play 4:lose
    public int score;
    public float max_last_time;
    public float win_time = 10f;
    public int click_times;
    public float nextCheck;
    public Text text_score;
    public Text text_show;
    // Start is called before the first frame update
    void Start() {
        nextCheck = 0;
        
    }

    // Update is called once per frame
    void Update() {
        if (Time.unscaledTime >= win_time && click_times == 0) {
            gamewin();
        }
        if (click_times != 0) {
            gameover();
        }
    }

    void gameover() {
        Time.timeScale = 0;
        text_score.text = "you lose";
        text_show.text = "他被你吵醒了";
    }

    void gamewin() {
        Time.timeScale = 0;
        text_score.text = "you win";
    }

    public void click() {
        click_times++;
    }
}
