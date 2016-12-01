using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SystemInvader
{
    public class InputTextKeyboard
    {
        string newChar = "";

        Keys[] keysToCheck = new Keys[] {
            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
            Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
            Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
            Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
            Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
            Keys.Z, Keys.Back, Keys.Space };

        KeyboardState _currentKeyboardState;

        public void Write(KeyboardState _lastKeyboardState)
        {
            _currentKeyboardState = Keyboard.GetState();
            newChar = null;
            foreach (Keys key in keysToCheck)
            {
                if (_lastKeyboardState.IsKeyDown(key) == false && _currentKeyboardState.IsKeyDown(key) == true)
                {
                    switch (key)
                    {
                        case Keys.A:
                            newChar = "a";
                            break;
                        case Keys.B:
                            newChar = "b";
                            break;
                        case Keys.C:
                            newChar = "c";
                            break;
                        case Keys.D:
                            newChar = "d";
                            break;
                        case Keys.E:
                            newChar = "e";
                            break;
                        case Keys.F:
                            newChar = "f";
                            break;
                        case Keys.G:
                            newChar = "g";
                            break;
                        case Keys.H:
                            newChar = "h";
                            break;
                        case Keys.I:
                            newChar = "i";
                            break;
                        case Keys.J:
                            newChar = "j";
                            break;
                        case Keys.K:
                            newChar = "k";
                            break;
                        case Keys.L:
                            newChar = "l";
                            break;
                        case Keys.M:
                            newChar = "m";
                            break;
                        case Keys.N:
                            newChar = "n";
                            break;
                        case Keys.O:
                            newChar = "o";
                            break;
                        case Keys.P:
                            newChar = "p";
                            break;
                        case Keys.Q:
                            newChar = "q";
                            break;
                        case Keys.R:
                            newChar = "r";
                            break;
                        case Keys.S:
                            newChar = "s";
                            break;
                        case Keys.T:
                            newChar = "t";
                            break;
                        case Keys.U:
                            newChar = "u";
                            break;
                        case Keys.V:
                            newChar = "v";
                            break;
                        case Keys.W:
                            newChar = "w";
                            break;
                        case Keys.X:
                            newChar = "x";
                            break;
                        case Keys.Y:
                            newChar = "y";
                            break;
                        case Keys.Z:
                            newChar = "z";
                            break;
                        case Keys.Space:
                            newChar = " ";
                            break;
                        case Keys.Back:
                            newChar = "DELETE";
                            break;
                    }
                    if (_currentKeyboardState.IsKeyDown(Keys.RightShift) || _currentKeyboardState.IsKeyDown(Keys.LeftShift))
                    {
                        newChar = newChar.ToUpper();
                    }
                }
            }
        }
        
        public string NewChar
        {
            get { return newChar; }
        }
    }
}
