using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using FirstRoguelike.Blessings;
using FirstRoguelike.Bloodlines;

namespace FirstRoguelike.UI
{
    public class BlessingCardUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI blessingNameText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI bloodlineText;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Button selectButton;

        private BlessingSO _blessing;
        private BloodlineSO _bloodline;
        private Action<BlessingSO, BloodlineSO> _onSelected;

        public void Setup(BlessingSO blessing, BloodlineSO bloodline, Action<BlessingSO, BloodlineSO> onSelected)
        {
            _blessing = blessing;
            _bloodline = bloodline;
            _onSelected = onSelected;

            blessingNameText.text = blessing.blessingName;
            descriptionText.text = blessing.description;
            bloodlineText.text = $"Bloodline: {bloodline.bloodlineName}";
            backgroundImage.color = bloodline.color;

            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() => _onSelected?.Invoke(_blessing, _bloodline));
        }
    }
}