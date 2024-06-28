using UnityEngine;
using UnityEngine.UI;

namespace Assets.N.Fridman.SoundVolumeController.Scripts
{
    public class SoundVolumeControllerComponent : MonoBehaviour
    {
        [Header("Components")]
        [Tooltip("Audio Source Does Тot Connect Automatically")]
        [SerializeField] private AudioSource audioSource;
        [Tooltip("Slider Search Using A Tag")]
        [SerializeField] private Slider slider;
        [Tooltip("Text Search Using A Tag")]
        [SerializeField] private Text text;
    
        [Header("Keys")]
        [Tooltip("Save Data PlayerPrefs Key")]
        [SerializeField] private string saveVolumeKey;
    
        [Header("Tags")]
        [Tooltip("Volume Control Slider Tag")]
        [SerializeField] private string sliderTag;
        [Tooltip("Volume Control Text Tag")]
        [SerializeField] private string textVolumeTag;
    
        [Header("Parameters")]
        [Tooltip("Sound Volume Value")]
        [SerializeField] [Range(0.0f, 1.0f)] private float volume;
    
        private void Awake()
        {    
            if (PlayerPrefs.HasKey(this.saveVolumeKey))
            {
                this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
                this.audioSource.volume = this.volume;
                
                GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
                if (sliderObj != null)
                {
                    this.slider = sliderObj.GetComponent<Slider>();
                    this.slider.value = this.volume;
                }
            }
            else
            {
                this.volume = 0.5f;
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
                this.audioSource.volume = this.volume;
            }
        }
    
        private void LateUpdate()
        {
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.volume = slider.value;
                
                if (this.audioSource.volume != this.volume)
                {
                    PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
                }
                
                GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
                if (textObj != null)
                {
                    this.text = textObj.GetComponent<Text>();

                    this.text.text = Mathf.Round(this.volume * 100) + "%";
                }
            }

            this.audioSource.volume = this.volume;
        }
    }
}
