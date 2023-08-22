using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        // 이동
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }

        // 회전
        if(Input.GetKey(KeyCode.R))
        {
            transform.eulerAngles += new Vector3(0, 0, 3);
        }
        if (Input.GetKey(KeyCode.T))
        {
            transform.eulerAngles += new Vector3(0, 0, -3);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.eulerAngles += new Vector3(0, 3, 0);
        }
        if (Input.GetKey(KeyCode.G))
        {
            transform.eulerAngles += new Vector3(0, -3, 0);
        }
        if (Input.GetKey(KeyCode.V))
        {
            transform.eulerAngles += new Vector3(3, 0, 0);
        }
        if (Input.GetKey(KeyCode.B))
        {
            transform.eulerAngles += new Vector3(-3, 0, 0);
        }

        // 확대/축소
        if (Input.GetKey(KeyCode.Z))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
        }
    }
}
