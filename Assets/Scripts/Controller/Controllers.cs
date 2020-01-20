using UnityEngine;


namespace Geekbrains
{
    public sealed class Controllers : IInitialization
    {
        private readonly BaseController[] _executeAndInitializeControllers;

        public int Length => _executeAndInitializeControllers.Length;

        public Controllers()
        {
            IMotor motor = default;
            if (Application.platform == RuntimePlatform.PS4)
            {
                //
            }
            else
            {
                motor = new UnitMotor(
                    ServiceLocatorMonoBehaviour.GetService<CharacterController>());
            }
            ServiceLocator.SetService(new PlayerController(motor));
            ServiceLocator.SetService(new FlashLightController());
            ServiceLocator.SetService(new InputController());
            ServiceLocator.SetService(new WeaponController());
            _executeAndInitializeControllers = new BaseController[4];

            _executeAndInitializeControllers[0] = ServiceLocator.Resolve<PlayerController>();

            _executeAndInitializeControllers[1] = ServiceLocator.Resolve<FlashLightController>();

            _executeAndInitializeControllers[2] = ServiceLocator.Resolve<InputController>();

            _executeAndInitializeControllers[3] = ServiceLocator.Resolve<WeaponController>();
        }
        
        public BaseController this[int index] => _executeAndInitializeControllers[index];

        public void Initialization()
        {
            foreach (var controller in _executeAndInitializeControllers)
            {
                if (controller is IInitialization initialization)
                {
                    initialization.Initialization();
                }
            }
            
            ServiceLocator.Resolve<InputController>().On();
        }
    }
}
