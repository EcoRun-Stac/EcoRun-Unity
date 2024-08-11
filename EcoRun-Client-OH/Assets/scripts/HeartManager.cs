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
            heartObjects[index] = null; // ���ŵ� ��Ʈ�� null�� ����
        }
        else
        {
            Debug.LogError("�߸��� �ε���: " + index);
        }
    }
}
