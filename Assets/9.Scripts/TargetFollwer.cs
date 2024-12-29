using UnityEngine;

public class TargetFollwer : MonoBehaviour
{
    // Ÿ�� ����ϸ� ���󰡵��� �ϱ�
    public Transform TargetTrans;
    public float SmothWeight = 0.1f;

    public Vector3 Offset;
    protected Vector3 m_LocalOffset;

    
    void Start()
    {
        m_LocalOffset = TargetTrans.position - this.transform.position;
    }

    void Update()
    {
        // ���� Time.deltatime
        // 
        // t : 0~1
        //float xx = Mathf.Lerp(transform.position.x
        //            , TargetTrans.position.x - Offset.x
        //            , SmothWeight);
        //float zz = Mathf.Lerp(transform.position.z
        //            , TargetTrans.position.z - Offset.z
        //            , SmothWeight);
        //float yy = Mathf.Lerp(transform.position.y
        //            , TargetTrans.position.y - Offset.y
        //            , SmothWeight);
        //Vector3.SmoothDamp()

        transform.position = Vector3.Lerp( transform.position
                            , TargetTrans.position - m_LocalOffset + Offset
                            , SmothWeight );

        

    }
}