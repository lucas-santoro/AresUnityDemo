using UnityEngine;
using TMPro;

public class AliveCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    void OnEnable()
    {
        TargetManager.Instance.OnAliveCountChanged += UpdateCount;
    }

    void OnDisable()
    {
        TargetManager.Instance.OnAliveCountChanged -= UpdateCount;
    }

    void UpdateCount(int count)
    {
        countText.text = count.ToString();
    }
}
