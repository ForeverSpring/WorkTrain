using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    private int game_type = 3;
    public int gamestate = 0;//0:not start 1:running 2:lose 3:win 4:perfect
    public float win_time = 30f, perfect_time = 15f, start_time;
    public GameObject obj_files;
    public GameObject obj_spawn;
    public int score;
    public float time_per_files = 1.0f;
    public int goal_num = 20;
    public Text text_score;
    public mainController sceneMainController;
    void Start()
    {
        gamestate = 1;
        start_time = Time.unscaledTime;
        score = 0;
        UpdateScore();
        StartCoroutine(files_drop());
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
        text_score.text = "score " + score;
    }

    public void add_score() {
        score++;
        UpdateScore();
    }

    IEnumerator files_drop() {
        while (gamestate == 1) {
            GameObject temp = Instantiate(obj_files);
            obj_files.transform.position = new Vector3(obj_spawn.transform.position.x + Random.Range(-4.5f, 4.5f), obj_spawn.transform.position.y + 5.0f, obj_spawn.transform.position.z);
            yield return new WaitForSeconds(time_per_files);
        }
    }

    void gameover() {
        stop_all_finish();
        text_score.text = "time out.";
        gamestate = 2;
    }

    void gamewin() {
        stop_all_finish();
        text_score.text = "win!";
        gamestate = 3;
    }

    void gameperfect() {
        stop_all_finish();
        text_score.text = "perfect play!!";
        gamestate = 4;
    }

    void stop_all_finish() {
        StopCoroutine(files_drop());
        GameObject[] arr_files = GameObject.FindGameObjectsWithTag("garbbage_files");
        foreach (GameObject obj in arr_files) {
            Destroy(obj);
        }
        GameObject.FindGameObjectWithTag("garbbage_catch").GetComponent<garbbage_file_controller>().canMove = false;
    }
}
