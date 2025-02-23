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

    public float HitSec = 10;

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

        // 판별하기 힘들다
        return E_JudgeType.Max;
    }



    void UpdateMove()
    {
        this.transform.Translate(0f, -MoveSpeed * Time.deltaTime, 0f);

        // 노드지우기
        if (transform.position.y <= DeadY)
        {
            GameObject.Destroy(gameObject);
        }


        return;
        //// 라인에서 사용함
        //// 키를 눌렀을때 처리부분
        //bool isakeypress = Input.GetKeyDown(PressCode);
        //if (isakeypress == false)
        //    return;


        //E_JudgeType type = GetJudgeType();
        //if (type == E_JudgeType.Max)
        //    return;

        //Debug.Log( $"노드타입 : {type}");
        //GameObject.Destroy(gameObject);


    }

    void Update()
    {
        UpdateMove();
    }
}
