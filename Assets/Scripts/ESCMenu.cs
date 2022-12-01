using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public bool isShow;
    void Start()
    {
        MenuCanvas.SetActive(false);
        isShow = false;
        Time.timeScale = (1);
    }
    void Update()
    {
        //判断是否按下Esc键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC");
            //如果面板正在显示，关掉面板并让游戏继续运行
            if (isShow)
            {
                MenuCanvas.SetActive(false);
                isShow = false;
                Time.timeScale = (1);
            }
            //否则开启面板并暂停游戏
            else
            {
                MenuCanvas.SetActive(true);
                isShow = true;
                Time.timeScale = (0);
            }
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}