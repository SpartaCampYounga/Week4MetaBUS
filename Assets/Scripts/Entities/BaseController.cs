using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5; // 이동 속도

        // 실제 물리 이동
        _rigidbody.velocity = direction;
        
        Rotate(movementDirection);  //이동할때만 방향 바뀔거임. zep처럼
    }

    private void Rotate(Vector2 direction)
    {
        bool isLeft = direction.x < 0 ? true : false;

        characterRenderer.flipX = isLeft;
    }
}
