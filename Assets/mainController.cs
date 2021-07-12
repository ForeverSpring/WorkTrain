using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

static class Screen {
    public static float screen_width = 2.2f, screen_height = 1.7f;
}
public class mainController : MonoBehaviour
{
    int sum_score;
    bool canFinish;
    public gameController game_garbage;
    public gameController_click game_click;
    public gameController_clickbubble game_bubble;
    public gameController_filedelete game_filedelete;
    public gameController_input game_input;
    public gameController_shot game_shot;
    public Text text_sumscore;
    public Text text_score_board;
    public train trains;
    public GameObject train_0;
    public GameObject train_1;
    public GameObject train_2;
    public GameObject train_3;
    public GameObject train_4;
    public GameObject train_5;
    public GameObject score_board;
    public AudioSource aud_coin;
    public AudioSource aud_finish;
    public AudioSource aud_bgm_game;
    int[] arr_game_score = { 0, 0, 0, 0, 0, 0 };
    List<GameObject> arr_train = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        aud_bgm_game.Play();
        text_score_board.text = "";
        score_board.SetActive(false);
        arr_train.Add(train_0);
        arr_train.Add(train_1);
        arr_train.Add(train_2);
        arr_train.Add(train_3);
        arr_train.Add(train_4);
        arr_train.Add(train_5);
        foreach(GameObject obj_train in arr_train) {
            obj_train.SetActive(false);
        }
        sum_score = 0;
        canFinish = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFinish) {
            if (gamefinished()) {
                finish();
            }
        }
        update_score();
    }

    bool gamefinished() {
        if (game_garbage.gamestate <= 1 || game_click.gamestate <= 1 || game_bubble.gamestate <= 1 || game_filedelete.gamestate <= 1 || game_input.gamestate <= 1 || game_shot.gamestate <= 1) {
            return false;
        }
        return true;
    }

    void finish() {
        canFinish = false;
        if (all_win()) {
            StartCoroutine(train_leave());
        }
        else {
            if (sum_score == 0) {
                StartCoroutine(zero_finish()); 
            }
            else {
                StartCoroutine(fail_finish());
            }
        }
        Debug.Log("finish");
    }

    public void report_game_win(int game_type,int game_state) {
        arr_train[game_type].SetActive(true);
        aud_coin.Play();
        if (game_state == 3) {
            sum_score += 60;
            arr_game_score[game_type] = 60;
        }
        if (game_state == 4) {
            sum_score += 100;
            arr_game_score[game_type] = 100;
        }
        update_score();
    }

    void update_score() {
        text_sumscore.text = "总分：" + sum_score;
    }

    bool all_win() {
        if (game_garbage.gamestate != 2 && game_click.gamestate != 2 && game_bubble.gamestate != 2 && game_filedelete.gamestate != 2 && game_input.gamestate != 2 && game_shot.gamestate != 2) {
            return true;
        }
        return false;
    }

    IEnumerator train_leave() {
        yield return new WaitForSeconds(2.0f);
        aud_finish.Play();
        trains.canMove = true;
        yield return new WaitForSeconds(5.0f);
        show_finishdetail();
        //Destroy(trains);
        yield return null;
    }


    IEnumerator zero_finish() {
        yield return new WaitForSeconds(2.0f);
        aud_finish.Play();
        trains.turnback();
        trains.move_back = true;
        yield return new WaitForSeconds(5.0f);
        show_finishdetail();
        //Destroy(trains);
        yield return null;
    }

    IEnumerator fail_finish() {
        yield return new WaitForSeconds(2.0f);
        show_finishdetail();
        yield return null;
    }

    void show_score_board() {
        string rank="rank";
        if (sum_score == 600) {
            rank = "rank S 卷积神经网络！！";
        }
        else if (sum_score >= 520) {
            rank = "rank A 宁就是卷王！";
        }
        else if (sum_score >= 440) {
            rank = "rank B 优秀员工";
        }
        else if (sum_score >=360) {
            rank = "rank C 一般路过社员";
        }
        else if (sum_score > 0) {
            rank = "rank D 菜";
        }
        else if (sum_score== 0){
            rank = "rank E 0分摸鱼之神";
        }
        string test = string.Format("\tscore\n{6,10}\n\nwork1: {0,6}\nwork2: {1,6}\nwork3: {2,6}\nwork4: {3,6}\nwork5: {4,6}\nwork6: {5,6}", arr_game_score[0], arr_game_score[1], arr_game_score[2], arr_game_score[3], arr_game_score[4], arr_game_score[5], rank);
        text_score_board.text = test;
    }

    void show_finishdetail() {
        score_board.SetActive(true);
        show_score_board();
    }
}