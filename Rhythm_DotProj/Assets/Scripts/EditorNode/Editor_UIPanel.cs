using Unity.Loading;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Editor_UIPanel : MonoBehaviour
{

    [Header("[값들용]")]
    public AudioClip CurrentAudioClip;



    [Header("[UI용들]")]
    public float OneFrameNodeSize = 100;
    public float DivFrameNodeSize = 100 * 10;
    public int OneSecFrame = 30; // 30프레임을 1초로 지정하기

    public Image FrameLineOriginal = null;


    [Header("[UI용들2]")]
    public ScrollRect NodeScrollView;

    public Editor_NodeSec ShotNode;
    public Editor_NodeSec LongNode;

    public void _On_SaveBTN()
    {

    }
    public void _On_LoadBTN()
    {

    }

    public void _On_LongNodeBTN()
    {

    }
    public void _On_ShotNodeBTN()
    {

    }



    

    void Start()
    {
        UpdateContentSize();

    }

    void UpdateContentSize()
    {
        float allsec = CurrentAudioClip.length;

        allsec = 10f;
        float ContentSize = OneSecFrame * allsec * OneFrameNodeSize;

        Vector2 tempsize = NodeScrollView.content.sizeDelta;
        tempsize.y = ContentSize + 100;
        NodeScrollView.content.sizeDelta = tempsize;

        InitAllDivLines(ContentSize);

    }

    void InitAllDivLines(float p_allcontentsize)
    {
        int linecount = (int)(p_allcontentsize / OneFrameNodeSize);

        RectTransform contenttrans = NodeScrollView.content;
        for (int i = 0; i < linecount; i++)
        {
            Image cloneframeline = GameObject.Instantiate(FrameLineOriginal, contenttrans);
            cloneframeline.gameObject.SetActive(true);

            Vector2 temppos = cloneframeline.rectTransform.anchoredPosition;
            temppos.y = OneFrameNodeSize * i;
            cloneframeline.rectTransform.anchoredPosition = temppos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
