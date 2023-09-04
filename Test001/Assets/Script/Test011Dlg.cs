using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    public InputField input_name = null;
    public InputField input_hp = null;
    public Button btn = null;
    public Button btn_ok = null;
    public Button btn_clear = null;
    public Text text = null;
    public Text text_Y = null;

    void Start()
    {
        btn.onClick.AddListener(Btn);
        btn_ok.onClick.AddListener(OK);
        btn_clear.onClick.AddListener(Clear);

        text_Y.text = "";
        text.text = "";
        input_hp.text = "";
        input_name.text = "";
    }

    List<Monster> list = new List<Monster>();

    void Btn()
    {
        if(0 <= int.Parse(input_hp.text) && int.Parse(input_hp.text) <= 100)
        {
            if(list.Count < 4)
            {
                Monster monster = new Monster();

                monster.Hp = int.Parse(input_hp.text);
                monster.Name = input_name.text;

                list.Add(monster);
                text_Y.text += $"({input_name.text}, {int.Parse(input_hp.text)}), ";

                input_hp.text = "";
                input_name.text = "";
            }
        }
    }

    void OK()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Hp -= 80;
            if (list[i].Hp < 0)
            {
                list[i].Hp = 0;
            }
            text.text += $"ÀÌ¸§ = {list[i].Name}, HP = {list[i].Hp}\n";
        }
    }

    void Clear()
    {
        text_Y.text = "";
        text.text = "";
        input_hp.text = "";
        input_name.text = "";
    }
}

public class Monster
{
    public int Hp;
    public string Name;
}
