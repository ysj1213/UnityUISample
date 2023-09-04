using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public InputField m_InputF = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Text m_Text = null;
    public Text m_ListText = null;

    void Start()
    {
        m_btnOk.onClick.AddListener(Ok);
        m_btnClear.onClick.AddListener(Clear);
        m_btnAdd.onClick.AddListener(Add);

        m_Text.text = "";
        m_ListText.text = "";
    }

    List<int> list = new List<int>();

    void Add()
    {
        if (list.Count == 5)
            return;

        int input = int.Parse(m_InputF.text);

        if(0 < input && input < 100)
        {
            list.Add(input);
            m_ListText.text += $"{m_InputF.text}, ";
            m_InputF.text = string.Empty; //"";
        }
    }

    void Clear()
    {
        m_Text.text = "";
        m_ListText.text = "";

        list.Clear();
    }

    void Ok()
    {
        list.Sort((int a, int b) => a > b ? 1 : -1);

        m_Text.text += $"Â¥ÀÜ!!\n";

        for (int i = 0; i < list.Count; i++)
        {
            m_Text.text += $"{list[i]}, ";
        }
    }
}
