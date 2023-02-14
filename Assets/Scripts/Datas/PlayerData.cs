using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Data/New Player")]
public class PlayerData : ScriptableObject
{
    public enum PlayerNum
    {
        Player1,
        Player2
    }
    #region Serialized data
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _rotationSpeed = 800f;
    [SerializeField]
    private KeyCode _keyCodeUp;
    [SerializeField]
    private KeyCode _keyCodeDown;
    [SerializeField]
    private KeyCode _keyCodeLeft;
    [SerializeField]
    private KeyCode _keyCodeRight;
    #endregion

    #region Getters
    public float MoveSpeed { get { return _moveSpeed; } }
    public float RotationSpeed { get { return _rotationSpeed; } }
    public KeyCode GetUpInput { get { return _keyCodeUp; } }
    public KeyCode GetDownInput { get { return _keyCodeDown; } }
    public KeyCode GetLeftInput { get { return _keyCodeLeft; } }
    public KeyCode GetRightInput { get { return _keyCodeRight; } }
    #endregion

}
