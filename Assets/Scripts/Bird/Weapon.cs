using UnityEngine;

[RequireComponent(typeof(InputBird))]
[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private BirdBulletFactory _bulletFactory;

    private InputBird _input;
    private AudioSource _audioSource;

    private void Awake()
    {
        _input = GetComponent<InputBird>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _input.Shooting += OnShootAction;
    }

    private void OnDisable()
    {
        _input.Shooting -= OnShootAction;
    }

    private void OnShootAction()
    {
        _bulletFactory.GetPrefab();

        _audioSource.Play();
    }
}