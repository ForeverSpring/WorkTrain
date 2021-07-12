using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_carry : MonoBehaviour
{
    public int window_state;//0:stop 1:running 2:win 3:perfect_play 4:lose
    public int score;
    public float max_last_time;
    public float win_time;
    public float time_per_files = 2.0f;
    public int goal_num = 10;
    public Text text_score;

    void Start() {
        score = 0;
        UpdateScore();
        StartCoroutine(files_drop());
    }

    // Update is called once per frame
    void Update() {
        if (score == goal_num) {
            Time.timeScale = 0;
            text_score.text = "win";
        }
    }

    void UpdateScore() {
        text_score.text = "score " + score;
    }

    public void add_score() {
        score++;
        UpdateScore();
    }

    IEnumerator files_drop() {
        while (true) {
            yield return new WaitForSeconds(time_per_files);
        }
    }
}
