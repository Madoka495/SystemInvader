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
        bool _towerSelected;
        TowerShop _selectedTower;

        public PlaceTower(Player player, Level level, ContentManager content)
        {
            _towers = new List<TowerShop>(); // position, sprite, rate, range, power, speed type, price, comment
            _towers.Add(new TowerShop(new Vector2(150, 570), content.Load<Texture2D>("Sprites/tower2"), 40, 175, 10, 8, 1, 100, "Multi-shot. Fire bullets all around\r\nthe tower."));
            _towers.Add(new TowerShop(new Vector2(230, 570), content.Load<Texture2D>("Sprites/tower5"), 30, 400, 5, 16, 2, 50, "Teleport bullets right on the foe."));
            _towers.Add(new TowerShop(new Vector2(310, 530), content.Load<Texture2D>("Sprites/tower6"), 8, 250, 12, 24, 3, 50, "Bullets will slow down the foe."));
            _towers.Add(new TowerShop(new Vector2(390, 530), content.Load<Texture2D>("Sprites/tower4"), 60, 300, 24, 24, 4, 75, "Bullets will freeze the foe,\r\nmaking it unable to move for 2 seconds."));
            _towers.Add(new TowerShop(new Vector2(470, 530), content.Load<Texture2D>("Sprites/tower3"), 10, 250, 12, 8, 5, 75, "Bullets will poison the foe,\r\nwhich will progressively deal it damage."));

            _placedTowers = new List<Tower>();
            _player = player;
            _level = level;
        }
 
        internal void Update()
        {
            MouseState stateMouse = Mouse.GetState();
            _towerSelected = false;
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
                        _towerSelected = true;
                        _selectedTower = tower;
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
                            float newX1 = tower.Position.X + 5;
                            float newX2 = tower.Position.X + tower.Sprite.Width - 5;
                            float newY1 = tower.Position.Y + (tower.Sprite.Height / 2);
                            float newY2 = tower.Position.Y + tower.Sprite.Height - 5;
                            float towerX1 = placedTower.GetPos().X + 5;
                            float towerX2 = placedTower.GetPos().X + placedTower.Sprite.Width - 5;
                            float towerY1 = placedTower.GetPos().Y + (placedTower.Sprite.Height / 2);
                            float towerY2 = placedTower.GetPos().Y + placedTower.Sprite.Height - 5;

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
                            _placedTowers.Add(new Tower(tower.Position, tower.Sprite, tower.Rate, tower.Range, tower.Power, tower.Speed, tower.Price, tower.Type, tower.Comment, _player));
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
        public TowerShop SelectedTower()
        {
            return _selectedTower;
        }
        public bool Selected()
        {
            return _towerSelected;
        }
    }
}
