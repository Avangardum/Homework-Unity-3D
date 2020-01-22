using UnityEngine;


namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour
    {
        private Controllers _controllers;
        private void Start()
        {
            _controllers = new Controllers();
            _controllers.Initialization();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                if(_controllers[i] is IExecute execute)
                    execute.Execute();
            }
        }
    }
}
