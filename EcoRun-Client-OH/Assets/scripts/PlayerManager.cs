using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 네임스페이스 추가

public class PlayerManager : MonoBehaviour
{
    public float jumpHeight = 2f; // 점프 높이
    public float jumpDuration = 0.5f; // 점프 시간
    public float slideDuration = 1f; // 슬라이드 시간

    public Sprite jumpSprite; // 점프할 때 사용할 스프라이트
    public Sprite slideSprite; // 슬라이드할 때 사용할 스프라이트
    public Sprite defaultSprite; // 기본 스프라이트

    private Vector3 startPosition;
    private bool isJumping = false;
    private bool isSliding = false;
    private float jumpTimer;
    private SpriteRenderer spriteRenderer;

    // ScoreManager를 특정 네임스페이스로 명시
    public ScoreManager scoreScript; // 점수를 관리하는 스크립트 (에디터에서 할당)
    public Button jumpButton; // Jump 버튼
    public Button slideButton; // Slide 버튼

    private Coroutine resetSpriteCoroutine;

    void Start()
    {
        startPosition = transform.position; // 시작 위치 저장
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트를 가져옴
        defaultSprite = spriteRenderer.sprite; // 기본 스프라이트 저장

        // 에디터에서 scoreManager가 할당되었는지 확인
        if (scoreScript == null)
        {
            Debug.LogError("ScoreManager가 할당되지 않았습니다. 에디터에서 ScoreManager를 PlayerManager에 할당하세요.");
        }

        // 버튼에 이벤트 추가
        jumpButton.onClick.AddListener(Jump);
        slideButton.onClick.AddListener(Slide);
    }

    void Update()
    {
        // 점프 및 슬라이드 로직 그대로 유지
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            float t = jumpTimer / jumpDuration;

            if (t < 0.5f)
            {
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * jumpHeight, t * 2);
            }
            else
            {
                transform.position = Vector3.Lerp(startPosition + Vector3.up * jumpHeight, startPosition, (t - 0.5f) * 2);
            }

            if (jumpTimer >= jumpDuration)
            {
                transform.position = startPosition;
                isJumping = false;
                jumpTimer = 0f; // 타이머 초기화
                spriteRenderer.sprite = defaultSprite; // 기본 스프라이트로 되돌리기
            }
        }
    }

    IEnumerator ResetSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.sprite = defaultSprite;
        isSliding = false; // 슬라이드 상태 종료
    }

    public void Jump()
    {
        isJumping = true;
        jumpTimer = 0f; // 점프 시작 시 타이머 초기화
        spriteRenderer.sprite = jumpSprite; // 점프 스프라이트로 변경
    }

    public void Slide()
    {
        isSliding = true;
        spriteRenderer.sprite = slideSprite; // 슬라이드 스프라이트로 변경

        // 슬라이드가 끝나면 기본 스프라이트로 되돌리는 Coroutine 시작
        if (resetSpriteCoroutine != null)
        {
            StopCoroutine(resetSpriteCoroutine);
        }
        resetSpriteCoroutine = StartCoroutine(ResetSpriteAfterDelay(slideDuration));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered with: " + other.gameObject.name);

        if (other.CompareTag("Coin"))
        {
            if (scoreScript != null)
            {
                scoreScript.IncreaseScore(); // 점수 증가
            }
            else
            {
                Debug.LogError("ScoreManager is null when trying to increase score.");
            }
            Destroy(other.gameObject); // 코인 제거
        }
        else if (other.CompareTag("Enemy"))
        {
            if (scoreScript != null)
            {
                scoreScript.DecreaseScore();
            }
            else
            {
                Debug.LogError("ScoreManager is null when trying to decrease score.");
            }
            Destroy(other.gameObject);
        }
    }
}
