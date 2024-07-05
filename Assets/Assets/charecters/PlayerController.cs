using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;

    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;
    public float jumpHeight = 1f;

    private float gravityValue = -9.8f;
    private Vector3 velocity;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float rotationY = Input.GetAxis("Horizontal"); //лево право
        float directionZ = Input.GetAxis("Vertical"); //вперед назад
        //запомнили куда смотрит персонаж (вперед)
        //привели локальную систему координат к глобальной
        transform.Rotate(0f, rotationY * rotateSpeed, 0f);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (directionZ != 0)
        {
            _characterController.SimpleMove(directionZ * speed * forward);
        }
        _animator.SetFloat("move", Mathf.Abs(directionZ));

        //проверка касания земли и наличия ускорения падения
        if (_characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0; //останавливаем, чтобы не ушел под землю
        }

        if (Input.GetKeyUp(KeyCode.Space) && _characterController.isGrounded)
        {
            _animator.SetTrigger("jump");
            //увеличили ускорение вверх (толкнули персонажа вверх)
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);



        if (Input.GetButton("Fire1"))
        {
            _animator.SetTrigger("attack");
        }
    }
}