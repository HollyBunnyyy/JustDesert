using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private InputSettings _inputSettings;
    public InputSettings InputSettings => _inputSettings != null ? _inputSettings : ScriptableObject.CreateInstance<InputSettings>();

    [SerializeField]
    private Camera _mainCamera;
    public Camera MainCamera => _mainCamera != null ? _mainCamera : _mainCamera = Camera.main;

    public Mouse CurrentMouse => Mouse.current;
    public Gamepad CurrentGamepad => Gamepad.current;

    public float ScrollDelta            => CurrentMouse.scroll.ReadValue().normalized.y;
    public Vector3 MousePositionScreen  => CurrentMouse.position.ReadValue();
    public Vector3 MousePositionWorld   => MainCamera.ScreenToWorldPoint( MousePositionScreen );
    public Vector3 MouseDelta           => CurrentMouse.delta.ReadValue() * _inputSettings.MouseScaling;
    public Vector3 WASDAxis { get; private set; }

    public InputBindings InputBindings { get; private set; }

    private void Awake()
    {
        InputBindings = new InputBindings();

        InputBindings.Keyboard.WASDMovement.performed += context => WASDAxis = InputBindings.Keyboard.WASDMovement.ReadValue<Vector2>().normalized;
        InputBindings.Keyboard.WASDMovement.canceled += context => WASDAxis = Vector2.zero;

    }

    private void OnEnable()
    {
        InputBindings.Keyboard.Enable();
    }

    private void OnDisable()
    {
        InputBindings.Keyboard.Disable();
    }
}
