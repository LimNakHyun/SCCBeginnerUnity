using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject square;
    public GameObject endPanel;
    public Text timeText;
    public Text thisScoreTxt;
    float alive = 0f;
    bool isRunning = true;
    public static gameManager I;    // public -> ������������ ȣ�� ����

    void Awake()
    {
        I = this;    // gameManager�� ȣ��Ǹ� I�� �־��־��
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeText.text = alive.ToString("N2");
        }
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void gameOver()
    {
        isRunning = false;
        Time.timeScale = 0f;
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString("N2");
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
