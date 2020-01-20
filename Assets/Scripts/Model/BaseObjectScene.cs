using UnityEngine;

namespace Geekbrains
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        public Transform Transform { get; private set; }

        private MeshRenderer _meshRenderer;
        private int _layer;
        private bool _isPhysicsEnabled;

        public bool IsVisible
        {
            get => _meshRenderer.enabled;
            set => _meshRenderer.enabled = value;
        }

        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                AskLayer(Transform, _layer);
            }
        }

        public bool IsPhysicsEnabled
        {
            get => _isPhysicsEnabled;
            set
            {
                _isPhysicsEnabled = value;
                Rigidbody.isKinematic = !_isPhysicsEnabled;
            }
        }

        private void AskLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;
            if (obj.childCount <= 0) return;

            foreach (Transform child in obj)
            {
                AskLayer(child, layer);
            }
        }

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}
