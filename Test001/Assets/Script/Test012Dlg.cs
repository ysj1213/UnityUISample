using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    public InputField Input_Name = null;
    public InputField Input_Kor = null;
    public InputField Input_Eng = null;
    public InputField Input_Math = null;
    public Button Btn_Ok = null;
    public Button Btn_Clear = null;
    public Text Text_Ok = null;

    void Start()
    {
        Btn_Ok.onClick.AddListener(OK);
        Btn_Clear.onClick.AddListener(Clear);

        Text_Ok.text = "";
    }

    void Clear()
    {
        Text_Ok.text = "";
    }

    void OK()
    {
        string name = Input_Name.text;
        int kor = int.Parse(Input_Kor.text);
        int eng = int.Parse(Input_Eng.text);
        int math = int.Parse(Input_Math.text);

        Text_Ok.text += $"이름 : {name} | 국어 : {kor}, 영어 : {eng}, 수학 : {math}\n";
    }
}
