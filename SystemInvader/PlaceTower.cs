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
        Level _level;

        public PlaceTower(Player player, Level level, ContentManager content)
        {
            _towers = new List<TowerShop>(); // position, sprite, rate, range, type, price
            _towers.Add(new TowerShop(new Vector2(150, 590), content.Load<Texture2D>("Sprites/tower2"), 40, 175, 1, 100));
            _towers.Add(new TowerShop(new Vector2(230, 590), content.Load<Texture2D>("Sprites/tower5"), 30, 400, 2, 50));
            _towers.Add(new TowerShop(new Vector2(310, 550), content.Load<Texture2D>("Sprites/tower6"), 10, 200, 3, 50));
            _towers.Add(new TowerShop(new Vector2(390, 550), content.Load<Texture2D>("Sprites/tower4"), 60, 280, 4, 75));
            _towers.Add(new TowerShop(new Vector2(470, 550), content.Load<Texture2D>("Sprites/tower3"), 8, 200, 5, 75));

            _placedTowers = new List<Tower>();
            _player = player;
            _level = level;
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
                    if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.Position != tower.Original && !_level.IsInPaths(tower.Position, tower.Sprite))
                    {
                        bool isOccuped = false;
                        foreach(Tower placedTower in _placedTowers )
                        {
                            float newX1 = tower.Position.X;
                            float newX2 = tower.Position.X + tower.Sprite.Width;
                            float newY1 = tower.Position.Y;
                            float newY2 = tower.Position.Y + tower.Sprite.Height;
                            float towerX1 = placedTower.GetPos().X;
                            float towerX2 = placedTower.GetPos().X + placedTower.Sprite.Width;
                            float towerY1 = placedTower.GetPos().Y;
                            float towerY2 = placedTower.GetPos().Y + placedTower.Sprite.Height;

                            if ((newX1 > towerX1 && newX1 < towerX2) || (newX2 > towerX1 && newX2 < towerX2) || (towerX1 > newX1 && towerX1 < newX2) || (towerX2 > newX1 && towerX2 < newX2))
                            {
                                if ((newY1 > towerY1 && newY1 < towerY2) || (newY2 > towerY1 && newY2 < towerY2) || (towerY1 > newY1 && towerY1 < newY2) || (towerY2 > newY1 && towerY2 < newY2))
                                {
                                    isOccuped = true;
                                }
                            }
                        }
                        if (_player.CurrentGold >= tower.Price && isOccuped == false)
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
