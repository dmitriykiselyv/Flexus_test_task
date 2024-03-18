using System.Globalization;
using MVC.Models;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Views
{
    public class PowerControlView : MonoBehaviour, MVC.Interfaces.IObserver<SliderModel>
    {
        [SerializeField] private Slider _powerSlider;
        [SerializeField] private Text _powerValue;
    
        private PowerSliderConfig _powerSliderConfig;
    
        public void Init(PowerSliderConfig powerSliderConfig)
        {
            _powerSliderConfig = powerSliderConfig;
            
            _powerSliderConfig.Attach(this);
            DataChanged(_powerSliderConfig.SliderModel);
        }
    
        public void Cleanup()
        {
            _powerSliderConfig.Detach(this);
        }

        public void DataChanged(SliderModel model)
        {
            _powerSlider.minValue = model.MinPowerValue;
            _powerSlider.maxValue = model.MaxPowerValue;
            _powerSlider.value = model.PowerValue;
            _powerValue.text = model.PowerValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}