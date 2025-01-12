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
            //Debug.Log( "적 hp : 0");
            // 애니메이션 1.3초뒤에 
            //GameObject.Destroy(gameObject);
            //GetComponent<NavMeshAgent>().speed = 0;

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;

            //// 3초 뒤에 지워라
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
