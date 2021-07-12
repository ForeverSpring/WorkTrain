using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour {
    public const int STATE_APPSTART = 0;
    public const int STATE_MAINMENU = 1;
    public const int STATE_OPTION = 2;
    private int menustate;
    public Image imgBackground;
    private GameObject textTitle;
    private GameObject textStartNotice;
    private GameObject btnStart;
    private GameObject btnOption;
    private GameObject btnExit;
    public const int BTN_START = 0;
    public const int BTN_OPTION = 1;
    public const int BTN_EXIT = 2;
    private int chosenbutton;
    private bool titlemove;
    public AudioSource aud_bgm_menu;
    void Start() {
        chosenbutton = 0;
        titlemove = false;
        textTitle = GameObject.Find("title");
        textStartNotice = GameObject.Find("startnotice");
        btnStart = GameObject.Find("startbutton");
        btnOption = GameObject.Find("optionbutton");
        btnExit = GameObject.Find("exitbutton");
        btnStart.GetComponent<UnityEngine.UI.Text>().fontSize = 70;
        menustate = STATE_APPSTART;
    }

    void Update() {
        //标题特效
        if (titlemove) {
            textTitle.transform.position += new Vector3(-250f, 200f, 0f) * Time.deltaTime;
            textTitle.transform.localScale -= (new Vector3(1f, 1f, 0) - new Vector3(0.5f, 0.5f, 0f)) * Time.deltaTime;
        }
        //主菜单操作
        if (menustate==STATE_MAINMENU) {
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                int unlocked = chosenbutton;
                chosenbutton++;
                if (chosenbutton >= 3) {
                    chosenbutton -= 3;
                }
                int locked = chosenbutton;
                updateButton(unlocked, locked);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                int unlocked = chosenbutton;
                chosenbutton--;
                if (chosenbutton < 0) {
                    chosenbutton += 3;
                }
                int locked = chosenbutton;
                updateButton(unlocked, locked);
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                //执行选中的按钮
                if (chosenbutton == BTN_EXIT) {
                    Application.Quit();
                }
                if (chosenbutton == BTN_START) {
                    SceneManager.LoadScene("main");
                }
                if (chosenbutton == BTN_OPTION) {
                    menustate = STATE_OPTION;
                }
            }
        }
        if (menustate == STATE_OPTION) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                menustate = STATE_MAINMENU;
            }
        }
    }

    void btnVisible() {
        btnStart.SetActive(true);
        btnOption.SetActive(true);
        btnExit.SetActive(true);
    }

    void btnInvisible() {
        btnStart.SetActive(false);
        btnOption.SetActive(false);
        btnExit.SetActive(false);
    }

    void updateButton(int unlocked,int locked) {
        if (unlocked == BTN_START) {
            btnStart.GetComponent<UnityEngine.UI.Text>().fontSize =60;
        }
        else if (unlocked == BTN_OPTION) {
            btnOption.GetComponent<UnityEngine.UI.Text>().fontSize = 60;
        }
        else if (unlocked == BTN_EXIT) {
            btnExit.GetComponent<UnityEngine.UI.Text>().fontSize = 60;
        }
        if (locked == BTN_START) {
            btnStart.GetComponent<UnityEngine.UI.Text>().fontSize = 70;
        }
        else if (locked == BTN_OPTION) {
            btnOption.GetComponent<UnityEngine.UI.Text>().fontSize = 70;
        }
        else if (locked == BTN_EXIT) {
            btnExit.GetComponent<UnityEngine.UI.Text>().fontSize = 70;
        }
    }

    IEnumerator movetitle() {
        titlemove = true;
        yield return new WaitForSeconds(1f);
        titlemove = false;
        yield return null;
    }

    void OnGUI() {
        switch (menustate) {
            case STATE_APPSTART:
                RenderStart();
                break;
            case STATE_MAINMENU:
                RenderMainMenu();
                break;
            case STATE_OPTION:
                RenderOption();
                break;
        }
    }

    void RenderStart() {
        imgBackground.sprite = Resources.Load("menu", typeof(Sprite)) as Sprite;
        btnInvisible();
        if (Event.current.isKey) {
            textStartNotice.SetActive(false);
            StartCoroutine(movetitle());
            menustate = STATE_MAINMENU;
            aud_bgm_menu.Play();
        }
    }

    void RenderMainMenu() {
        imgBackground.sprite = Resources.Load("menu", typeof(Sprite)) as Sprite;
        textTitle.SetActive(true);
        btnVisible();
    }

    void RenderOption() {
        imgBackground.sprite = Resources.Load("explain", typeof(Sprite)) as Sprite;
        textTitle.SetActive(false);
        btnInvisible();
    }
}
