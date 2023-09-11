using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test013Dlg : MonoBehaviour
{
    public InputField Input_Name = null;
    public InputField Input_Kor = null;
    public InputField Input_Eng = null;
    public InputField Input_Math = null;
    public Button Btn_Add = null;
    public Button Btn_Ok = null;
    public Button Btn_Clear = null;
    public Text Text_Add = null;
    public Text Text_Ok = null;

    void Start()
    {
        Btn_Add.onClick.AddListener(Add);
        Btn_Ok.onClick.AddListener(Ok);
        Btn_Clear.onClick.AddListener(Clear);

        Text_Add.text = "";
        Text_Ok.text = "";

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void Clear()
    {
        Text_Add.text = "";
        Text_Ok.text = "";

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    List<Score1> score1s = new List<Score1>();

    void Add()
    {
        Score1 score1 = new Score1();

        score1.m_Name = Input_Name.text;
        score1.m_Kor = int.Parse(Input_Kor.text);
        score1.m_Eng = int.Parse(Input_Eng.text);
        score1.m_Math = int.Parse(Input_Math.text);

        score1s.Add(score1);

        Text_Add.text += $"{score1.m_Name} : {score1.m_Kor}, {score1.m_Eng}, {score1.m_Math}\n";

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void Ok()
    {
        Score1 score1 = new Score1();

        for (int i = 0; i < score1s.Count; i++)
        {
            Text_Ok.text += $"{score1s[i].m_Name} : {score1s[i].m_Kor}, {score1s[i].m_Eng}, {score1s[i].m_Math} | ÇÕ°è : {score1s[i].Add()}, Æò±Õ : {string.Format("{0:0.00}", score1s[i].Average())}\n";
        }
    }
}

public class Score1
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
