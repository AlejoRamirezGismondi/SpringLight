using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioClip[] _audioClips;
    private int _currentClip;

    private static MusicManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        _audioSource = GetComponent<AudioSource>();
        _audioClips = Resources.LoadAll<AudioClip>("Music");
    }
    
    private void Start()
    {
        _currentClip = 0;
        ShuffleMusic(_audioClips);
        _audioSource.clip = _audioClips[_currentClip];
        _audioSource.Play();
    }
    
    private void Update()
    {
        if (_audioSource.isPlaying) return;
        _currentClip = (_currentClip + 1) % _audioClips.Length;
        _audioSource.clip = _audioClips[_currentClip];
        _audioSource.Play();
    }

    private static void ShuffleMusic(AudioClip[] array)
    {
        for (var i = array.Length - 1; i > 0; i--)
        {
            var r = Random.Range(0, i);
            (array[i], array[r]) = (array[r], array[i]);
        }
    }
}
