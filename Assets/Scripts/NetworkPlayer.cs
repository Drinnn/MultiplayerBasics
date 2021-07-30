using Mirror;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour {
    [SyncVar] [SerializeField] private string displayName = "Missing Name";
    [SyncVar] [SerializeField] private Color displayColor;


    [Server]
    public void SetDisplayName(string newDisplayName) {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor() {
        displayColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
