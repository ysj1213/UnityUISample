using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    public InputField m_InputField0 = null;
    public InputField m_InputField1 = null;
    public InputField m_InputField2 = null;
    public Text m_Result = null;
    public Button m_btn = null;

    void Start()
    {
        m_btn.onClick.AddListener(Ok);
    }

    void Ok()
    {
        int score0 = int.Parse(m_InputField0.text);
        int score1 = int.Parse(m_InputField1.text);
        int score2 = int.Parse(m_InputField2.text);

        int[] score = new int[3];
        score[0] = score0;
        score[1] = score1;
        score[2] = score2;

        int number;

        if (score0 > score1)
        {
            if(score2 > score1)
            {
                if (score2 > score0)
                {
                    number = score2;
                    m_Result.text = $"가장 큰 숫자(if문) = {number}";
                    m_Result.text += $"\n{number}, {score0}, {score1}";
                }
                else
                {
                    number = score0;
                    m_Result.text = $"가장 큰 숫자(if문) = {number}";
                    m_Result.text += $"\n{number}, {score2}, {score1}";
                }
            }
            else
            {
                number = score0;
                m_Result.text = $"가장 큰 숫자(if문) = {number}";
                m_Result.text += $"\n{number}, {score1}, {score2}";
            }
        }
        else if(score1 > score2)
        {
            if (score0 > score2)
            {
                if (score1 > score0)
                {
                    number = score1;
                    m_Result.text = $"가장 큰 숫자(if문) = {number}";
                    m_Result.text += $"\n{number}, {score0}, {score2}";
                }
                else
                {
                    number = score0;
                    m_Result.text = $"가장 큰 숫자(if문) = {number}";
                    m_Result.text += $"\n{number}, {score1}, {score2}";
                }
            }
            else
            {
                number = score1;
                m_Result.text = $"가장 큰 숫자(if문) = {number}";
                m_Result.text += $"\n{number}, {score2}, {score0}";
            }
        }
        else if(score2 > score0)
        {
            if (score1 > score0)
            {
                if (score2 > score1)
                {
                    number = score2;
                    m_Result.text = $"가장 큰 숫자(if문) = {number}";
                    m_Result.text += $"\n{number}, {score1}, {score0}";
                }
                else
                {
                    number = score1;
                    m_Result.text = $"가장 큰 숫자(if문) = {number}";
                    m_Result.text += $"\n{number}, {score2}, {score0}";
                }
            }
            else
            {
                number = score2;
                m_Result.text = $"가장 큰 숫자(if문) = {number}";
                m_Result.text += $"\n{number}, {score0}, {score1}";
            }
        }

        if (score0 < score1)
        {
            Swap(ref score0, ref score1);
        }
        if(score1 < score2)
        {
            Swap(ref score1, ref score2);
        }
        if(score0 < score1)
        {
            Swap(ref score0, ref score1);
        }
        m_Result.text += $"\n가장 큰 숫자(Swap)는 {score0}\n{score0}, {score1}, {score2}";

        for (int i = 0; i < score.Length; i++)
        {
            for (int j = 0; j < score.Length - 1; j++)
            {
                if (score[i] > score[j])
                {
                    Swap(ref score[i], ref score[j]);
                }
            }
        }
        m_Result.text += $"\n가장 큰 숫자(for)는 {score[0]}\n{score[0]}, {score[1]}, {score[2]}";
    }

    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;

    }
}
