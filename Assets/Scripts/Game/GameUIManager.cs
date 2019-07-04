using System;
using System.Collections;
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
		[SerializeField] private TextMeshProUGUI bestScoreText;
		[SerializeField] private TextMeshProUGUI targetObjectText;
		[SerializeField] private Button backButton;
		[SerializeField] private Button pauseButton;
		[SerializeField] private Button resumeButton;
		[SerializeField] private GameObject pauseMenu;
		[SerializeField] private float targetTextShiningTime;

		private Color targetTextColor;
		
		private void Awake()
		{
			backButton.onClick.AddListener(OnBackButtonClicked);
			pauseButton.onClick.AddListener(OnPauseButtonClicked);
			resumeButton.onClick.AddListener(OnResumeButtonClicked);

			targetTextColor = targetObjectText.color;

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
		public void UpdateBestScoreText(int bestScore) => bestScoreText.text = $"Best: {bestScore}";

		public void UpdateTargetObjectText(string targetObjectName, int roundNumber)
		{
			if (roundNumber == 0)	targetObjectText.text = targetObjectName;
			else
			{
				targetObjectText.color = Color.red;
				targetObjectText.text = targetObjectName;
				Time.timeScale = 0;
				StartCoroutine(WaitForColorChange(targetTextShiningTime));
			}
		}

		private IEnumerator WaitForColorChange(float shinningTime)
		{
			yield return new WaitForSecondsRealtime(shinningTime);
			targetObjectText.color = targetTextColor;
			Time.timeScale = 1f;
		}
	}
}