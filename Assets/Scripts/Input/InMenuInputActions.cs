using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class InMenuInputActions : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerAction Back;
    public PlayerAction Submit;

    public InMenuInputActions()
    {
        Left = CreatePlayerAction("Left");
        Right = CreatePlayerAction("Right");
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        Back = CreatePlayerAction("Back");
        Submit = CreatePlayerAction("Submit");

        BindActions();
    }

    private void BindActions()
    {
        Left.AddDefaultBinding(Key.A);
        Left.AddDefaultBinding(Key.LeftArrow);
        Left.AddDefaultBinding(InputControlType.DPadLeft);
        Left.AddDefaultBinding(InputControlType.LeftStickLeft);

        Right.AddDefaultBinding(Key.D);
        Right.AddDefaultBinding(Key.RightArrow);
        Right.AddDefaultBinding(InputControlType.DPadRight);
        Right.AddDefaultBinding(InputControlType.LeftStickRight);

        Up.AddDefaultBinding(Key.W);
        Up.AddDefaultBinding(Key.UpArrow);
        Up.AddDefaultBinding(InputControlType.DPadUp);
        Up.AddDefaultBinding(InputControlType.LeftStickUp);

        Down.AddDefaultBinding(Key.S);
        Down.AddDefaultBinding(Key.DownArrow);
        Down.AddDefaultBinding(InputControlType.DPadDown);
        Down.AddDefaultBinding(InputControlType.LeftStickDown);

        Back.AddDefaultBinding(Key.Escape);
        Back.AddDefaultBinding(Key.Backspace);
        Back.AddDefaultBinding(InputControlType.Action4);

        Submit.AddDefaultBinding(Key.Space);
        Submit.AddDefaultBinding(Key.Return);
        Submit.AddDefaultBinding(InputControlType.Action1);
    }
}
