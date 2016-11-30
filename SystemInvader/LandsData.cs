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
    public class LandsData
    {
        List<Texture2D> _listLands1 = new List<Texture2D>();
        List<Texture2D> _listLands2 = new List<Texture2D>();
        List<Texture2D> _listLands3 = new List<Texture2D>();

        string _folderPath = "Lands/Land1/";
        public void AddTextureLands1(ContentManager content)
        {
            for (int i = 1; i <= 27; i++)
            {
                string nameImage = "Ground" + i.ToString();
                Texture2D newTexture = content.Load<Texture2D>(_folderPath + nameImage);
                _listLands1.Add(newTexture);
            }
        }

        public List<Texture2D> Lands1
        {
            get { return _listLands1; }
        }

    }
}
