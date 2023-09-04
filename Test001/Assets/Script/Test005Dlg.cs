using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    public Text m_Result = null;
    public Button m_btn = null;
    public Button m_btnC = null;

    void Start()
    {
        m_btn.onClick.AddListener(Ok);
        m_btnC.onClick.AddListener(Clear);
    }

    void Clear()
    {
        m_Result.text = "";
    }

    int[] nums = new int[3];

    void Ok()
    {
        nums[0] = 100;
        nums[1] = 200;
        nums[2] = 300;

        //Test_for();
        //Test_while();
        //Test_do_whlie();
        Test_int2_1();
        Test_int2_2();
    }
    void Test_for()
    {
        m_Result.text += "[for문 실행]\n";
        for (int i = 0; i < nums.Length; i++)
        {
            m_Result.text += $"for문 = {nums[i]}, ";
        }
    }

    void Test_while()
    {
        m_Result.text += "\n[whlie문 실행]\n";
        int j = 0;

        while (j < nums.Length)
        {
            m_Result.text += $"while문  = {nums[j]}, ";
            j++;
        }
    }

    void Test_do_whlie()
    {
        m_Result.text += "\n[do_while문 실행]\n";
        int j = 0;

        do
        {
            m_Result.text += $"while문  = {nums[j]}, ";
            j++;
        }
        while (j < nums.Length);
    }

    void Test_int2_1()
    {
        int[,] nums1 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

        m_Result.text += $"[2중 배열_1]\n";

        PrintArray(nums1);
    }

    void Test_int2_2()
    {
        int[,] nums2 = new int[3, 2];

        nums2[0, 0] = 1;
        nums2[0, 1] = 2;
        nums2[1, 0] = 3;
        nums2[1, 1] = 4;
        nums2[2, 0] = 5;
        nums2[2, 1] = 6;

        m_Result.text += $"[2중 배열_2]\n";

        PrintArray(nums2);
    }

    void PrintArray(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                m_Result.text += $"array[{i},{j}] = {arr[i, j]}\n";
            }
        }
    }
}
