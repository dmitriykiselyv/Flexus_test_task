using System.Collections;
using UnityEngine;

namespace Cannon
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _recoilAngle = 1f;
        [SerializeField] private float _recoilSpeed = 6f;
        [SerializeField] private float _returnSpeed = 5f;
        [SerializeField] private float _recoilThreshold = 0.01f;
        [SerializeField] private AnimationCurve _recoilCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        private CannonInputHandler _cannonInputHandler;
        private Quaternion _originalRotation;
        private bool _isRecoiling;

        public void Init(CannonInputHandler cannonInputHandler)
        {
            _cannonInputHandler = cannonInputHandler;
            
            _cannonInputHandler.OnFire += TriggerShake;
        }
    
        public void Cleanup()
        {
            _cannonInputHandler.OnFire -= TriggerShake;
        }

        private void TriggerShake()
        {
            if (_isRecoiling)  return;
            
            _originalRotation = transform.localRotation;
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            _isRecoiling = true;
            float elapsedTime = 0f;
            float recoilPhaseDuration = _recoilCurve.keys[_recoilCurve.length - 1].time;
            
            float direction = Random.Range(-1f, 1f) >= 0 ? 1f : -1f;
            float targetAngle = _recoilAngle * direction;

            // Recoil phase
            while (elapsedTime < recoilPhaseDuration)
            {
                elapsedTime += Time.deltaTime * _recoilSpeed;
                float curveValue = _recoilCurve.Evaluate(elapsedTime);
                float angle = targetAngle * curveValue;
                transform.localRotation = _originalRotation * Quaternion.Euler(0, angle, 0);
                yield return null;
            }

            // Return phase
            elapsedTime = 0f;
            while (Quaternion.Angle(transform.localRotation, _originalRotation) > _recoilThreshold)
            {
                elapsedTime += Time.deltaTime * _returnSpeed;
                transform.localRotation = Quaternion.Lerp(transform.localRotation, _originalRotation, elapsedTime);
                yield return null;
            }

            transform.localRotation = _originalRotation;
            _isRecoiling = false;
        }
    }
}
