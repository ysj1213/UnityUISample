using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Test015Dlg : MonoBehaviour
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
        Btn_Ok.onClick.AddListener(OK);
        Btn_Clear.onClick.AddListener(Clear);

        Text_Add.text = $"";
        Text_Ok.text = $"";
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void Clear()
    {
        Text_Add.text = $"";
        Text_Ok.text = $"";
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    List<Score3> score3s = new List<Score3>();

    void Add()
    {
        Score3 score3 = new Score3();

        score3.m_Name = Input_Name.text;
        score3.m_Kor = int.Parse(Input_Kor.text);
        score3.m_Eng = int.Parse(Input_Eng.text);
        score3.m_Math = int.Parse(Input_Math.text);

        if (0 <= score3.m_Kor && score3.m_Kor <= 100)
        {
            if (0 <= score3.m_Eng && score3.m_Eng <= 100)
            {
                if (0 <= score3.m_Math && score3.m_Math <= 100)
                {
                    if (score3s.Count >= 3)
                        return;

                    score3s.Add(score3);

                    Text_Add.text += $"{score3.m_Name} : {score3.m_Kor}, {score3.m_Eng}, {score3.m_Math}\n";
                }
            }
        }
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void OK()
    {
        float kor = 0;
        float eng = 0;
        float math = 0;

        score3s.Sort((a, b) => a.Add() < b.Add() ? 1 : -1);

        for (int i = 0; i < score3s.Count; i++)
        {
            Score3 Forscore = score3s[i];
            Text_Ok.text += $"{i + 1}등 - {Forscore.m_Name} : {Forscore.m_Kor}, {Forscore.m_Eng}, {Forscore.m_Math} | 합계 : {Forscore.Add()}, 평균 : {string.Format("{0:0.00}", Forscore.Add() / score3s.Count + 1)}\n";

            kor += Forscore.m_Kor;
            eng += Forscore.m_Eng;
            math += Forscore.m_Math;
        }
        Text_Ok.text += $"============================================\n";
        Text_Ok.text += $"국어 | 합계 : {kor}, 평균 : {string.Format("{0:0.00}", kor / score3s.Count + 1)}\n";
        Text_Ok.text += $"영어 | 합계 : {eng}, 평균 : {string.Format("{0:0.00}", eng / score3s.Count + 1)}\n";
        Text_Ok.text += $"수학 | 합계 : {math}, 평균 : {string.Format("{0:0.00}", math / score3s.Count + 1)}\n";
    }
}

public class Score3
{
    public string m_Name = "";
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;

    public float Add()
    {
        return (m_Kor + m_Eng + m_Math);
    }

    //public float Average()
    //{
    //    return (float)Add() / 3;
    //}
}
