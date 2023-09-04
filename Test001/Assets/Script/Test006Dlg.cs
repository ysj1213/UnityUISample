using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    public Text m_Result = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;

    List<int> nums1 = new List<int>();
    List<int> nums2 = new List<int>();
    void Start()
    {
        m_btnOk.onClick.AddListener(Ok);
        m_btnClear.onClick.AddListener(Clear);
    }

    void Clear()
    {
        m_Result.text = $"";
    }

    void Ok()
    {
        nums1.Clear();
        nums2.Clear();

        nums1.Add(10);
        nums1.Add(20);
        nums1.Add(30);
        ListFor(nums1);

        nums2.Add(10);
        nums2.Add(20);
        nums2.Add(30);
        nums2.Add(40);
        nums2.Add(50);
        ListForeach(nums2);

        nums2.Remove(10);
        nums2.Remove(40);
        ListForeach(nums2);
    }

    void ListFor(List<int> nums)
    {
        m_Result.text += $"[[List : for¹®]\n";

        for (int i = 0; i < nums.Count; i++)
        {
            m_Result.text += $"[{i}] : {nums[i]}, ";
        }

        m_Result.text += $"\n------------------\n";
    }

    void ListForeach(List<int> nums)
    {
        m_Result.text += $"[[List : foreach¹®]\n";

        foreach (int item in nums)
        {
            m_Result.text += ($"{item}, ");
        }

        m_Result.text += $"\n------------------\n";
    }
}
