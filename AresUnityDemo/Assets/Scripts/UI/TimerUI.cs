using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TimerService timerService;
    [SerializeField] private TextMeshProUGUI timerText;

    private void Start()
    {
        timerService.OnTimerTick += UpdateDisplay;
        timerService.OnTimerFinished += ShowGameOver;
        TargetManager.Instance.OnAllTargetsKilled += ShowGameOver;
    }

    private void OnDestroy()
    {
        timerService.OnTimerTick -= UpdateDisplay;
        timerService.OnTimerFinished -= ShowGameOver;
        TargetManager.Instance.OnAllTargetsKilled -= ShowGameOver;
    }

    private void UpdateDisplay(float remaining)
    {
        int minutes = Mathf.FloorToInt(remaining / 60f);
        int seconds = Mathf.FloorToInt(remaining % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void ShowGameOver()
    {
        timerText.text = "Game Over";
    }
}
