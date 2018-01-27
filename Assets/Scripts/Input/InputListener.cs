using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public static InputListener instance;

    private InMenuInputActions menuInput;
    private InGameInputActions gameInput;

    private State currentState;
    private State onMenu;
    private State onGame;

    private void Awake()
    {
        instance = this;

        gameInput = new InGameInputActions();

        onGame = new OnGame();

        SetState(onGame);
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Refresh();
    }

    private abstract class State
    {
        public abstract void End();
        public abstract void Refresh();
        public abstract void Start();
    }

    private void SetState(State newState)
    {
        if (currentState != null)
            currentState.End();

        currentState = newState;
        currentState.Start();
    }


    #region OnGame State

    private class OnGame : State
    {
        public override void End()
        {
        }

        public override void Refresh()
        {
            Vector2 movement = instance.gameInput.Move.Value;
			Events.InputGameMove(movement);
			if (instance.gameInput.Left.WasPressed) { Events.InputGameRun(true); Debug.Log("Run pressed"); }
			if (instance.gameInput.Right.WasPressed) { Events.InputGameRun(true); Debug.Log("Run pressed"); }
			if (instance.gameInput.Up.WasPressed) { Events.InputGameRun(true); Debug.Log("Run pressed"); }
			if (instance.gameInput.Down.WasPressed) { Events.InputGameRun(true); Debug.Log("Run pressed"); }

            if (instance.gameInput.Run.WasPressed) { Events.InputGameRun(true); Debug.Log("Run pressed"); }
            if (instance.gameInput.Run.WasReleased) { Events.InputGameRun(false); Debug.Log("Run released"); }
            if (instance.gameInput.Target.WasPressed) { Events.InputGameTarget(); Debug.Log("Target"); }
            if (instance.gameInput.Attack1.WasPressed) { Events.InputGameAttack1(); Debug.Log("Attack1 pressed"); }
            if (instance.gameInput.Attack2.WasPressed) { Events.InputGameAttack2(); Debug.Log("Attack2 pressed"); }
            if (instance.gameInput.Parry.WasPressed) { Events.InputGameParry(); Debug.Log("Parry pressed"); }
            if (instance.gameInput.Kick.WasPressed) { Events.InputGameKick(); Debug.Log("Kick pressed"); }
        }

        public override void Start()
        {
        }
    }
    #endregion


    public static class Events
    {

        //IN MENU INPUT
        public static Action OnInputMenuUp;
        public static void InputMenuUp()
        {
            if (OnInputMenuUp != null)
                OnInputMenuUp();
        }

        public static Action OnInputMenuDown;
        public static void InputMenuDown()
        {
            if (OnInputMenuDown != null)
                OnInputMenuDown();
        }

        public static Action OnInputMenuLeft;
        public static void InputMenuLeft()
        {
            if (OnInputMenuLeft != null)
                OnInputMenuLeft();
        }

        public static Action OnInputMenuRight;
        public static void InputMenuRight()
        {
            if (OnInputMenuRight != null)
                OnInputMenuRight();
        }

        public static Action OnInputMenuBack;
        public static void InputMenuBack()
        {
            if (OnInputMenuBack != null)
                OnInputMenuBack();
        }

        public static Action OnInputMenuSubmit;
        public static void InputMenuSubmit()
        {
            if (OnInputMenuSubmit != null)
                OnInputMenuSubmit();
        }

        //IN GAME INPUT

        public static Action<Vector2> OnInputGameMove;
        public static void InputGameMove(Vector2 movement)
        {
            if (OnInputGameMove != null)
                OnInputGameMove(movement);
        }

        public static Action<bool> OnInputGameRun;
        public static void InputGameRun(bool run)
        {
            if (OnInputGameRun != null)
                OnInputGameRun(run);
        }

        public static Action OnInputGameAttack1;
        public static void InputGameAttack1()
        {
            if (OnInputGameAttack1 != null)
                OnInputGameAttack1();
        }

        public static Action OnInputGameAttack2;
        public static void InputGameAttack2()
        {
            if (OnInputGameAttack2 != null)
                OnInputGameAttack2();
        }

        public static Action OnInputGameTarget;
        public static void InputGameTarget()
        {
            if (OnInputGameTarget != null)
                OnInputGameTarget();
        }

        public static Action OnInputGameParry;
        public static void InputGameParry()
        {
            if (OnInputGameParry != null)
                OnInputGameParry();
        }

        public static Action OnInputGameKick;
        public static void InputGameKick()
        {
            if (OnInputGameKick != null)
                OnInputGameKick();
        }

    }
}