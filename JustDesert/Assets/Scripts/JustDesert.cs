using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class JustDesert : MonoBehaviour
{
    private static JustDesert _instance = null;
    public static JustDesert Instance => FindSingletonUniqueInstance();

    [SerializeField]
    private GameManager _gameManager;
    public GameManager GameManager
    {
        get { return _gameManager != null ? _gameManager : _gameManager = Instance.GetOrAddComponent<GameManager>(); }
    }


    [SerializeField]
    private InputHandler _inputHandler;
    public InputHandler InputHandler
    {
        get { return _inputHandler != null ? _inputHandler : _inputHandler = Instance.GetOrAddComponent<InputHandler>(); }
    }

    public static JustDesert FindSingletonUniqueInstance()
    {
        if( _instance != null )
        {
            return _instance;
        }

        JustDesert justDesertInstance = GameObject.FindObjectsOfType<JustDesert>().FirstOrDefault();

        if( justDesertInstance == null )
        {
            justDesertInstance = new GameObject( "JustDesert" ).AddComponent<JustDesert>();
        }

        return _instance = justDesertInstance;

    }
}
