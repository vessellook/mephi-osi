// Decompiled with JetBrains decompiler
// Type: v
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using Ionic.Zip;
using Ionic.Zlib;
using Microsoft.Win32;
using NetLab.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

#nullable disable
public class v : Form
{
  public static System.Drawing.Color b;
  public static bool c;
  public static string d;
  public static Font e;
  public static bool f;
  public static string g;
  public static string h;
  public static int i;
  public static int j;
  public static int k;
  public static int l;
  public static bool m;
  public static bool n;
  public static bool o;
  private global::s p;
  public static global::t q;
  public static string r;
  public static global::u s;
  public static bool t;
  private global::at u;
  public global::i v;
  public static string w;
  public static byte x;
  public static int y;
  public static int z;
  public static int aa;
  public static ArrayList ab;
  public static ArrayList ac;
  public static ArrayList ad;
  public static ArrayList ae;
  public static string af;
  public static int ag;
  public static bool ah;
  public static string ai;
  public static bool aj;
  public static bool ak;
  public static string al;
  private IContainer am;
  private Panel an;
  private MenuStrip ao;
  private ToolStripMenuItem ap;
  private Panel aq;
  private Label ar;
  private Panel @as;
  private Panel at;
  private Button au;
  private Button av;
  private Button aw;
  private Button ax;
  private Button ay;
  private Button az;
  private Panel a0;
  private Panel a1;
  private Button a2;
  private Button a3;
  private Button a4;
  private Button a5;
  private Panel a6;
  private Button a7;
  private Button a8;
  private Label a9;
  private Panel ba;
  private Panel bb;
  private Button bc;
  private Button bd;
  private Button be;
  private Button bf;
  private Label bg;
  private Panel bh;
  private Button bi;
  private Button bj;
  private Button bk;
  private TextBox bl;
  private Button bm;
  private Button bn;
  private Button bo;
  private ToolStripMenuItem bp;
  private ToolStripSeparator bq;
  private ToolStripMenuItem br;
  private ToolStripMenuItem bs;
  private ToolStripMenuItem bt;
  private ToolStripMenuItem bu;
  private Panel bv;
  private Label bw;
  private ToolStripMenuItem bx;
  private ToolStripMenuItem by;
  private ToolStripMenuItem bz;
  private ToolStripSeparator b0;
  private ToolStripMenuItem b1;
  private ToolStripMenuItem b2;
  private ToolStripMenuItem b3;
  private ToolStripMenuItem b4;
  private SaveFileDialog b5;
  private ToolStripSeparator b6;
  private ToolStripMenuItem b7;
  private OpenFileDialog b8;
  private ToolStripMenuItem b9;
  private ToolStripSeparator ca;
  private ToolStripMenuItem cb;
  private ToolStripMenuItem cc;
  private ToolStripMenuItem cd;
  private ToolStripMenuItem ce;
  private ToolStripMenuItem cf;
  private ToolStripMenuItem cg;
  private ToolStripMenuItem ch;
  private ToolStripMenuItem ci;
  private ToolStripMenuItem cj;
  private ToolStripMenuItem ck;
  private ToolStripMenuItem cl;
  private ToolStripMenuItem cm;
  private ToolStripMenuItem cn;
  private ToolStripMenuItem co;
  private ToolStripMenuItem cp;
  private ToolStripMenuItem cq;
  private ToolStripMenuItem cr;
  private ToolStripMenuItem cs;
  private ToolStripMenuItem ct;
  public Button cu;
  private ToolStripMenuItem cv;
  private ToolStripMenuItem cw;
  private ToolStripMenuItem cx;
  private ToolStripMenuItem cy;
  private ToolStripMenuItem cz;
  private ToolStripMenuItem c0;
  public ToolStripMenuItem c1;
  public ToolStripMenuItem c2;
  public ToolStripMenuItem c3;
  public ToolStripMenuItem c4;
  public ToolStripMenuItem c5;
  public ToolStripMenuItem c6;
  public ToolStripMenuItem c7;
  private ToolStripMenuItem c8;
  private ToolStripMenuItem c9;
  private ToolStripSeparator da;
  private ToolStripMenuItem db;
  private ToolStripMenuItem dc;
  private ToolStripMenuItem dd;
  private ToolStripMenuItem de;
  private ToolStripMenuItem df;
  private ToolStripMenuItem dg;
  private ToolStripMenuItem dh;
  private ToolStripSeparator di;
  private ToolStripMenuItem dj;
  private ToolStripMenuItem dk;
  public ToolStripMenuItem dl;
  public ToolStripMenuItem dm;
  public ToolStripMenuItem dn;
  public ToolStripMenuItem dp;
  public ToolStripMenuItem dq;
  public ToolStripMenuItem dr;
  public ToolStripMenuItem ds;
  private Panel dt;

  [CompilerGenerated]
  [SpecialName]
  public global::an c() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void a(global::an A_0) => this.a = A_0;

  public void c(string A_0) => this.bl.AppendText(A_0 + Environment.NewLine);

  static v() => AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(global::v.a);

  private static Assembly a(object A_0, ResolveEventArgs A_1) => Assembly.Load(Resources.Ionic_Zip);

  public v()
  {
    this.a();
    Application.CurrentCulture = new CultureInfo("ru-RU", false);
    global::v.af = Encoding.Unicode.GetString(Resources.vibration1.GetPropertyItem(40093).Value, 0, 22) + "nv";
    this.a(new global::an(this));
    global::v.g = "Untitled.lab";
    this.p = new global::s(this.c());
    this.u = new global::at(this);
    this.v = new global::i(this.c());
    global::v.q.a = "None";
    global::v.q.c = 0;
    global::v.q.b = "None";
    global::v.f = false;
    global::v.t = false;
    global::v.s.f = true;
    global::v.r = Application.StartupPath + "\\help\\0.chm";
    global::v.w = "netlab@somewhere.ru";
    global::v.x = (byte) 0;
    global::v.z = 0;
    global::v.y = 0;
    global::v.ab = new ArrayList();
    global::v.ac = new ArrayList();
    global::v.ad = new ArrayList();
    global::v.ae = new ArrayList();
    global::v.ae.Add((object) "transmit");
    global::v.ae.Add((object) "getaddress");
    global::v.ak = false;
    global::d.a = new SortedList();
    try
    {
      using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\EventsParams.txt"))
      {
        string str1;
        while ((str1 = streamReader.ReadLine()) != null)
        {
          string key = str1.Substring(0, str1.IndexOf(";"));
          string str2 = str1.Substring(str1.IndexOf(";"));
          global::d.a.Add((object) key, (object) str2);
        }
        streamReader.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadComments, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\МИФИ\\Netlab1.5"))
    {
      if (registryKey == null)
      {
        global::v.h = "log.txt";
        global::v.m = true;
        global::v.n = false;
        global::v.i = 100;
        global::v.j = 100;
        global::v.k = 600;
        global::v.l = 800;
        global::v.o = false;
        global::v.e = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
        global::v.b = System.Drawing.Color.White;
        global::v.ag = 50;
        global::v.ah = false;
        global::v.ai = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\auto.lab";
        global::v.aj = false;
        global::v.al = "res1";
        global::v.c = false;
        global::v.d = "1000";
      }
      else
      {
        global::v.h = (string) registryKey.GetValue("LogFileName", (object) "log.txt");
        global::v.d = (string) registryKey.GetValue("version", (object) "1000");
        global::v.m = Convert.ToBoolean(registryKey.GetValue("DisplayLog", (object) true));
        global::v.c = Convert.ToBoolean(registryKey.GetValue("AutoUpdate", (object) false));
        global::v.n = Convert.ToBoolean(registryKey.GetValue("UseDelay", (object) false));
        global::v.i = (int) registryKey.GetValue("EditorLeft", (object) 100);
        global::v.j = (int) registryKey.GetValue("EditorTop", (object) 100);
        global::v.k = (int) registryKey.GetValue("EditorHeight", (object) 600);
        global::v.l = (int) registryKey.GetValue("EditorWidth", (object) 800);
        global::v.o = Convert.ToBoolean(registryKey.GetValue("EditorCommonPlace", (object) false));
        string familyName = (string) registryKey.GetValue("FontName", (object) "Microsoft Sans Serif");
        bool boolean = Convert.ToBoolean(registryKey.GetValue("FontItalic", (object) false));
        double single = (double) Convert.ToSingle(registryKey.GetValue("FontSize", (object) 10));
        int style = boolean ? 2 : 0;
        global::v.e = new Font(familyName, (float) single, (FontStyle) style);
        global::v.b = System.Drawing.Color.FromArgb(Convert.ToInt32(registryKey.GetValue("BGcolor", (object) -1)));
        global::v.ag = (int) registryKey.GetValue("DebugDelay", (object) 50);
        global::v.ah = Convert.ToBoolean(registryKey.GetValue("autosave", (object) false));
        global::v.ai = (string) registryKey.GetValue("AutoSaveFile", (object) (Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\auto.lab"));
        global::v.aj = Convert.ToBoolean(registryKey.GetValue("AskOnOpen", (object) false));
        global::v.al = (string) registryKey.GetValue("BG", (object) "res1");
        switch (global::v.al)
        {
          case "res1":
            this.dt.BackgroundImage = (Image) Resources.dante;
            break;
          case "res2":
            this.dt.BackgroundImage = (Image) Resources.Rainbow1;
            break;
          default:
            if (System.IO.File.Exists(global::v.al))
            {
              this.dt.BackgroundImage = Image.FromFile(global::v.al);
              break;
            }
            this.dt.BackgroundImage = (Image) Resources.dante;
            break;
        }
        registryKey.Close();
      }
    }
  }

  private void a6(object A_0, EventArgs A_1) => this.Close();

  private void a5(object A_0, EventArgs A_1) => this.Close();

  private void a(object A_0, FormClosingEventArgs A_1)
  {
    if (global::v.ak)
    {
      switch (MessageBox.Show(Resources.SaveChangesQ.Replace("%s", global::v.g), "NetLab", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Cancel:
          A_1.Cancel = true;
          break;
        case DialogResult.Yes:
          this.bt.PerformClick();
          break;
      }
    }
    using (RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\МИФИ\\Netlab1.5"))
    {
      subKey.SetValue("LogFileName", (object) global::v.h);
      subKey.SetValue("DisplayLog", (object) global::v.m);
      subKey.SetValue("EditorLeft", (object) global::v.i);
      subKey.SetValue("EditorTop", (object) global::v.j);
      subKey.SetValue("EditorHeight", (object) global::v.k);
      subKey.SetValue("EditorWidth", (object) global::v.l);
      subKey.SetValue("UseDelay", (object) global::v.n);
      subKey.SetValue("EditorCommonPlace", (object) global::v.o);
      subKey.SetValue("BGcolor", (object) global::v.b.ToArgb());
      subKey.SetValue("FontName", (object) global::v.e.Name);
      subKey.SetValue("FontSize", (object) global::v.e.SizeInPoints);
      subKey.SetValue("FontItalic", (object) global::v.e.Italic);
      subKey.SetValue("DebugDelay", (object) global::v.ag);
      subKey.SetValue("autosave", (object) global::v.ah);
      subKey.SetValue("AutoSaveFile", (object) global::v.ai);
      subKey.SetValue("AskOnOpen", (object) global::v.aj);
      subKey.SetValue("AutoUpdate", (object) global::v.c);
      subKey.SetValue("BG", (object) global::v.al);
      subKey.Close();
    }
  }

  private void a4(object A_0, EventArgs A_1)
  {
    if (this.p.Visible)
    {
      this.p.BringToFront();
    }
    else
    {
      switch ((A_0 as Button).Name.Substring(2, 4))
      {
        case "SysA":
          this.p.a(this.c().d());
          string str1 = (A_0 as Button).Name.Substring(0, 2);
          if (str1 != null && str1.Length == 2)
          {
            switch (str1[0])
            {
              case 'A':
                switch (str1)
                {
                  case "AL":
                    this.p.a(this.c().d().i());
                    goto label_52;
                  case "AP":
                    this.p.a(this.c().d().k());
                    goto label_52;
                }
                break;
              case 'N':
                if (str1 == "NL")
                {
                  this.p.a(this.c().d().e());
                  goto label_52;
                }
                else
                  break;
              case 'P':
                if (str1 == "PL")
                {
                  this.p.a(this.c().d().h());
                  goto label_52;
                }
                else
                  break;
              case 'S':
                if (str1 == "SL")
                {
                  this.p.a(this.c().d().g());
                  goto label_52;
                }
                else
                  break;
              case 'T':
                if (str1 == "TL")
                {
                  this.p.a(this.c().d().f());
                  goto label_52;
                }
                else
                  break;
              case 'U':
                if (str1 == "UE")
                {
                  this.p.a(this.c().d().j());
                  goto label_52;
                }
                else
                  break;
            }
          }
          throw new InvalidOperationException("Unknown button");
        case "Guid":
          this.p.a(this.c().c());
          string str2 = (A_0 as Button).Name.Substring(0, 2);
          if (str2 != null && str2.Length == 2)
          {
            switch (str2[0])
            {
              case 'A':
                switch (str2)
                {
                  case "AL":
                    this.p.a(this.c().c().i());
                    goto label_52;
                  case "AP":
                    this.p.a(this.c().c().k());
                    goto label_52;
                }
                break;
              case 'N':
                if (str2 == "NL")
                {
                  this.p.a(this.c().c().e());
                  goto label_52;
                }
                else
                  break;
              case 'P':
                if (str2 == "PL")
                {
                  this.p.a(this.c().c().h());
                  goto label_52;
                }
                else
                  break;
              case 'S':
                if (str2 == "SL")
                {
                  this.p.a(this.c().c().g());
                  goto label_52;
                }
                else
                  break;
              case 'T':
                if (str2 == "TL")
                {
                  this.p.a(this.c().c().f());
                  goto label_52;
                }
                else
                  break;
              case 'U':
                if (str2 == "UE")
                {
                  this.p.a(this.c().c().j());
                  goto label_52;
                }
                else
                  break;
            }
          }
          throw new InvalidOperationException("Unknown button");
        case "SysB":
          this.p.a(this.c().b());
          string str3 = (A_0 as Button).Name.Substring(0, 2);
          if (str3 != null && str3.Length == 2)
          {
            switch (str3[0])
            {
              case 'A':
                switch (str3)
                {
                  case "AL":
                    this.p.a(this.c().b().i());
                    goto label_52;
                  case "AP":
                    this.p.a(this.c().b().k());
                    goto label_52;
                }
                break;
              case 'N':
                if (str3 == "NL")
                {
                  this.p.a(this.c().b().e());
                  goto label_52;
                }
                else
                  break;
              case 'P':
                if (str3 == "PL")
                {
                  this.p.a(this.c().b().h());
                  goto label_52;
                }
                else
                  break;
              case 'S':
                if (str3 == "SL")
                {
                  this.p.a(this.c().b().g());
                  goto label_52;
                }
                else
                  break;
              case 'T':
                if (str3 == "TL")
                {
                  this.p.a(this.c().b().f());
                  goto label_52;
                }
                else
                  break;
              case 'U':
                if (str3 == "UE")
                {
                  this.p.a(this.c().b().j());
                  goto label_52;
                }
                else
                  break;
            }
          }
          throw new InvalidOperationException("Unknown button");
        default:
          throw new InvalidOperationException("Unknown button");
      }
label_52:
      this.p.b();
      this.p.Show();
    }
  }

  private void b(string A_0)
  {
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      global::ad.a(A_0_1, "User info");
      global::ad.a(A_0_1, global::v.q.a);
      global::ad.a(A_0_1, global::v.q.b);
      global::ad.a(A_0_1, global::v.q.c.ToString());
      global::ad.a(A_0_1, global::v.q.e.ToString());
      global::ad.a(A_0_1, global::v.q.d.ToString());
      global::ad.a(A_0_1, global::v.q.g.ToString());
      global::ad.a(A_0_1, global::v.q.f.ToString());
      global::ad.a(A_0_1, global::v.q.i.ToString());
      global::ad.a(A_0_1, global::v.q.h.ToString());
      global::ad.a(A_0_1, global::v.q.k.ToString());
      global::ad.a(A_0_1, global::v.q.j.ToString());
      global::ad.a(A_0_1, global::v.q.m.ToString());
      global::ad.a(A_0_1, global::v.q.l.ToString());
      global::ad.a(A_0_1, global::v.q.o.ToString());
      global::ad.a(A_0_1, global::v.q.n.ToString());
      global::ad.a(A_0_1, global::v.q.q.ToString());
      global::ad.a(A_0_1, global::v.q.p.ToString());
      global::ad.a(A_0_1, "end User info");
      global::ad.a(A_0_1, "Level access");
      global::ad.a(A_0_1, this.c7.Checked.ToString());
      global::ad.a(A_0_1, this.c6.Checked.ToString());
      global::ad.a(A_0_1, this.c5.Checked.ToString());
      global::ad.a(A_0_1, this.c4.Checked.ToString());
      global::ad.a(A_0_1, this.c3.Checked.ToString());
      global::ad.a(A_0_1, this.c2.Checked.ToString());
      global::ad.a(A_0_1, this.c1.Checked.ToString());
      global::ad.a(A_0_1, "end Level access");
      this.c().d().d(A_0_1);
      this.c().c().d(A_0_1);
      this.c().b().d(A_0_1);
      global::ad.a(A_0_1, "All netparams");
      global::ad.a(A_0_1, this.c().d().d().j().ToString());
      global::ad.a(A_0_1, this.c().d().d().i().c().ToString());
      global::ad.a(A_0_1, this.c().d().d().i().b().ToString());
      global::ad.a(A_0_1, this.c().d().d().g().c().ToString());
      global::ad.a(A_0_1, this.c().d().d().g().b().ToString());
      global::ad.a(A_0_1, this.c().d().d().f().c().ToString());
      global::ad.a(A_0_1, this.c().d().d().f().b().ToString());
      global::ad.a(A_0_1, this.c().d().d().h().ToString());
      global::ad.a(A_0_1, this.c().d().d().e().ToString());
      global::ad.a(A_0_1, this.c().d().d().d().ToString());
      global::ad.a(A_0_1, this.c().d().d().c().ToString());
      global::ad.a(A_0_1, this.c().d().d().b().c().ToString());
      global::ad.a(A_0_1, this.c().d().d().b().b().ToString());
      global::ad.a(A_0_1, this.c().d().d().a().ToString());
      this.c().d().b(A_0_1);
      this.c().c().b(A_0_1);
      this.c().b().b(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(A_0);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(A_0, "bak"), true);
        using (ZipFile zipFile = new ZipFile(A_0))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::v.af;
          if (zipFile.Entries.Count > 0)
            zipFile.RemoveEntry("1");
          zipFile.AddEntry("1", (Stream) A_0_1);
          zipFile.Save();
          zipFile.Dispose();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
      global::v.ak = false;
    }
  }

  private void b()
  {
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\syntax.dsc"))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::v.af;
          zipFile["syntax" + (global::v.q.c % 10 + 1).ToString() + "desc.txt"].Extract((Stream) memoryStream);
          zipFile.Dispose();
        }
        memoryStream.Position = 0L;
        using (StreamReader streamReader = new StreamReader((Stream) memoryStream))
        {
          global::v.ab.Clear();
          global::v.ac.Clear();
          global::v.ad.Clear();
          string str1;
          while ((str1 = streamReader.ReadLine()) != null)
          {
            string str2 = str1.Substring(0, str1.IndexOf(":"));
            string str3 = str1.Substring(str1.IndexOf(":") + 1);
            string str4 = str3.Substring(0, str3.IndexOf(";"));
            string str5 = str3.Substring(str3.IndexOf(";") + 1);
            global::v.ab.Add((object) str4);
            global::v.ac.Add((object) str2);
            global::v.ad.Add((object) str5.Remove(str5.Length - 1));
          }
          streamReader.Close();
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadSyntax, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void a(string A_0)
  {
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(A_0))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::v.af;
          zipFile["1"].Extract((Stream) A_0_1);
          zipFile.Dispose();
        }
        A_0_1.Position = 0L;
        global::v.q.a = !(global::ad.a(A_0_1) != "User info") ? global::ad.a(A_0_1) : throw new InvalidOperationException(Resources.ErrorWrongFormat);
        global::v.q.b = global::ad.a(A_0_1);
        global::v.q.c = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.e = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.d = Convert.ToDateTime(global::ad.a(A_0_1));
        global::v.q.g = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.f = Convert.ToDateTime(global::ad.a(A_0_1));
        global::v.q.i = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.h = Convert.ToDateTime(global::ad.a(A_0_1));
        global::v.q.k = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.j = Convert.ToDateTime(global::ad.a(A_0_1));
        global::v.q.m = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.l = Convert.ToDateTime(global::ad.a(A_0_1));
        global::v.q.o = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.n = Convert.ToDateTime(global::ad.a(A_0_1));
        global::v.q.q = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.q.p = Convert.ToInt32(global::ad.a(A_0_1));
        global::v.x = (byte) (global::v.q.c % 10 + 1);
        global::v.z = 0;
        global::v.y = 0;
        global::v.aa = 0;
        this.b();
        global::v.r = Application.StartupPath + "\\help\\" + global::v.x.ToString() + ".chm";
        if (global::ad.a(A_0_1) != "end User info")
          throw new InvalidOperationException(Resources.ErrorWrongFormat);
        this.c7.Checked = !(global::ad.a(A_0_1) != "Level access") ? Convert.ToBoolean(global::ad.a(A_0_1)) : throw new InvalidOperationException(Resources.ErrorWrongFormat);
        if (this.c7.Checked)
        {
          this.c().d().e().b(global::v.x);
          this.c().b().e().b(global::v.x);
          this.c().c().e().b(global::v.x);
        }
        else
        {
          this.c().d().e().b((byte) 0);
          this.c().b().e().b((byte) 0);
          this.c().c().e().b((byte) 0);
        }
        this.c6.Checked = Convert.ToBoolean(global::ad.a(A_0_1));
        if (this.c6.Checked)
        {
          this.c().d().f().b(global::v.x);
          this.c().b().f().b(global::v.x);
          this.c().c().f().b(global::v.x);
        }
        else
        {
          this.c().d().f().b((byte) 0);
          this.c().b().f().b((byte) 0);
          this.c().c().f().b((byte) 0);
        }
        this.c5.Checked = Convert.ToBoolean(global::ad.a(A_0_1));
        if (this.c5.Checked)
        {
          this.c().d().g().b(global::v.x);
          this.c().b().g().b(global::v.x);
          this.c().c().g().b(global::v.x);
        }
        else
        {
          this.c().d().g().b((byte) 0);
          this.c().b().g().b((byte) 0);
          this.c().c().g().b((byte) 0);
        }
        this.c4.Checked = Convert.ToBoolean(global::ad.a(A_0_1));
        if (this.c4.Checked)
        {
          this.c().d().h().b(global::v.x);
          this.c().b().h().b(global::v.x);
          this.c().c().h().b(global::v.x);
        }
        else
        {
          this.c().d().h().b((byte) 0);
          this.c().b().h().b((byte) 0);
          this.c().c().h().b((byte) 0);
        }
        this.c3.Checked = Convert.ToBoolean(global::ad.a(A_0_1));
        if (this.c3.Checked)
        {
          this.c().d().i().b(global::v.x);
          this.c().b().i().b(global::v.x);
          this.c().c().i().b((byte) 0);
        }
        else
        {
          this.c().d().i().b((byte) 0);
          this.c().b().i().b((byte) 0);
          this.c().c().i().b((byte) 0);
        }
        this.c2.Checked = Convert.ToBoolean(global::ad.a(A_0_1));
        if (this.c2.Checked)
        {
          this.c().d().j().b(global::v.x);
          this.c().b().j().b((byte) 0);
          this.c().c().j().b(global::v.x);
        }
        else
        {
          this.c().d().j().b((byte) 0);
          this.c().b().j().b((byte) 0);
          this.c().c().j().b((byte) 0);
        }
        this.c1.Checked = Convert.ToBoolean(global::ad.a(A_0_1));
        if (this.c1.Checked)
        {
          this.c().d().k().b(global::v.x);
          this.c().b().k().b(global::v.x);
          this.c().c().k().b(global::v.x);
        }
        else
        {
          this.c().d().k().b((byte) 0);
          this.c().b().k().b((byte) 0);
          this.c().c().k().b((byte) 0);
        }
        if (global::ad.a(A_0_1) != "end Level access")
          throw new InvalidOperationException(Resources.ErrorWrongFormat);
        this.c().d().c(A_0_1);
        this.c().c().c(A_0_1);
        this.c().b().c(A_0_1);
        if (global::ad.a(A_0_1) != "All netparams")
          throw new InvalidOperationException(Resources.ErrorWrongFormat);
        this.c().d().d().a(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().i().b(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().i().a(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().g().b(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().g().a(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().f().b(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().f().a(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().e(Convert.ToDouble(global::ad.a(A_0_1)));
        this.c().d().d().d(Convert.ToDouble(global::ad.a(A_0_1)));
        this.c().d().d().c(Convert.ToDouble(global::ad.a(A_0_1)));
        this.c().d().d().b(Convert.ToDouble(global::ad.a(A_0_1)));
        this.c().d().d().b().b(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().b().a(Convert.ToInt32(global::ad.a(A_0_1)));
        this.c().d().d().a(Convert.ToDouble(global::ad.a(A_0_1)));
        this.c().c().d().a(this.c().d().d().j());
        this.c().c().d().i().b(this.c().d().d().i().c());
        this.c().c().d().i().a(this.c().d().d().i().b());
        this.c().c().d().g().b(this.c().d().d().g().c());
        this.c().c().d().g().a(this.c().d().d().g().b());
        this.c().c().d().f().b(this.c().d().d().f().c());
        this.c().c().d().f().a(this.c().d().d().f().b());
        this.c().c().d().e(this.c().d().d().h());
        this.c().c().d().d(this.c().d().d().e());
        this.c().c().d().c(this.c().d().d().d());
        this.c().c().d().b(this.c().d().d().c());
        this.c().c().d().b().b(this.c().d().d().b().c());
        this.c().c().d().b().a(this.c().d().d().b().b());
        this.c().c().d().a(this.c().d().d().a());
        this.c().b().d().a(this.c().d().d().j());
        this.c().b().d().i().b(this.c().d().d().i().c());
        this.c().b().d().i().a(this.c().d().d().i().b());
        this.c().b().d().g().b(this.c().d().d().g().c());
        this.c().b().d().g().a(this.c().d().d().g().b());
        this.c().b().d().f().b(this.c().d().d().f().c());
        this.c().b().d().f().a(this.c().d().d().f().b());
        this.c().b().d().e(this.c().d().d().h());
        this.c().b().d().d(this.c().d().d().e());
        this.c().b().d().c(this.c().d().d().d());
        this.c().b().d().b(this.c().d().d().c());
        this.c().b().d().b().b(this.c().d().d().b().c());
        this.c().b().d().b().a(this.c().d().d().b().b());
        this.c().b().d().a(this.c().d().d().a());
        this.c().d().a(A_0_1);
        this.c().c().a(A_0_1);
        this.c().b().a(A_0_1);
        A_0_1.Close();
        global::v.ak = false;
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    try
    {
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::v.af;
          zipFile["network.csv"].Extract((Stream) memoryStream1);
          zipFile.Dispose();
        }
        memoryStream1.Position = 0L;
        using (StreamReader streamReader1 = new StreamReader((Stream) memoryStream1))
        {
          string str1;
          while ((str1 = streamReader1.ReadLine()) != null)
          {
            string str2 = str1.Substring(0, str1.IndexOf(";"));
            try
            {
              if ((int) Convert.ToInt16(str2) == global::v.q.c)
              {
                string str3 = str1.Substring(str1.IndexOf(";") + 1);
                try
                {
                  using (MemoryStream A_0_2 = new MemoryStream())
                  {
                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                    {
                      zipFile.CompressionMethod = (CompressionMethod) 8;
                      zipFile.CompressionLevel = (CompressionLevel) 6;
                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                      zipFile.Password = global::v.af;
                      zipFile["Network" + Convert.ToInt16(str3.Substring(0, str3.IndexOf(";"))).ToString() + ".lev"].Extract((Stream) A_0_2);
                      zipFile.Dispose();
                    }
                    A_0_2.Position = 0L;
                    this.c().d().e().c(A_0_2);
                    this.c().c().e().c(A_0_2);
                    this.c().b().e().c(A_0_2);
                    A_0_2.Close();
                  }
                  if (!this.c5.Checked)
                  {
                    using (MemoryStream A_0_3 = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::v.af;
                        zipFile["session1.lev"].Extract((Stream) A_0_3);
                        zipFile.Dispose();
                      }
                      A_0_3.Position = 0L;
                      this.c().d().g().c(A_0_3);
                      this.c().c().g().c(A_0_3);
                      this.c().b().g().c(A_0_3);
                      A_0_3.Close();
                    }
                  }
                  else if (!this.c4.Checked)
                  {
                    try
                    {
                      using (MemoryStream memoryStream2 = new MemoryStream())
                      {
                        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
                        {
                          zipFile.CompressionMethod = (CompressionMethod) 8;
                          zipFile.CompressionLevel = (CompressionLevel) 6;
                          zipFile.Encryption = (EncryptionAlgorithm) 3;
                          zipFile.Password = global::v.af;
                          zipFile["Session.csv"].Extract((Stream) memoryStream2);
                          zipFile.Dispose();
                        }
                        memoryStream2.Position = 0L;
                        using (StreamReader streamReader2 = new StreamReader((Stream) memoryStream2))
                        {
                          string str4;
                          while ((str4 = streamReader2.ReadLine()) != null)
                          {
                            string str5 = str4.Substring(0, str4.IndexOf(";"));
                            try
                            {
                              if ((int) Convert.ToInt16(str5) == global::v.q.c)
                              {
                                string str6 = str4.Substring(str4.IndexOf(";") + 3);
                                string str7 = !(str6.Substring(0, str6.IndexOf(";")) == "есть") ? "2" : "1";
                                try
                                {
                                  using (MemoryStream A_0_4 = new MemoryStream())
                                  {
                                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                                    {
                                      zipFile.CompressionMethod = (CompressionMethod) 8;
                                      zipFile.CompressionLevel = (CompressionLevel) 6;
                                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                                      zipFile.Password = global::v.af;
                                      zipFile["presentation" + str7 + ".lev"].Extract((Stream) A_0_4);
                                      zipFile.Dispose();
                                    }
                                    A_0_4.Position = 0L;
                                    this.c().d().h().c(A_0_4);
                                    this.c().c().h().c(A_0_4);
                                    this.c().b().h().c(A_0_4);
                                    A_0_4.Close();
                                    break;
                                  }
                                }
                                catch (Exception ex)
                                {
                                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                  break;
                                }
                              }
                            }
                            catch (Exception ex)
                            {
                              int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                          }
                          streamReader2.Close();
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                  }
                  else if (!this.c3.Checked)
                  {
                    try
                    {
                      using (MemoryStream memoryStream3 = new MemoryStream())
                      {
                        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
                        {
                          zipFile.CompressionMethod = (CompressionMethod) 8;
                          zipFile.CompressionLevel = (CompressionLevel) 6;
                          zipFile.Encryption = (EncryptionAlgorithm) 3;
                          zipFile.Password = global::v.af;
                          zipFile["Presentation.csv"].Extract((Stream) memoryStream3);
                          zipFile.Dispose();
                        }
                        memoryStream3.Position = 0L;
                        using (StreamReader streamReader3 = new StreamReader((Stream) memoryStream3))
                        {
                          string str8;
                          while ((str8 = streamReader3.ReadLine()) != null)
                          {
                            string str9 = str8.Substring(0, str8.IndexOf(";"));
                            try
                            {
                              if ((int) Convert.ToInt16(str9) == global::v.q.c)
                              {
                                string str10 = str8.Substring(str8.IndexOf(";") + 3);
                                string str11 = str10.Substring(0, str10.IndexOf(";"));
                                try
                                {
                                  using (MemoryStream A_0_5 = new MemoryStream())
                                  {
                                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                                    {
                                      zipFile.CompressionMethod = (CompressionMethod) 8;
                                      zipFile.CompressionLevel = (CompressionLevel) 6;
                                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                                      zipFile.Password = global::v.af;
                                      zipFile["application" + str11 + ".lev"].Extract((Stream) A_0_5);
                                      zipFile.Dispose();
                                    }
                                    A_0_5.Position = 0L;
                                    this.c().d().i().c(A_0_5);
                                    this.c().c().i().c(A_0_5);
                                    this.c().b().i().c(A_0_5);
                                    A_0_5.Close();
                                    break;
                                  }
                                }
                                catch (Exception ex)
                                {
                                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                  break;
                                }
                              }
                            }
                            catch (Exception ex)
                            {
                              int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                          }
                          streamReader3.Close();
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                  }
                  else if (!this.c2.Checked)
                  {
                    try
                    {
                      using (MemoryStream memoryStream4 = new MemoryStream())
                      {
                        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
                        {
                          zipFile.CompressionMethod = (CompressionMethod) 8;
                          zipFile.CompressionLevel = (CompressionLevel) 6;
                          zipFile.Encryption = (EncryptionAlgorithm) 3;
                          zipFile.Password = global::v.af;
                          zipFile["Application.csv"].Extract((Stream) memoryStream4);
                          zipFile.Dispose();
                        }
                        memoryStream4.Position = 0L;
                        using (StreamReader streamReader4 = new StreamReader((Stream) memoryStream4))
                        {
                          string str12;
                          while ((str12 = streamReader4.ReadLine()) != null)
                          {
                            string str13 = str12.Substring(0, str12.IndexOf(";"));
                            try
                            {
                              if ((int) Convert.ToInt16(str13) == global::v.q.c)
                              {
                                string str14 = str12.Substring(str12.IndexOf(";") + 3);
                                string str15 = str14.Substring(0, str14.IndexOf(";"));
                                string str16 = str14.Substring(str14.IndexOf(";") + 1);
                                string str17 = str16.Substring(0, str16.IndexOf(";"));
                                try
                                {
                                  using (MemoryStream A_0_6 = new MemoryStream())
                                  {
                                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                                    {
                                      zipFile.CompressionMethod = (CompressionMethod) 8;
                                      zipFile.CompressionLevel = (CompressionLevel) 6;
                                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                                      zipFile.Password = global::v.af;
                                      zipFile["ue" + str17 + ".lev"].Extract((Stream) A_0_6);
                                      zipFile.Dispose();
                                    }
                                    A_0_6.Position = 0L;
                                    this.c().d().j().c(A_0_6);
                                    this.c().c().j().c(A_0_6);
                                    this.c().b().j().c(A_0_6);
                                    A_0_6.Close();
                                  }
                                }
                                catch (Exception ex)
                                {
                                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                try
                                {
                                  using (MemoryStream A_0_7 = new MemoryStream())
                                  {
                                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                                    {
                                      zipFile.CompressionMethod = (CompressionMethod) 8;
                                      zipFile.CompressionLevel = (CompressionLevel) 6;
                                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                                      zipFile.Password = global::v.af;
                                      zipFile["g" + str15 + ".lev"].Extract((Stream) A_0_7);
                                      zipFile.Dispose();
                                    }
                                    A_0_7.Position = 0L;
                                    this.c().c().i().c(A_0_7);
                                    A_0_7.Close();
                                    break;
                                  }
                                }
                                catch (Exception ex)
                                {
                                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                  break;
                                }
                              }
                            }
                            catch (Exception ex)
                            {
                              int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                          }
                          streamReader4.Close();
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                  }
                }
                catch (Exception ex)
                {
                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                string str18 = str3.Substring(str3.IndexOf(";") + 1);
                this.c().d().d().a(Convert.ToInt32(str18.Substring(0, str18.IndexOf(";"))));
                string str19 = str18.Substring(str18.IndexOf(";") + 1);
                this.c().d().d().i().b(Convert.ToInt32(str19.Substring(0, str19.IndexOf(";"))));
                string str20 = str19.Substring(str19.IndexOf(";") + 1);
                this.c().d().d().i().a(Convert.ToInt32(str20.Substring(0, str20.IndexOf(";"))));
                string str21 = str20.Substring(str20.IndexOf(";") + 1);
                this.c().d().d().e(Convert.ToDouble(str21.Substring(0, str21.IndexOf(";"))));
                string str22 = str21.Substring(str21.IndexOf(";") + 1);
                this.c().d().d().f().b(Convert.ToInt32(str22.Substring(0, str22.IndexOf(";"))));
                string str23 = str22.Substring(str22.IndexOf(";") + 1);
                this.c().d().d().f().a(Convert.ToInt32(str23.Substring(0, str23.IndexOf(";"))));
                string str24 = str23.Substring(str23.IndexOf(";") + 1);
                this.c().d().d().g().b(Convert.ToInt32(str24.Substring(0, str24.IndexOf(";"))));
                string str25 = str24.Substring(str24.IndexOf(";") + 1);
                this.c().d().d().g().a(Convert.ToInt32(str25.Substring(0, str25.IndexOf(";"))));
                string str26 = str25.Substring(str25.IndexOf(";") + 1);
                this.c().d().d().d(Convert.ToDouble(str26.Substring(0, str26.IndexOf(";"))));
                string str27 = str26.Substring(str26.IndexOf(";") + 1);
                this.c().d().d().c(Convert.ToDouble(str27.Substring(0, str27.IndexOf(";"))));
                string str28 = str27.Substring(str27.IndexOf(";") + 1);
                this.c().d().d().b(Convert.ToDouble(str28.Substring(0, str28.IndexOf(";"))));
                string str29 = str28.Substring(str28.IndexOf(";") + 1);
                this.c().d().d().b().b(Convert.ToInt32(str29.Substring(0, str29.IndexOf(";"))));
                string str30 = str29.Substring(str29.IndexOf(";") + 1);
                this.c().d().d().b().a(Convert.ToInt32(str30.Substring(0, str30.IndexOf(";"))));
                string str31 = str30.Substring(str30.IndexOf(";") + 1);
                this.c().d().d().a(Convert.ToDouble(str31));
                this.c().c().d().a(this.c().d().d().j());
                this.c().c().d().i().b(this.c().d().d().i().c());
                this.c().c().d().i().a(this.c().d().d().i().b());
                this.c().c().d().g().b(this.c().d().d().g().c());
                this.c().c().d().g().a(this.c().d().d().g().b());
                this.c().c().d().f().b(this.c().d().d().f().c());
                this.c().c().d().f().a(this.c().d().d().f().b());
                this.c().c().d().e(this.c().d().d().h());
                this.c().c().d().d(this.c().d().d().e());
                this.c().c().d().c(this.c().d().d().d());
                this.c().c().d().b(this.c().d().d().c());
                this.c().c().d().b().b(this.c().d().d().b().c());
                this.c().c().d().b().a(this.c().d().d().b().b());
                this.c().c().d().a(this.c().d().d().a());
                this.c().b().d().a(this.c().d().d().j());
                this.c().b().d().i().b(this.c().d().d().i().c());
                this.c().b().d().i().a(this.c().d().d().i().b());
                this.c().b().d().g().b(this.c().d().d().g().c());
                this.c().b().d().g().a(this.c().d().d().g().b());
                this.c().b().d().f().b(this.c().d().d().f().c());
                this.c().b().d().f().a(this.c().d().d().f().b());
                this.c().b().d().e(this.c().d().d().h());
                this.c().b().d().d(this.c().d().d().e());
                this.c().b().d().c(this.c().d().d().d());
                this.c().b().d().b(this.c().d().d().c());
                this.c().b().d().b().b(this.c().d().d().b().c());
                this.c().b().d().b().a(this.c().d().d().b().b());
                this.c().b().d().a(this.c().d().d().a());
                break;
              }
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
          }
          streamReader1.Close();
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    this.bl.Text = global::v.z.ToString() + " " + global::v.y.ToString() + " " + global::v.aa.ToString();
  }

  private void a3(object A_0, EventArgs A_1)
  {
    if (global::v.g == "Untitled.lab")
      this.bu.PerformClick();
    else
      this.b(global::v.g);
  }

  private void a2(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    global::v.g = this.b5.FileName;
    this.b(global::v.g);
    this.Text = "NetLab - " + global::v.g;
  }

  private void a1(object A_0, EventArgs A_1)
  {
    if (global::v.ak && global::v.aj)
    {
      switch (MessageBox.Show(Resources.SaveChangesQ.Replace("%s", global::v.g), "NetLab", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Cancel:
          return;
        case DialogResult.Yes:
          this.bt.PerformClick();
          break;
      }
    }
    if (this.p.Visible)
      this.p.Close();
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    global::v.g = this.b8.FileName;
    this.a(global::v.g);
    this.Text = "NetLab - " + global::v.g;
  }

  private void a0(object A_0, EventArgs A_1)
  {
    this.c7.Checked = true;
    this.c6.Checked = true;
    this.c5.Checked = true;
    this.c4.Checked = true;
    this.c3.Checked = true;
    this.c2.Checked = true;
    this.c1.Checked = true;
  }

  private void az(object A_0, EventArgs A_1)
  {
    this.bi.Enabled = this.c7.Checked;
    this.bk.Enabled = this.c7.Checked;
    this.bj.Enabled = this.c7.Checked;
    global::v.s.g = this.c7.Checked;
  }

  private void ay(object A_0, EventArgs A_1)
  {
    this.ax.Enabled = this.c6.Checked;
    this.bc.Enabled = this.c6.Checked;
    this.a2.Enabled = this.c6.Checked;
    global::v.s.f = this.c6.Checked;
  }

  private void ax(object A_0, EventArgs A_1)
  {
    this.ay.Enabled = this.c5.Checked;
    this.bd.Enabled = this.c5.Checked;
    this.a3.Enabled = this.c5.Checked;
    global::v.s.e = this.c5.Checked;
  }

  private void aw(object A_0, EventArgs A_1)
  {
    this.az.Enabled = this.c4.Checked;
    this.be.Enabled = this.c4.Checked;
    this.a4.Enabled = this.c4.Checked;
    global::v.s.d = this.c4.Checked;
  }

  private void av(object A_0, EventArgs A_1)
  {
    this.au.Enabled = this.c3.Checked;
    if (this.c3.Enabled)
      this.bf.Enabled = this.c3.Checked;
    this.a5.Enabled = this.c3.Checked;
    global::v.s.c = this.c3.Checked;
  }

  private void au(object A_0, EventArgs A_1)
  {
    this.aw.Enabled = this.c2.Checked;
    this.a7.Enabled = this.c2.Checked;
    global::v.s.b = this.c2.Checked;
  }

  private void at(object A_0, EventArgs A_1)
  {
    this.av.Enabled = this.c1.Checked;
    this.a8.Enabled = this.c1.Checked;
    global::v.s.a = this.c1.Checked;
  }

  private void @as(object A_0, EventArgs A_1)
  {
    global::o o = new global::o(this);
    int num = (int) o.ShowDialog();
    o.Dispose();
  }

  private void ar(object A_0, EventArgs A_1)
  {
    global::c c = new global::c();
    int num = (int) c.ShowDialog();
    c.Dispose();
  }

  private void aq(object A_0, EventArgs A_1)
  {
    this.bl.Clear();
    if (global::v.ah)
      this.b(global::v.ai);
    global::an.e = 0;
    this.cu.Enabled = true;
    this.bn.Enabled = false;
    this.bm.Enabled = false;
    ++global::v.q.q;
    this.c().a(global::v.h);
    this.cu.Enabled = false;
    this.bn.Enabled = true;
    this.bm.Enabled = true;
    if (global::v.m)
      return;
    this.bl.Text = System.IO.File.ReadAllText(global::v.h);
    this.bl.Select(this.bl.TextLength - 1, 0);
    this.bl.ScrollToCaret();
  }

  private void ap(object A_0, EventArgs A_1)
  {
    global::p p = new global::p();
    byte[] salt = new byte[13]
    {
      (byte) 0,
      (byte) 1,
      (byte) 3,
      (byte) 4,
      (byte) 8,
      (byte) 16,
      (byte) 22,
      (byte) 241,
      (byte) 240,
      (byte) 238,
      (byte) 33,
      (byte) 34,
      (byte) 69
    };
    byte[] first = new byte[16]
    {
      (byte) 19,
      (byte) 159,
      (byte) 98,
      (byte) 86,
      (byte) 223,
      (byte) 26,
      (byte) 5,
      (byte) 80,
      (byte) 14,
      (byte) 194,
      (byte) 34,
      (byte) 231,
      (byte) 10,
      (byte) 89,
      (byte) 50,
      (byte) 174
    };
    if (p.ShowDialog() == DialogResult.OK && ((IEnumerable<byte>) first).SequenceEqual<byte>((IEnumerable<byte>) new Rfc2898DeriveBytes(p.a, salt).GetBytes(16)))
    {
      this.b7.Enabled = true;
      this.c7.Enabled = true;
      this.c6.Enabled = true;
      this.c5.Enabled = true;
      this.c4.Enabled = true;
      this.c3.Enabled = true;
      this.c2.Enabled = true;
      this.c1.Enabled = true;
      this.c7.Checked = true;
      this.c6.Checked = true;
      this.c5.Checked = true;
      this.c4.Checked = true;
      this.c3.Checked = true;
      this.c2.Checked = true;
      this.c1.Checked = true;
      this.ca.Visible = true;
      this.cb.Visible = true;
      this.cc.Visible = true;
      this.cr.Visible = true;
      this.cr.Checked = global::v.t;
      global::v.f = true;
    }
    p.Dispose();
  }

  private void ao(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().k().g(A_0_1);
      this.c().c().k().g(A_0_1);
      this.c().b().k().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void an(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().j().g(A_0_1);
      this.c().c().j().g(A_0_1);
      this.c().b().j().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void am(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().i().g(A_0_1);
      this.c().c().i().g(A_0_1);
      this.c().b().i().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void al(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().h().g(A_0_1);
      this.c().c().h().g(A_0_1);
      this.c().b().h().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void ak(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().g().g(A_0_1);
      this.c().c().g().g(A_0_1);
      this.c().b().g().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void aj(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().f().g(A_0_1);
      this.c().c().f().g(A_0_1);
      this.c().b().f().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void ai(object A_0, EventArgs A_1)
  {
    if (this.b5.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream A_0_1 = new MemoryStream())
    {
      this.c().d().e().g(A_0_1);
      this.c().c().e().g(A_0_1);
      this.c().b().e().g(A_0_1);
      A_0_1.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.b5.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.b5.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.b5.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < A_0_1.Length; ++index)
            fileStream.WriteByte((byte) A_0_1.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      A_0_1.Close();
    }
  }

  private void ah(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().k().c(A_0_1);
        this.c().c().k().c(A_0_1);
        this.c().b().k().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void ag(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().j().c(A_0_1);
        this.c().c().j().c(A_0_1);
        this.c().b().j().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void af(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().i().c(A_0_1);
        this.c().c().i().c(A_0_1);
        this.c().b().i().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void ae(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().h().c(A_0_1);
        this.c().c().h().c(A_0_1);
        this.c().b().h().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void ad(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().g().c(A_0_1);
        this.c().c().g().c(A_0_1);
        this.c().b().g().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void ac(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().f().c(A_0_1);
        this.c().c().f().c(A_0_1);
        this.c().b().f().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void ab(object A_0, EventArgs A_1)
  {
    if (this.b8.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream A_0_1 = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.b8.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            A_0_1.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        A_0_1.Position = 0L;
        this.c().d().e().c(A_0_1);
        this.c().c().e().c(A_0_1);
        this.c().b().e().c(A_0_1);
        A_0_1.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void aa(object A_0, EventArgs A_1)
  {
    int num = (int) this.u.ShowDialog();
  }

  private void z(object A_0, EventArgs A_1)
  {
    if (new global::q().ShowDialog() != DialogResult.OK)
      return;
    global::v.g = "Untitled.lab";
    this.Text = "NetLab - Untitled.lab";
    this.c().d().a();
    this.c().b().a();
    this.c().c().a();
    global::v.x = (byte) (global::v.q.c % 10 + 1);
    global::v.z = 0;
    global::v.y = 0;
    global::v.aa = 0;
    this.b();
    global::v.r = Application.StartupPath + "\\help\\" + global::v.x.ToString() + ".chm";
    this.c7.Checked = false;
    this.c().d().e().b((byte) 0);
    this.c().b().e().b((byte) 0);
    this.c().c().e().b((byte) 0);
    this.c6.Checked = true;
    this.c().d().f().b(global::v.x);
    this.c().b().f().b(global::v.x);
    this.c().c().f().b(global::v.x);
    this.c5.Checked = false;
    this.c().d().g().b((byte) 0);
    this.c().b().g().b((byte) 0);
    this.c().c().g().b((byte) 0);
    this.c4.Checked = false;
    this.c().d().h().b((byte) 0);
    this.c().b().h().b((byte) 0);
    this.c().c().h().b((byte) 0);
    this.c3.Checked = false;
    this.c().d().i().b((byte) 0);
    this.c().b().i().b((byte) 0);
    this.c().c().i().b((byte) 0);
    this.c2.Checked = false;
    this.c().d().j().b((byte) 0);
    this.c().b().j().b((byte) 0);
    this.c().c().j().b((byte) 0);
    this.c1.Checked = false;
    this.c().d().k().b((byte) 0);
    this.c().b().k().b((byte) 0);
    this.c().c().k().b((byte) 0);
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::v.af;
          zipFile["network.csv"].Extract((Stream) memoryStream);
          zipFile.Dispose();
        }
        memoryStream.Position = 0L;
        using (StreamReader streamReader = new StreamReader((Stream) memoryStream))
        {
          string str1;
          while ((str1 = streamReader.ReadLine()) != null)
          {
            string str2 = str1.Substring(0, str1.IndexOf(";"));
            try
            {
              if ((int) Convert.ToInt16(str2) == global::v.q.c)
              {
                string str3 = str1.Substring(str1.IndexOf(";") + 1);
                try
                {
                  using (MemoryStream A_0_1 = new MemoryStream())
                  {
                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                    {
                      zipFile.CompressionMethod = (CompressionMethod) 8;
                      zipFile.CompressionLevel = (CompressionLevel) 6;
                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                      zipFile.Password = global::v.af;
                      zipFile["Network" + Convert.ToInt16(str3.Substring(0, str3.IndexOf(";"))).ToString() + ".lev"].Extract((Stream) A_0_1);
                      zipFile.Dispose();
                    }
                    A_0_1.Position = 0L;
                    this.c().d().e().c(A_0_1);
                    this.c().c().e().c(A_0_1);
                    this.c().b().e().c(A_0_1);
                    A_0_1.Close();
                  }
                  using (MemoryStream A_0_2 = new MemoryStream())
                  {
                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                    {
                      zipFile.CompressionMethod = (CompressionMethod) 8;
                      zipFile.CompressionLevel = (CompressionLevel) 6;
                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                      zipFile.Password = global::v.af;
                      zipFile["session1.lev"].Extract((Stream) A_0_2);
                      zipFile.Dispose();
                    }
                    A_0_2.Position = 0L;
                    this.c().d().g().c(A_0_2);
                    this.c().c().g().c(A_0_2);
                    this.c().b().g().c(A_0_2);
                    A_0_2.Close();
                  }
                }
                catch (Exception ex)
                {
                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                string str4 = str3.Substring(str3.IndexOf(";") + 1);
                this.c().d().d().a(Convert.ToInt32(str4.Substring(0, str4.IndexOf(";"))));
                string str5 = str4.Substring(str4.IndexOf(";") + 1);
                this.c().d().d().i().b(Convert.ToInt32(str5.Substring(0, str5.IndexOf(";"))));
                string str6 = str5.Substring(str5.IndexOf(";") + 1);
                this.c().d().d().i().a(Convert.ToInt32(str6.Substring(0, str6.IndexOf(";"))));
                string str7 = str6.Substring(str6.IndexOf(";") + 1);
                this.c().d().d().e(Convert.ToDouble(str7.Substring(0, str7.IndexOf(";"))));
                string str8 = str7.Substring(str7.IndexOf(";") + 1);
                this.c().d().d().f().b(Convert.ToInt32(str8.Substring(0, str8.IndexOf(";"))));
                string str9 = str8.Substring(str8.IndexOf(";") + 1);
                this.c().d().d().f().a(Convert.ToInt32(str9.Substring(0, str9.IndexOf(";"))));
                string str10 = str9.Substring(str9.IndexOf(";") + 1);
                this.c().d().d().g().b(Convert.ToInt32(str10.Substring(0, str10.IndexOf(";"))));
                string str11 = str10.Substring(str10.IndexOf(";") + 1);
                this.c().d().d().g().a(Convert.ToInt32(str11.Substring(0, str11.IndexOf(";"))));
                string str12 = str11.Substring(str11.IndexOf(";") + 1);
                this.c().d().d().d(Convert.ToDouble(str12.Substring(0, str12.IndexOf(";"))));
                string str13 = str12.Substring(str12.IndexOf(";") + 1);
                this.c().d().d().c(Convert.ToDouble(str13.Substring(0, str13.IndexOf(";"))));
                string str14 = str13.Substring(str13.IndexOf(";") + 1);
                this.c().d().d().b(Convert.ToDouble(str14.Substring(0, str14.IndexOf(";"))));
                string str15 = str14.Substring(str14.IndexOf(";") + 1);
                this.c().d().d().b().b(Convert.ToInt32(str15.Substring(0, str15.IndexOf(";"))));
                string str16 = str15.Substring(str15.IndexOf(";") + 1);
                this.c().d().d().b().a(Convert.ToInt32(str16.Substring(0, str16.IndexOf(";"))));
                string str17 = str16.Substring(str16.IndexOf(";") + 1);
                this.c().d().d().a(Convert.ToDouble(str17));
                this.c().c().d().a(this.c().d().d().j());
                this.c().c().d().i().b(this.c().d().d().i().c());
                this.c().c().d().i().a(this.c().d().d().i().b());
                this.c().c().d().g().b(this.c().d().d().g().c());
                this.c().c().d().g().a(this.c().d().d().g().b());
                this.c().c().d().f().b(this.c().d().d().f().c());
                this.c().c().d().f().a(this.c().d().d().f().b());
                this.c().c().d().e(this.c().d().d().h());
                this.c().c().d().d(this.c().d().d().e());
                this.c().c().d().c(this.c().d().d().d());
                this.c().c().d().b(this.c().d().d().c());
                this.c().c().d().b().b(this.c().d().d().b().c());
                this.c().c().d().b().a(this.c().d().d().b().b());
                this.c().c().d().a(this.c().d().d().a());
                this.c().b().d().a(this.c().d().d().j());
                this.c().b().d().i().b(this.c().d().d().i().c());
                this.c().b().d().i().a(this.c().d().d().i().b());
                this.c().b().d().g().b(this.c().d().d().g().c());
                this.c().b().d().g().a(this.c().d().d().g().b());
                this.c().b().d().f().b(this.c().d().d().f().c());
                this.c().b().d().f().a(this.c().d().d().f().b());
                this.c().b().d().e(this.c().d().d().h());
                this.c().b().d().d(this.c().d().d().e());
                this.c().b().d().c(this.c().d().d().d());
                this.c().b().d().b(this.c().d().d().c());
                this.c().b().d().b().b(this.c().d().d().b().c());
                this.c().b().d().b().a(this.c().d().d().b().b());
                this.c().b().d().a(this.c().d().d().a());
                break;
              }
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
          }
          streamReader.Close();
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void y(object A_0, EventArgs A_1) => global::v.t = this.cr.Checked;

  private void x(object A_0, EventArgs A_1)
  {
    this.bl.Clear();
    int num = (int) this.v.ShowDialog();
  }

  private void w(object A_0, EventArgs A_1)
  {
    this.b(Path.GetTempPath() + "\\" + global::v.q.a + ".lab");
    global::w w = new global::w();
    w.a(Path.GetTempPath() + "\\" + global::v.q.a + ".lab");
    w.d(global::v.w);
    w.b("task from " + global::v.q.a, "ready");
  }

  private void u(object A_0, EventArgs A_1) => global::an.e = 6;

  private void t(object A_0, EventArgs A_1)
  {
  }

  private void s(object A_0, EventArgs A_1)
  {
  }

  private void r(object A_0, EventArgs A_1)
  {
    global::ap ap = new global::ap();
    int num = (int) ap.ShowDialog();
    ap.Dispose();
    switch (global::v.al)
    {
      case "res1":
        this.dt.BackgroundImage = (Image) Resources.dante;
        break;
      case "res2":
        this.dt.BackgroundImage = (Image) Resources.Rainbow1;
        break;
      default:
        if (System.IO.File.Exists(global::v.al))
        {
          this.dt.BackgroundImage = Image.FromFile(global::v.al);
          break;
        }
        this.dt.BackgroundImage = (Image) Resources.dante;
        break;
    }
  }

  private void q(object A_0, EventArgs A_1) => new global::n(0, "lec.rtf").Show();

  private void p(object A_0, EventArgs A_1) => new global::n(1, "sem11.rtf").Show();

  private void o(object A_0, EventArgs A_1) => new global::n(2, "sem12.rtf").Show();

  private void n(object A_0, EventArgs A_1) => new global::n(3, "sem2.rtf").Show();

  private void m(object A_0, EventArgs A_1) => new global::n(4, "sem3.rtf").Show();

  private void l(object A_0, EventArgs A_1) => new global::n(5, "sem4.rtf").Show();

  private void k(object A_0, EventArgs A_1)
  {
  }

  private void j(object A_0, EventArgs A_1) => global::ab.a = this.c9.Checked;

  private void i(object A_0, EventArgs A_1)
  {
    global::ab.layers[(object) "Transport"] = (object) this.db.Checked;
  }

  private void h(object A_0, EventArgs A_1) => global::ab.layers[(object) "Session"] = (object) this.dc.Checked;

  private void g(object A_0, EventArgs A_1)
  {
    global::ab.layers[(object) "Presentation"] = (object) this.dd.Checked;
  }

  private void f(object A_0, EventArgs A_1)
  {
    global::ab.layers[(object) "Application"] = (object) this.de.Checked;
  }

  private void e(object A_0, EventArgs A_1) => global::ab.layers[(object) "UE"] = (object) this.df.Checked;

  private void d(object A_0, EventArgs A_1) => global::ab.layers[(object) "Process"] = (object) this.dg.Checked;

  private void c(object A_0, EventArgs A_1)
  {
    if (MessageBox.Show(Resources.NewLevelWarning, Resources.Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
      return;
    if (!this.c5.Checked)
    {
      this.c().d().g().b();
      this.c().b().g().b();
      this.c().c().g().b();
      this.c().d().g().b(global::v.x);
      this.c().b().g().b(global::v.x);
      this.c().c().g().b(global::v.x);
      this.c5.Checked = true;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
          {
            zipFile.CompressionMethod = (CompressionMethod) 8;
            zipFile.CompressionLevel = (CompressionLevel) 6;
            zipFile.Encryption = (EncryptionAlgorithm) 3;
            zipFile.Password = global::v.af;
            zipFile["Session.csv"].Extract((Stream) memoryStream);
            zipFile.Dispose();
          }
          memoryStream.Position = 0L;
          using (StreamReader streamReader = new StreamReader((Stream) memoryStream))
          {
            string str1;
            while ((str1 = streamReader.ReadLine()) != null)
            {
              string str2 = str1.Substring(0, str1.IndexOf(";"));
              try
              {
                if ((int) Convert.ToInt16(str2) == global::v.q.c)
                {
                  string str3 = str1.Substring(str1.IndexOf(";") + 3);
                  string str4 = !(str3.Substring(0, str3.IndexOf(";")) == "есть") ? "2" : "1";
                  try
                  {
                    using (MemoryStream A_0_1 = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::v.af;
                        zipFile["presentation" + str4 + ".lev"].Extract((Stream) A_0_1);
                        zipFile.Dispose();
                      }
                      A_0_1.Position = 0L;
                      this.c().d().h().c(A_0_1);
                      this.c().c().h().c(A_0_1);
                      this.c().b().h().c(A_0_1);
                      A_0_1.Close();
                      break;
                    }
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
                int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              }
            }
            streamReader.Close();
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
    else if (!this.c4.Checked)
    {
      this.c().d().h().b();
      this.c().b().h().b();
      this.c().c().h().b();
      this.c().d().h().b(global::v.x);
      this.c().b().h().b(global::v.x);
      this.c().c().h().b(global::v.x);
      this.c4.Checked = true;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
          {
            zipFile.CompressionMethod = (CompressionMethod) 8;
            zipFile.CompressionLevel = (CompressionLevel) 6;
            zipFile.Encryption = (EncryptionAlgorithm) 3;
            zipFile.Password = global::v.af;
            zipFile["Presentation.csv"].Extract((Stream) memoryStream);
            zipFile.Dispose();
          }
          memoryStream.Position = 0L;
          using (StreamReader streamReader = new StreamReader((Stream) memoryStream))
          {
            string str5;
            while ((str5 = streamReader.ReadLine()) != null)
            {
              string str6 = str5.Substring(0, str5.IndexOf(";"));
              try
              {
                if ((int) Convert.ToInt16(str6) == global::v.q.c)
                {
                  string str7 = str5.Substring(str5.IndexOf(";") + 3);
                  string str8 = str7.Substring(0, str7.IndexOf(";"));
                  try
                  {
                    using (MemoryStream A_0_2 = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::v.af;
                        zipFile["application" + str8 + ".lev"].Extract((Stream) A_0_2);
                        zipFile.Dispose();
                      }
                      A_0_2.Position = 0L;
                      this.c().d().i().c(A_0_2);
                      this.c().c().i().c(A_0_2);
                      this.c().b().i().c(A_0_2);
                      A_0_2.Close();
                      break;
                    }
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
                int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              }
            }
            streamReader.Close();
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
    else
    {
      if (this.c3.Checked)
        return;
      this.c().d().i().b();
      this.c().b().i().b();
      this.c().c().i().b();
      this.c().d().i().b(global::v.x);
      this.c().b().i().b(global::v.x);
      this.c3.Checked = true;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
          {
            zipFile.CompressionMethod = (CompressionMethod) 8;
            zipFile.CompressionLevel = (CompressionLevel) 6;
            zipFile.Encryption = (EncryptionAlgorithm) 3;
            zipFile.Password = global::v.af;
            zipFile["Application.csv"].Extract((Stream) memoryStream);
            zipFile.Dispose();
          }
          memoryStream.Position = 0L;
          using (StreamReader streamReader = new StreamReader((Stream) memoryStream))
          {
            string str9;
            while ((str9 = streamReader.ReadLine()) != null)
            {
              string str10 = str9.Substring(0, str9.IndexOf(";"));
              try
              {
                if ((int) Convert.ToInt16(str10) == global::v.q.c)
                {
                  string str11 = str9.Substring(str9.IndexOf(";") + 3);
                  string str12 = str11.Substring(0, str11.IndexOf(";"));
                  string str13 = str11.Substring(str11.IndexOf(";") + 1);
                  string str14 = str13.Substring(0, str13.IndexOf(";"));
                  try
                  {
                    using (MemoryStream A_0_3 = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::v.af;
                        zipFile["ue" + str14 + ".lev"].Extract((Stream) A_0_3);
                        zipFile.Dispose();
                      }
                      A_0_3.Position = 0L;
                      this.c().d().j().c(A_0_3);
                      this.c().c().j().c(A_0_3);
                      this.c().b().j().c(A_0_3);
                      A_0_3.Close();
                    }
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  }
                  try
                  {
                    using (MemoryStream A_0_4 = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::v.af;
                        zipFile["g" + str12 + ".lev"].Extract((Stream) A_0_4);
                        zipFile.Dispose();
                      }
                      A_0_4.Position = 0L;
                      this.c().c().i().c(A_0_4);
                      A_0_4.Close();
                      break;
                    }
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
                int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 1", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              }
            }
            streamReader.Close();
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadNetParams + " 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
  }

  private void b(object A_0, EventArgs A_1) => global::ab.layers[(object) "Network"] = (object) this.dj.Checked;

  private void a(object A_0, EventArgs A_1)
  {
    if (!global::v.c)
      return;
    WebClient webClient = new WebClient();
    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    Stream stream = webClient.OpenRead("http://netlab.front.ru/update.txt");
    StreamReader streamReader = new StreamReader(stream);
    string str = streamReader.ReadLine();
    streamReader.Close();
    stream.Close();
    if (!(str != global::v.d) || MessageBox.Show("Обновить?", "Обнаружено обновление", MessageBoxButtons.YesNo) != DialogResult.Yes)
      return;
    Process.Start("updater.exe");
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.am != null)
      this.am.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (global::v));
    this.an = new Panel();
    this.bh = new Panel();
    this.bj = new Button();
    this.bk = new Button();
    this.bi = new Button();
    this.a0 = new Panel();
    this.a1 = new Panel();
    this.a2 = new Button();
    this.a3 = new Button();
    this.a4 = new Button();
    this.a5 = new Button();
    this.a6 = new Panel();
    this.a7 = new Button();
    this.a8 = new Button();
    this.a9 = new Label();
    this.aq = new Panel();
    this.at = new Panel();
    this.ax = new Button();
    this.ay = new Button();
    this.az = new Button();
    this.au = new Button();
    this.@as = new Panel();
    this.aw = new Button();
    this.av = new Button();
    this.ar = new Label();
    this.ba = new Panel();
    this.bb = new Panel();
    this.bc = new Button();
    this.bd = new Button();
    this.be = new Button();
    this.bf = new Button();
    this.bg = new Label();
    this.ao = new MenuStrip();
    this.ap = new ToolStripMenuItem();
    this.br = new ToolStripMenuItem();
    this.bs = new ToolStripMenuItem();
    this.bt = new ToolStripMenuItem();
    this.bu = new ToolStripMenuItem();
    this.di = new ToolStripSeparator();
    this.dh = new ToolStripMenuItem();
    this.bq = new ToolStripSeparator();
    this.bp = new ToolStripMenuItem();
    this.ca = new ToolStripSeparator();
    this.cb = new ToolStripMenuItem();
    this.cd = new ToolStripMenuItem();
    this.cf = new ToolStripMenuItem();
    this.ce = new ToolStripMenuItem();
    this.cg = new ToolStripMenuItem();
    this.ch = new ToolStripMenuItem();
    this.ci = new ToolStripMenuItem();
    this.cj = new ToolStripMenuItem();
    this.cc = new ToolStripMenuItem();
    this.ck = new ToolStripMenuItem();
    this.cl = new ToolStripMenuItem();
    this.cm = new ToolStripMenuItem();
    this.cn = new ToolStripMenuItem();
    this.co = new ToolStripMenuItem();
    this.cp = new ToolStripMenuItem();
    this.cq = new ToolStripMenuItem();
    this.ct = new ToolStripMenuItem();
    this.bx = new ToolStripMenuItem();
    this.by = new ToolStripMenuItem();
    this.bz = new ToolStripMenuItem();
    this.b0 = new ToolStripSeparator();
    this.b1 = new ToolStripMenuItem();
    this.b2 = new ToolStripMenuItem();
    this.cs = new ToolStripMenuItem();
    this.c8 = new ToolStripMenuItem();
    this.c9 = new ToolStripMenuItem();
    this.da = new ToolStripSeparator();
    this.dj = new ToolStripMenuItem();
    this.db = new ToolStripMenuItem();
    this.dc = new ToolStripMenuItem();
    this.dd = new ToolStripMenuItem();
    this.de = new ToolStripMenuItem();
    this.df = new ToolStripMenuItem();
    this.dg = new ToolStripMenuItem();
    this.dk = new ToolStripMenuItem();
    this.dl = new ToolStripMenuItem();
    this.dm = new ToolStripMenuItem();
    this.dn = new ToolStripMenuItem();
    this.dp = new ToolStripMenuItem();
    this.dq = new ToolStripMenuItem();
    this.dr = new ToolStripMenuItem();
    this.ds = new ToolStripMenuItem();
    this.b3 = new ToolStripMenuItem();
    this.c1 = new ToolStripMenuItem();
    this.c2 = new ToolStripMenuItem();
    this.c3 = new ToolStripMenuItem();
    this.c4 = new ToolStripMenuItem();
    this.c5 = new ToolStripMenuItem();
    this.c6 = new ToolStripMenuItem();
    this.c7 = new ToolStripMenuItem();
    this.b6 = new ToolStripSeparator();
    this.b7 = new ToolStripMenuItem();
    this.cr = new ToolStripMenuItem();
    this.b4 = new ToolStripMenuItem();
    this.b9 = new ToolStripMenuItem();
    this.cv = new ToolStripMenuItem();
    this.cw = new ToolStripMenuItem();
    this.cx = new ToolStripMenuItem();
    this.cy = new ToolStripMenuItem();
    this.cz = new ToolStripMenuItem();
    this.c0 = new ToolStripMenuItem();
    this.bl = new TextBox();
    this.dt = new Panel();
    this.bv = new Panel();
    this.bw = new Label();
    this.bo = new Button();
    this.bm = new Button();
    this.cu = new Button();
    this.bn = new Button();
    this.b5 = new SaveFileDialog();
    this.b8 = new OpenFileDialog();
    this.an.SuspendLayout();
    this.bh.SuspendLayout();
    this.a0.SuspendLayout();
    this.a1.SuspendLayout();
    this.a6.SuspendLayout();
    this.aq.SuspendLayout();
    this.at.SuspendLayout();
    this.@as.SuspendLayout();
    this.ba.SuspendLayout();
    this.bb.SuspendLayout();
    this.ao.SuspendLayout();
    this.dt.SuspendLayout();
    this.bv.SuspendLayout();
    this.SuspendLayout();
    this.an.BorderStyle = BorderStyle.Fixed3D;
    this.an.Controls.Add((Control) this.bh);
    this.an.Controls.Add((Control) this.a0);
    this.an.Controls.Add((Control) this.aq);
    this.an.Controls.Add((Control) this.ba);
    this.an.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.an.Location = new Point(0, 24);
    this.an.Name = "panel1";
    this.an.Size = new Size(482, 335);
    this.an.TabIndex = 1;
    this.bh.BorderStyle = BorderStyle.FixedSingle;
    this.bh.Controls.Add((Control) this.bj);
    this.bh.Controls.Add((Control) this.bk);
    this.bh.Controls.Add((Control) this.bi);
    this.bh.Cursor = Cursors.SizeWE;
    this.bh.Location = new Point(18, 268);
    this.bh.Name = "panel7";
    this.bh.Size = new Size(443, 37);
    this.bh.TabIndex = 3;
    this.bj.Cursor = Cursors.SizeWE;
    this.bj.Enabled = false;
    this.bj.FlatStyle = FlatStyle.Flat;
    this.bj.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.bj.Location = new Point(321, 3);
    this.bj.Name = "NLSysBButton";
    this.bj.Size = new Size(115, 28);
    this.bj.TabIndex = 6;
    this.bj.Text = "Сетевой";
    this.bj.UseVisualStyleBackColor = true;
    this.bj.Click += new EventHandler(this.a4);
    this.bk.Cursor = Cursors.SizeWE;
    this.bk.Enabled = false;
    this.bk.FlatStyle = FlatStyle.Flat;
    this.bk.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.bk.Location = new Point(162, 3);
    this.bk.Name = "NLGuideButton";
    this.bk.Size = new Size(115, 28);
    this.bk.TabIndex = 5;
    this.bk.Text = "Сетевой";
    this.bk.UseVisualStyleBackColor = true;
    this.bk.Click += new EventHandler(this.a4);
    this.bi.Cursor = Cursors.SizeWE;
    this.bi.Enabled = false;
    this.bi.FlatStyle = FlatStyle.Flat;
    this.bi.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.bi.Location = new Point(3, 3);
    this.bi.Name = "NLSysAButton";
    this.bi.Size = new Size(115, 28);
    this.bi.TabIndex = 4;
    this.bi.Text = "Сетевой";
    this.bi.UseVisualStyleBackColor = true;
    this.bi.Click += new EventHandler(this.a4);
    this.a0.BorderStyle = BorderStyle.FixedSingle;
    this.a0.Controls.Add((Control) this.a1);
    this.a0.Controls.Add((Control) this.a6);
    this.a0.Controls.Add((Control) this.a9);
    this.a0.Location = new Point(328, 12);
    this.a0.Name = "panel8";
    this.a0.Size = new Size(142, 310);
    this.a0.TabIndex = 2;
    this.a1.BorderStyle = BorderStyle.FixedSingle;
    this.a1.Controls.Add((Control) this.a2);
    this.a1.Controls.Add((Control) this.a3);
    this.a1.Controls.Add((Control) this.a4);
    this.a1.Controls.Add((Control) this.a5);
    this.a1.Cursor = Cursors.SizeNS;
    this.a1.Location = new Point(3, 96);
    this.a1.Name = "panel9";
    this.a1.Size = new Size(133, 206);
    this.a1.TabIndex = 2;
    this.a2.BackColor = SystemColors.Control;
    this.a2.Cursor = Cursors.Default;
    this.a2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.a2.FlatStyle = FlatStyle.Flat;
    this.a2.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.a2.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.a2.Location = new Point(4, 105);
    this.a2.Name = "TLSysBButton";
    this.a2.Size = new Size(123, 28);
    this.a2.TabIndex = 3;
    this.a2.Text = "Транспортный";
    this.a2.UseVisualStyleBackColor = false;
    this.a2.Click += new EventHandler(this.a4);
    this.a3.BackColor = SystemColors.Control;
    this.a3.Cursor = Cursors.Default;
    this.a3.Enabled = false;
    this.a3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.a3.FlatStyle = FlatStyle.Flat;
    this.a3.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.a3.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.a3.Location = new Point(4, 71);
    this.a3.Name = "SLSysBButton";
    this.a3.Size = new Size(123, 28);
    this.a3.TabIndex = 2;
    this.a3.Text = "Сеансовый";
    this.a3.UseVisualStyleBackColor = false;
    this.a3.Click += new EventHandler(this.a4);
    this.a4.BackColor = SystemColors.Control;
    this.a4.Cursor = Cursors.Default;
    this.a4.Enabled = false;
    this.a4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.a4.FlatStyle = FlatStyle.Flat;
    this.a4.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.a4.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.a4.Location = new Point(4, 37);
    this.a4.Name = "PLSysBButton";
    this.a4.Size = new Size(123, 28);
    this.a4.TabIndex = 1;
    this.a4.Text = "Представления";
    this.a4.UseVisualStyleBackColor = false;
    this.a4.Click += new EventHandler(this.a4);
    this.a5.BackColor = SystemColors.Control;
    this.a5.Cursor = Cursors.Default;
    this.a5.Enabled = false;
    this.a5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.a5.FlatStyle = FlatStyle.Flat;
    this.a5.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.a5.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.a5.Location = new Point(4, 3);
    this.a5.Name = "ALSysBButton";
    this.a5.Size = new Size(123, 28);
    this.a5.TabIndex = 0;
    this.a5.Text = "Прикладной";
    this.a5.UseVisualStyleBackColor = false;
    this.a5.Click += new EventHandler(this.a4);
    this.a6.BorderStyle = BorderStyle.FixedSingle;
    this.a6.Controls.Add((Control) this.a7);
    this.a6.Controls.Add((Control) this.a8);
    this.a6.Cursor = Cursors.SizeNS;
    this.a6.Location = new Point(3, 19);
    this.a6.Name = "panel10";
    this.a6.Size = new Size(133, 71);
    this.a6.TabIndex = 1;
    this.a7.BackColor = SystemColors.Control;
    this.a7.Cursor = Cursors.Default;
    this.a7.Enabled = false;
    this.a7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.a7.FlatStyle = FlatStyle.Flat;
    this.a7.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.a7.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.a7.Location = new Point(4, 37);
    this.a7.Name = "UESysBButton";
    this.a7.Size = new Size(123, 28);
    this.a7.TabIndex = 2;
    this.a7.Text = "ЭП";
    this.a7.UseVisualStyleBackColor = false;
    this.a7.Click += new EventHandler(this.a4);
    this.a8.BackColor = SystemColors.Control;
    this.a8.Cursor = Cursors.Default;
    this.a8.Enabled = false;
    this.a8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.a8.FlatStyle = FlatStyle.Flat;
    this.a8.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.a8.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.a8.Location = new Point(4, 3);
    this.a8.Name = "APSysBButton";
    this.a8.Size = new Size(123, 28);
    this.a8.TabIndex = 1;
    this.a8.Text = "ПП";
    this.a8.UseVisualStyleBackColor = false;
    this.a8.Click += new EventHandler(this.a4);
    this.a9.Anchor = AnchorStyles.None;
    this.a9.AutoSize = true;
    this.a9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.a9.Location = new Point(20, 3);
    this.a9.Name = "label3";
    this.a9.Size = new Size(84, 16);
    this.a9.TabIndex = 0;
    this.a9.Text = "Система В";
    this.aq.BorderStyle = BorderStyle.FixedSingle;
    this.aq.Controls.Add((Control) this.at);
    this.aq.Controls.Add((Control) this.@as);
    this.aq.Controls.Add((Control) this.ar);
    this.aq.Location = new Point(10, 12);
    this.aq.Name = "panel2";
    this.aq.Size = new Size(142, 310);
    this.aq.TabIndex = 0;
    this.at.BorderStyle = BorderStyle.FixedSingle;
    this.at.Controls.Add((Control) this.ax);
    this.at.Controls.Add((Control) this.ay);
    this.at.Controls.Add((Control) this.az);
    this.at.Controls.Add((Control) this.au);
    this.at.Cursor = Cursors.SizeNS;
    this.at.Location = new Point(3, 96);
    this.at.Name = "panel4";
    this.at.Size = new Size(133, 206);
    this.at.TabIndex = 2;
    this.ax.BackColor = SystemColors.Control;
    this.ax.Cursor = Cursors.Default;
    this.ax.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.ax.FlatStyle = FlatStyle.Flat;
    this.ax.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.ax.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.ax.Location = new Point(4, 105);
    this.ax.Name = "TLSysAButton";
    this.ax.Size = new Size(123, 28);
    this.ax.TabIndex = 3;
    this.ax.Text = "Транспортный";
    this.ax.UseVisualStyleBackColor = false;
    this.ax.Click += new EventHandler(this.a4);
    this.ay.BackColor = SystemColors.Control;
    this.ay.Cursor = Cursors.Default;
    this.ay.Enabled = false;
    this.ay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.ay.FlatStyle = FlatStyle.Flat;
    this.ay.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.ay.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.ay.Location = new Point(4, 71);
    this.ay.Name = "SLSysAButton";
    this.ay.Size = new Size(123, 28);
    this.ay.TabIndex = 2;
    this.ay.Text = "Сеансовый";
    this.ay.UseVisualStyleBackColor = false;
    this.ay.Click += new EventHandler(this.a4);
    this.az.BackColor = SystemColors.Control;
    this.az.Cursor = Cursors.Default;
    this.az.Enabled = false;
    this.az.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.az.FlatStyle = FlatStyle.Flat;
    this.az.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.az.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.az.Location = new Point(4, 37);
    this.az.Name = "PLSysAButton";
    this.az.Size = new Size(123, 28);
    this.az.TabIndex = 1;
    this.az.Text = "Представления";
    this.az.UseVisualStyleBackColor = false;
    this.az.Click += new EventHandler(this.a4);
    this.au.BackColor = SystemColors.Control;
    this.au.Cursor = Cursors.Default;
    this.au.Enabled = false;
    this.au.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.au.FlatStyle = FlatStyle.Flat;
    this.au.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.au.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.au.Location = new Point(4, 3);
    this.au.Name = "ALSysAButton";
    this.au.Size = new Size(123, 28);
    this.au.TabIndex = 0;
    this.au.Text = "Прикладной";
    this.au.UseVisualStyleBackColor = false;
    this.au.Click += new EventHandler(this.a4);
    this.@as.BorderStyle = BorderStyle.FixedSingle;
    this.@as.Controls.Add((Control) this.aw);
    this.@as.Controls.Add((Control) this.av);
    this.@as.Location = new Point(3, 19);
    this.@as.Name = "panel3";
    this.@as.Size = new Size(133, 71);
    this.@as.TabIndex = 1;
    this.aw.BackColor = SystemColors.Control;
    this.aw.Enabled = false;
    this.aw.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.aw.FlatStyle = FlatStyle.Flat;
    this.aw.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.aw.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.aw.Location = new Point(4, 37);
    this.aw.Name = "UESysAButton";
    this.aw.Size = new Size(123, 28);
    this.aw.TabIndex = 2;
    this.aw.Text = "ЭП";
    this.aw.UseVisualStyleBackColor = false;
    this.aw.Click += new EventHandler(this.a4);
    this.av.BackColor = SystemColors.Control;
    this.av.Enabled = false;
    this.av.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.av.FlatStyle = FlatStyle.Flat;
    this.av.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.av.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.av.Location = new Point(4, 3);
    this.av.Name = "APSysAButton";
    this.av.Size = new Size(123, 28);
    this.av.TabIndex = 1;
    this.av.Text = "ПП";
    this.av.UseVisualStyleBackColor = false;
    this.av.Click += new EventHandler(this.a4);
    this.ar.Anchor = AnchorStyles.None;
    this.ar.AutoSize = true;
    this.ar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.ar.Location = new Point(20, 3);
    this.ar.Name = "label1";
    this.ar.Size = new Size(84, 16);
    this.ar.TabIndex = 0;
    this.ar.Text = "Система А";
    this.ba.BorderStyle = BorderStyle.FixedSingle;
    this.ba.Controls.Add((Control) this.bb);
    this.ba.Controls.Add((Control) this.bg);
    this.ba.Location = new Point(169, 12);
    this.ba.Name = "panel5";
    this.ba.Size = new Size(142, 310);
    this.ba.TabIndex = 1;
    this.bb.BorderStyle = BorderStyle.FixedSingle;
    this.bb.Controls.Add((Control) this.bc);
    this.bb.Controls.Add((Control) this.bd);
    this.bb.Controls.Add((Control) this.be);
    this.bb.Controls.Add((Control) this.bf);
    this.bb.Cursor = Cursors.SizeNS;
    this.bb.Location = new Point(3, 96);
    this.bb.Name = "panel6";
    this.bb.Size = new Size(133, 206);
    this.bb.TabIndex = 2;
    this.bc.BackColor = SystemColors.Control;
    this.bc.Cursor = Cursors.Default;
    this.bc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.bc.FlatStyle = FlatStyle.Flat;
    this.bc.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.bc.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.bc.Location = new Point(4, 105);
    this.bc.Name = "TLGuideButton";
    this.bc.Size = new Size(123, 28);
    this.bc.TabIndex = 3;
    this.bc.Text = "Транспортный";
    this.bc.UseVisualStyleBackColor = false;
    this.bc.Click += new EventHandler(this.a4);
    this.bd.BackColor = SystemColors.Control;
    this.bd.Cursor = Cursors.Default;
    this.bd.Enabled = false;
    this.bd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.bd.FlatStyle = FlatStyle.Flat;
    this.bd.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.bd.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.bd.Location = new Point(4, 71);
    this.bd.Name = "SLGuideButton";
    this.bd.Size = new Size(123, 28);
    this.bd.TabIndex = 2;
    this.bd.Text = "Сеансовый";
    this.bd.UseVisualStyleBackColor = false;
    this.bd.Click += new EventHandler(this.a4);
    this.be.BackColor = SystemColors.Control;
    this.be.Cursor = Cursors.Default;
    this.be.Enabled = false;
    this.be.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.be.FlatStyle = FlatStyle.Flat;
    this.be.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.be.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.be.Location = new Point(4, 37);
    this.be.Name = "PLGuideButton";
    this.be.Size = new Size(123, 28);
    this.be.TabIndex = 1;
    this.be.Text = "Представления";
    this.be.UseVisualStyleBackColor = false;
    this.be.Click += new EventHandler(this.a4);
    this.bf.BackColor = SystemColors.Control;
    this.bf.Cursor = Cursors.Default;
    this.bf.Enabled = false;
    this.bf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.bf.FlatStyle = FlatStyle.Flat;
    this.bf.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.bf.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.bf.Location = new Point(4, 3);
    this.bf.Name = "ALGuideButton";
    this.bf.Size = new Size(123, 28);
    this.bf.TabIndex = 0;
    this.bf.Text = "Прикладной";
    this.bf.UseVisualStyleBackColor = false;
    this.bf.Click += new EventHandler(this.a4);
    this.bg.Anchor = AnchorStyles.None;
    this.bg.AutoSize = true;
    this.bg.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.bg.Location = new Point(20, 3);
    this.bg.Name = "label2";
    this.bg.Size = new Size(97, 16);
    this.bg.TabIndex = 0;
    this.bg.Text = "Справочник";
    this.ao.Items.AddRange(new ToolStripItem[5]
    {
      (ToolStripItem) this.ap,
      (ToolStripItem) this.bx,
      (ToolStripItem) this.b2,
      (ToolStripItem) this.b3,
      (ToolStripItem) this.b4
    });
    this.ao.Location = new Point(0, 0);
    this.ao.Name = "MainMenu";
    this.ao.Size = new Size(616, 24);
    this.ao.TabIndex = 1;
    this.ap.DropDownItems.AddRange(new ToolStripItem[12]
    {
      (ToolStripItem) this.br,
      (ToolStripItem) this.bs,
      (ToolStripItem) this.bt,
      (ToolStripItem) this.bu,
      (ToolStripItem) this.di,
      (ToolStripItem) this.dh,
      (ToolStripItem) this.bq,
      (ToolStripItem) this.bp,
      (ToolStripItem) this.ca,
      (ToolStripItem) this.cb,
      (ToolStripItem) this.cc,
      (ToolStripItem) this.ct
    });
    this.ap.Name = "FileMenu";
    this.ap.Size = new Size(48, 20);
    this.ap.Text = "Файл";
    this.br.Image = (Image) componentResourceManager.GetObject("NewMenuItem.Image");
    this.br.Name = "NewMenuItem";
    this.br.ShortcutKeys = Keys.N | Keys.Control;
    this.br.Size = new Size(234, 22);
    this.br.Text = "Создать";
    this.br.Click += new EventHandler(this.z);
    this.bs.Image = (Image) componentResourceManager.GetObject("OpenMenuItem.Image");
    this.bs.Name = "OpenMenuItem";
    this.bs.ShortcutKeys = Keys.O | Keys.Control;
    this.bs.Size = new Size(234, 22);
    this.bs.Text = "Открыть";
    this.bs.Click += new EventHandler(this.a1);
    this.bt.Image = (Image) componentResourceManager.GetObject("SaveMenuItem.Image");
    this.bt.Name = "SaveMenuItem";
    this.bt.ShortcutKeys = Keys.S | Keys.Control;
    this.bt.Size = new Size(234, 22);
    this.bt.Text = "Сохранить";
    this.bt.Click += new EventHandler(this.a3);
    this.bu.Name = "SaveAsMenuItem";
    this.bu.Size = new Size(234, 22);
    this.bu.Text = "Сохранить как ...";
    this.bu.Click += new EventHandler(this.a2);
    this.di.Name = "toolStripSeparator5";
    this.di.Size = new Size(231, 6);
    this.dh.Name = "OpenNextLevelMenuItem";
    this.dh.Size = new Size(234, 22);
    this.dh.Text = "Открыть следующее задание";
    this.dh.Click += new EventHandler(this.c);
    this.bq.Name = "toolStripSeparator1";
    this.bq.Size = new Size(231, 6);
    this.bp.Name = "ExitMenuItem";
    this.bp.ShortcutKeys = Keys.X | Keys.Alt;
    this.bp.Size = new Size(234, 22);
    this.bp.Text = "Выход";
    this.bp.Click += new EventHandler(this.a5);
    this.ca.Name = "SpecialSeparator";
    this.ca.Size = new Size(231, 6);
    this.ca.Visible = false;
    this.cb.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.cd,
      (ToolStripItem) this.cf,
      (ToolStripItem) this.ce,
      (ToolStripItem) this.cg,
      (ToolStripItem) this.ch,
      (ToolStripItem) this.ci,
      (ToolStripItem) this.cj
    });
    this.cb.Name = "SaveLevelMenuItem";
    this.cb.Size = new Size(234, 22);
    this.cb.Text = "Сохранить уровень";
    this.cb.Visible = false;
    this.cd.Name = "SaveAPMenuItem";
    this.cd.Size = new Size(205, 22);
    this.cd.Text = "Прикладной процесс";
    this.cd.Click += new EventHandler(this.ao);
    this.cf.Name = "SaveUEMenuItem";
    this.cf.Size = new Size(205, 22);
    this.cf.Text = "Элемент пользователя";
    this.cf.Click += new EventHandler(this.an);
    this.ce.Name = "SaveALMenuItem";
    this.ce.Size = new Size(205, 22);
    this.ce.Text = "Прикладной уровень";
    this.ce.Click += new EventHandler(this.am);
    this.cg.Name = "SavePLMenuItem";
    this.cg.Size = new Size(205, 22);
    this.cg.Text = "Уровень представления";
    this.cg.Click += new EventHandler(this.al);
    this.ch.Name = "SaveSLMenuItem";
    this.ch.Size = new Size(205, 22);
    this.ch.Text = "Сеансовый уровень";
    this.ch.Click += new EventHandler(this.ak);
    this.ci.Name = "SaveTLMenuItem";
    this.ci.Size = new Size(205, 22);
    this.ci.Text = "Транспортный уровень";
    this.ci.Click += new EventHandler(this.aj);
    this.cj.Name = "SaveNLMenuItem";
    this.cj.Size = new Size(205, 22);
    this.cj.Text = "Сетевой уровень";
    this.cj.Click += new EventHandler(this.ai);
    this.cc.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.ck,
      (ToolStripItem) this.cl,
      (ToolStripItem) this.cm,
      (ToolStripItem) this.cn,
      (ToolStripItem) this.co,
      (ToolStripItem) this.cp,
      (ToolStripItem) this.cq
    });
    this.cc.Name = "LoadLevelMenuItem";
    this.cc.Size = new Size(234, 22);
    this.cc.Text = "Загрузить уровень";
    this.cc.Visible = false;
    this.cc.Click += new EventHandler(this.s);
    this.ck.Name = "LoadPPMenuItem";
    this.ck.Size = new Size(205, 22);
    this.ck.Text = "Прикладной процесс";
    this.ck.Click += new EventHandler(this.ah);
    this.cl.Name = "LoadUEMenuItem";
    this.cl.Size = new Size(205, 22);
    this.cl.Text = "Элемент пользователя";
    this.cl.Click += new EventHandler(this.ag);
    this.cm.Name = "LoadALMenuItem";
    this.cm.Size = new Size(205, 22);
    this.cm.Text = "Прикладной уровень";
    this.cm.Click += new EventHandler(this.af);
    this.cn.Name = "LoadPLMenuItem";
    this.cn.Size = new Size(205, 22);
    this.cn.Text = "Уровень представления";
    this.cn.Click += new EventHandler(this.ae);
    this.co.Name = "LoadSLMenuItem";
    this.co.Size = new Size(205, 22);
    this.co.Text = "Сеансовый уровень";
    this.co.Click += new EventHandler(this.ad);
    this.cp.Name = "LoadTLMenuItem";
    this.cp.Size = new Size(205, 22);
    this.cp.Text = "Транспортный уровень";
    this.cp.Click += new EventHandler(this.ac);
    this.cq.Name = "LoadNLMenuItem";
    this.cq.Size = new Size(205, 22);
    this.cq.Text = "Сетевой уровень";
    this.cq.Click += new EventHandler(this.ab);
    this.ct.Name = "SendByMailMenuItem";
    this.ct.Size = new Size(234, 22);
    this.ct.Text = "Переслать по почте";
    this.ct.Visible = false;
    this.ct.Click += new EventHandler(this.w);
    this.bx.DropDownItems.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.by,
      (ToolStripItem) this.bz,
      (ToolStripItem) this.b0,
      (ToolStripItem) this.b1
    });
    this.bx.Name = "OptionsMenu";
    this.bx.Size = new Size(83, 20);
    this.bx.Text = "Параметры";
    this.by.Name = "OptionsMenuItem";
    this.by.Size = new Size(213, 22);
    this.by.Text = "Параметры комплекса ...";
    this.by.Click += new EventHandler(this.r);
    this.bz.Name = "NetEmuOptionsMenuItem";
    this.bz.Size = new Size(213, 22);
    this.bz.Text = "Параметры эмулятора ...";
    this.bz.Click += new EventHandler(this.@as);
    this.b0.Name = "toolStripSeparator2";
    this.b0.Size = new Size(210, 6);
    this.b1.Name = "PasswordMenuItem";
    this.b1.Size = new Size(213, 22);
    this.b1.Text = "Пароль";
    this.b1.Click += new EventHandler(this.ap);
    this.b2.DropDownItems.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.cs,
      (ToolStripItem) this.c8,
      (ToolStripItem) this.dk
    });
    this.b2.Name = "DebugMenu";
    this.b2.Size = new Size(64, 20);
    this.b2.Text = "Отладка";
    this.cs.Name = "DebuggerMenuItem";
    this.cs.Size = new Size(157, 22);
    this.cs.Text = "Отладчик";
    this.cs.Click += new EventHandler(this.x);
    this.c8.DropDownItems.AddRange(new ToolStripItem[9]
    {
      (ToolStripItem) this.c9,
      (ToolStripItem) this.da,
      (ToolStripItem) this.dj,
      (ToolStripItem) this.db,
      (ToolStripItem) this.dc,
      (ToolStripItem) this.dd,
      (ToolStripItem) this.de,
      (ToolStripItem) this.df,
      (ToolStripItem) this.dg
    });
    this.c8.Name = "TraceMenu";
    this.c8.Size = new Size(157, 22);
    this.c8.Text = "Трассировка";
    this.c8.Click += new EventHandler(this.k);
    this.c9.CheckOnClick = true;
    this.c9.Name = "TraceMenuItem";
    this.c9.Size = new Size(199, 22);
    this.c9.Text = "Включить";
    this.c9.Click += new EventHandler(this.j);
    this.da.Name = "toolStripSeparator4";
    this.da.Size = new Size(196, 6);
    this.dj.CheckOnClick = true;
    this.dj.Name = "NetworkTraceMenuItem";
    this.dj.Size = new Size(199, 22);
    this.dj.Text = "Сетевой";
    this.dj.Click += new EventHandler(this.b);
    this.db.CheckOnClick = true;
    this.db.Name = "TransportTraceMenuItem";
    this.db.Size = new Size(199, 22);
    this.db.Text = "Транспортный";
    this.db.Click += new EventHandler(this.i);
    this.dc.CheckOnClick = true;
    this.dc.Name = "SessionTraceMenuItem";
    this.dc.Size = new Size(199, 22);
    this.dc.Text = "Сеансовый";
    this.dc.Click += new EventHandler(this.h);
    this.dd.CheckOnClick = true;
    this.dd.Name = "PresentationTraceStripMenuItem";
    this.dd.Size = new Size(199, 22);
    this.dd.Text = "Представления";
    this.dd.Click += new EventHandler(this.g);
    this.de.CheckOnClick = true;
    this.de.Name = "ApplicationTraceStripMenuItem";
    this.de.Size = new Size(199, 22);
    this.de.Text = "Прикладной";
    this.de.Click += new EventHandler(this.f);
    this.df.CheckOnClick = true;
    this.df.Name = "UETraceStripMenuItem";
    this.df.Size = new Size(199, 22);
    this.df.Text = "Элемент пользователя";
    this.df.Click += new EventHandler(this.e);
    this.dg.CheckOnClick = true;
    this.dg.Name = "APTraceStripMenuItem";
    this.dg.Size = new Size(199, 22);
    this.dg.Text = "Прикладной процесс";
    this.dg.Click += new EventHandler(this.d);
    this.dk.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.dl,
      (ToolStripItem) this.dm,
      (ToolStripItem) this.dn,
      (ToolStripItem) this.dp,
      (ToolStripItem) this.dq,
      (ToolStripItem) this.dr,
      (ToolStripItem) this.ds
    });
    this.dk.Name = "журналированиеToolStripMenuItem";
    this.dk.Size = new Size(157, 22);
    this.dk.Text = "Отключить out";
    this.dl.CheckOnClick = true;
    this.dl.Name = "NLogMenuItem";
    this.dl.Size = new Size(199, 22);
    this.dl.Text = "Сетевой";
    this.dm.CheckOnClick = true;
    this.dm.Name = "TLogMenuItem";
    this.dm.Size = new Size(199, 22);
    this.dm.Text = "Транспортный";
    this.dn.CheckOnClick = true;
    this.dn.Name = "SLogMenuItem";
    this.dn.Size = new Size(199, 22);
    this.dn.Text = "Сеансовый";
    this.dp.CheckOnClick = true;
    this.dp.Name = "PLogMenuItem";
    this.dp.Size = new Size(199, 22);
    this.dp.Text = "Представления";
    this.dq.CheckOnClick = true;
    this.dq.Name = "ALogMenuItem";
    this.dq.Size = new Size(199, 22);
    this.dq.Text = "Прикладной";
    this.dr.CheckOnClick = true;
    this.dr.Name = "UELogMenuItem";
    this.dr.Size = new Size(199, 22);
    this.dr.Text = "Элемент пользователя";
    this.ds.CheckOnClick = true;
    this.ds.Name = "APLogMenuItem";
    this.ds.Size = new Size(199, 22);
    this.ds.Text = "Прикладной процесс";
    this.b3.DropDownItems.AddRange(new ToolStripItem[10]
    {
      (ToolStripItem) this.c1,
      (ToolStripItem) this.c2,
      (ToolStripItem) this.c3,
      (ToolStripItem) this.c4,
      (ToolStripItem) this.c5,
      (ToolStripItem) this.c6,
      (ToolStripItem) this.c7,
      (ToolStripItem) this.b6,
      (ToolStripItem) this.b7,
      (ToolStripItem) this.cr
    });
    this.b3.Name = "LevelsMenu";
    this.b3.Size = new Size(60, 20);
    this.b3.Text = "Уровни";
    this.c1.CheckOnClick = true;
    this.c1.Enabled = false;
    this.c1.Name = "APMenuItem";
    this.c1.Size = new Size(231, 22);
    this.c1.Text = "Прикладной процесс";
    this.c1.CheckedChanged += new EventHandler(this.at);
    this.c2.CheckOnClick = true;
    this.c2.Enabled = false;
    this.c2.Name = "UEMenuItem";
    this.c2.Size = new Size(231, 22);
    this.c2.Text = "Элемент пользователя";
    this.c2.CheckedChanged += new EventHandler(this.au);
    this.c3.CheckOnClick = true;
    this.c3.Enabled = false;
    this.c3.Name = "ApplicationMenuItem";
    this.c3.Size = new Size(231, 22);
    this.c3.Text = "Прикладной";
    this.c3.CheckedChanged += new EventHandler(this.av);
    this.c4.CheckOnClick = true;
    this.c4.Enabled = false;
    this.c4.Name = "PresentationMenuItem";
    this.c4.Size = new Size(231, 22);
    this.c4.Text = "Представления";
    this.c4.CheckedChanged += new EventHandler(this.aw);
    this.c5.CheckOnClick = true;
    this.c5.Enabled = false;
    this.c5.Name = "SessionMenuItem";
    this.c5.Size = new Size(231, 22);
    this.c5.Text = "Сеансовый";
    this.c5.CheckedChanged += new EventHandler(this.ax);
    this.c6.Checked = true;
    this.c6.CheckOnClick = true;
    this.c6.CheckState = CheckState.Checked;
    this.c6.Enabled = false;
    this.c6.Name = "TransportMenuItem";
    this.c6.Size = new Size(231, 22);
    this.c6.Text = "Транспортный";
    this.c6.CheckedChanged += new EventHandler(this.ay);
    this.c7.CheckOnClick = true;
    this.c7.Enabled = false;
    this.c7.Name = "NetworkMenuItem";
    this.c7.Size = new Size(231, 22);
    this.c7.Text = "Сетевой";
    this.c7.CheckedChanged += new EventHandler(this.az);
    this.b6.Name = "toolStripSeparator3";
    this.b6.Size = new Size(228, 6);
    this.b7.Enabled = false;
    this.b7.Name = "AllMenuItem";
    this.b7.Size = new Size(231, 22);
    this.b7.Text = "Все";
    this.b7.Click += new EventHandler(this.a0);
    this.cr.CheckOnClick = true;
    this.cr.Name = "asymmetricMenuItem";
    this.cr.Size = new Size(231, 22);
    this.cr.Text = "Несимметричный протокол";
    this.cr.Visible = false;
    this.cr.CheckedChanged += new EventHandler(this.y);
    this.b4.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.b9,
      (ToolStripItem) this.cv,
      (ToolStripItem) this.cw,
      (ToolStripItem) this.cx,
      (ToolStripItem) this.cy,
      (ToolStripItem) this.cz,
      (ToolStripItem) this.c0
    });
    this.b4.Name = "HelpMenu";
    this.b4.Size = new Size(122, 20);
    this.b4.Text = "Справка";
    this.b9.Name = "AboutMenuItem";
    this.b9.Size = new Size(330, 22);
    this.b9.Text = "О программе...";
    this.b9.Click += new EventHandler(this.ar);
    this.cv.Name = "LectionsMenuItem";
    this.cv.Size = new Size(330, 22);
    this.cv.Text = "Лекции";
    this.cv.Click += new EventHandler(this.q);
    this.cw.Name = "Seminar0MenuItem";
    this.cw.Size = new Size(330, 22);
    this.cw.Text = "Вводный семинар";
    this.cw.Click += new EventHandler(this.p);
    this.cx.Name = "Seminar1MenuItem";
    this.cx.Size = new Size(330, 22);
    this.cx.Text = "Транспортный уровень";
    this.cx.Click += new EventHandler(this.o);
    this.cy.Name = "Seminar2MenuItem";
    this.cy.Size = new Size(330, 22);
    this.cy.Text = "Сеансовый уровень";
    this.cy.Click += new EventHandler(this.n);
    this.cz.Name = "Seminar3MenuItem";
    this.cz.Size = new Size(330, 22);
    this.cz.Text = "Уровень представления";
    this.cz.Click += new EventHandler(this.m);
    this.c0.Name = "Seminar4MenuItem";
    this.c0.Size = new Size(330, 22);
    this.c0.Text = "Прикладной уровень и прикладные процессы";
    this.c0.Click += new EventHandler(this.l);
    this.bl.AcceptsReturn = true;
    this.bl.AcceptsTab = true;
    this.bl.Location = new Point(0, 365);
    this.bl.Multiline = true;
    this.bl.Name = "Log";
    this.bl.ReadOnly = true;
    this.bl.ScrollBars = ScrollBars.Vertical;
    this.bl.Size = new Size(482, 142);
    this.bl.TabIndex = 2;
    this.dt.BackgroundImage = (Image) Resources.dante;
    this.dt.BorderStyle = BorderStyle.Fixed3D;
    this.dt.Controls.Add((Control) this.bv);
    this.dt.Controls.Add((Control) this.bo);
    this.dt.Controls.Add((Control) this.bm);
    this.dt.Controls.Add((Control) this.cu);
    this.dt.Controls.Add((Control) this.bn);
    this.dt.Dock = DockStyle.Right;
    this.dt.Location = new Point(484, 24);
    this.dt.Name = "panel11";
    this.dt.Size = new Size(132, 485);
    this.dt.TabIndex = 0;
    this.bv.BorderStyle = BorderStyle.FixedSingle;
    this.bv.Controls.Add((Control) this.bw);
    this.bv.Location = new Point(13, 378);
    this.bv.Name = "panel12";
    this.bv.Size = new Size(104, 93);
    this.bv.TabIndex = 5;
    this.bw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.bw.BorderStyle = BorderStyle.Fixed3D;
    this.bw.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.bw.Location = new Point(3, 3);
    this.bw.Margin = new Padding(3);
    this.bw.Name = "label4";
    this.bw.Size = new Size(96, 85);
    this.bw.TabIndex = 0;
    this.bw.Text = "NetLab 1.8.6.24";
    this.bw.TextAlign = ContentAlignment.MiddleCenter;
    this.bo.Location = new Point(13, 333);
    this.bo.Name = "ExitButton";
    this.bo.Size = new Size(104, 30);
    this.bo.TabIndex = 4;
    this.bo.Text = "Выход";
    this.bo.UseVisualStyleBackColor = true;
    this.bo.Click += new EventHandler(this.a6);
    this.bm.Location = new Point(13, 140);
    this.bm.Name = "button22";
    this.bm.Size = new Size(104, 30);
    this.bm.TabIndex = 2;
    this.bm.Text = "Статистика";
    this.bm.UseVisualStyleBackColor = true;
    this.bm.Click += new EventHandler(this.aa);
    this.cu.Enabled = false;
    this.cu.Location = new Point(13, 52);
    this.cu.Name = "button21";
    this.cu.Size = new Size(104, 30);
    this.cu.TabIndex = 1;
    this.cu.Text = "Остановить";
    this.cu.UseVisualStyleBackColor = true;
    this.cu.Click += new EventHandler(this.u);
    this.bn.Location = new Point(13, 16);
    this.bn.Name = "button20";
    this.bn.Size = new Size(104, 30);
    this.bn.TabIndex = 0;
    this.bn.Text = "Запуск эмуляции";
    this.bn.UseVisualStyleBackColor = true;
    this.bn.Click += new EventHandler(this.aq);
    this.b5.DefaultExt = "lab";
    this.b5.Filter = "Файлы NetLab|*.lab";
    this.b5.Title = "Сохранить работу как ";
    this.b8.DefaultExt = "lab";
    this.b8.Filter = "Файлы NelLab|*.lab";
    this.b8.Title = "Открыть файл";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(616, 509);
    this.Controls.Add((Control) this.dt);
    this.Controls.Add((Control) this.bl);
    this.Controls.Add((Control) this.an);
    this.Controls.Add((Control) this.ao);
    this.FormBorderStyle = FormBorderStyle.Fixed3D;
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.MainMenuStrip = this.ao;
    this.MaximizeBox = false;
    this.Name = "MainForm";
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "NetLab";
    this.FormClosing += new FormClosingEventHandler(this.a);
    this.Shown += new EventHandler(this.a);
    this.an.ResumeLayout(false);
    this.bh.ResumeLayout(false);
    this.a0.ResumeLayout(false);
    this.a0.PerformLayout();
    this.a1.ResumeLayout(false);
    this.a6.ResumeLayout(false);
    this.aq.ResumeLayout(false);
    this.aq.PerformLayout();
    this.at.ResumeLayout(false);
    this.@as.ResumeLayout(false);
    this.ba.ResumeLayout(false);
    this.ba.PerformLayout();
    this.bb.ResumeLayout(false);
    this.ao.ResumeLayout(false);
    this.ao.PerformLayout();
    this.dt.ResumeLayout(false);
    this.bv.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
