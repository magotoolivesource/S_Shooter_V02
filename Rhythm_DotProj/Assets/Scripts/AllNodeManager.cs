using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public enum E_NodeType
{
    Line1, 
    Line2, 
    Line3, 
    Line4,

    MAX,
}

[System.Serializable]
public class CreateNode
{
    public float HitSec;
    public E_NodeType NodeType = E_NodeType.Line1;
}




public class AllNodeManager : MonoBehaviour
{
    [Header("데이터용")]
    public List<CreateNode> CreateNodeType = new List<CreateNode>();


    [Header("매니저사용용")]
    public NodeSec OriginalNodeSec = null;

    [Header("참고용")]
    public List<NodeSec> AllNodeList = new List<NodeSec>();

    [SerializeField]
    protected float NormalSecSize = 10f;
    [SerializeField]
    protected float m_CurrentPrgressSec = 0f;
    [SerializeField]
    protected float m_ElapsedSec = 0f;


    // node 에 값을 읽어와서 노트 위치값 적용하도록 하기
    public static void SetNodePos(NodeSec p_outnode, AllNodeManager p_allnodemanager)
    {
        float remainingsec = p_outnode.HitSec - p_allnodemanager.m_ElapsedSec;

        Vector3 temppos = p_outnode.transform.position;
        temppos.y = remainingsec * p_allnodemanager.NormalSecSize;
        p_outnode.transform.position = temppos;

        p_outnode.UpdateRemineSec(p_allnodemanager.m_ElapsedSec);
    }

    void InitAllSettingNodes()
    {
        AllNodeList.Clear();
        foreach (var item in CreateNodeType)
        {
            NodeSec copynode = GameObject.Instantiate(OriginalNodeSec);
            //copynode.HitSec = item.HitSec;
            copynode.InitLineType(item.HitSec, item.NodeType);
            AllNodeList.Add(copynode);
        }
    }

    void AllUpdatePosition()
    {
        foreach (var item in AllNodeList)
        {
            AllNodeManager.SetNodePos(item, this);
        }

    }

    void Start()
    {
        InitAllSettingNodes();
        AllUpdatePosition();
    }

    protected void UpdateDeltaTime()
    {
        m_CurrentPrgressSec += Time.deltaTime;
        m_ElapsedSec += Time.deltaTime;

    }
    
    void Update()
    {
        UpdateDeltaTime();

        AllUpdatePosition();
    }
}
