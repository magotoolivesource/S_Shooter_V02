using UnityEngine;

public class NextTargetCom : MonoBehaviour
{
    public NextTargetCom NextTarget;
    public NextTargetCom[] NextTargetArray; // 3

    public NextTargetCom GetNextTraget()
    {
        //int rand = Random.Range(0, NextTargetArray.Length);// 0; // 0~2
        return NextTargetArray[2];
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
