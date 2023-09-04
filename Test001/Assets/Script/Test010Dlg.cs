using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public InputField input_name = null;
    public InputField input_kg = null;
    public Button btn = null;
    public Button btn_clear = null;
    public Button btn_ok = null;
    public Text text = null;
    
    void Start()
    {
        btn_ok.onClick.AddListener(Ok);
        btn_clear.onClick.AddListener(clear);
        btn.onClick.AddListener(btn_);

        text.text = "";
    }

    List<Animal> list = new List<Animal>();

    void btn_()
    {
        if (0 <= int.Parse(input_kg.text) && int.Parse(input_kg.text) <= 2000)
        {
            if (list.Count < 2)
            {
                Animal animal = new Animal();

                animal.kg = int.Parse(input_kg.text);
                animal.name = input_name.text;

                list.Add(animal);

                input_name.text = "";
                input_kg.text = "";
            }
        }
    }

    void clear()
    {
        text.text = "";
        input_name.text = "";
        input_kg.text = "";

        list.Clear();
    }

    void Ok()
    {
        text.text = "";
        if(list.Count == 2)
        {
            text.text += $"{list[0].name}, {list[1].name}의 몸무게 합은 {list[0].kg + list[1].kg}Kg이다.";
        }
        else
        {
            text.text += $"{list[0].name}의 몸무게는 {list[0].kg}Kg이다.";
        }
    }
}

public class Animal
{
    public int kg;
    public string name;
}
