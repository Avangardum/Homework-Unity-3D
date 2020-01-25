using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    static class TagManager
    {
        public enum Tag
        {
            Player
        }

        private static Dictionary<Tag, string> _tags;

        public static string GetStringTag(Tag tag)
        {
            return _tags[tag];
        }

        public static GameObject GetObjectWithTag(Tag tag)
        {
            return GameObject.FindWithTag(GetStringTag(tag));
        }

        static TagManager()
        {
            _tags = new Dictionary<Tag, string>();
            _tags.Add(Tag.Player, "Player");
        }
    } 
}
