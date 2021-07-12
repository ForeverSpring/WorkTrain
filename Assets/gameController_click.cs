using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_click : MonoBehaviour
{
    private int game_type = 5;
    public int gamestate = 0;//0:not start 1:running 2:lose 3:win 4:perfect
    public float win_time = 30f, perfect_time = 15f, start_time;
    public int score;
    public int goal_num = 20;
    public Text text_score;
    public mainController sceneMainController;
    // Start is called before the first frame update
    void Start()
    {
        gamestate = 1;
        start_time = Time.unscaledTime;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate == 1) {
            if ((Time.unscaledTime - start_time) > win_time) {
                gameover();
            }
            else {
                if (score == goal_num) {
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
        if (gamestate == 2) {
            gameover();
        }
    }

    void UpdateScore() {
        text_score.text = "愤怒 " + 100 * score / goal_num + "%";
    }

    public void add_score() {
        if (gamestate == 1) {
            if (score == goal_num) {
                return;
            }
            score++;
            UpdateScore();
        }
    }

    void gameover() {
        text_score.text = "time out.";
        gamestate = 2;
    }

    void gamewin() {
        text_score.text = "win!";
        gamestate = 3;
    }

    void gameperfect() {
        text_score.text = "perfect play!!";
        gamestate = 4;
    }
}
