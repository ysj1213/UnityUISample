using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    public Text m_Result = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;

    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_Result.text = "";
    }

    private void OnClicked_Clear()
    {
        m_Result.text = "";
    }

    private void OnClicked_OK()
    {
        int a = 100;
        int b = 200;

        int sum = Sum(a, b);
        m_Result.text = $"a = {a}, b = {b}\n";
        m_Result.text += $"гу╟Х = {sum}\n";

        Swap1(a, b);
        m_Result.text += $"Swap1 = {a}, {b}\n";

        Swap2(ref a, ref b);
        m_Result.text += $"Swap2 = {a}, {b}\n";
    }

    private int Sum(int a, int b)
    {
        int sum = a + b;
        return sum;
    }

    private void Swap1(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    private void Swap2(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
