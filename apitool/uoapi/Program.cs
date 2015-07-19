using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultima;

namespace uoapi
{
	class Program
	{
		static void Main(string[] args)
		{
			Ultima.Files.SetMulPath(@"C:\Program Files (x86)\Electronic Arts\Ultima Online Classic");

			var mongo = new MongoClient("mongodb://heroku_app123:123@123.mongolab.com:123/heroku_app123");
			var db = mongo.GetServer().GetDatabase("heroku_app123");

			/*
			var collection = db.GetCollection("cliloc_enu");
			var cliloc = new StringList("ENU");
			List<dynamic> l = new List<dynamic>();
			foreach (var entry in cliloc.Entries)
				l.Add(new { _id = entry.Number, text = entry.Text, flag = (int)entry.Flag } );
			collection.InsertBatch(l);*/

			/*var col = db.GetCollection("itemdata");
			var table = TileData.ItemTable;
			var lid = new List<dynamic>();
			for (int id = 0; id < table.Length; id++)
			{
				var iid = table[id];
				if (String.IsNullOrEmpty(iid.Name) && iid.Flags == TileFlag.None && iid.Unk1 == 0 && iid.Weight == 0 && iid.Quality == 0
					&& iid.Quantity == 0 && iid.Value == 0 && iid.Height == 0 && iid.Animation == 0 && iid.Hue == 0 && iid.StackingOffset == 0
					&& iid.MiscData == 0 && iid.Unk2 == 0 && iid.Unk3 == 0)
					continue;

				lid.Add(new
				{
					_id = id,
					name = iid.Name,
					flags = iid.Flags,
					unk1 = iid.Unk1,
					weight = iid.Weight,
					quality = iid.Quality,
					quantity = iid.Quantity,
					value = iid.Value,
					height = iid.Height,
					animation = iid.Animation,
					hue = iid.Hue,
					stackingoffset = iid.StackingOffset,
					miscdata = iid.MiscData,
					unk2 = iid.Unk2,
					unk3 = iid.Unk3,
				});
			}
			col.InsertBatch(lid);*/

			/*var scol = db.GetCollection("itemart");
			int ac = Art.GetMaxItemID();
			var sl = new List<dynamic>();
			for (int ai = 0; ai < ac; ai++)
			{
				if (!Art.IsValidStatic(ai))
					continue;

				var b = Art.GetStatic(ai);
				using (MemoryStream stream = new MemoryStream())
				{
					b.Save(stream, ImageFormat.Png);
					stream.Close();

					sl.Add(new { _id = ai, png = stream.ToArray() });
				}
			}
			scol.InsertBatch(sl);*/

			/*var scol = db.GetCollection("itemdata");
			int ac = Art.GetMaxItemID();
			var sl = new List<dynamic>();
			for (int ai = 0; ai < ac; ai++)
			{
				if (!Art.IsValidStatic(ai))
					continue;

				var b = Art.GetStatic(ai);
				using (MemoryStream stream = new MemoryStream())
				{
					b.Save(stream, ImageFormat.Png);
					stream.Close();
					sl.Add(new { _id = ai, png = stream.ToArray() });
				}
			}
			foreach(dynamic d in sl)
				scol.Update(Query.EQ("_id", d._id), Update.Set("png", d.png), UpdateFlags.Upsert);*/

			/*var scol = db.GetCollection("itemdata");
			int ac = Art.GetMaxItemID();
			var sl = new List<dynamic>();
			for (int ai = 0; ai < ac; ai++)
			{
				if (!Art.IsValidStatic(ai))
					continue;

				var b = Art.GetStatic(ai);
				sl.Add(new { _id = ai, png_width = b.Width, png_height = b.Height });
			}
			foreach (dynamic d in sl)
			{
				scol.Update(Query.EQ("_id", d._id), Update.Set("png_width", d.png_width), UpdateFlags.Upsert);
				scol.Update(Query.EQ("_id", d._id), Update.Set("png_height", d.png_height), UpdateFlags.Upsert);
			}*/

			/*var gcol = db.GetCollection("gumpart");
			int gcount = Gumps.GetCount();
			var sg = new List<dynamic>();
			for(int gi = 0; gi < gcount; gi++)
			{
				if (!Gumps.IsValidIndex(gi))
					continue;

				var b = Gumps.GetGump(gi);
				using (MemoryStream stream = new MemoryStream())
				{
					b.Save(stream, ImageFormat.Png);
					stream.Close();

					sg.Add(new { _id = gi, png = stream.ToArray() });
				}
			}
			gcol.InsertBatch(sg);*/

			/*var hcol = db.GetCollection("hues");
			hcol.Drop();
			var hg = new List<dynamic>();
			foreach(var hue in Hues.List)
			{
				hg.Add(new { _id = hue.Index+1, name = hue.Name, colors = hue.Colors, rgb = hue.Colors.Select(i => Hues.HueToColor(i).ToArgb()).ToArray(), tablestart = hue.TableStart, tableend = hue.TableEnd });
			}
			hcol.InsertBatch(hg);*/

			/*var mulcol = db.GetCollection("multidata");
			mulcol.Drop();
			var mulg = new List<dynamic>();
			for(int muli = 0; muli < 0x2000; muli++)
			{
				var mcl = Multis.GetComponents(muli);

				if (mcl == MultiComponentList.Empty)
					continue;

				var b = mcl.GetImage();
				byte[] png = null;
				using (MemoryStream stream = new MemoryStream())
				{
					b.Save(stream, ImageFormat.Png);
					stream.Close();

					png = stream.ToArray();
				}

				List<dynamic> com = new List<dynamic>();
				foreach (var tile in mcl.SortedTiles)
				{
					com.Add(new {itemid = tile.m_ItemID, x = tile.m_OffsetX, y = tile.m_OffsetY, z = tile.m_OffsetZ, flags = tile.m_Flags, unk1 = tile.m_Unk1});
				}

				mulg.Add(new { _id = muli, width = mcl.Width, height = mcl.Height, maxz = mcl.maxHeight, surface = mcl.Surface, min = new { x = mcl.Min.X, y = mcl.Min.Y }, max = new { x = mcl.Max.X, y = mcl.Max.Y }, center = new { x = mcl.Center.X, y = mcl.Center.Y }, components = com, png = png, png_width = b.Width, png_height = b.Height });
			}
			mulcol.InsertBatch(mulg);*/

			/*var spcol = db.GetCollection("speech");
			spcol.Drop();
			var spl = new List<dynamic>();
			foreach (var se in SpeechList.Entries)
				spl.Add(new { _id = se.Order, number = se.ID, keyword = se.KeyWord });

			spcol.InsertBatch(spl);*/

			/*var tcol = db.GetCollection("textures");
			int tcount = Textures.GetIdxLength();
			var tg = new List<dynamic>();
			for (int ti = 0; ti < tcount; ti++)
			{
				var tex = Textures.GetTexture(ti);

				if (tex == null)
					continue;

				using (MemoryStream stream = new MemoryStream())
				{
					tex.Save(stream, ImageFormat.Png);
					stream.Close();

					tg.Add(new { _id = ti, png = stream.ToArray() });
				}
			}
			tcol.InsertBatch(tg);*/

			/*var skcol = db.GetCollection("skills");
			skcol.Drop();
			var skl = new List<dynamic>();
			foreach (var ske in Skills.SkillEntries)
				skl.Add(new { _id = ske.Index, name = ske.Name, action = ske.IsAction, extra = ske.Extra });

			skcol.InsertBatch(skl);*/

			/*long total = 0;
			int scnt = 0;
			UOSound largest = null;
			for (int si = 0; si < 0xFFF; si++)
			{
				var sound = Sounds.GetSound(si);
				if (sound == null)
					continue;

				//Console.WriteLine(sound.Name);
				scnt++;
				total += sound.buffer.Length;

				if (largest == null || sound.buffer.Length > largest.buffer.Length)
					largest = sound;
			}
			Console.WriteLine("Sounds: {0}, Length: {1}", scnt, total);
			Console.WriteLine("Largest: {0} {1}", largest.Name, largest.buffer.Length);*/

			var lcol = db.GetCollection("landart");
			int lcount = Art.GetIdxLength();
			var sl = new List<dynamic>();
			for(int li = 0; li < lcount; li++)
			{
				if (!Art.IsValidLand(li))
					continue;

				Console.WriteLine(li);
				/*var b = Gumps.GetGump(li);
				using (MemoryStream stream = new MemoryStream())
				{
					b.Save(stream, ImageFormat.Png);
					stream.Close();

					sg.Add(new { _id = gi, png = stream.ToArray() });
				}*/
			}
			//lcol.InsertBatch(sl);

			Console.WriteLine("done");
			Console.ReadLine();
		}
	}
}
