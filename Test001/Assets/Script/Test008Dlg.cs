using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    public Button btnOk = null;
    public Button btnClear = null;
    public Text text = null;

    void Start()
    {
        btnOk.onClick.AddListener(Ok);
        btnClear.onClick.AddListener(Clear);

        text.text = $"";
    }

    void Clear()
    {
        text.text = $"";
    }

    Dictionary<int, string> dic = new Dictionary<int, string>();

    void Ok()
    {
        dic.Add(1, "���");
        dic.Add(2, "��");
        dic.Add(3, "����");

        text.text += $"[Dictionary - KeyValuePair]\n";
        Foreach();

        dic[1] = "���ִ� ���";
        dic[2] = "���ִ� ��";

        text.text += $"\n[�� ���� - Key1,Key2�� �� ����]\n";
        Foreach();

        dic.Remove(1);

        text.text += $"\n[���� - Key1 ����]\n";
        Foreach();
    }

    void Foreach()
    {
        foreach (KeyValuePair<int, string> item in dic)
        {
            text.text += $"{item.Key} : {item.Value}, ";
        }
    }
}
