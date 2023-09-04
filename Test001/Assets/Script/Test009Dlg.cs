using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_text = null;

    void Start()
    {
        m_btnOk.onClick.AddListener(Ok);
        m_btnClear.onClick.AddListener(Clear);
    }

    void Clear()
    {
        m_text.text = "";
    }

    void Ok()
    {
        Actor m_Master = new Actor(5000, 100);
        //m_Master.m_HP = 5000;
        //m_Master.m_Attack = 100;

        Actor m_Enemy = new Actor(2000, 200);
        //m_Enemy.m_HP = 2000;
        //m_Enemy.m_Attack = 200;

        m_text.text = $"[기본 HP=5000, Attack=100]\nMaster HP = {m_Master.m_HP}\n";

        m_Master.SetDamage(50);
        m_text.text += $"[데미지 50 생김]\nMaster HP = {m_Master.m_HP}\n";

        m_text.text += $"------------------------------------------------------------\n";

        m_text.text += $"[적 HP=2000, Attack=200 으로 설정]\nEnemy HP = {m_Enemy.m_HP}\n";

        m_Enemy.SetDamage(m_Master.m_Attack);
        m_text.text += $"[적이 마스터에게 공격 당함]\nEnemy HP = {m_Enemy.m_HP}\n";

        m_text.text += $"------------------------------------------------------------\n";

        m_Master.SetHeal(100);
        m_text.text += $"[마스터가 HP 100만큼 힐링이 됨]\nMaster HP = {m_Master.m_HP}\n";

        m_Enemy.SetHeal(200);
        m_text.text += $"[적의 HP 200만큼 힐링이 됨]\nEnamy HP = {m_Enemy.m_HP}\n";

        m_text.text += $"------------------------------------------------------------\n";
    }
}
