using UnityEngine.InputSystem;
using UnityEngine;

// Using state of gamepad device directly.
[RequireComponent(typeof(CharacterController2D))]
public class InputSystem : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public GameObject projectile;

    CharacterController2D controller;

    private Vector2 m_Rotation;
    private bool m_Firing;
    private float m_FireCooldown;

    public void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    public void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        var right = keyboard.dKey.ReadValue();
        var left = -1 * keyboard.aKey.ReadValue();
        bool jump = keyboard.wKey.ReadValue() > 0f;
        //if (jump)
        //{
        //    Debug.Log("Jumped!");
        //}
        var shoot = keyboard.spaceKey.ReadValue();

        controller.Move(right + left, jump);

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            m_Firing = true;
            m_FireCooldown = 0;
        }
        else if (keyboard.spaceKey.wasReleasedThisFrame)
        {
            m_Firing = false;
        }

        if (m_Firing && m_FireCooldown < Time.time)
        {
            controller.Shoot();
            m_FireCooldown = Time.time + 0.4f;
        }
    }

    //private void Move(Vector2 direction)
    //{
    //    if (direction.sqrMagnitude < 0.01)
    //        return;
    //    var scaledMoveSpeed = moveSpeed * Time.deltaTime;
    //    // For simplicity's sake, we just keep movement in a single plane here. Rotate
    //    // direction according to world Y rotation of player.
    //    var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
    //    transform.position += move * scaledMoveSpeed;
    //}

    //private void Look(Vector2 rotate)
    //{
    //    if (rotate.sqrMagnitude < 0.01)
    //        return;
    //    var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
    //    m_Rotation.y += rotate.x * scaledRotateSpeed;
    //    m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
    //    transform.localEulerAngles = m_Rotation;
    //}

    //private void Fire()
    //{
    //    var transform = this.transform;
    //    var newProjectile = Instantiate(projectile);
    //    newProjectile.transform.position = transform.position + transform.forward * 0.6f;
    //    newProjectile.transform.rotation = transform.rotation;
    //    const int size = 1;
    //    newProjectile.transform.localScale *= size;
    //    newProjectile.GetComponent<Rigidbody>().mass = Mathf.Pow(size, 3);
    //    newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
    //    newProjectile.GetComponent<MeshRenderer>().material.color =
    //        new Color(Random.value, Random.value, Random.value, 1.0f);
    //}
}
