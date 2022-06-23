using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    private const float DEFAULT_SPEED = 3f;
    private static readonly Vector3 JUMP_DIRECTION = new Vector3(0, 30, 0);

    [Inject] private IMoving movingHandler;
    [Inject] private IPlayerComponent component;

    [SerializeField] private LayerMask shootingTargetMask;
    [SerializeField] private Transform shootingCameraTransform;

    private Rigidbody rigidBd;

    [Inject]
    public PlayerHandler() { }

    private void Awake()
    {        
        rigidBd = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        if (component != null)
        {
            component.OnFired -= handleFire;
            component.OnJumped -= handleJumping;
            component.OnMovingDirectionChanged -= handleMoving;
        }
    }

    private void Start()
    {
        if (component != null)
        {
            component.OnFired += handleFire;
            component.OnJumped += handleJumping;
            component.OnMovingDirectionChanged += handleMoving;
        }
    }

    private void handleFire()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(shootingCameraTransform.position, shootingCameraTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootingTargetMask))
        {
            Debug.DrawRay(shootingCameraTransform.position, shootingCameraTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit = " + hit.transform.tag);
        }
        else
        {
            Debug.DrawRay(shootingCameraTransform.position, shootingCameraTransform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void handleJumping()
    {
        movingHandler?.JumpTo(rigidBd, JUMP_DIRECTION);
    }

    private void handleMoving(Vector3 direction)
    {
        movingHandler?.MoveTo(rigidBd, direction, component.Stats.Speed);
    }

    public IPlayerComponent GetSyncComponent()
    {
        return component;
    }

    public void SetInfo(PlayerSettings info)
    {
        if (component != null)
        {
            component.Id = info.Id;
            component.Stats.Speed = info.Speed;
            component.Stats.HP = info.Hp;
            component.Stats.Strength = info.Strength;
        }
        {
            Debug.Log("component of character is null");
        }
    }

}
