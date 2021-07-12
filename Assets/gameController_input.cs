using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_input : MonoBehaviour
{
    public Text text_screen;
    public int input_length = 20;
    private int game_type = 2;
    public int gamestate = 0;//0:not start 1:running 2:lose 3:win 4:perfect
    public float win_time = 30f, perfect_time = 15f, start_time;
    string to_input;
    string has_input;
    string not_input;
    int pos;
    public mainController sceneMainController;
    public AudioSource aud_input;
    void Start()
    {
        gamestate = 1;
        start_time = Time.unscaledTime;
        pos = 0;
        for(int i = 0; i < input_length; i++) {
            to_input += (int)Random.Range(0, 2);
        }
        drawtext();
    }

    void Update()
    {
        if (gamestate == 1) {
            if (pos < to_input.Length && Input.GetKeyDown((KeyCode)not_input[0])) {
                aud_input.Play();
                pos++;
                drawtext();
            }
            if (pos < to_input.Length && Input.GetKeyDown(KeyCode.Keypad0) && not_input[0] == '0') {
                aud_input.Play();
                pos++;
                drawtext();
            }
            if (pos < to_input.Length && Input.GetKeyDown(KeyCode.Keypad1) && not_input[0] == '1') {
                aud_input.Play();
                pos++;
                drawtext();
            }
            if ((Time.unscaledTime - start_time) > win_time) {
                gameover();
            }
            else {
                if (pos == to_input.Length) {
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

    void drawtext() {
        has_input = to_input.Substring(0, pos);
        not_input = to_input.Substring(pos);
        text_screen.text = "<color=white>" + has_input + "</color>" + "<color=red>" + not_input + "</color>";
    }

    void gameover() {
        text_screen.text = "<color=white>" + "time out." + "</color>";
        gamestate = 2;
    }

    void gamewin() {
        text_screen.text = "<color=white>" + "win!" + "</color>"; ;
        gamestate = 3;
    }

    void gameperfect() {
        text_screen.text = "<color=white>" + "perfect play!!" + "</color>";
        gamestate = 4;
    }
}
