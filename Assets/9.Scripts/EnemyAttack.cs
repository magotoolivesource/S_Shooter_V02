using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // �÷��̾ 2�̸� �Ÿ��϶� ����ó��
    // ������ �Ÿ��� 2�̻��̵Ǹ� �������
    // �÷��̾�� �����Ҷ� 2�ʿ� �ѹ��� ���� ó��

    

    public LayerMask AttackLayerMask;
    void UpdateAttack()
    {
        LayerMask codemask = LayerMask.GetMask("Player");
        //this.transform.position;
        Collider[] collarr = Physics.OverlapSphere(transform.position
            , 2f
            , codemask); 
        for (int i = 0; i < collarr.Length; i++)
        {
            if(collarr[i].tag == "Player"
                && collarr[i].transform.GetComponent<PlayerMove>() )
            {


            }
        }

    }


    public Transform Target;
    protected PlayerStat TargetStat;
    void Start()
    {
        // ������Ʈ �̸�����ã��
        //GameObject obj = GameObject.Find("Player111");
        // tagŸ������ ã��
        //GameObject obj = GameObject.FindGameObjectWithTag("Player");
        //GameObject[] objarr = GameObject.FindGameObjectsWithTag("Player");

        // ������Ʈ Ÿ������ ã��
        TargetStat = GameObject.FindFirstObjectByType<PlayerStat>();
        //GameObject.FindObjectsByType<PlayerStat>()

        
    }


    public float AttackDealySec = 1f;
    protected float m_AttackCurrentSec = 0f;
    void UpdateAttack2()
    {
        m_AttackCurrentSec -= Time.deltaTime;
        Vector3 vec = TargetStat.transform.position - transform.position;
        if( vec.magnitude <= 2f
            && m_AttackCurrentSec <= 0f )
        {
            Debug.Log($"{name} -> ���� -> �÷��̾�");
            TargetStat.SetDamage(1);
            m_AttackCurrentSec = AttackDealySec;
        }
    }

    void Update()
    {
        if( false)
        {
            //UpdateAttack();
        }
        else
        {
            UpdateAttack2();
        }

        

    }
}
