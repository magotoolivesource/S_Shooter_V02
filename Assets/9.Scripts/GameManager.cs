using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static public int Score;


    public void RestartGame()
    {
        // 플레이어 초기위치
        // 적 다지우기
        // 점수 0으로 하기

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
