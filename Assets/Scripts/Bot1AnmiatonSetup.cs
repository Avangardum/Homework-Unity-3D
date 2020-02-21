using UnityEngine;

public class Bot1AnmiatonSetup : MonoBehaviour
{
    [SerializeField]private float _rotationSpeedForFullTurn;

    private Animator _animator;
    private float _previousFrameYRotation;
    private int _speedId;
    private int _turnId;
    private bool _firstFrame = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _speedId = Animator.StringToHash("Speed");
        _turnId = Animator.StringToHash("Turn");
    }

    private void Update()
    {
        if (!_firstFrame)
        {
            float deltaRotation = _previousFrameYRotation - transform.rotation.y;
            float rotationSpeed = deltaRotation / Time.deltaTime;
            float turn = rotationSpeed / _rotationSpeedForFullTurn;
            if (turn > 1)
                turn = 1;
            _animator.SetFloat(_speedId, 1);
            _animator.SetFloat(_turnId, turn);
            print("Turn = " + turn);
        }
        else
            _firstFrame = false;
        _previousFrameYRotation = transform.rotation.y;
    }
}
