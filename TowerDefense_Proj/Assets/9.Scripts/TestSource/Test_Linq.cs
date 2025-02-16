using UnityEngine;
using System.Linq;

public class Test_Linq : MonoBehaviour
{
    public int[] TestSort = { 12, 6, 1, 7, 2 };

    public Transform[] TestObjectSort = new Transform[10];

    void _Editor_Sort()
    {
        Vector3 conterpos = transform.position;
        // 거리기준 정렬
        var resultarr = from item in TestObjectSort
                        where item.name == "Enemy"
                        orderby (conterpos - item.position).magnitude ascending
                        select item;

        //Transform[] sortarr = resultarr.ToArray();

        //// 가장 가까운값
        //sortarr[0];

        //// 가장 먼녀석
        //sortarr[sortarr.Length - 1];



        // 정렬 IOrderedEnumerable<int>
        var result = from item in TestSort
                     orderby item descending // asc오름차순, desc내림차순
                     select item;

        int[] resultsort = result.ToArray();

        
        
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
