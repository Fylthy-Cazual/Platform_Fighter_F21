// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Mechanics/RatControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @RatControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @RatControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RatControls"",
    ""maps"": [
        {
            ""name"": ""Battle"",
            ""id"": ""30917c84-d236-47a6-b889-6d88415da0e2"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""8fd1b4e2-d492-4878-ae6a-4b0e1030859d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""474e41f9-aa99-4d9c-a4c6-badb7415fb9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""ace4f0e4-e904-4307-815a-643eb4ed81c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""5c38462d-3f63-4cfa-afa2-4d95c0ae6344"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ff7a2cd6-ea66-4033-b548-0a6f32417d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""fd88fddc-be90-480c-a61f-567008ce534f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c7ef6c0b-f1a6-4546-844d-18ed49285789"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c1a49ab-1a53-4d87-9d08-4e145999ad92"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b288c70d-3942-48e8-b06d-8229261172cc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d69e90e4-d1b7-4875-885f-115d64cbdc2d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""159f31d7-2c71-4cc0-9ff4-5952d7985702"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b66d5f1e-4194-429d-baac-ca3823a2fbf3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d85c256-5481-4211-813d-e65996b85591"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13840add-60d8-480d-973b-6a8cd9d4f2b2"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70457d24-7b45-405e-aabe-b68a2ed25a74"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d974036-a645-4880-98ed-de35cd1a0df0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77b652a7-4e36-466f-9a4d-ccca09eed0b4"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09fc2d1a-b155-4201-93e7-c1637818bfa2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Battle
        m_Battle = asset.FindActionMap("Battle", throwIfNotFound: true);
        m_Battle_Up = m_Battle.FindAction("Up", throwIfNotFound: true);
        m_Battle_Down = m_Battle.FindAction("Down", throwIfNotFound: true);
        m_Battle_Left = m_Battle.FindAction("Left", throwIfNotFound: true);
        m_Battle_Right = m_Battle.FindAction("Right", throwIfNotFound: true);
        m_Battle_Attack = m_Battle.FindAction("Attack", throwIfNotFound: true);
        m_Battle_Special = m_Battle.FindAction("Special", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Battle
    private readonly InputActionMap m_Battle;
    private IBattleActions m_BattleActionsCallbackInterface;
    private readonly InputAction m_Battle_Up;
    private readonly InputAction m_Battle_Down;
    private readonly InputAction m_Battle_Left;
    private readonly InputAction m_Battle_Right;
    private readonly InputAction m_Battle_Attack;
    private readonly InputAction m_Battle_Special;
    public struct BattleActions
    {
        private @RatControls m_Wrapper;
        public BattleActions(@RatControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Battle_Up;
        public InputAction @Down => m_Wrapper.m_Battle_Down;
        public InputAction @Left => m_Wrapper.m_Battle_Left;
        public InputAction @Right => m_Wrapper.m_Battle_Right;
        public InputAction @Attack => m_Wrapper.m_Battle_Attack;
        public InputAction @Special => m_Wrapper.m_Battle_Special;
        public InputActionMap Get() { return m_Wrapper.m_Battle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleActions set) { return set.Get(); }
        public void SetCallbacks(IBattleActions instance)
        {
            if (m_Wrapper.m_BattleActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnRight;
                @Attack.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnAttack;
                @Special.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_BattleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }
        }
    }
    public BattleActions @Battle => new BattleActions(this);
    public interface IBattleActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
    }
}
