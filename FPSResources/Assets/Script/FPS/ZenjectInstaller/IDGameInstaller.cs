using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IDGameInstaller : MonoInstaller
{
    [SerializeField] private GameObject inputPrefab;
    [SerializeField] private TextAsset playerSettings;

    public override void InstallBindings()
    {
        Debug.Log("Install bindings");
        //Components
        Container.Bind<IStatsComponent>().To<StatsComponent>().AsTransient();
        Container.Bind<IPlayerComponent>().To<PlayerComponent>().AsTransient();

        //Systems
        Container.Bind<IInputSystem>().FromComponentInNewPrefab(inputPrefab).AsSingle();

        // Handlers
        Container.Bind<IMoving>().To<Moving>().AsTransient();
    }
}
