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
using Microsoft.Xna.Framework.Audio;

namespace SystemInvader
{
    public class PlaceTower
    {
        List<TowerShop> _towers;
        List<Tower> _placedTowers;
        List<Tower> _evolutions;
        List<Tower> _2ndEvolutions;
        Player _player;
        Level _level;
        Vector2 _mouse;
        bool _towerSelected;
        TowerShop _selectedTower = null;

        public PlaceTower(Player player, Level level, ContentManager content)
        {
            _towers = new List<TowerShop>(); // position, sprite, rate, range, power, speed, type, price, comment

            _evolutions = new List<Tower>();
            _2ndEvolutions = new List<Tower>();
            _2ndEvolutions.Add(new Tower(new Vector2(780, 755), content.Load<Texture2D>("Sprites/tower2-3"), new List<Tower>(), 14, 350, 20, 16, 500, 8, "Elemental bullets ! This portal can fire\r\nbullets with different effects.", content.Load<SoundEffect>("Sound/Effect/shoot"), _player));
            _evolutions.Add(new Tower(new Vector2(710, 749), content.Load<Texture2D>("Sprites/tower2-2"), _2ndEvolutions, 16, 350, 18, 12, 300, 7, "Bullets from another dimension...\r\nFaster and stronger than the previous\r\nones.", content.Load<SoundEffect>("Sound/Effect/shoot"), _player));
            _towers.Add(new TowerShop(new Vector2(470, 960), content.Load<Texture2D>("Sprites/tower2"), _evolutions, 36, 200, 20, 8, 1, 200, "Multi-shot. Fire bullets all around\r\nthe portal.", content.Load<SoundEffect>("Sound/Effect/shoot")));

            _evolutions = new List<Tower>();
            _2ndEvolutions = new List<Tower>();
            _evolutions.Add(new Tower(new Vector2(710, 770), content.Load<Texture2D>("Sprites/tower5-2"), _2ndEvolutions, 10, 9999, 16, 16, 400, 6, "Fire a literal storm of bullets at the\r\nentire map !", content.Load<SoundEffect>("Sound/Effect/shoot2"), _player));
            _2ndEvolutions = new List<Tower>();
            _evolutions.Add(new Tower(new Vector2(810, 770), content.Load<Texture2D>("Sprites/tower5-3"), _2ndEvolutions, 90, 600, 2000, 36, 450, 9, "A living portal that fire extremely\r\npowerful bullets, but needs to load\r\nthem.", content.Load<SoundEffect>("Sound/Effect/shoot"), _player));
            _towers.Add(new TowerShop(new Vector2(530, 965), content.Load<Texture2D>("Sprites/tower5"), _evolutions, 30, 450, 14, 16, 2, 150, "Teleport bullets right on the foe.", content.Load<SoundEffect>("Sound/Effect/shoot")));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(150, 962), content.Load<Texture2D>("Sprites/tower6"), _evolutions, 8, 250, 16, 24, 3, 50, "Bullets will slow down the foe.", content.Load<SoundEffect>("Sound/Effect/shoot3")));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(230, 962), content.Load<Texture2D>("Sprites/tower4"), _evolutions, 60, 300, 30, 24, 4, 50, "Bullets will freeze the foe,\r\nmaking it unable to move for 2 seconds.", content.Load<SoundEffect>("Sound/Effect/shoot3")));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(310, 962), content.Load<Texture2D>("Sprites/tower3"), _evolutions, 10, 250, 18, 8, 5, 50, "Bullets will poison the foe,\r\nwhich will progressively deal it damage.", content.Load<SoundEffect>("Sound/Effect/shoot3")));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(390, 962), content.Load<Texture2D>("Sprites/tower7"), _evolutions, 8, 250, 22, 10, 10, 50, "Bullets will change the foe\r\ninto gold, making its drop two times\r\nbigger.", content.Load<SoundEffect>("Sound/Effect/shoot3")));

            _placedTowers = new List<Tower>();
            _player = player;
            _level = level;
        }
 
        internal void Update()
        {
            _mouse = new Vector2(Mouse.GetState().X * (float)1.4, Mouse.GetState().Y * (float)1.4);
            _towerSelected = false;
            foreach (TowerShop tower in _towers)
            {
                if (tower.Price <= _player.CurrentGold)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.WasPressed == false)
                        {
                            if (tower.Old.X < _mouse.X)
                            {
                                tower.Position = new Vector2(tower.Position.X + (_mouse.X - tower.Old.X), tower.Position.Y);
                            }
                            else if (tower.Old.X > _mouse.X)
                            {
                                tower.Position = new Vector2(tower.Position.X - (tower.Old.X - _mouse.X), tower.Position.Y);
                            }

                            if (tower.Old.Y < _mouse.Y)
                            {
                                tower.Position = new Vector2(tower.Position.X, tower.Position.Y + (_mouse.Y - tower.Old.Y));
                            }
                            else if (tower.Old.Y > _mouse.Y)
                            {
                                tower.Position = new Vector2(tower.Position.X, tower.Position.Y - (tower.Old.Y - _mouse.Y));
                            }
                        }
                        if (_mouse.X >= tower.Position.X && _mouse.X <= tower.Position.X + tower.Sprite.Width && _mouse.Y >= tower.Position.Y && _mouse.Y <= tower.Position.Y + tower.Sprite.Height)
                        {
                            tower.Old = new Vector2(_mouse.X, _mouse.Y);
                            _towerSelected = true;

                            if (_selectedTower == null)
                            {
                                _selectedTower = tower;
                            }
                        }
                        else
                        {
                            tower.WasPressed = true;
                        }
                    }
                    else
                    {
                        if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.Position != tower.Original && !_level.IsInPaths(tower.Position, tower.Sprite, _player))
                        {
                            bool isOccuped = false;
                            foreach (Tower placedTower in _placedTowers)
                            {
                                if (placedTower.InGame() == true)
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
                            }
                            if (_player.CurrentGold >= tower.Price && isOccuped == false)
                            {
                                _player.CurrentGold -= tower.Price;
                                _placedTowers.Add(new Tower(tower.Position, tower.Sprite, tower.Evolutions, tower.Rate, tower.Range, tower.Power, tower.Speed, tower.Price, tower.Type, tower.Comment, tower.Shoot, _player));
                            }
                        }
                        tower.Position = tower.Original;
                        tower.Old = new Vector2(-1000, -1000);
                        tower.WasPressed = false;
                        _selectedTower = null;
                    }
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
