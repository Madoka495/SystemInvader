using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.SystemInvader
{
    public class TowersData : Microsoft.Xna.Framework.Game
    {
        //Parametres/////////////////////////////////////////////////////////////////////////////////////////////////
        List<Tower> _listTowers1 = new List<Tower>();
        List<Tower> _listTowers2 = new List<Tower>();
        List<Tower> _listTowers3 = new List<Tower>();
        List<Tower> _listTowersGreateArrow = new List<Tower>();
        List<Tower> _listTowersPoison = new List<Tower>();
        List<Tower> _listTowersSpecial = new List<Tower>();
        List<Tower> _listTowersLight = new List<Tower>();
        List<Tower> _listTowersExplosive = new List<Tower>();

        List<Texture2D> _listTextureTowers = new List<Texture2D>();
        BulletsData _bulletsData;
        //Functions/////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Texture2D> TowerTexture
        {
            get { return _listTextureTowers; }
        }

        public void AddTextureTowers(ContentManager content, BulletsData bulletsData)
        {
            _bulletsData = bulletsData;
            //GreatArrowTower///////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/GreatArrowTower1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/GreatArrowTower2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/GreatArrowTower3"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/GreatArrowTower4"));

            //PoisonTower/////////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/PoisonTower1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/PoisonTower2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/PoisonTower3"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/PoisonTower4"));

            //Tower1//////////////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower1Upgrade0"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower1Upgrade1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower1Upgrade2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower1Upgrade3"));

            //Tower2//////////////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower2Upgrade0"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower2Upgrade1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower2Upgrade2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower2Upgrade3"));

            //Tower3//////////////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower3Upgrade0"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower3Upgrade1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower3Upgrade2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/Tower3Upgrade3"));

            //TowerExplosive//////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerExplosive1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerExplosive2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerExplosive3"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerExplosive4"));

            //TowerLight//////////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerLight1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerLight2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerLight3"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerLight4"));

            //TowerSpecial////////////////////////////////////////////////////////////////////////////
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerSpecial1"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerSpecial2"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerSpecial3"));
            _listTextureTowers.Add(content.Load<Texture2D>("Sprites/Towers/TowerSpecial4"));
        }


        public void AddAllTowers()
        {
            AddTowerGreatArrow();
            AddTowerPoison();
            AddTower1();
            AddTower2();
            AddTower3();
            AddTowerExplosive();
            AddTowerLight();
            AddTowerSpecial();
        }

        public void AddTowerGreatArrow()
        {
            TowerGreatArrow.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[0], Vector2.Zero, 10, 5, 1, 10, 64, 90, 0, TowerGreatArrow, 10));
            TowerGreatArrow.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[1], Vector2.Zero, 5, 5, 1, 12, 64, 90, 1, TowerGreatArrow, 10));
            TowerGreatArrow.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[2], Vector2.Zero, 5, 5, 1, 15, 64, 98, 2, TowerGreatArrow, 10));
            TowerGreatArrow.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[3], Vector2.Zero, 5, 5, 1, 20, 64, 98, 3, TowerGreatArrow, 10));
        }
        public void AddTowerPoison()
        {
            TowerPoison.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[4], Vector2.Zero, 5, 5, 1, 10, 64, 80, 0, TowerPoison, 10));
            TowerPoison.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[5], Vector2.Zero, 5, 5, 1, 10, 64, 85, 1, TowerPoison, 10));
            TowerPoison.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[6], Vector2.Zero, 5, 5, 1, 10, 64, 83, 2, TowerPoison, 10));
            TowerPoison.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[7], Vector2.Zero, 5, 5, 1, 10, 64, 83, 3, TowerPoison, 10));
        }
        public void AddTower1()
        {
            Tower1.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[8], Vector2.Zero, 5, 5, 1, 10, 64, 80, 0, Tower1, 10));
            Tower1.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[9], Vector2.Zero, 5, 5, 1, 10, 64, 85, 1, Tower1, 10));
            Tower1.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[10], Vector2.Zero, 5, 5, 1, 10, 64, 88, 2, Tower1, 10));
            Tower1.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[11], Vector2.Zero, 5, 5, 1, 10, 64, 88, 3, Tower1, 10));
        }
        public void AddTower2()
        {
            Tower2.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[12], Vector2.Zero, 5, 5, 1, 10, 64, 80, 0, Tower2, 10));
            Tower2.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[13], Vector2.Zero, 5, 5, 1, 10, 64, 80, 1, Tower2, 10));
            Tower2.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[14], Vector2.Zero, 5, 5, 1, 10, 64, 80, 2, Tower2, 10));
            Tower2.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[15], Vector2.Zero, 5, 5, 1, 10, 64, 80, 3, Tower2, 10));
        }
        public void AddTower3()
        {
            Tower3.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[16], Vector2.Zero, 5, 100, 1, 10, 64, 80, 0, Tower3, 10));
            Tower3.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[17], Vector2.Zero, 5, 5, 1, 10, 64, 85, 1, Tower3, 10));
            Tower3.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[18], Vector2.Zero, 5, 5, 1, 10, 64, 88, 2, Tower3, 10));
            Tower3.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[19], Vector2.Zero, 5, 5, 1, 10, 64, 88, 3, Tower3, 10));
        }
        public void AddTowerExplosive()
        {
            TowerExplosive.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[20], Vector2.Zero, 5, 100, 1, 10, 64, 80, 0, TowerExplosive, 10));
            TowerExplosive.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[21], Vector2.Zero, 5, 5, 1, 10, 64, 80, 1, TowerExplosive, 10));
            TowerExplosive.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[22], Vector2.Zero, 5, 5, 1, 10, 64, 82, 2, TowerExplosive, 10));
            TowerExplosive.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[23], Vector2.Zero, 5, 5, 1, 10, 64, 82, 3, TowerExplosive, 10));
        }
        public void AddTowerLight()
        {
            TowerLight.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[24], Vector2.Zero, 5, 100, 1, 10, 64, 83, 0, TowerLight, 10));
            TowerLight.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[25], Vector2.Zero, 5, 5, 1, 10, 64, 83, 1, TowerLight, 10));
            TowerLight.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[26], Vector2.Zero, 5, 5, 1, 10, 64, 80, 2, TowerLight, 10));
            TowerLight.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[27], Vector2.Zero, 5, 5, 1, 10, 64, 80, 3, TowerLight, 10));
        }
        public void AddTowerSpecial()
        {
            TowerSpecial.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[28], Vector2.Zero, 5, 100, 1, 10, 64, 83, 0, TowerSpecial, 10));
            TowerSpecial.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[29], Vector2.Zero, 5, 5, 1, 10, 64, 83, 1, TowerSpecial, 10));
            TowerSpecial.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[30], Vector2.Zero, 5, 5, 1, 10, 64, 85, 2, TowerSpecial, 10));
            TowerSpecial.Add(new Tower(_bulletsData.GreatArrow[1].GiveTexture, TowerTexture[31], Vector2.Zero, 5, 5, 1, 10, 64, 85, 3, TowerSpecial, 10));
        }

        public List<Tower> Tower1
        {
            get { return _listTowers1; }
        }
        public List<Tower> Tower2
        {
            get { return _listTowers2; }
        }
        public List<Tower> Tower3
        {
            get { return _listTowers3; }
        }
        public List<Tower> TowerGreatArrow
        {
            get { return _listTowersGreateArrow; }
        }
        public List<Tower> TowerExplosive
        {
            get { return _listTowersExplosive; }
        }
        public List<Tower> TowerSpecial
        {
            get { return _listTowersSpecial; }
        }
        public List<Tower> TowerLight
        {
            get { return _listTowersLight; }
        }
        public List<Tower> TowerPoison
        {
            get { return _listTowersPoison; }
        }
    }
}
