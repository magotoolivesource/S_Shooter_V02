using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public int HP;
    public float Def;

    public void SetDamage(float p_dmg)
    {
        if( HP <= 0)
            return;


        float dmg = p_dmg - Def;
        if( dmg <= 0)
        {
            dmg = 1;
        }

        HP = HP - (int)p_dmg;

        if( HP <= 0)
        {
            Debug.Log("게임오버");

            this.GetComponent<PlayerMove>().enabled = false;
            this.GetComponent<PlayerAttack>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
