using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class InGameInputActions : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerAction Run;
    public TwoAxisInputControl Move;

    public PlayerAction Target;

    public PlayerAction Attack1;
    public PlayerAction Attack2;
    public PlayerAction Parry;
    public PlayerAction Kick;


    public InGameInputActions()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        Run = CreatePlayerAction("Run");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);

        Target = CreatePlayerAction("Target");

        Attack1 = CreatePlayerAction("Attack 1");
        Attack2 = CreatePlayerAction("Attack 2");
        Parry = CreatePlayerAction("Parry");
        Kick = CreatePlayerAction("Kick");


        BindActions();
    }

    private void BindActions()
    {
        Left.AddDefaultBinding(Key.A);
        Left.AddDefaultBinding(Key.LeftArrow);
        Left.AddDefaultBinding(InputControlType.LeftStickLeft);

        Right.AddDefaultBinding(Key.D);
        Right.AddDefaultBinding(Key.RightArrow);
        Right.AddDefaultBinding(InputControlType.LeftStickRight);

        Up.AddDefaultBinding(Key.W);
        Up.AddDefaultBinding(Key.UpArrow);
        Up.AddDefaultBinding(InputControlType.LeftStickUp);

        Down.AddDefaultBinding(Key.S);
        Down.AddDefaultBinding(Key.DownArrow);
        Down.AddDefaultBinding(InputControlType.LeftStickDown);

        Run.AddDefaultBinding(Key.LeftShift);
        Run.AddDefaultBinding(Key.RightShift);
        Run.AddDefaultBinding(InputControlType.RightTrigger);

        Target.AddDefaultBinding(InputControlType.RightBumper);

        Attack1.AddDefaultBinding(InputControlType.Action1);
        Attack1.AddDefaultBinding(Mouse.LeftButton);

        Attack2.AddDefaultBinding(InputControlType.Action3);
        Attack2.AddDefaultBinding(Mouse.RightButton);

        Parry.AddDefaultBinding(Key.LeftAlt);
        Parry.AddDefaultBinding(Key.RightAlt);
        Parry.AddDefaultBinding(InputControlType.Action2);

        Kick.AddDefaultBinding(Key.LeftControl);
        Kick.AddDefaultBinding(Key.RightControl);
        Kick.AddDefaultBinding(InputControlType.Action4);
    }
}
