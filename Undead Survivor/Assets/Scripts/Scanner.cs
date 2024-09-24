using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 원거리 공격을 위한 주변 몬스터 스캔 스크립트
public class Scanner : MonoBehaviour
{
    public float scanRange; //스캔 범위
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;  //플레이어와 가장 가까운 타겟

    void FixedUpdate()
    {
        //CircleCast 원 형태로 캐스팅 (캐스팅 시작 위치, 원의 반지름, 캐스팅 방향, 캐스팅 길이, 대상 레이어)                              
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);
            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
}
