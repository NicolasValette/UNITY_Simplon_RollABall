using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int _scoreValue = 0;
    private int _targetDestroyed = 0;

    [SerializeField]
    private ScoreData _score;
    [SerializeField]
    private ScenarioData _scenario;
    [SerializeField]
    private float _speed = 2f;
    [SerializeField] 
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _scoreSOText;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            _scoreValue = PlayerPrefs.GetInt("Score");
        }
        _targetDestroyed = 0;
        _rigidbody = GetComponent<Rigidbody>();
        _scoreText.text = "Score : " + _scoreValue;
        _scoreSOText.text = "ScoreSO : " +  _score.Score;
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) 
        {
            _rigidbody.AddForce(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * _speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target_Trigger"))
        {
            ScoreAndDestroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            ScoreAndDestroy(collision.gameObject);
        }
    }

    private void ScoreAndDestroy(GameObject target)
    {
        Destroy(target);
        _scoreValue++;
        _score.Score++;
        
       
        PlayerPrefs.SetInt("Score", _scoreValue);
        _scoreText.text = "Score : " + _scoreValue;
        _scoreSOText.text = "Score SO: " + _score.Score;

        if (_targetDestroyed < _scenario.Walls.Count)
        {
            Instantiate(_scenario.WallPrefab, _scenario.Walls[_targetDestroyed].position, _scenario.Walls[_targetDestroyed].rotation);
        }
        _targetDestroyed++;
        if (_targetDestroyed >= 8)
        {
            SceneManager.LoadScene(1);
        }
    }
}
