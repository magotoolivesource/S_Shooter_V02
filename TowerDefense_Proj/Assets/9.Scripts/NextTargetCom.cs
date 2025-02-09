using UnityEngine;

public class NextTargetCom : MonoBehaviour
{
    public NextTargetCom NextTarget;



    public NextTargetCom[] NextTargetArray; // 3

    public NextTargetCom GetRandomNextTraget()
    {
        int size = NextTargetArray.Length;
        if (size <= 0)
            return null;
        int rand = Random.Range(0, size);// 0; // 0~2
        return NextTargetArray[rand];
    }

    public NextTargetCom GetNextTraget(int p_index)
    {
        // p_index = 20
        // NextTargetArray.Length = 2

        int size = NextTargetArray.Length;
        if (size <= 0)
            return null;


        //// 방법 2
        //// 배열범위 마이너가 되었을때 예외처리
        //if (p_index < 0
        //   || p_index >= size )
        //{
        //    return null;
        //}
        //return NextTargetArray[p_index];


        //// 방법 1
        //if (0 <= p_index && p_index < size)
        //{
        //    return NextTargetArray[p_index];
        //}
        //else
        //{
        //    return null;
        //}


        if ( !(0 <= p_index && p_index < size) )
        {
            return null;
        }

        return NextTargetArray[p_index];
    }

    private void OnDrawGizmos()
    {
        if(NextTarget != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, NextTarget.transform.position);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.4f);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(NextTarget.transform.position, 0.5f);

        }


    }



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
