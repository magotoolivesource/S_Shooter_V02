using UnityEngine;
using UnityEngine.AI;

public class EnemyHPStat : MonoBehaviour
{
    public int HP = 5;

    public void SetDamage(float p_dmg)
    {
        if (HP <= 0)
            return;

        HP = HP - (int)p_dmg;
        if( HP <= 0)
        {
            //Debug.Log( "�� hp : 0");
            // �ִϸ��̼� 1.3�ʵڿ� 
            //GameObject.Destroy(gameObject);
            //GetComponent<NavMeshAgent>().speed = 0;

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;

            //// 3�� �ڿ� ������
            //GameObject.Destroy(gameObject, 3f);

        }
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
