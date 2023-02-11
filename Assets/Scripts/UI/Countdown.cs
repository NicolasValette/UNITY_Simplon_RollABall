using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _countdownText;


    public static event Action OnStartGame;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartCountDown()
    {
        float current = 3f;
        _countdownText.text= current.ToString();
        while (current > 0f)
        {
            yield return new WaitForSeconds(1f);
            current--;
            _countdownText.text = current.ToString();
        }
        if (current <=0f)
        {
            _countdownText.enabled = false;
            OnStartGame?.Invoke();
        }
    }
}
