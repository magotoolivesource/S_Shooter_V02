using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    float m_CurrTime = 0;
    public float DelayAttackSec = 1f;
    void Fire1()
    {
        // ���콺�� ������ ������ 1�ʿ� �ѹ��� ����
        // ���콺�� �������ִ�
        if (Input.GetMouseButton(0))
        {
            // 1�ʿ� �ѹ���
            //Time.time; // 24�� �� �ִ�

            if (m_CurrTime < Time.time)
            {
                Debug.Log("����");
                m_CurrTime = Time.time + DelayAttackSec;
            }

        }

    }


    public float RemineSec = 0f;
    void UpdateFire2()
    {
        // 0.0001f -= 10f; // 2
        RemineSec -= Time.deltaTime;

        if (RemineSec <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                RemineSec = DelayAttackSec;
                Debug.Log("����2");
                Attack();
            }
        }

    }

    public Transform EndBariel = null;
    void Attack()
    {
        RaycastHit hit;
        // fps ���� �Ѿ� ���� 
        if ( Physics.Raycast(EndBariel.position
            , EndBariel.forward
            , out hit) )
        {
            // �������� �ε��� ������Ʈ �̸� ���
            Debug.Log( $"{hit.transform.name }" );
        }

        //Debug.DrawLine(EndBariel.position
        //    , EndBariel.position + EndBariel.forward * 100f
        //    , Color.red, 2f);

    }

    void Start()
    {
        m_CurrTime = Time.time; // 1��
    }


    void Update()
    {
        //Fire1();
        UpdateFire2();
    }



}
