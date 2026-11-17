
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;

    public Rigidbody2D rb;

    // Directional character sprites
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;

    // Weapon
    public Transform sword;

    public Vector2 upPosition;
    public Vector2 downPosition;
    public Vector2 leftPosition;
    public Vector2 rightPosition;

    public float upRotation;
    public float downRotation;
    public float leftRotation;
    public float rightRotation;

    // FirePoint
    public Transform firePoint;

    public Vector2 upFirePosition;
    public Vector2 downFirePosition;
    public Vector2 leftFirePosition;
    public Vector2 rightFirePosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initial FirePoint position
        firePoint.localPosition = downFirePosition;
    }

    void Update()
    {
        Movement();
        ChangeDirection();
        ChangeSwordDirection();
        ChangeFirePointDirection();
    }

    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }

    void ChangeDirection()
    {
        if (speedX == 0 && speedY == 0)
            return;

        if (Mathf.Abs(speedX) > Mathf.Abs(speedY))
        {
            if (speedX > 0)
                spriteRenderer.sprite = rightSprite;
            else
                spriteRenderer.sprite = leftSprite;
        }
        else
        {
            if (speedY > 0)
                spriteRenderer.sprite = upSprite;
            else
                spriteRenderer.sprite = downSprite;
        }
    }

    void ChangeSwordDirection()
    {
        if (speedX == 0 && speedY == 0)
            return;

        if (Mathf.Abs(speedX) > Mathf.Abs(speedY))
        {
            if (speedX > 0)
            {
                sword.localPosition = rightPosition;
                sword.localRotation = Quaternion.Euler(0, 0, rightRotation);
            }
            else
            {
                sword.localPosition = leftPosition;
                sword.localRotation = Quaternion.Euler(0, 0, leftRotation);
            }
        }
        else
        {
            if (speedY > 0)
            {
                sword.localPosition = upPosition;
                sword.localRotation = Quaternion.Euler(0, 0, upRotation);
            }
            else
            {
                sword.localPosition = downPosition;
                sword.localRotation = Quaternion.Euler(0, 0, downRotation);
            }
        }
    }

    void ChangeFirePointDirection()
    {
        if (speedX == 0 && speedY == 0)
            return;

        if (Mathf.Abs(speedX) > Mathf.Abs(speedY))
        {
            if (speedX > 0)
                firePoint.localPosition = rightFirePosition;
            else
                firePoint.localPosition = leftFirePosition;
        }
        else
        {
            if (speedY > 0)
                firePoint.localPosition = upFirePosition;
            else
                firePoint.localPosition = downFirePosition;
        }
    }
}
