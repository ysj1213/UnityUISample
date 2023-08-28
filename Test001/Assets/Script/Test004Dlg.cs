using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public InputField m_InputField = null;
    public Text m_Result = null;
    public Button m_btn = null;
    void Start()
    {
        m_btn.onClick.AddListener(Ok);
    }

    void Ok()
    {
        int score = int.Parse(m_InputField.text);
        int number = 1;
        m_Result.text = $"";

        for (int i = 2; i <= score; i++)
        {
            number *= i;
            m_Result.text += $"{i - 1} X ";
        }
        m_Result.text += $"{score}";
        m_Result.text += $" = {number}";

    }
}
