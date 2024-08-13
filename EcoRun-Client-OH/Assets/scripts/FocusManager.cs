using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class focusManager : MonoBehaviour
{
    public Button jumpButton;  // Jump 버튼을 에디터에서 할당
    public Button slideButton; // Slide 버튼을 에디터에서 할당

    private bool isJumpPressed = false; // Jump 버튼이 눌린 상태 추적
    private bool isSlidePressed = false; // Slide 버튼이 눌린 상태 추적
    private bool isTrigger = false;

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        jumpButton.onClick.AddListener(OnJumpButtonPressed);
        slideButton.onClick.AddListener(OnSlideButtonPressed);
    }

    // Jump 버튼 클릭 시 호출되는 메서드
    void OnJumpButtonPressed()
    {
        isJumpPressed = true;
        CheckCombo();
    }

    // Slide 버튼 클릭 시 호출되는 메서드
    void OnSlideButtonPressed()
    {
        isSlidePressed = true;
    }

    // 두 버튼이 모두 눌렸을 때 실행될 함수
    bool CheckCombo()
    {
        if (isJumpPressed && isSlidePressed && isTrigger)
        {
            // 이후 다시 둘 다 false로 설정해 초기화
            isJumpPressed = false;
            isSlidePressed = false;

            return true;
        }
        else return false;
    }
    
    // Attack 함수 (동시에 버튼이 눌렸을 때 실행)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack") && CheckCombo()) {
            Destroy(other.gameObject);
            Debug.Log("attack!");
        }
    }
}