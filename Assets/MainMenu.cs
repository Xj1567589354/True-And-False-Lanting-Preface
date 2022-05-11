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
    /// ��ʼ��Ϸ
    /// </summary>
    public void PlayGame()
    {
        show.StartGame = true;      //��ʼ��Ϸ
        Menu.SetActive(false);      //�������˵�
    }
    /// <summary>
    /// �˳���Ϸ
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
