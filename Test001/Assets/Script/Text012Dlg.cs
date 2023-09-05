using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Text012Dlg : MonoBehaviour
{
    public InputField Input_Name = null;
    public InputField m_infiKor = null;
    public InputField m_infiEng = null;
    public InputField m_infiMat = null;
    public Button Btn_Ok = null;
    public Button Btn_Clear = null;
    public Text Text = null;


    void Start()
    {
        Btn_Ok.onClick.AddListener(OK);
        Btn_Clear.onClick.AddListener(Clear);
        Text.text = $"";
        Input_Name.text = "";
        m_infiKor.text = "";
        m_infiEng.text = "";
        m_infiMat.text = "";
    }

    void Clear()
    {
        Text.text = $"";
        Input_Name.text = "";
        m_infiKor.text = "";
        m_infiEng.text = "";
        m_infiMat.text = "";
    }

    void OK()
    {
        Score score = new Score();

        score.Name = Input_Name.text;
        score.m_Kor = int.Parse(m_infiKor.text);
        score.m_Eng = int.Parse(m_infiEng.text);
        score.m_Mat = int.Parse(m_infiMat.text);

        Text.text += $"이름 : {score.Name}\n국어 : {score.m_Kor}, 영어 : {score.m_Eng}, 수학 : {score.m_Mat}" +
            $"\n합계 : {score.Sum()}, 평균 : {score.Average()}";

        Input_Name.text = "";
        m_infiKor.text = "";
        m_infiEng.text = "";
        m_infiMat.text = "";
    }
}

public class Score
{
    public string Name = "";
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Mat = 0;

    int All = 0;
    int average = 0;

    public int Sum()
    {
         return (m_Kor + m_Eng + m_Mat);
    }

    public float Average()
    {
        return (float)Sum() / 3;
    }
}
