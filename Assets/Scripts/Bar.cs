using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _filledArea;

    private Coroutine _currentCoroutine;
    
    private void OnEnable()
    {
        _player.HealthChanged += Render;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= Render;
    }

    private void Render(float currentValue, float maxValue)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        float healthValue = currentValue / maxValue;
        _currentCoroutine = StartCoroutine(ChangeValueSmoothly(healthValue));
    }

    private IEnumerator ChangeValueSmoothly(float targetValue)
    {
        float changeSpeed = .3f;
        
        while (_filledArea.fillAmount != targetValue)
        {
            _filledArea.fillAmount = Mathf.MoveTowards(_filledArea.fillAmount, targetValue, changeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
