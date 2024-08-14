using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusManager : MonoBehaviour
{
    private GameObject collidingObject; // �浹�� ��ü�� �����ϴ� ����

    void Update()
    {
        // 'a' Ű�� ������ ��, �浹�� ��ü�� �����ϰ�, �� ��ü�� Attack �±׸� ������ ������ ����
        if (Input.GetKey(KeyCode.A) && collidingObject != null && collidingObject.CompareTag("Attack"))
        {
            Destroy(collidingObject);
            Debug.Log("Attack ������ ����!");
            collidingObject = null; // ���� �� ���� �ʱ�ȭ
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Attack �±��� �����۰� �浹���� ��
        if (other.CompareTag("Attack"))
        {
            collidingObject = other.gameObject; // �浹�� ��ü ����
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // �浹�� ������ ��ü �ʱ�ȭ
        if (collidingObject == other.gameObject)
        {
            collidingObject = null;
        }
    }
}
