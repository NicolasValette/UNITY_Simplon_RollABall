using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    #region Serialized fields
    [SerializeField]
    private LevelManager _levelManager;
    [Header("Datas")]
    [SerializeField]
    private ScoreData _score;
    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _scoreSOText;
    #endregion
    private Rigidbody _rigidbody;
    private int _scoreValue = 0;
    private int _targetDestroyed = 0;
    private bool _isGameStarted = false;
    private ScenarioData _scenario;

    public static event Action LevelCompleted;
    void Start()
    {
        _scoreValue = PlayerPrefs.GetInt("Score");
        _targetDestroyed = 0;
        _rigidbody = GetComponent<Rigidbody>();
        _scoreText.text = "Score : " + _scoreValue;
        //_scoreSOText.text = "ScoreSO : " +  _score.Score;
        _scenario = _levelManager.GetScenarioLevel();
    }
    private void OnEnable()
    {
        Countdown.OnStartGame += StartGame;
    }
    private void OnDisable()
    {
        Countdown.OnStartGame -= StartGame;
    }

    void Update()
    {
        if (_isGameStarted)
        {
            Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDir.Normalize();
            Debug.Log(moveDir);
            if (moveDir != Vector3.zero)
            {
                //_rigidbody.AddForce(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * _speed * Time.deltaTime);
                //_rigidbody.AddForce(moveDir * _moveSpeed * Time.deltaTime);
                transform.Translate(moveDir * _playerData.MoveSpeed * Time.deltaTime, Space.World);
                Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _playerData.RotationSpeed * Time.deltaTime);
            }
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
        //  _score.Score++;


        PlayerPrefs.SetInt("Score", _scoreValue);
        _scoreText.text = "Score : " + _scoreValue;
        // _scoreSOText.text = "Score SO: " + _score.Score;
        _targetDestroyed++;
        for (int i = 0; i < _scenario.Menaces.Count; i++)
        {
            if (_scenario.Menaces[i].TargetNeeded == _targetDestroyed)
            {
                Debug.Log("Instantiate element : " + i);
                Instantiate(_scenario.WallPrefab, _scenario.Menaces[i].Position, _scenario.Menaces[i].Rotation);
            }
        }


        if (_targetDestroyed >= 8)
        {
            LevelCompleted?.Invoke();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void StartGame()
    {
        _isGameStarted = true;
    }
}
