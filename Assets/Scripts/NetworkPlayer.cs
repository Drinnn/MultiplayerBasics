using Mirror;
using TMPro;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour {
    [SerializeField] private TMP_Text displayNameText;
    [SerializeField] private Renderer displayColorRenderer;

    [SyncVar(hook = nameof(HandleDisplayNameUpdated))] [SerializeField] private string displayName = "Missing Name";
    [SyncVar(hook = nameof(HandleDisplayColorUpdated))] [SerializeField] private Color displayColor;

    #region Server

    [Server]
    public void SetDisplayName(string newDisplayName) {
        displayName = newDisplayName;
        RpcLogNewName(newDisplayName);
    }

    [Server]
    public void SetDisplayColor() {
        displayColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    [Command]
    private void CmdSetDisplayName(string newDisplayName) {
        SetDisplayName(newDisplayName);
    }

    #endregion

    #region Client

    private void HandleDisplayNameUpdated(string oldName, string newName) {
        displayNameText.SetText(newName);
    }

    private void HandleDisplayColorUpdated(Color oldColor, Color newColor) {
        displayColorRenderer.material.SetColor("_BaseColor", newColor);
    }

    [ClientRpc]
    private void RpcLogNewName(string newDisplayName) {
        Debug.Log(newDisplayName);
    }

    [ContextMenu("Set Name")]
    private void SetName() {
        CmdSetDisplayName("My New Name");
    }

    #endregion
}
