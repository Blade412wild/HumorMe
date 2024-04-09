using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public enum Button { Serious, Funny };
    public Button button;

    [SerializeField] private Transform visualTarget;
    [SerializeField] private Vector3 localAxis;
    [SerializeField] private float resetSpeed = 5.0f;
    [SerializeField] private float followAngleThreshold = 45.0f;
    

    private Vector3 offset;
    private Vector3 initialLocalPos;
    private Transform pokeAttachTransform;
    private bool freeze = false;

    //private XRBaseInteractor interactable;
    private XRSimpleInteractable interactable;
    private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);

        initialLocalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze) return;
        if (isFollowing)
        {
            Vector3 localTransformPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTransformPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
        }
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;

            pokeAttachTransform = interactor.transform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));
            if (pokeAngle < followAngleThreshold)
            {
                isFollowing = true;
                freeze = false;
            }

        }
    }
    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;

        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            EventManagerEnum.Instance.TriggerEvent(EventManagerEnum.EventType.OnButtonClicked);
            freeze = true;
        }
    }
}
