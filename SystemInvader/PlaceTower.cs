using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MO.SystemInvader;
using Microsoft.Xna.Framework.Content;

namespace SystemInvader
{
    public class PlaceTower
    {
        List<TowerShop> _towers;
        List<Tower> _placedTowers;
        Player _player;

        public PlaceTower(Player player, ContentManager content)
        {
            _towers = new List<TowerShop>(); // position, sprite, rate, range, type, price
            _towers.Add(new TowerShop(new Vector2(150, 550), content.Load<Texture2D>("Sprites/tower"), 10, 200, 1, 20));
            _towers.Add(new TowerShop(new Vector2(230, 550), content.Load<Texture2D>("Sprites/tower"), 8, 280, 2, 10));
            _towers.Add(new TowerShop(new Vector2(310, 590), content.Load<Texture2D>("Sprites/tower2"), 40, 175, 3, 50));
            _towers.Add(new TowerShop(new Vector2(390, 590), content.Load<Texture2D>("Sprites/tower2"), 16, 200, 4, 100));

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
                    if (stateMouse.X >= tower.Position.X && stateMouse.X <= tower.Position.X + tower.Sprite.Width && stateMouse.Y >= tower.Position.Y && stateMouse.Y <= tower.Position.Y + tower.Sprite.Height)
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
                            _placedTowers.Add(new Tower(tower.Position, tower.Sprite, tower.Rate, tower.Range, tower.Type));
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
