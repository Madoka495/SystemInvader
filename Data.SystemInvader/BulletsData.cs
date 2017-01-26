using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MO.SystemInvader;

namespace Data.SystemInvader
{
    public class BulletsData
    {
        //Parametres/////////////////////////////////////////////////////////////////////////////////////////////////
        List<Projectile> _normalArrow = new List<Projectile>();
        List<Projectile> _bombe = new List<Projectile>();
        List<Projectile> _bullet = new List<Projectile>();
        List<Projectile> _fireBullet = new List<Projectile>();
        List<Projectile> _greatArrow = new List<Projectile>();

        List<Texture2D> _listTextureBullet = new List<Texture2D>();


        //Functions/////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Texture2D> BulletTextures
        {
            get { return _listTextureBullet; }
        }

        public void AddTextureBullets(ContentManager content)
        {
            //Arrow/////////////////////////////////////////////////////////////////////////////////
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Arrow1"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Arrow2"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Arrow3"));
            //Bombe/////////////////////////////////////////////////////////////////////////////////
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Bombe1"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Bombe2"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Bombe3"));
            //Bullets///////////////////////////////////////////////////////////////////////////////
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Bullet1"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Bullet2"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/Bullet3"));
            //Firebullet////////////////////////////////////////////////////////////////////////////
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/FireBullet1"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/FireBullet2"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/FireBullet3"));
            //GreatArrow////////////////////////////////////////////////////////////////////////////
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/GreatArrow1"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/GreatArrow2"));
            _listTextureBullet.Add(content.Load<Texture2D>("Sprites/Bullets/GreatArrow3"));
        }

        public void AddAllBullets()
        {
            AddtNormalArrow();
            AddBombes();
            AddBullet1();
            AddFireBullet();
            AddGreatArrow();
        }

        public void AddtNormalArrow()
        {
            _normalArrow.Add(new Projectile(BulletTextures[0], Vector2.Zero, Vector2.Zero, 5f, 5, 10, 40));
            _normalArrow.Add(new Projectile(BulletTextures[1], Vector2.Zero, Vector2.Zero, 6f, 6, 10, 40));
            _normalArrow.Add(new Projectile(BulletTextures[2], Vector2.Zero, Vector2.Zero, 7f, 7, 10, 40));
        }
        public void AddBombes()
        {
            _bombe.Add(new Projectile(BulletTextures[3], Vector2.Zero, Vector2.Zero, 2f, 10, 20, 20));
            _bombe.Add(new Projectile(BulletTextures[4], Vector2.Zero, Vector2.Zero, 3f, 15, 20, 20));
            _bombe.Add(new Projectile(BulletTextures[5], Vector2.Zero, Vector2.Zero, 4f, 20, 20, 20));
        }
        public void AddBullet1()
        {
            _bullet.Add(new Projectile(BulletTextures[6], Vector2.Zero, Vector2.Zero, 5f, 5, 10, 20));
            _bullet.Add(new Projectile(BulletTextures[7], Vector2.Zero, Vector2.Zero, 6f, 10, 10, 20));
            _bullet.Add(new Projectile(BulletTextures[8], Vector2.Zero, Vector2.Zero, 7f, 20, 10, 20));
        }
        public void AddFireBullet()
        {
            _fireBullet.Add(new Projectile(BulletTextures[9], Vector2.Zero, Vector2.Zero, 5f, 5, 10, 20));
            _fireBullet.Add(new Projectile(BulletTextures[10], Vector2.Zero, Vector2.Zero, 6f, 6, 10, 20));
            _fireBullet.Add(new Projectile(BulletTextures[11], Vector2.Zero, Vector2.Zero, 7f, 7, 10, 20));
        }
        public void AddGreatArrow()
        {
            _greatArrow.Add(new Projectile(BulletTextures[12], Vector2.Zero, Vector2.Zero, 5f, 5, 12, 45));
            _greatArrow.Add(new Projectile(BulletTextures[13], Vector2.Zero, Vector2.Zero, 6f, 6, 12, 45));
            _greatArrow.Add(new Projectile(BulletTextures[14], Vector2.Zero, Vector2.Zero, 7f, 7, 12, 45));
        }


        public List<Projectile> NormalArrow
        {
            get { return _normalArrow; }
        }
        public List<Projectile> Bombe
        {
            get { return _bombe; }
        }
        public List<Projectile> Bullet
        {
            get { return _bullet; }
        }
        public List<Projectile> FireBullet
        {
            get { return _fireBullet; }
        }
        public List<Projectile> GreatArrow
        {
            get { return _greatArrow; }
        }

    }
}
