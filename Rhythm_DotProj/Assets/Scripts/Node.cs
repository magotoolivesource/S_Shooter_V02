using UnityEditor.PackageManager.UI;
using UnityEngine;

public enum E_JudgeType
{
    Perfect,
    Good,
    Normal,
    Miss,

    Max
}


public class Node : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public float DeadY = -0.4f;

    public KeyCode PressCode = KeyCode.A;

    void Start()
    {
        
    }

    E_JudgeType GetJudgeType()
    {
        float y = transform.position.y;

        // 0.1f ~ -0.1f
        if(-0.1 < y && y < 0.1f )
        {
            return E_JudgeType.Perfect;
        }

        if (-0.3 < y && y < 0.3f)
        {
            return E_JudgeType.Good;
        }

        if (-0.5 < y && y < 0.5f)
        {
            return E_JudgeType.Normal;
        }

        if (-0.8 < y && y < 0.8f)
        {
            return E_JudgeType.Miss;
        }

        // �Ǻ��ϱ� �����
        return E_JudgeType.Max;
    }



    void UpdateMove()
    {
        this.transform.Translate(0f, -MoveSpeed * Time.deltaTime, 0f);

        // ��������
        if (transform.position.y <= DeadY)
        {
            GameObject.Destroy(gameObject);
        }


        // Ű�� �������� ó���κ�
        bool isakeypress = Input.GetKeyDown(PressCode);
        if (isakeypress == false)
            return;


        E_JudgeType type = GetJudgeType();
        if (type == E_JudgeType.Max)
            return;

        Debug.Log( $"���Ÿ�� : {type}");
        GameObject.Destroy(gameObject);


    }

    void Update()
    {
        UpdateMove();
    }
}
