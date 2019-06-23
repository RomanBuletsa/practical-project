using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public sealed class GameUIManager : MonoBehaviour
	{
		public event Action BackButtonClicked;
		public event Action PauseButtonClicked;
		public event Action ResumeButtonClicked;
		
		[SerializeField] private TextMeshProUGUI scoreText;
		[SerializeField] private TextMeshProUGUI targetObjectText;
		[SerializeField] private Button backButton;
		[SerializeField] private Button pauseButton;
		[SerializeField] private Button resumeButton;
		[SerializeField] private GameObject pauseMenu;
		
		private void Awake()
		{
			backButton.onClick.AddListener(OnBackButtonClicked);
			pauseButton.onClick.AddListener(OnPauseButtonClicked);
			resumeButton.onClick.AddListener(OnResumeButtonClicked);

			pauseMenu.SetActive(false);
		}

		private void OnBackButtonClicked() => BackButtonClicked?.Invoke();

		private void OnPauseButtonClicked()
		{
			PauseButtonClicked?.Invoke();
			pauseMenu.SetActive(true);
		}

		private void OnResumeButtonClicked()
		{
			ResumeButtonClicked?.Invoke();
			pauseMenu.SetActive(false);
		}

		public void UpdateScoreText(int score) => scoreText.text = $"{score}";

		public void UpdateTargetObjectText(string targetObjectName) => targetObjectText.text = targetObjectName;
	}
}