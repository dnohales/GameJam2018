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
			if (instance.gameInput.Left.WasPressed) { Events.InputLeft(-1); Debug.Log("LEFT Pressed"); }
			if (instance.gameInput.Right.WasPressed) { Events.InputRight(1); Debug.Log("RIGHT Pressed"); }
			if (instance.gameInput.Up.WasPressed) { Events.InputUp(1); Debug.Log("UP Pressed"); }
			if (instance.gameInput.Down.WasPressed) { Events.InputDown(-1); Debug.Log("DOWN Pressed"); }


			if (instance.gameInput.Left.WasReleased) { Events.InputLeft(0); Debug.Log("LEFT Released"); }
			if (instance.gameInput.Right.WasReleased) { Events.InputRight(0); Debug.Log("RIGHT Released"); }
			if (instance.gameInput.Up.WasReleased) { Events.InputUp(0); Debug.Log("UP Released"); }
			if (instance.gameInput.Down.WasReleased) { Events.InputDown(0); Debug.Log("DOWN Released"); }


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
		public static Action <float> OnInputUp;
		public static void InputUp(float value)
        {
            if (OnInputUp != null)
				OnInputUp(value);
        }

        public static Action <float> OnInputDown;
		public static void InputDown(float value)
        {
            if (OnInputDown != null)
				OnInputDown(value);
        }

		public static Action <float> OnInputLeft;
		public static void InputLeft(float value)
        {
            if (OnInputLeft != null)
				OnInputLeft(value);
        }

		public static Action <float> OnInputRight;
		public static void InputRight(float value)
        {
            if (OnInputRight != null)
				OnInputRight(value);
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