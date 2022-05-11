using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Show show;
    public GameObject Menu;
    public CameraController camcon;
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void PlayGame()
    {
        show.StartGame = true;      //开始游戏
        Menu.SetActive(false);      //隐藏主菜单
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
