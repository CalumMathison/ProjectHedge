using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Input
{
    public class InputManager
    {
        public enum MouseButtons { Left, Right, Middle }
        private static InputManager _instance;
        private KeyboardState _currKb, _prevKb;
        private MouseState _currMs, _prevMs;
        private GamePadState _currGp, _prevGp;
        private float _currMouseScroll, _prevMouseScroll;

        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputManager();
                }
                return _instance;
            }
        }

        public InputManager()
        {
            _currKb = Keyboard.GetState();
            _currMs = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                _currGp = GamePad.GetState(PlayerIndex.One);
            }

            _currMouseScroll = 0;
            _prevMouseScroll = 0;
            
        }

        public void Update()
        {
            _prevMouseScroll = _currMouseScroll;
            _prevKb = _currKb;
            _prevMs = _currMs;

            _currKb = Keyboard.GetState();
            _currMs = Mouse.GetState();
            _currMouseScroll = _currMs.ScrollWheelValue;

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                _prevGp = _currGp;
                _currGp = GamePad.GetState(PlayerIndex.One);
            }
        }

        public bool IsMouseDown(MouseButtons b)
        {
            switch (b)
            {
                case MouseButtons.Left:
                    return _currMs.LeftButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return _currMs.RightButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return _currMs.MiddleButton == ButtonState.Pressed;
            }
            return false;
        }

        public bool IsMousePressed(MouseButtons b)
        {
            switch (b)
            {
                case MouseButtons.Left:
                    return _currMs.LeftButton == ButtonState.Released &&
                        _prevMs.LeftButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return _currMs.RightButton == ButtonState.Released &&
                        _prevMs.RightButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return _currMs.MiddleButton == ButtonState.Released &&
                        _prevMs.MiddleButton == ButtonState.Pressed;
            }
            return false;
        }

        //public Vector2 GetMouseScreenPosition()
        //{

        //}

        public bool GetMouseScrollUp()
        {
            return _currMouseScroll > _prevMouseScroll;
        }

        public bool GetMouseScrollDown()
        {
            return _currMouseScroll < _prevMouseScroll;
        }

        public bool IsKeyDown(Keys k)
        {
            return _currKb.IsKeyDown(k);
        }

        public bool IsKeyPressed(Keys k)
        {
            return _currKb.IsKeyUp(k) && _prevKb.IsKeyDown(k);
        }

        public bool IsButtonDown(Buttons b)
        {
            if (_currGp.IsConnected)
            {
                switch (b)
                {
                    case Buttons.DPadUp:
                        return _currGp.DPad.Up == ButtonState.Pressed;
                    case Buttons.DPadDown:
                        return _currGp.DPad.Down == ButtonState.Pressed;
                    case Buttons.DPadLeft:
                        return _currGp.DPad.Left == ButtonState.Pressed;
                    case Buttons.DPadRight:
                        return _currGp.DPad.Right == ButtonState.Pressed;
                    case Buttons.Start:
                        return _currGp.Buttons.Start == ButtonState.Pressed;
                    case Buttons.Back:
                        return _currGp.Buttons.Back == ButtonState.Pressed;
                    case Buttons.LeftShoulder:
                        return _currGp.Buttons.LeftShoulder == ButtonState.Pressed;
                    case Buttons.RightShoulder:
                        return _currGp.Buttons.RightShoulder == ButtonState.Pressed;
                    case Buttons.A:
                        return _currGp.Buttons.A == ButtonState.Pressed;
                    case Buttons.B:
                        return _currGp.Buttons.B == ButtonState.Pressed;
                    case Buttons.X:
                        return _currGp.Buttons.X == ButtonState.Pressed;
                    case Buttons.Y:
                        return _currGp.Buttons.Y == ButtonState.Pressed;
                    case Buttons.RightTrigger:
                        return _currGp.Triggers.Right > 0.2f;
                    case Buttons.LeftTrigger:
                        return _currGp.Triggers.Left > 0.2f;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool IsButtonPressed(Buttons b)
        {
            if (_currGp.IsConnected)
            {
                switch (b)
                {
                    case Buttons.DPadUp:
                        return _currGp.DPad.Up == ButtonState.Released &&
                            _prevGp.DPad.Up == ButtonState.Pressed;
                    case Buttons.DPadDown:
                        return _currGp.DPad.Down == ButtonState.Released &&
                            _prevGp.DPad.Down == ButtonState.Pressed;
                    case Buttons.DPadLeft:
                        return _currGp.DPad.Left == ButtonState.Released &&
                            _prevGp.DPad.Left == ButtonState.Pressed;
                    case Buttons.DPadRight:
                        return _currGp.DPad.Right == ButtonState.Released &&
                            _prevGp.DPad.Right == ButtonState.Pressed;
                    case Buttons.Start:
                        return _currGp.Buttons.Start == ButtonState.Released &&
                            _prevGp.Buttons.Start == ButtonState.Pressed;
                    case Buttons.Back:
                        return _currGp.Buttons.Back == ButtonState.Released &&
                            _prevGp.Buttons.Back == ButtonState.Pressed;
                    case Buttons.LeftShoulder:
                        return _currGp.Buttons.LeftShoulder == ButtonState.Released &&
                            _prevGp.Buttons.LeftShoulder == ButtonState.Pressed;
                    case Buttons.RightShoulder:
                        return _currGp.Buttons.RightShoulder == ButtonState.Released &&
                            _prevGp.Buttons.RightShoulder == ButtonState.Pressed;
                    case Buttons.A:
                        return _currGp.Buttons.A == ButtonState.Released &&
                            _prevGp.Buttons.A == ButtonState.Pressed;
                    case Buttons.B:
                        return _currGp.Buttons.B == ButtonState.Released &&
                            _prevGp.Buttons.B == ButtonState.Pressed;
                    case Buttons.X:
                        return _currGp.Buttons.X == ButtonState.Released &&
                            _prevGp.Buttons.X == ButtonState.Pressed;
                    case Buttons.Y:
                        return _currGp.Buttons.Y == ButtonState.Released &&
                             _prevGp.Buttons.Y == ButtonState.Pressed;
                    case Buttons.RightTrigger:
                        return _currGp.Triggers.Right < 0.2f &&
                            _prevGp.Triggers.Right > 0.2f;
                    case Buttons.LeftTrigger:
                        return _currGp.Triggers.Left < 0.2f &&
                            _prevGp.Triggers.Left > 0.2f;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
