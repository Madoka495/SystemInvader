using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using VirusInvader;

namespace SystemInvader
{
    public class TowersData : Microsoft.Xna.Framework.Game
    {
        List<Tower> _listTowers1 = new List<Tower>();
        List<Tower> _listTowers2 = new List<Tower>();
        List<Tower> _listTowers3 = new List<Tower>();
        List<Tower> _listTowersGreateArrow = new List<Tower>();
        List<Tower> _listTowersPoison = new List<Tower>();
        List<Tower> _listTowersSpecial = new List<Tower>();
        List<Tower> _listTowersLight = new List<Tower>();
        List<Tower> _listTowersExplosive = new List<Tower>();

        List<Texture2D> _listTextureTowers = new List<Texture2D>();

        public List<Texture2D> TowerTexture
        {
            get { return _listTextureTowers; }
        }

        public void AddTextureTowers(ContentManager content)
        {
            List<Texture2D> listTextureTowers = new List<Texture2D>();

            //GreatArrowTower///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture1 = content.Load<Texture2D>("Towers/GreatArrowTower1");
            listTextureTowers.Add(towerTexture1);
            Texture2D towerTexture2 = content.Load<Texture2D>("Towers/GreatArrowTower2");
            listTextureTowers.Add(towerTexture2);
            Texture2D towerTexture3 = content.Load<Texture2D>("Towers/GreatArrowTower3");
            listTextureTowers.Add(towerTexture3);
            Texture2D towerTexture4 = content.Load<Texture2D>("Towers/GreatArrowTower4");
            listTextureTowers.Add(towerTexture4);

            //PoisonTower///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture5 = content.Load<Texture2D>("Towers/PoisonTower1");
            listTextureTowers.Add(towerTexture5);
            Texture2D towerTexture6 = content.Load<Texture2D>("Towers/PoisonTower2");
            listTextureTowers.Add(towerTexture6);
            Texture2D towerTexture7 = content.Load<Texture2D>("Towers/PoisonTower3");
            listTextureTowers.Add(towerTexture7);
            Texture2D towerTexture8 = content.Load<Texture2D>("Towers/PoisonTower4");
            listTextureTowers.Add(towerTexture8);

            //Tower1///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture9 = content.Load<Texture2D>("Towers/Tower1Upgrade0");
            listTextureTowers.Add(towerTexture5);
            Texture2D towerTexture10 = content.Load<Texture2D>("Towers/Tower1Upgrade1");
            listTextureTowers.Add(towerTexture10);
            Texture2D towerTexture11 = content.Load<Texture2D>("Towers/Tower1Upgrade2");
            listTextureTowers.Add(towerTexture11);
            Texture2D towerTexture12 = content.Load<Texture2D>("Towers/Tower1Upgrade3");
            listTextureTowers.Add(towerTexture12);

            //Tower2///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture13 = content.Load<Texture2D>("Towers/Tower2Upgrade0");
            listTextureTowers.Add(towerTexture13);
            Texture2D towerTexture14 = content.Load<Texture2D>("Towers/Tower2Upgrade1");
            listTextureTowers.Add(towerTexture14);
            Texture2D towerTexture15 = content.Load<Texture2D>("Towers/Tower2Upgrade2");
            listTextureTowers.Add(towerTexture15);
            Texture2D towerTexture16 = content.Load<Texture2D>("Towers/Tower2Upgrade3");
            listTextureTowers.Add(towerTexture16);

            //Tower3///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture17 = content.Load<Texture2D>("Towers/Tower3Upgrade0");
            listTextureTowers.Add(towerTexture17);
            Texture2D towerTexture18 = content.Load<Texture2D>("Towers/Tower3Upgrade1");
            listTextureTowers.Add(towerTexture18);
            Texture2D towerTexture19 = content.Load<Texture2D>("Towers/Tower3Upgrade2");
            listTextureTowers.Add(towerTexture19);
            Texture2D towerTexture20 = content.Load<Texture2D>("Towers/Tower3Upgrade3");
            listTextureTowers.Add(towerTexture20);

            //TowerExplosive///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture21 = content.Load<Texture2D>("Towers/TowerExplosive1");
            listTextureTowers.Add(towerTexture21);
            Texture2D towerTexture22 = content.Load<Texture2D>("Towers/TowerExplosive2");
            listTextureTowers.Add(towerTexture22);
            Texture2D towerTexture23 = content.Load<Texture2D>("Towers/TowerExplosive3");
            listTextureTowers.Add(towerTexture23);
            Texture2D towerTexture24 = content.Load<Texture2D>("Towers/TowerExplosive4");
            listTextureTowers.Add(towerTexture24);

            //TowerLight///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture25 = content.Load<Texture2D>("Towers/TowerLight1");
            listTextureTowers.Add(towerTexture25);
            Texture2D towerTexture26 = content.Load<Texture2D>("Towers/TowerLight2");
            listTextureTowers.Add(towerTexture26);
            Texture2D towerTexture27 = content.Load<Texture2D>("Towers/TowerLight3");
            listTextureTowers.Add(towerTexture27);
            Texture2D towerTexture28 = content.Load<Texture2D>("Towers/TowerLight4");
            listTextureTowers.Add(towerTexture28);

            //TowerSpecial///////////////////////////////////////////////////////////////////////
            Texture2D towerTexture29 = content.Load<Texture2D>("Towers/TowerSpecial1");
            listTextureTowers.Add(towerTexture29);
            Texture2D towerTexture30 = content.Load<Texture2D>("Towers/TowerSpecial2");
            listTextureTowers.Add(towerTexture30);
            Texture2D towerTexture31 = content.Load<Texture2D>("Towers/TowerSpecial3");
            listTextureTowers.Add(towerTexture31);
            Texture2D towerTexture32 = content.Load<Texture2D>("Towers/TowerSpecial4");
            listTextureTowers.Add(towerTexture32);

            /////////////////////////////////////////////////////////////////////////
            _listTextureTowers = listTextureTowers;
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
            Tower tower0 = new Tower(TowerTexture[0], Vector2.Zero, 5, 5, 1, 32, 60);
            TowerGreatArrow.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[1], Vector2.Zero, 5, 5, 1, 32, 65);
            TowerGreatArrow.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[2], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerGreatArrow.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[3], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerGreatArrow.Add(tower3);
        }
        public void AddTowerPoison()
        {
            Tower tower0 = new Tower(TowerTexture[4], Vector2.Zero, 5, 5, 1, 32, 60);
            TowerPoison.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[5], Vector2.Zero, 5, 5, 1, 32, 65);
            TowerPoison.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[6], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerPoison.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[7], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerPoison.Add(tower3);
        }
        public void AddTower1()
        {
            Tower tower0 = new Tower(TowerTexture[8], Vector2.Zero, 5, 5, 1, 32, 60);
            Tower1.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[9], Vector2.Zero, 5, 5, 1, 32, 65);
            Tower1.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[10], Vector2.Zero, 5, 5, 1, 32, 68);
            Tower1.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[11], Vector2.Zero, 5, 5, 1, 32, 68);
            Tower1.Add(tower3);
        }
        public void AddTower2()
        {
            Tower tower0 = new Tower(TowerTexture[12], Vector2.Zero, 5, 5, 1, 32, 60);
            Tower2.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[13], Vector2.Zero, 5, 5, 1, 32, 65);
            Tower2.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[14], Vector2.Zero, 5, 5, 1, 32, 68);
            Tower2.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[15], Vector2.Zero, 5, 5, 1, 32, 68);
            Tower2.Add(tower3);
        }
        public void AddTower3()
        {
            Tower tower0 = new Tower(TowerTexture[16], Vector2.Zero, 5, 5, 1, 32, 60);
            Tower3.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[17], Vector2.Zero, 5, 5, 1, 32, 65);
            Tower3.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[18], Vector2.Zero, 5, 5, 1, 32, 68);
            Tower3.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[19], Vector2.Zero, 5, 5, 1, 32, 68);
            Tower3.Add(tower3);
        }
        public void AddTowerExplosive()
        {
            Tower tower0 = new Tower(TowerTexture[20], Vector2.Zero, 5, 5, 1, 32, 60);
            TowerExplosive.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[21], Vector2.Zero, 5, 5, 1, 32, 60);
            TowerExplosive.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[22], Vector2.Zero, 5, 5, 1, 32, 62);
            TowerExplosive.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[23], Vector2.Zero, 5, 5, 1, 32, 62);
            TowerExplosive.Add(tower3);
        }
        public void AddTowerLight()
        {
            Tower tower0 = new Tower(TowerTexture[24], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerLight.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[25], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerLight.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[26], Vector2.Zero, 5, 5, 1, 32, 60);
            TowerLight.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[27], Vector2.Zero, 5, 5, 1, 32, 60);
            TowerLight.Add(tower3);
        }
        public void AddTowerSpecial()
        {
            Tower tower0 = new Tower(TowerTexture[28], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerSpecial.Add(tower0);
            Tower tower1 = new Tower(TowerTexture[29], Vector2.Zero, 5, 5, 1, 32, 63);
            TowerSpecial.Add(tower1);
            Tower tower2 = new Tower(TowerTexture[30], Vector2.Zero, 5, 5, 1, 32, 65);
            TowerSpecial.Add(tower2);
            Tower tower3 = new Tower(TowerTexture[31], Vector2.Zero, 5, 5, 1, 32, 65);
            TowerSpecial.Add(tower3);
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
