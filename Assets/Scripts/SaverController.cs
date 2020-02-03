using UnityEngine;

namespace Geekbrains
{
    public static class SaverController
    {
        private static IConcreteSaver _concreteSaver;
        private static string _path = "Saves";

        public static void Save()
        {
            var gameObjects = Object.FindObjectsOfType<GameObject>();
            foreach (var gameObject in gameObjects)
            {
                _concreteSaver.Save(gameObject);
            }
        }

        public static void Load()
        {
            throw new System.NotImplementedException();
        }

        static SaverController()
        {
            _concreteSaver = new JSONSaver(_path);
        }
    }
}
