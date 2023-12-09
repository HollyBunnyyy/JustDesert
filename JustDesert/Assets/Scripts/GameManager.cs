using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    public Player Player
    {
        get { return _player != null ? _player : _player = new GameObject( "Player" ).AddComponent<Player>(); }
    }
}
