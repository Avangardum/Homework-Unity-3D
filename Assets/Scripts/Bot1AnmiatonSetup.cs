using UnityEngine;

public class Bot1AnmiatonSetup : MonoBehaviour
{
    [SerializeField] private Transform _gunHoldingPoint;
    [SerializeField] private float _rotationSpeedForFullTurn;

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
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
    }

    private void Update()
    {
        SpeedAndRotationSetup();
    }

    private void SpeedAndRotationSetup()
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
        }
        else
            _firstFrame = false;
        _previousFrameYRotation = transform.rotation.y;
    }

    private void HandIKSetup()
    {
        _animator.SetIKPosition(AvatarIKGoal.LeftHand, _gunHoldingPoint.position);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, _gunHoldingPoint.position);
    }
}
