using System.Linq;
using UnityEngine;

public class JustDesert : MonoBehaviour
{
    private static JustDesert _instance = null;
    public static JustDesert Instance => FindSingletonUniqueInstance();

    public static JustDesert FindSingletonUniqueInstance()
    {
        if( _instance != null )
        {
            return _instance;
        }

        JustDesert justDesertInstance = GameObject.FindObjectsOfType<JustDesert>().FirstOrDefault();

        if( justDesertInstance == null )
        {
            justDesertInstance = new GameObject( "Roguelike" ).AddComponent<JustDesert>();
        }

        return _instance = justDesertInstance;

    }
}
