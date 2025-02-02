using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform TargetPos;
    public Transform NextTarget1;
    public Transform NextTarget2;
    public Transform NextTarget3;
    public Transform NextTarget4;
    public Transform NextTarget5;
    public Transform NextTarget6;
    public Transform NextTarget7;

    public Transform[] NextTragetArr;// = new Transform[10];


    public float MoveSpeed;
    public int MoveCount = 0;

    // 방법 1
    public void UpdateMove()
    {
        Vector3 offsetvec = TargetPos.position - this.transform.position;

        Vector3 tagetvec = offsetvec;

        offsetvec.Normalize();
        // 이동
        offsetvec = offsetvec * MoveSpeed * Time.deltaTime;

        if(offsetvec.magnitude > tagetvec.magnitude)
        {
            // 도착
            this.transform.position = TargetPos.position;

            //++MoveCount;
            MoveCount = (MoveCount + 1);

            if ( false )
            {
                // 무조건 이동방식
                //MoveCount = (MoveCount + 1);
                if (MoveCount < NextTragetArr.Length)
                {
                    TargetPos = NextTragetArr[MoveCount];
                }
            }
            else
            {
                TargetPos = NextTragetArr[MoveCount % NextTragetArr.Length];
            }
            
                

            //if ( MoveCount == 1 )
            //    TargetPos = NextTragetArr[1 - 1];
            //else if (MoveCount == 2)
            //    TargetPos = NextTragetArr[2 - 1];
            //else if (MoveCount == 3)
            //    TargetPos = NextTragetArr[3 - 1];
            //else if (MoveCount == 4)
            //    TargetPos = NextTragetArr[4- 1];
            //else if (MoveCount == 5)
            //    TargetPos = NextTragetArr[4];
            //else if (MoveCount == 6)
            //    TargetPos = NextTragetArr[5];
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




        // 목표까지 이동이후
        // 다음 목표 이동처리하기
        //TargetPos = 

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
