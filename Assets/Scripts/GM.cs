using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/****************************
 * 
 * 編排遊戲進程 彈幕出現順序
 * 
 * ****************************/

public class GM : MonoBehaviour {

    [System.Serializable]
    public struct Danmu {
        public DanmuDesign danmu;
        public float 幾秒後下一個彈幕;
    }

    public string 通關後的下一關;
    public Danmu[] danmus;
    public GameObject Player;
    public GameObject[] HPs = new GameObject[5];
    public GameObject[] Ultimates = new GameObject[5];
    public float bossHP;
    public int bulletDamage;
    public RectTransform bossHPBar;
    public Text LvName;
    public Text Score;
    public GameObject WinGameObject;
    public GameObject LoseGameObject;

    private float nextDanmuWaitTime = 0;
    private float nextDanmuExactTime = 0;
    private int nowDanmuIndex = 0;
    private int recordedPlayerHP = 5;
    private int recordedUltimateTimes = 5;
    private float bossTotalHP;
    private Scene currentScene;

	// Use this for initialization
	void Start () {
        GlobalVariables.playerHP = 5;
        GlobalVariables.bossHP = bossHP;
        GlobalVariables.bulletDamage = bulletDamage;
        GlobalVariables.ultimateTimes = recordedUltimateTimes;
        bossTotalHP = bossHP;
        GlobalVariables.gameOver = false;
        GlobalVariables.win = false;
        GlobalVariables.score = 0;
        currentScene = SceneManager.GetActiveScene();
        LvName.text = currentScene.name;
        Score.text = GlobalVariables.score.ToString();
        LoseGameObject.SetActive(false);
        WinGameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!GlobalVariables.gameOver && !GlobalVariables.win) {
            Score.text = GlobalVariables.score.ToString();
            if (recordedPlayerHP != GlobalVariables.playerHP) {
                recordedPlayerHP = GlobalVariables.playerHP;
                for (int i = 0; i < HPs.Length; i++) {
                    if (i < recordedPlayerHP) {
                        HPs[i].SetActive(true);
                    }
                    else {
                        HPs[i].SetActive(false);
                    }
                }
            }
            if (bossHP != GlobalVariables.bossHP) {
                bossHP = GlobalVariables.bossHP;
                print(bossHP);
                print(bossTotalHP);
                print(GlobalVariables.bossHPBar_totalW);
                print(bossHP / bossTotalHP * GlobalVariables.bossHPBar_totalW);
                bossHPBar.sizeDelta = new Vector2(bossHP / bossTotalHP * GlobalVariables.bossHPBar_totalW, 35);
            }
            if (recordedUltimateTimes != GlobalVariables.ultimateTimes) {
                recordedUltimateTimes = GlobalVariables.ultimateTimes;
                for (int i = 0; i < Ultimates.Length; i++) {
                    if (i < recordedUltimateTimes) {
                        Ultimates[i].SetActive(true);
                    }
                    else {
                        Ultimates[i].SetActive(false);
                    }
                }
            }
            if (GlobalVariables.playerHP > 0 && GlobalVariables.bossHP > 0) {
                if (nowDanmuIndex < danmus.Length) {
                    if (Time.time >= nextDanmuExactTime) {
                        Danmu danmuTemp = danmus[nowDanmuIndex];
                        danmuTemp.danmu.StartDanmu();
                        nextDanmuWaitTime = danmuTemp.幾秒後下一個彈幕;


                        nextDanmuExactTime = Time.time + nextDanmuWaitTime;
                        nowDanmuIndex += 1;
                    }
                }
                else {
                    nowDanmuIndex = 0;
                }
            }
            else if (GlobalVariables.playerHP <= 0) {
                //lose
                GlobalVariables.gameOver = true;
                LoseGameObject.SetActive(true);
            }
            else if (GlobalVariables.bossHP <= 0) {
                GlobalVariables.win = true;
                WinGameObject.SetActive(true);
            }
        }

        if (GlobalVariables.win == true) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                SceneManager.LoadScene(通關後的下一關);
            }
        }
        else if (GlobalVariables.gameOver == true) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                SceneManager.LoadScene("Title");
            }
        }
	}
}
