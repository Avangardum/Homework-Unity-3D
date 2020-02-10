using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _weapon1 = KeyCode.Alpha1;
        private KeyCode _weapon2 = KeyCode.Alpha2;
        private KeyCode _save = KeyCode.F5;
        private KeyCode _load = KeyCode.F9;
        private KeyCode _reload = KeyCode.R;
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
                ServiceLocator.Resolve<WeaponController>().Fire();
            }

            if (Input.GetKeyDown(_weapon1))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                ServiceLocator.Resolve<WeaponController>().On(Object.FindObjectOfType<Gun>());
            }

            if (Input.GetKeyDown(_weapon2))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                ServiceLocator.Resolve<WeaponController>().On(Object.FindObjectOfType<UgandaGun>());
            }

            if (Input.GetKeyDown(_save))
            {
                SaverController.Save();
            }

            if (Input.GetKeyDown(_load))
            {
                SaverController.Load();
                if (Input.GetKeyDown(_reload))
                {
                    ServiceLocator.Resolve<WeaponController>().ReloadClip();
                }
            }
        }
    }
}
