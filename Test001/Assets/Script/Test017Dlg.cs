using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017Dlg : MonoBehaviour
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

    List<Student> students = new List<Student>();

    void OnClick_Clear()
    {
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
        Text_Add.text = "";
        Text_Ok.text = "";
    }

    void OnClick_Add()
    {
        Student student = new Student(Input_Name.text, int.Parse(Input_Kor.text), int.Parse(Input_Eng.text), int.Parse(Input_Math.text));

        if (0 > int.Parse(Input_Kor.text) || int.Parse(Input_Kor.text) > 100)
            return;
        if (0 > int.Parse(Input_Eng.text) || int.Parse(Input_Eng.text) > 100)
            return;
        if (0 > int.Parse(Input_Math.text) || int.Parse(Input_Math.text) > 100)
            return;

        students.Add(student);

        Text_Add.text = "";

        for (int i = 0; i < students.Count; i++)
        {
            Student kstudent = students[i];
            Text_Add.text += $"{kstudent.m_Name}, {kstudent.m_Kor}, {kstudent.m_Eng}, {kstudent.m_Math}\n";
        }
        Input_Name.text = "";
        Input_Kor.text = "";
        Input_Eng.text = "";
        Input_Math.text = "";
    }

    void OnClick_Save()
    {
        StreamWriter SW = new StreamWriter("Students.txt");
        SW.Flush();
        SW.WriteLine(students.Count);
        for (int i = 0; i < students.Count; i++)
        {
            SW.WriteLine(students[i].m_Name);
            SW.WriteLine(students[i].m_Kor);
            SW.WriteLine(students[i].m_Eng);
            SW.WriteLine(students[i].m_Math);
        }
        SW.Close();
    }

    void OnClick_Open()
    {
        students.Clear();

        StreamReader SR = new StreamReader("Students.txt");
        int count = int.Parse(SR.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = SR.ReadLine();
            int kor = int.Parse(SR.ReadLine());
            int eng = int.Parse(SR.ReadLine());
            int math = int.Parse(SR.ReadLine());
            Student student = new Student(name, kor, eng, math);
            students.Add(student);
            Student kstudent = students[i];
            Text_Add.text += $"{kstudent.m_Name}, {kstudent.m_Kor}, {kstudent.m_Eng}, {kstudent.m_Math}\n";
        }
        SR.Close();
    }


    void OnClick_Ok()
    {
        Text_Ok.text = "";

        students.Sort((a, b) => a.Add() < b.Add() ? 1 : -1);

        for (int i = 0; i < students.Count; i++)
        {
            Student kstudent = students[i];
            string ratingKor = kstudent.Rating(kstudent.m_Kor);
            string ratingEng = kstudent.Rating(kstudent.m_Eng);
            string ratingMath = kstudent.Rating(kstudent.m_Math);
            string ratingAverage = kstudent.Rating(kstudent.Average());
            Text_Ok.text += $"{i + 1}µî | {kstudent.m_Name}, {ratingKor}, {ratingEng}, {ratingMath} | {ratingAverage}\n";
        }
    }
}

public class Student
{
    public string m_Name = "";
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;

    public Student(string name, int kor, int eng, int math)
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
        if (61 <= rating && rating <= 70)
            return "D";
        if (71 <= rating && rating <= 80)
            return "C";
        if (81 <= rating && rating <= 90)
            return "B";
        if (91 <= rating && rating <= 100)
            return "A";
        else
            return "F";
    }
}