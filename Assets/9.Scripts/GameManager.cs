using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static public int Score;

    public void RestartGame()
    {
        // �÷��̾� �ʱ���ġ
        // �� �������
        // ���� 0���� �ϱ�
        // 

        SceneManager.LoadScene("SampleScene");

        PlayerStat.Global_HP = PlayerStat.Global_MAXHP;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
