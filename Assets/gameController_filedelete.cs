using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_filedelete : MonoBehaviour
{
    private int game_type = 4;
    public int gamestate = 0;//0:not start 1:running 2:lose 3:win 4:perfect
    public float win_time = 30f, perfect_time = 15f, start_time;
    public GameObject obj_file;
    public GameObject screen;
    public GameObject trashbin;
    float x_max, y_max, x_min, y_min;
    List<Vector3> arr_spawn_pos = new List<Vector3>{ new Vector3(1f, 0f, 0f), new Vector3(2f, 0f, 0f), new Vector3(3f, 0f, 0f), new Vector3(4f, 0f, 0f),
      new Vector3(0f, -1f, 0f), new Vector3(1f, -1f, 0f),new Vector3(2f, -1f, 0f),new Vector3(3f, -1f, 0f),new Vector3(4f, -1f, 0f),
      new Vector3(0f, -2f, 0f), new Vector3(1f, -2f, 0f),new Vector3(2f, -2f, 0f),new Vector3(3f, -2f, 0f),new Vector3(4f, -2f, 0f)};
    int pos_length = 14;
    int score;
    public Text text_win;
    int file_nums;
    public int nums_min, nums_max;
    public mainController sceneMainController;
    public AudioSource aud_delete;
    void Start()
    {
        gamestate = 1;
        start_time = Time.unscaledTime;
        screen = GameObject.Find("screen_5");
        x_max = screen.transform.position.x + Screen.screen_width;
        x_min = screen.transform.position.x - Screen.screen_width;
        y_max = screen.transform.position.y + Screen.screen_height;
        y_min = screen.transform.position.y - Screen.screen_height;
        score = 0;
        file_nums = Random.Range(nums_min, nums_max);
        ini_files(file_nums);
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate == 1) {
            if ((Time.unscaledTime - start_time) > win_time) {
                gameover();
            }
            else {
                if (GameObject.FindGameObjectWithTag("file_todelete") == null) {
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

    void ini_files(int nums) {
        int _nums = nums;
        bool ini_flag = true;
        if (nums > pos_length) {
            _nums = pos_length;
        }
        while (ini_flag) {
            int temp_index = Random.Range(0, nums);
            Vector3 v = arr_spawn_pos[temp_index];
            arr_spawn_pos.RemoveAt(temp_index);
            GameObject temp = Instantiate(obj_file);
            Vector3 spawn = trashbin.transform.position + v;
            obj_file.transform.position = spawn;
            _nums--;
            if (_nums == 0) {
                ini_flag = false;
            }
        }
        
    }

    public void add_score() {
        aud_delete.Play();
        score++;
    }

    void gameover() {
        text_win.text = "time out.";
        gamestate = 2;
        GameObject[] arr_files = GameObject.FindGameObjectsWithTag("file_todelete");
        foreach (GameObject obj in arr_files) {
            Destroy(obj);
        }
    }

    void gamewin() {
        text_win.text = "win!";
        gamestate = 3;
    }

    void gameperfect() {
        text_win.text = "perfect play!!";
        gamestate = 4;
    }
}
