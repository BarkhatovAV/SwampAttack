using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaweButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaweButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }    

    public void OnNextWaweButtonClick()
    {
        _spawner.NextWave();

        _nextWaveButton.gameObject.SetActive(false);
    }
}
