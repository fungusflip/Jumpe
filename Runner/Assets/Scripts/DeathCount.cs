using UnityEngine;
using TMPro;

public class DeathCount : MonoBehaviour
{
    public int deathCount;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        deathCount = PlayerPrefs.GetInt("deathCount");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        UpdateDeathCountText();
    }

    void UpdateDeathCountText()
    {
        textMeshPro.text = "Deadeth " + deathCount;
    }

    // Add this method to update the death count externally
    public void SetDeathCount(int newDeathCount)
    {
        deathCount = newDeathCount;
        PlayerPrefs.SetInt("deathCount", deathCount);
        PlayerPrefs.Save();
        UpdateDeathCountText();
    }
}