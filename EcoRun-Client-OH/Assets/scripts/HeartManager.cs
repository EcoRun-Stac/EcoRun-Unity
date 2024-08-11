using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject[] heartObjects;

    void Start()
    {
        heartObjects = GameObject.FindGameObjectsWithTag("Heart");
    }

    public void DestroyHeart(int index)
    {
        Debug.Log("destroy");
        if (index >= 0 && index < heartObjects.Length)
        {
            Destroy(heartObjects[index]);
            heartObjects[index] = null; // 제거된 하트를 null로 설정
        }
        else
        {
            Debug.LogError("잘못된 인덱스: " + index);
        }
    }
}
