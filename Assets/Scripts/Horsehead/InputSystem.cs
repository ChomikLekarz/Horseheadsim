using UnityEngine.InputSystem;
using UnityEngine;

// Using state of gamepad device directly.
[RequireComponent(typeof(CharacterController2D))]
public class InputSystem : MonoBehaviour
{

    CharacterController2D controller;

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
}
