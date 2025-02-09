using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public NextTargetCom TargetPos;
    public float MoveSpeed;

    public void SetTargetPos()
    {
        TargetPos = null;
    }

    // 방법 2
    public void UpdateMove()
    {
        // 빈값이면 이동 처리안함
        if(TargetPos == null)
        {
            return;
        }

        // 이동처리
        Vector3 offsetvec = TargetPos.transform.position - this.transform.position;

        Vector3 tagetvec = offsetvec;

        offsetvec.Normalize();
        // 이동
        offsetvec = offsetvec * MoveSpeed * Time.deltaTime;

        if (offsetvec.magnitude > tagetvec.magnitude)
        {
            // 도착
            this.transform.position = TargetPos.transform.position;

            // 도착 하면 다음 타겟 이동처리
            TargetPos = TargetPos.NextTarget;

            //TargetPos = TargetPos.GetRandomNextTraget();
            //TargetPos = TargetPos.GetNextTraget(0);
        }
        else
        {
            this.transform.position += offsetvec;
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }
}
