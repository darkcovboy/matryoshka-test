using CookingPrototype.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public class StartMenuWindow : MonoBehaviour {
		[SerializeField] private Button _playButton;
		[SerializeField] private TextMeshProUGUI _targetText;

		void Awake() {
			_playButton.onClick.AddListener(OnButtonClicked);
		}

		void OnDestroy() {
			_playButton.onClick.RemoveAllListeners();
		}

		public void Show() {
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}

		public void Init(int ordersTarget) {
			_targetText.text = $"{ordersTarget}";
		}

		private void OnButtonClicked() {
			GameplayController.Instance.StartGame();
		}
	}
}