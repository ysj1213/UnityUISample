using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_Result = null;
    public InputField m_InputField = null;
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClick_OK);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }

    void OnClick_Clear()
    {
        m_Result.text = "";
    }

    void OnClick_OK()
    {
        string rank;

        int score = int.Parse(m_InputField.text);

        if (score >= 90)
        {
            rank = "A";
        }
        else if (score >= 80)
        {
            rank = "B";
        }
        else if (score >= 70)
        {
            rank = "C";
        }
        else if (score >= 60)
        {
            rank = "D";
        }
        else
        {
            rank = "F";
        }
        m_Result.text = $"if¹® = {rank}";
        switch (score)
        {
            case >= 90:
                rank = "A";
                break;
            case >= 80:
                rank = "B";
                break;
            case >= 70:
                rank = "C";
                break;
            case >= 60:
                rank = "D";
                break;
            default:
                rank = "F";
                break;
        }

        m_Result.text += $"\nswitch¹® = {rank}";
    }
}
