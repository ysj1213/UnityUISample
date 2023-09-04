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
        dic.Add(1, "사과");
        dic.Add(2, "배");
        dic.Add(3, "수박");

        text.text += $"[Dictionary - KeyValuePair]\n";
        Foreach();

        dic[1] = "맛있는 사과";
        dic[2] = "맛있는 배";

        text.text += $"\n[값 변경 - Key1,Key2의 값 변경]\n";
        Foreach();

        dic.Remove(1);

        text.text += $"\n[삭제 - Key1 삭제]\n";
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
