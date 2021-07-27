using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager {
    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);

        Debug.Log("Connected to a Server!");
    }

    public override void OnServerAddPlayer(NetworkConnection conn) {
        base.OnServerAddPlayer(conn);

        Debug.Log($"Player has been created! Now, there are ${numPlayers} on the server.");
    }
}
