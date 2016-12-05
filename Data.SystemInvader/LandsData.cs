using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Data.SystemInvader
{
    public class LandsData
    {
        List<Texture2D> _listLands = new List<Texture2D>();

        string _folderPath = "Sprites/";
        public void AddTextureLands1(ContentManager content)
        {
            for (int i = 1; i <= 27; i++)
            {
                string nameImage = "Ground" + i.ToString();
                Texture2D newTexture = content.Load<Texture2D>(_folderPath + nameImage);
                _listLands.Add(newTexture);
            }
        }

        public List<Texture2D> Lands
        {
            get { return _listLands; }
        }
    }
}
