using UnityEngine;

public class SpaceshipVisual : MonoBehaviour
{
    private const string DAMAGE_TRIGGER = "GetDamage";

    [SerializeField] private GameObject _explosionFX;

    private Animator _animator;
    private DamageManager _damageManager;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _damageManager = GetComponent<DamageManager>();

        _damageManager.OnDamageTaken += OnDamageTaken;
    }

    private void OnDamageTaken(int damageCount)
    {
        SetDamageAnimation();
    }

    public void SetDamageAnimation()
    {
        _animator.SetTrigger(DAMAGE_TRIGGER);
        StartCoroutine(ShowExplosion());
    }

    private System.Collections.IEnumerator ShowExplosion()
    {
        _explosionFX.SetActive(true);
        yield return new WaitForSeconds(1);
        _explosionFX.SetActive(false);
    }

    private void OnDisable()
    {
        _damageManager.OnDamageTaken -= OnDamageTaken;
    }
}
