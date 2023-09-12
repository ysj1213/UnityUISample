using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017_1Dlg : MonoBehaviour
{
    public InputField Input_Name = null;
    public InputField Input_Kor = null;
    public InputField Input_Eng = null;
    public InputField Input_Math = null;
    public Button Btn_Add = null;
    public Button Btn_Ok = null;
    public Button Btn_Clear = null;
    public Button Btn_Save = null;
    public Button Btn_Open = null;
    public Text Text_Add = null;
    public Text Text_Ok = null;

    void Start()
    {
        Btn_Add.onClick.AddListener(OnClick_Add);
        Btn_Ok.onClick.AddListener(OnClick_Ok);
        Btn_Clear.onClick.AddListener(OnClick_Clear);
        Btn_Save.onClick.AddListener(OnClick_Save);
        Btn_Open.onClick.AddListener(OnClick_Open);

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
        Text_Add.text = "";
        Text_Ok.text = "";
    }

    List<Student1> student1s = new List<Student1>();

    void OnClick_Add()
    {
        Student1 student1 = new Student1(Input_Name.text, int.Parse(Input_Kor.text), int.Parse(Input_Eng.text), int.Parse(Input_Math.text));
        student1s.Add(student1);

        Text_Add.text = "";
        for (int i = 0; i < student1s.Count; i++)
        {
            Student1 kstudent1 = student1s[i];
            Text_Add.text += $"{kstudent1.m_Name}, {kstudent1.m_Kor}, {kstudent1.m_Eng}, {kstudent1.m_Math}\n";
        }

        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void OnClick_Ok()
    {
        Text_Ok.text = "";
        for (int i = 0; i < student1s.Count; i++)
        {
            Student1 kstudent1 = student1s[i];
            string StuKor = kstudent1.Rating(kstudent1.m_Kor);
            string StuEng = kstudent1.Rating(kstudent1.m_Eng);
            string StuMath = kstudent1.Rating(kstudent1.m_Math);
            string StuAverage = kstudent1.Rating(kstudent1.Average());
            Text_Ok.text += $"{i + 1}µî | {kstudent1.m_Name}, {StuKor}, {StuEng}, {StuMath} | {StuAverage}\n";
        }
    }

    void OnClick_Clear()
    {
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
        Text_Add.text = "";
        Text_Ok.text = "";
    }

    void OnClick_Save()
    {
        StreamWriter SW = new StreamWriter("Test017_1.txt");
        SW.Flush();
        SW.WriteLine(student1s.Count);
        for (int i = 0; i < student1s.Count; i++)
        {
            Student1 kstu = student1s[i];
            SW.WriteLine(kstu.m_Name);
            SW.WriteLine(kstu.m_Kor);
            SW.WriteLine(kstu.m_Eng);
            SW.WriteLine(kstu.m_Math);
        }
        SW.Close();
    }

    void OnClick_Open()
    {
        student1s.Clear();
        StreamReader WR = new StreamReader("Test017_1.txt");
        int count = int.Parse(WR.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = WR.ReadLine();
            int kor = int.Parse(WR.ReadLine());
            int eng = int.Parse(WR.ReadLine());
            int math = int.Parse(WR.ReadLine());
            Student1 student1 = new Student1(name, kor, eng, math);
            student1s.Add(student1);
            Student1 kstu = student1s[i];
            Text_Add.text += $"{kstu.m_Name}, {kstu.m_Kor}, {kstu.m_Eng}, {kstu.m_Math}\n";
        }
        WR.Close();
    }
}

public class Student1
{
    public string m_Name = "";
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;

    public Student1(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
    }

    public float Add()
    {
        return (float)m_Kor + m_Eng + m_Math;
    }

    public float Average()
    {
        return (float)Add() / 3;
    }

    public string Rating(float rating)
    {
        if (100 >= rating && rating > 90)
            return "A";
        if (90 >= rating && rating > 80)
            return "B";
        if (80 >= rating && rating > 70)
            return "C";
        if (70 >= rating && rating > 60)
            return "D";
        else
            return "F";
    }
}