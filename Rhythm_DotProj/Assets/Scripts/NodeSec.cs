using UnityEngine;

public class NodeSec : MonoBehaviour
{
    public float HitSec = 10;
    public float DurationSec = 0; // 0이하면 숏 0.1이라도 되면 10.1 초까지 유지 형태임

    public E_NodeType Nodetype = E_NodeType.MAX;


    [SerializeField]
    protected float m_ElapsedSec = 0f; // 경과시간
    [SerializeField]
    protected float m_RemineSec = 0f; // 남은 시간

    public void UpdateRemineSec(float p_elapsedSec)
    {
        m_ElapsedSec = p_elapsedSec;
        m_RemineSec = HitSec - m_ElapsedSec;
    }

    public void InitLineType(float p_hitsec, E_NodeType p_type)
    {
        HitSec = p_hitsec;
        Nodetype = p_type;

        transform.position = new Vector3(((int)Nodetype - 2) * 1f , 0, 0);

        this.gameObject.name = $"Node_{HitSec}_[{Nodetype}]";
        this.gameObject.layer = LayerMask.NameToLayer("Node");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
