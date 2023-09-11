using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Text013Dlg : MonoBehaviour
{
    public InputField Input_Name = null;
    public InputField Input_Kor = null;
    public InputField Input_Eng = null;
    public InputField Input_Math = null;
    public Button Btn_Ok = null;
    public Button Btn_Clear = null;
    public Button Btn_Add = null;
    public Text Text_Ok = null;
    public Text Text_Add = null;

    void Start()
    {
        Btn_Ok.onClick.AddListener(Ok);
        Btn_Clear.onClick.AddListener(Clear);
        Btn_Add.onClick.AddListener(Add);
        Text_Add.text = "";
        Text_Ok.text = "";
    }

    void Clear()
    {
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
        Text_Add.text = "";
        Text_Ok.text = "";
    }

    List<Score2> score2s = new List<Score2>();

    void Add()
    {
        Score2 score2 = new Score2();

        string name = Input_Name.text;
        int kor = int.Parse(Input_Kor.text);
        int eng = int.Parse(Input_Eng.text);
        int math = int.Parse(Input_Math.text);

        score2.m_Name = name;
        score2.m_Kor = kor;
        score2.m_Eng = eng;
        score2.m_Math = math;

        score2s.Add(score2);

        Text_Add.text += $"{score2.m_Name} : {score2.m_Kor}, {score2.m_Eng}, {score2.m_Math}\n";

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void Ok()
    {
        int kKor = 0;
        int kEng = 0;
        int kMath = 0;

        score2s.Sort((a, b) => a.Add() < b.Add() ? 1 : -1);
        for (int i = 0; i < score2s.Count; i++)
        {
            Score2 kscore = score2s[i];
            Text_Ok.text += $"{i + 1}등 - {kscore.m_Name} : {kscore.m_Kor}, {kscore.m_Eng}, {kscore.m_Math} | 합계 : {kscore.Add()}, 평균 : {string.Format("{0:0.00}", kscore.Average())}\n";
            kKor += kscore.m_Kor;
            kEng += kscore.m_Eng;
            kMath += kscore.m_Math;
        }
        Text_Ok.text += $"--------------------------------------------------------------\n";
        Text_Ok.text += $"합계 | 국어 : {kKor}, 영어 : {kEng}, 수학 : {kMath}\n";
        Text_Ok.text += $"--------------------------------------------------------------\n";
        Text_Ok.text += $"평균 | 국어 : {string.Format("{0:0.00}", kKor / 3)}, 영어 : {string.Format("{0:0.00}", kEng / 3)}, 수학 : {string.Format("{0:0.00}", kMath / 3)}\n";
        Text_Ok.text += $"--------------------------------------------------------------\n";
    }
}

public class Score2
{
    public string m_Name = "";
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;

    public int Add()
    {
        return (m_Kor + m_Eng + m_Math);
    }

    public float Average()
    {
        return (float)Add() / 3;
    }
}
