using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform TargetPos;
    public float MoveSpeed;

    public void UpdateMove()
    {
        Vector3 offsetvec = TargetPos.position - this.transform.position;

        Vector3 tagetvec = offsetvec;

        offsetvec.Normalize();
        // 이동
        offsetvec = offsetvec * MoveSpeed * Time.deltaTime;

        if(offsetvec.magnitude > tagetvec.magnitude)
        {
            this.transform.position = TargetPos.position;
        }
        else
        {
            this.transform.position += offsetvec;
        }

        //Vector3.MoveTowards()
        

        // 내위치를 기준으로 상대 위치값이 나옴 = (상대위치 vector3, - 내위치 vector3)
        // vector3, length, normal()
        // normal() * 2f;

        //Vector3 targetpos = 

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }
}
