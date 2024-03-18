using System.Collections.Generic;
using MVC.Interfaces;
using UnityEngine;

namespace MVC.Models
{
    [CreateAssetMenu(fileName = "PowerSliderConfig", menuName = "ScriptableObjects/PowerSliderConfig", order = 1)]
    public class PowerSliderConfig : ScriptableObject, IObservable<SliderModel>
    {
        [SerializeField] private SliderModel _sliderModel;
        private readonly List<IObserver<SliderModel>> _observers = new List<IObserver<SliderModel>>();

        public SliderModel SliderModel
        {
            get => _sliderModel;
            set
            {
                _sliderModel = value;
                NotifyObservers();
            }
        }

        public void Attach(IObserver<SliderModel> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IObserver<SliderModel> observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.DataChanged(_sliderModel);
            }
        }
    }

    [System.Serializable]
    public class SliderModel
    {
        [SerializeField] private float _powerValue = 30f;
        [SerializeField] private float _scrollSensitivity = 1f;
        [SerializeField] private float _minPowerValue = 0f;
        [SerializeField] private float _maxPowerValue = 100f;

        public float PowerValue => _powerValue;
        public float ScrollSensitivity => _scrollSensitivity;
        public float MinPowerValue => _minPowerValue;
        public float MaxPowerValue => _maxPowerValue;

        public void UpdatePowerValue(float value)
        {
            _powerValue = value;
        }
    }
}