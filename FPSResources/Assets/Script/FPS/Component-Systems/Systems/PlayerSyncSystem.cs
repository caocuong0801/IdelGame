using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSyncSystem : MonoBehaviour
{
    [Inject] private IInputSystem inputSystem;

    [SerializeField] private TextAsset settingsAsset;
    [SerializeField] private GameObject playerPrefab;

    private IPlayerComponent mainPlayerComponent;
    private List<IPlayerComponent> otherPlayerComponents;

    void Start()
    {
        inputSystem.OnJumping += handleMainPlayerJump;
        inputSystem.OnMoving += handleMainPlayerMove;
        inputSystem.OnFire += handleMainPlayerFire;

        var settingsStr = settingsAsset.text;
        Debug.Log("Init player sync system with settings = " + settingsStr);
        var settings = JsonUtility.FromJson<AllPlayerSettings>(settingsStr);
        if (settings != null && settings.Players != null && settings.Players.Any())
        {
            foreach (var item in settings.Players)
            {
                createPlayerWithData(item);
            }
        }
    }

    void Destroy()
    {
        inputSystem.OnJumping -= handleMainPlayerJump;
        inputSystem.OnMoving -= handleMainPlayerMove;
        inputSystem.OnFire -= handleMainPlayerFire;
    }

    private void createPlayerWithData(PlayerSettings info)
    {
        if (playerPrefab == null)
        {
            Debug.Log("Player prefab is null");
            return;
        }

        var playerObj = Instantiate(playerPrefab);
        var playerHandler = playerObj?.GetComponent<PlayerHandler>();
        playerHandler?.SetInfo(info);

        var isMainPlayer = true; // TODO: Check by player id
        var component = playerHandler?.GetSyncComponent();
        if (isMainPlayer)
        {
            mainPlayerComponent = component;
        }
        else
        {
            if (component != null)
            {
                otherPlayerComponents.Add(component);
            }
        }
    }

    private void handleMainPlayerFire()
    {
        handlePlayerFire(true);
    }

    private void handleMainPlayerJump()
    {
        handlePlayerJump(true);
    }

    private void handleMainPlayerMove(Vector3 direction)
    {
        handlePlayerMove(direction, true);
    }

    private void handlePlayerFire(bool isMain = false)
    {
        if (isMain)
        {
            mainPlayerComponent.Fire();
        }
        // TODO: Checking for the others
    }

    private void handlePlayerJump(bool isMain = false)
    {
        if (isMain)
        {
            mainPlayerComponent.Jump();
        }
        // TODO: Checking for the others
    }

    private void handlePlayerMove(Vector3 direction, bool isMain = false)
    {
        if (isMain)
        {
            mainPlayerComponent.Move(direction);
        }
        // TODO: Checking for the others
    }

    public void AddPlayer(PlayerHandler player)
    {
        var isMainPlayer = true; // TODO: should check base on player id
        if (isMainPlayer)
        {
            mainPlayerComponent = null;
        }
    }
    public void RemovePlayer(PlayerHandler player)
    {

    }

}


[Serializable]
public class AllPlayerSettings
{
    public PlayerSettings[] Players;
}

[Serializable]
public class PlayerSettings
{
    public float Hp;
    public string Id;
    public float Strength;
    public float Speed;
}
