using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{

    public RectTransform HPImg;
    public Text HPText;
    public void UpdateHPBar()
    {

        float weight = (float)HP / MaxHP;
        // 스트레츠가 아닐때만 적용 가능
        //HPImg.anchoredPosition
        HPImg.sizeDelta = new Vector2(128 * HPImgCount * weight, 128);

        HPText.text = $"{HP}/{MaxHP}";
    }


    public int HP;
    protected int MaxHP;
    public float Def;
    public int HPImgCount = 5;

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
        UpdateHPBar();

        if ( HP <= 0)
        {
            Debug.Log("게임오버");

            this.GetComponent<PlayerMove>().enabled = false;
            this.GetComponent<PlayerAttack>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    void Start()
    {
        MaxHP = HP;
        UpdateHPBar();
    }


    void Update()
    {
        
    }
}
