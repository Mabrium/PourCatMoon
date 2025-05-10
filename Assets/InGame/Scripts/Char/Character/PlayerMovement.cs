using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isMoving = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isMoving) // 이동 중이 아닐 때만 입력을 받음
        {
            float moveX = Input.GetAxisRaw("Horizontal"); // 좌우 이동
            float moveY = Input.GetAxisRaw("Vertical");   // 상하 이동

            // 대각선 입력 방지 (한 번에 한 방향만 이동)
            if (moveX != 0) moveY = 0;

            moveInput = new Vector2(moveX, moveY);

            if (moveInput != Vector2.zero) // 방향 입력이 있을 때만 이동
            {
                StartCoroutine(Move());
            }
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        Vector3 targetPosition = transform.position + (Vector3)moveInput; // 1칸 이동

        // 이동 가능 여부 확인
        if (CanMove(moveInput))
        {
            float elapsedTime = 0f;
            Vector3 startPosition = transform.position;

            while (elapsedTime < 1f / moveSpeed)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime * moveSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition; // 이동 완료 후 위치 고정
        }

        isMoving = false;
    }

    private bool CanMove(Vector2 direction)
    {
        if (direction == Vector2.zero) return false;

        // Raycast를 쏴서 벽이 있는지 확인
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, LayerMask.GetMask("Wall"));
        return hit.collider == null; // 벽이 없으면 이동 가능
    }
}
