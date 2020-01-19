using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private int _shootMouseButton = 0;

        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch();
            }

            if (Input.GetMouseButtonDown(_shootMouseButton))
            {
                
            }
        }
    }
}
