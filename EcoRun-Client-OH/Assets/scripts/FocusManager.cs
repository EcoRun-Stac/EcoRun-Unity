using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusManager : MonoBehaviour
{
    private GameObject collidingObject; // 충돌한 객체를 저장하는 변수

    void Update()
    {
        // 'a' 키를 눌렀을 때, 충돌한 객체가 존재하고, 그 객체가 Attack 태그를 가지고 있으면 제거
        if (Input.GetKey(KeyCode.A) && collidingObject != null && collidingObject.CompareTag("Attack"))
        {
            Destroy(collidingObject);
            Debug.Log("Attack 아이템 제거!");
            collidingObject = null; // 제거 후 변수 초기화
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Attack 태그의 아이템과 충돌했을 때
        if (other.CompareTag("Attack"))
        {
            collidingObject = other.gameObject; // 충돌한 객체 저장
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 충돌이 끝나면 객체 초기화
        if (collidingObject == other.gameObject)
        {
            collidingObject = null;
        }
    }
}
