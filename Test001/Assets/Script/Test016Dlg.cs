using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Test016Dlg : MonoBehaviour
{
    public InputField Input_Name = null;
    public InputField Input_Kor = null;
    public InputField Input_Eng = null;
    public InputField Input_Math = null;
    public Button Btn_Add = null;
    public Button Btn_Ok = null;
    public Button Btn_Clear = null;
    public Button Btn_Open = null;
    public Button Btn_Save = null;
    public Text Text_Add = null;
    public Text Text_Ok = null;

    void Start()
    {
        Btn_Add.onClick.AddListener(Add);
        Btn_Ok.onClick.AddListener(OK);
        Btn_Clear.onClick.AddListener(Clear);
        Btn_Open.onClick.AddListener(Open);
        Btn_Save.onClick.AddListener(Save);

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
        Text_Add.text = "";
        Text_Ok.text = "";
    }

    List<Score016> scorelist = new List<Score016>();

    void Save()
    {
        
        StreamWriter SW = new StreamWriter("temp.txt");
        SW.WriteLine(scorelist.Count);
        for (int i = 0; i < scorelist.Count; i++)
        {
            Score016 scorefor = scorelist[i];
            SW.WriteLine(scorefor.m_Name);
            SW.WriteLine(scorefor.m_Kor);
            SW.WriteLine(scorefor.m_Eng);
            SW.WriteLine(scorefor.m_Math);
        }
        SW.Close();
    }

    void Open()
    {
        scorelist.Clear();
        Text_Add.text = "";
        Text_Ok.text = "";
        StreamReader WR = new StreamReader("temp.txt");
        int count = int.Parse(WR.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string  name = WR.ReadLine();
            int kor = int.Parse(WR.ReadLine());
            int eng = int.Parse(WR.ReadLine());
            int math = int.Parse(WR.ReadLine());
            Score016 kscore = new Score016(name , kor, eng, math);
            scorelist.Add(kscore);
            Text_Add.text += $"{name}, {kor}, {eng}, {math}\n";
        }
        WR.Close();
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

    void Add()
    {

        string name = Input_Name.text;
        int kor = int.Parse(Input_Kor.text);
        int eng = int.Parse(Input_Eng.text);
        int math = int.Parse(Input_Math.text);
        Score016 score016 = new Score016(name,kor,eng,math);
        if (0 > score016.m_Kor || score016.m_Kor > 100)
            return;
        if (0 > score016.m_Eng || score016.m_Eng > 100)
            return;
        if (0 > score016.m_Math || score016.m_Math > 100)
            return;

        scorelist.Add(score016);

        Text_Add.text += $"{score016.m_Name}, {score016.m_Kor}, {score016.m_Eng}, {score016.m_Math}\n";

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";

    }

    async void OK()
    {

        float kor = 0;
        float eng = 0;
        float math = 0;

        //삼항연산자
        // 조건문 ? 참일때 : 거짓일때
        scorelist.Sort((a, b) => a.ADD() < b.ADD() ? 1 : -1);

        for (int i = 0; i < scorelist.Count; i++)
        {
            Score016 scorefor = scorelist[i];
            kor += scorefor.m_Kor;
            eng += scorefor.m_Eng;
            math += scorefor.m_Math;

            Text_Ok.text += $"{i + 1}등 | {scorefor.m_Name}, {scorefor.m_Kor}, {scorefor.m_Eng}, {scorefor.m_Math} | 합계 : {scorefor.ADD()}, 평균 : {string.Format("{0:0.00}",(scorefor.ADD() / scorelist.Count + 1))}\n";
        }

        Text_Ok.text += $"국어 | 합계 : {kor}, 평균 : {string.Format("{0:0.00}", (kor / scorelist.Count + 1))}\n";
        Text_Ok.text += $"영어 | 합계 : {eng}, 평균 : {string.Format("{0:0.00}", (eng / scorelist.Count + 1))}\n";
        Text_Ok.text += $"수학 | 합계 : {math}, 평균 : {string.Format("{0:0.00}", (math / scorelist.Count + 1))}\n";
    }
}

public class Score016
{
    public string m_Name = "";
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;

    public Score016(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
    }


    public float ADD()
    {
        return (float)m_Kor + m_Eng + m_Math;
    }
}
