using UnityEngine;
using UnityEngine.UI;

public class HPBar_Observer : MonoBehaviour
{
    public Text HPTextLabel;
    public Image HPImg;

    // 1锅掳 规过
    public PlayerStat PlayerStat;

    public void UpdateUIType01()
    {
        float value = PlayerStat.GetUnlitHPValue();

        HPImg.rectTransform.sizeDelta = 
            new Vector2(128 * 4 * value, 128);
        HPTextLabel.text = $"{PlayerStat.HP}/{PlayerStat.GetMaxHP()}";
    }

    protected int m_CurrentHP = 0;
    public void UpdateUIType02()
    {
        float hp = PlayerStat.Global_HP;
        float maxhp = PlayerStat.Global_MAXHP;

        if(m_CurrentHP == hp)
        {
            return;
        }
        m_CurrentHP = (int)hp;

        float val = hp / maxhp;
        HPImg.rectTransform.sizeDelta =
            new Vector2(128 * 4 * val, 128);
        HPTextLabel.text = $"{hp}/{maxhp}";
    }

    void Start()
    {
        
    }

    void Update()
    {
        if( false )
        {
            // 规过2-1
            UpdateUIType01();
        }
        else
        {
            // 规过2-2
            UpdateUIType02();
        }

        
    }
}
