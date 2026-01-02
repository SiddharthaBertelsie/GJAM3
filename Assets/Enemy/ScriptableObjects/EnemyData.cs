using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data (Base)", menuName = "Enemy Data", order = 0)]
public class EnemyData : ScriptableObject
{
    #region Variables

    [SerializeField] private float _startingHealth;

    [SerializeField] private float _movementSpeed;

    [SerializeField] private float _attackDamage;

    [SerializeField] private float _distanceToAttackFrom;

    [SerializeField] private float _attackCooldown;

    #endregion

    #region Getters

    // These are the what we will call to get the values in here
    public float StartingHealth { get { return _startingHealth; } }
    public float MovementSpeed { get { return _movementSpeed; } }
    public float AttackDamage {  get { return _attackDamage; } }
    public float DistanceToAttackFrom { get {  return _distanceToAttackFrom; } }
    public float AttackCooldown { get { return _attackCooldown; } }

    #endregion
}