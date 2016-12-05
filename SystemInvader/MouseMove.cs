using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MO.SystemInvader;

namespace SystemInvader
{
    public class MouseMove
    {
        List<TowerShop> _towers;
        List<Tower> _placedTowers;
        Player _player;

        public MouseMove(Player player)
        {
            _towers = new List<TowerShop>(); // position, rate, range, width, height, type, price
            _towers.Add(new TowerShop(new Vector2(220, 550), 10, 200, 70, 120, 1, 20));
            _towers.Add(new TowerShop(new Vector2(320, 550), 8, 280, 70, 120, 2, 10));

            _placedTowers = new List<Tower>();
            _player = player;
        }
 
        internal void Update()
        {
            MouseState stateMouse = Mouse.GetState();
            foreach (TowerShop tower in _towers)
            {
                if (stateMouse.LeftButton == ButtonState.Pressed)
                {
                    if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.WasPressed == false)
                    {
                        if (tower.Old.X < stateMouse.X)
                        {
                            tower.Position = new Vector2(tower.Position.X + (stateMouse.X - tower.Old.X), tower.Position.Y);
                        }
                        else if (tower.Old.X > stateMouse.X)
                        {
                            tower.Position = new Vector2(tower.Position.X - (tower.Old.X - stateMouse.X), tower.Position.Y);
                        }

                        if (tower.Old.Y < stateMouse.Y)
                        {
                            tower.Position = new Vector2(tower.Position.X, tower.Position.Y + (stateMouse.Y - tower.Old.Y));
                        }
                        else if (tower.Old.Y > stateMouse.Y)
                        {
                            tower.Position = new Vector2(tower.Position.X, tower.Position.Y - (tower.Old.Y - stateMouse.Y));
                        }
                    }
                    if (stateMouse.X >= tower.Position.X && stateMouse.X <= tower.Position.X + tower.Width && stateMouse.Y >= tower.Position.Y && stateMouse.Y <= tower.Position.Y + tower.Height)
                    {
                        tower.Old = new Vector2(stateMouse.X, stateMouse.Y);
                    }
                    else
                    {
                        tower.WasPressed = true;
                    }
                }
                else
                {
                    if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.Position != tower.Original)
                    {
                        if (_player.CurrentGold >= tower.Price)
                        {
                            _player.CurrentGold -= tower.Price;
                            _placedTowers.Add(new Tower(tower.Position, tower.Rate, tower.Range, tower.Type));
                        }
                    }
                    tower.Position = tower.Original;
                    tower.Old = new Vector2(-1000, -1000);
                    tower.WasPressed = false;
                }
            }
            
        }

        public List<TowerShop> Towers()
        {
            return _towers;
        }
        public List<Tower> PlacedTowers()
        {
            return _placedTowers;
        }
    }
}
