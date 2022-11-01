using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class GameMananger : MonoBehaviour
{
    public GameObject main;
    public GameObject tut;
    public GameObject score;
    public GameObject over;

    public Text nowScoreText;
    public Text bestScoreText;
    public GameObject NewScore;
    public Image Medal;

    public List<Sprite> medals;

    public bool isGameReady = false;
    public bool isGameStart = false;

    public Text scoreText;

    public GameObject bird;

    private void Awake()
    {
        Init();
    }

    //public void Start()
    //{
    //    PlayerPrefs.SetInt("bestScore", 0);
    //}

    public void PlayBtnClick()
    {
        Tools.Ins.HideUI(main);
        Tools.Ins.ShowUI(tut);
        Tools.Ins.ShowUI(score);
        bird.GetComponent<birdFly>().ChangeState(true);
        isGameReady = true;
        OnStateBtn(true);
    }

    private void Update()
    {
        if (!isGameReady) return;
        if (isGameStart) return;
        if (Input.GetMouseButtonDown(0))
        {
            Tools.Ins.HideUI(tut);
            bird.GetComponent<birdFly>().Fly();
            bird.GetComponent<birdFly>().ChangeState(true, true);
            isGameStart = true;
        }
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void GameOver()
    {
        if (!isGameStart) return;

        isGameReady = false;
        isGameStart = false;

        GameObject.Find("ZhuZiController").GetComponent<ZhuZiController>().StopMove();
        GameObject.Find("bgs").GetComponent<bgController>().isMove = false;
        GameObject.Find("lands").GetComponent<bgController>().isMove = false;

        Tools.Ins.ShowUI(over);

        //拿到分数
        int score = int.Parse(scoreText.text);

        if(score >= 50)
        {
            Medal.sprite = medals[3];
        }
        else if(score >= 30)
        {
            Medal.sprite = medals[2];
        }
        else if(score >= 20)
        {
            Medal.sprite = medals[1];
        }
        else if(score >= 10)
        {
            Medal.sprite = medals[0];
        }
        else
        {
            Medal.gameObject.SetActive(false);
        }
        

        if(PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
            NewScore.SetActive(true);
        }

        nowScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();

        GameContainer.Instance.goldCoin += score;
        pauseGO.SetActive(false);
        playGO.SetActive(false);
    }

    /// <summary>
    /// 得分
    /// </summary>
    public void GetScore()
    {
        if (!isGameStart) return;
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
    }

    /// <summary>
    /// 重新开始
    /// </summary>
    public void ReStart()
    {
        SceneManager.LoadScene("GameScene");
    }



    //-----分界线-----
    [Space(5)] public GameObject pauseGO;
    public GameObject playGO;
    public Shopping shopping;
    public Settings setting;


    private void Init()
    {
        pauseGO.SetActive(false);
        playGO.SetActive(false);
        shopping.SetActive(false);
        setting.SetActive(false);
        setting.Init(GameContainer.Instance.muteState);
    }

    public void OnStateBtn(bool state)
    {
        Time.timeScale = state ? 1 : 0;
        pauseGO.SetActive(state);
        playGO.SetActive(!state);
    }

    /// <summary> 点击商店按钮 </summary>
    public void OnShoppingBtn()
    {
        shopping.SetActive(true);
    }

    /// <summary> 点击设置按钮 </summary>
    public void OnSettingBtn()
    {
        setting.SetActive(true);
    }

    /// <summary> 点击Ok按钮 </summary>
    public void OnOkBtn()
    {
        shopping.SetActive(false);
        setting.SetActive(false);
        ReStart();
    }

}
