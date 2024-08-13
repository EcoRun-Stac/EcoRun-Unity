using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class focusManager : MonoBehaviour
{
    public Button jumpButton;  // Jump ��ư�� �����Ϳ��� �Ҵ�
    public Button slideButton; // Slide ��ư�� �����Ϳ��� �Ҵ�

    private bool isJumpPressed = false; // Jump ��ư�� ���� ���� ����
    private bool isSlidePressed = false; // Slide ��ư�� ���� ���� ����
    private bool isTrigger = false;

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �޼��� ����
        jumpButton.onClick.AddListener(OnJumpButtonPressed);
        slideButton.onClick.AddListener(OnSlideButtonPressed);
    }

    // Jump ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    void OnJumpButtonPressed()
    {
        isJumpPressed = true;
        CheckCombo();
    }

    // Slide ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    void OnSlideButtonPressed()
    {
        isSlidePressed = true;
    }

    // �� ��ư�� ��� ������ �� ����� �Լ�
    bool CheckCombo()
    {
        if (isJumpPressed && isSlidePressed && isTrigger)
        {
            // ���� �ٽ� �� �� false�� ������ �ʱ�ȭ
            isJumpPressed = false;
            isSlidePressed = false;

            return true;
        }
        else return false;
    }
    
    // Attack �Լ� (���ÿ� ��ư�� ������ �� ����)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack") && CheckCombo()) {
            Destroy(other.gameObject);
            Debug.Log("attack!");
        }
    }
}