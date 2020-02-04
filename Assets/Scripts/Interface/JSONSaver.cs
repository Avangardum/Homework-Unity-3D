using System.IO;
using UnityEngine;

namespace Geekbrains
{
    public class JSONSaver : IConcreteSaver
    {
        private string _path;

        public void Save(Object obj)
        {
            string text = JsonUtility.ToJson(obj);//не работает
            File.WriteAllText($"{_path}/{obj.GetInstanceID()}", text);
        }

        public Object Load()
        {
            throw new System.NotImplementedException();
        }

        public JSONSaver(string path)
        {
            _path = path;
        }
    } 
}
