using System.Collections;
using UnityEngine;

namespace Cannon
{
    public class CannonRecoil : MonoBehaviour
    {
        [SerializeField] private float _recoilDistance = -0.2f;
        [SerializeField] private float _recoilSpeed = 4f;
        [SerializeField] private float _returnSpeed = 4f;
        [SerializeField] private AnimationCurve _recoilCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        [SerializeField] private float _recoilTimeComplete = 1f;
        [SerializeField] private float _initialTimeValue;
        [SerializeField] private Transform _ts;

        private CannonInputHandler _cannonInputHandler;
        private float _originalZPosition;
        private Coroutine _recoilCoroutine;
        
        public void Init(CannonInputHandler cannonInputHandler)
        {
            _cannonInputHandler = cannonInputHandler;
            
            cannonInputHandler.OnFire += Fire;
        }

        public void Cleanup()
        {
            _cannonInputHandler.OnFire -= Fire;
        }

        private void Fire()
        {
            if (_recoilCoroutine != null) return;
            
            _originalZPosition = transform.localPosition.z;
            _recoilCoroutine = StartCoroutine(RecoilAndReturn());
        }

        private IEnumerator RecoilAndReturn()
        {
            float time = _initialTimeValue;
            while (time < _recoilTimeComplete)
            {
                time += Time.deltaTime * _recoilSpeed;
                float zPosition = _originalZPosition + _recoilCurve.Evaluate(time) * _recoilDistance;
                _ts.localPosition = new Vector3(transform.localPosition.x, _ts.localPosition.y, zPosition);
                yield return null;
            }
            
            time = _initialTimeValue;
            Vector3 startPosition = transform.localPosition;
            while (time < _recoilTimeComplete)
            {
                time += Time.deltaTime * _returnSpeed;
                _ts.localPosition = Vector3.Lerp(startPosition, new Vector3(transform.localPosition.x, _ts.localPosition.y, _originalZPosition), time);
                yield return null;
            }
            
            _ts.localPosition = new Vector3(transform.localPosition.x, _ts.localPosition.y, _originalZPosition);
            _recoilCoroutine = null;
        }
    }
}