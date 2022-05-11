using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Other_Narrator : MonoBehaviour
{
    public Dialogue _Narrator;
    public Queue<string> Sentences;
    public GameObject PlayerHandle;
    public Text NarratorText;
    bool FadeState = false;
    public float time = 0;
    public TaskList TaskList;
    KeyBoardInput KBI;       //��λ����

    private void Start()
    {
        Sentences = new Queue<string>();
        KBI = FindObjectOfType<KeyBoardInput>();
    }

    public void Update()
    {
        if (FadeState == true)      //4s���԰���ʧ
        {
            time += Time.deltaTime;
            if (time > 4.0f)
            {
                NarratorText.gameObject.SendMessage("UIHide", SendMessageOptions.DontRequireReceiver);
                KBI.mouseEnable = true;
                KBI.KeyEnable = true;

                FadeState = false;
                time = 0;

                TaskList.ElapseTime = 0;                //�����ʱ����
                TaskList.Count++;       //��ʾ��һ��������ʾ
            }
        }
    }

    /// <summary>
    /// ��ʼ�԰��¼�
    /// </summary>
    /// <param name="_narrator">�԰�����</param>
    public void StartNarrator(Dialogue _narrator)
    {
        NarratorText.gameObject.SendMessage("UIShow", SendMessageOptions.DontRequireReceiver);       //�԰���ʾ
        KBI.mouseEnable = false;        //��������ͷ�ƶ�
        KBI.KeyEnable = false;          //���ü�λ����

        Sentences.Clear();  //��ն���
        foreach (string item_sentence in _narrator.Sentences)
        {
            Sentences.Enqueue(item_sentence);       //���
        }
        DisplayNarrator();      //������һ���԰�
    }

    /// <summary>
    /// ������һ���԰��¼�
    /// </summary>
    public void DisplayNarrator()
    {
        StopAllCoroutines();
        string sentence = Sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    /// <summary>
    /// �԰�������ʾ�¼�
    /// </summary>
    /// <param name="Sentence">�԰�����</param>
    /// <returns></returns>
    IEnumerator TypeSentence(string Sentence)
    {
        NarratorText.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            NarratorText.text += letter;
            yield return new WaitForSeconds(0.1f);      //0.1s�����ִ��
        }
        EndNarrator();
    }

    /// <summary>
    /// �����԰�
    /// </summary>
    public void EndNarrator()
    {
        FadeState = true;
    }
}