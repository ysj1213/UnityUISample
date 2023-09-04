using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public int m_HP = 0;
    public int m_Attack = 0;
    public void SetDamage(int damage)
    {
        m_HP -= damage;
    }

    public void SetHeal(int heal)
    {
        m_HP += heal;
    }

    public Actor(int h, int a)
    {
        m_HP = h;
        m_Attack = a;
    }
}
