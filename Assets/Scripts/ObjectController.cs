using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class ObjectController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Kecepatan gerak objek")]
    [SerializeField] private float speed = 5f;

    void Update()
    {
        float moveX = 0f;

#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                moveX -= 1f;
            }
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                moveX += 1f;
            }
        }
#else
        moveX = Input.GetAxisRaw("Horizontal");
#endif
        transform.position += new Vector3(moveX * speed * Time.deltaTime, 0f, 0f);
    }
}
