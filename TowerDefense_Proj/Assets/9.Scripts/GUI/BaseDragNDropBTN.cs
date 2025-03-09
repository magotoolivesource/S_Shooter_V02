using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public enum E_DragNDropType
{
    None = 0,

    E_DragNDropBTN,
    E_OnlyDrag,
    //E_SmithDrag,

    Max,
}

// 원본슬롯과 현재 슬롯의 타입을 이용해서 복사및, 치환에 관련한 속성값
public enum E_DropCopyType
{
    E_None = 0,
    E_Copy,
    E_Chnage,
    E_Delete,
}


public class BaseDragNDropBTN : MonoBehaviour
    , IDropHandler
{
    public Image DragIcon;
    public Vector3 m_InitPos;


    //public E_DragNDropType DragNDropType = E_DragNDropType.Max;

    public virtual E_DragNDropType GetDragNDropType()
    {
        return E_DragNDropType.Max;
    }


    public E_DropCopyType[,] m_ResultType = new E_DropCopyType[(int)E_DragNDropType.Max
                                            , (int)E_DragNDropType.Max]
    {
        { E_DropCopyType.E_None , E_DropCopyType.E_None, E_DropCopyType.E_None},
        { E_DropCopyType.E_None , E_DropCopyType.E_Chnage, E_DropCopyType.E_Delete },
        { E_DropCopyType.E_None , E_DropCopyType.E_Copy, E_DropCopyType.E_Chnage },
    };

    public E_DropCopyType GetSrcTODestMatrixType(E_DragNDropType p_src
        , E_DragNDropType p_dest)
    {
        return m_ResultType[(int)p_dest, (int)p_src];
    }

    public E_DropCopyType GetSrcTODest(E_DragNDropType p_src
        , E_DragNDropType p_dest)
    {
        // DrngNDropBTN -> DrngNDropBTN
        if( p_src == E_DragNDropType.E_DragNDropBTN
            && p_dest == E_DragNDropType.E_DragNDropBTN)
        {
            return E_DropCopyType.E_Chnage;
        }

        if (p_src == E_DragNDropType.E_OnlyDrag
            && p_dest == E_DragNDropType.E_OnlyDrag)
        {
            return E_DropCopyType.E_Chnage;
        }

        if (p_src == E_DragNDropType.E_DragNDropBTN
            && p_dest == E_DragNDropType.E_OnlyDrag)
        {
            return E_DropCopyType.E_Copy;
        }

        if (p_src == E_DragNDropType.E_OnlyDrag
            && p_dest == E_DragNDropType.E_DragNDropBTN)
        {
            return E_DropCopyType.E_Delete;
        }



        return E_DropCopyType.E_None;
    }

    protected void CopyDragNDrop(BaseDragNDropBTN p_src, BaseDragNDropBTN p_dest)
    {
        // src -> dest
        p_dest.DragIcon.sprite = p_src.DragIcon.sprite;

    }

    protected void ChangeDragNDrop(BaseDragNDropBTN p_src, BaseDragNDropBTN p_dest)
    {
        // src -> dest
        Sprite tempsprite = p_dest.DragIcon.sprite;
        p_dest.DragIcon.sprite = p_src.DragIcon.sprite;
        p_src.DragIcon.sprite = tempsprite;

    }

    protected void DeleteDragNDrop(BaseDragNDropBTN p_src, BaseDragNDropBTN p_dest)
    {
        // src 지우기
        p_src.DragIcon.sprite = null;

    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        //DrngNDropBTN srcbtn = eventData.selectedObject.GetComponent<DrngNDropBTN>();
        //Debug.Log($"드랍처리 : {eventData.selectedObject.name} -> {this.name} ");

        //if(srcbtn != null)
        //{
        //    // 복사
        //    this.DragIcon.sprite = srcbtn.DragIcon.sprite;
        //}

        //// 서로 치환
        //OnlyDropBTN seletedbtn = eventData.selectedObject.GetComponent<OnlyDropBTN>();
        //if (seletedbtn != null)
        //{
        //    // 서로 치환
        //    Sprite swapsprite = this.DragIcon.sprite;
        //    this.DragIcon.sprite = seletedbtn.DragIcon.sprite;
        //    seletedbtn.DragIcon.sprite = swapsprite;
        //}


        BaseDragNDropBTN srcbtn = eventData.selectedObject.GetComponent<BaseDragNDropBTN>();
        Debug.Log($"드랍처리 : {eventData.selectedObject.name} -> {this.name} ");

        E_DragNDropType srctype = srcbtn.GetDragNDropType();
        E_DragNDropType desttype = this.GetDragNDropType();

        E_DropCopyType copytype = this.GetSrcTODestMatrixType(srctype, desttype);
        if (copytype == E_DropCopyType.E_Chnage)
        {
            // 교체
            ChangeDragNDrop(srcbtn, this);
        }
        else if (copytype == E_DropCopyType.E_Copy)
        {
            // src -> dest 카피용
            CopyDragNDrop(srcbtn, this);
        }
        else if (copytype == E_DropCopyType.E_Delete)
        {
            // src 지우기
            DeleteDragNDrop(srcbtn, this);
        }


    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
