using System;
using System.Linq;
using UnityEngine;

public class TestSorting : MonoBehaviour
{

    
    void SortingAse(int[] p_sortval )
    {
        int src = 0;
        int dest = 1;
        for (int j = 0; j < p_sortval.Length - 1; j++)
        {
            src = j;
            for (int i = src + 1; i < p_sortval.Length; i++)
            {
                dest = i;
                if (p_sortval[src] > p_sortval[dest])
                {
                    int temp = p_sortval[src];
                    p_sortval[src] = p_sortval[dest];
                    p_sortval[dest] = temp;
                }
            }
        }
    }


    //6	2	7	12	1
    //1	2	6	7	12
    public int[] SortVal = { 6, 2, 7, 12, 1 };
    //public int[] SortVal2 = new int[5];

    void Start()
    {
        int src = 0;
        int dest = 1;
        for (int j = 0; j < SortVal.Length-1; j++)
        {
            src = j;
            for (int i = src + 1; i < SortVal.Length; i++)
            {
                dest = i;
                if (SortVal[src] > SortVal[dest])
                {
                    int temp = SortVal[src];
                    SortVal[src] = SortVal[dest];
                    SortVal[dest] = temp;
                }
            }
        }

        
        

        //int dest = 1;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}

        //dest = 2;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}



        //int src = 0;
        //int dest = 1;
        //if( SortVal[src] > SortVal[dest] )
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////2, 6, 7, 12, 1

        //dest = 2;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////2, 6, 7, 12, 1

        //dest = 3;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////2, 6, 7, 12, 1


        //dest = 4;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////1, 6, 7, 12, 2




        //src = 1;
        //dest = src+1;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////1, 6, 7, 12, 2

        //dest = src + 2;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////1, 6, 7, 12, 2

        //dest = src + 3;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////1, 2, 7, 12, 6


        //src = 2;
        //dest = src + 1;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////1, 6, 7, 12, 2

        //dest = src + 2;
        //if (SortVal[src] > SortVal[dest])
        //{
        //    int temp = SortVal[src];
        //    SortVal[src] = SortVal[dest];
        //    SortVal[dest] = temp;
        //}
        ////1, 6, 7, 12, 2

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
