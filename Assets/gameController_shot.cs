using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_shot : MonoBehaviour
{
    public GameObject obj_ball;
    private GameObject obj_curball;
    private int game_type = 1;
    public int gamestate = 0;//0:not start 1:running 2:lose 3:win 4:perfect
    public int score;
    public float win_time = 30f, perfect_time = 15f, start_time;
    public int goal_num = 5;
    public bool canSpawn;
    public Text text_score;
    public GameObject garbbage_shot;//y 1.45 z 12
    public mainController sceneMainController;
    public AudioSource aud_shot;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        start_time = Time.unscaledTime;
        gamestate = 1;
    }

    // Update is called once per frame
    void Update()
     {
        if (gamestate == 1) {
            if (canSpawn) {
                GameObject temp = Instantiate(obj_ball);
                temp.transform.position = new Vector3(garbbage_shot.transform.position.x, garbbage_shot.transform.position.y + 1.45f, garbbage_shot.transform.position.z - 12f);
                obj_curball = temp;
                canSpawn = false;
            }
            if (Input.GetKeyDown(KeyCode.Space) && obj_curball.GetComponent<moveball>().canBeshot) {
                aud_shot.Play();
                obj_curball.GetComponent<moveball>().slip = false;
                obj_curball.GetComponent<moveball>().shot();
            }
            if ((Time.unscaledTime - start_time) > win_time) {
                gameover();
            }
            else {
                if (score >= goal_num) {
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
            stop_ball_finish();
        }
        if(gamestate == 3|| gamestate == 4) {
            stop_ball_finish();
        }
    }
    

    void UpdateScore() {
        text_score.text = "score " + score;
    }

    public void add_score() {
        score++;
        UpdateScore();
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

    void stop_ball_finish() {
        GameObject ball = GameObject.FindGameObjectWithTag("ball_shot");
        if (ball != null) {
            ball.GetComponent<moveball>().slip = false;
        }
    }
}
