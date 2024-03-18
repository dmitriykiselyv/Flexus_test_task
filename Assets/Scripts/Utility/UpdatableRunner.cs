using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class UpdatableRunner : MonoBehaviour
    {
        private readonly List<IUpdatebleRunner> _updatables = new List<IUpdatebleRunner>();

        public void Register(IUpdatebleRunner updatable)
        {
            if (!_updatables.Contains(updatable))
            {
                _updatables.Add(updatable);
            }
        }

        public void Unregister(IUpdatebleRunner updatable)
        {
            if (_updatables.Contains(updatable))
            {
                _updatables.Remove(updatable);
            }
        }

        private void Update()
        {
            foreach (var updatable in _updatables)
            {
                updatable.Update();
            }
        }
    }
}