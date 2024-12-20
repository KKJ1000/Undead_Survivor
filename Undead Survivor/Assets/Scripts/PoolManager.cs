using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리팹들을 보관할 변수들
    public GameObject[] prefabs;

    //풀 담당을 하는 리스트
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];      //풀을 담는 배열 초기화

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();         
        }

    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택한 풀의 놀고 있는 (비활성화 된) 게임 오브젝트 접근

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // 못 찾았으면?
        if (select == null)
        {
            // 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);  //생성된 오브젝트는 해당 오브젝트 풀 리스트에 Add 함수로 추가
        }

        return select;
    }
}
