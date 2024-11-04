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
public class MainWindow : Form
{
  public static System.Drawing.Color backColor;
  public static bool checkForUpdates;
  public static string version;
  public static Font font;
  public static bool f;
  public static string labFileName;
  public static string h;
  public static int i;
  public static int j;
  public static int k;
  public static int l;
  public static bool m;
  public static bool n;
  public static bool o;
  private global::LayerWindow p;
  public static global::t userInfo;
  public static string helpPath;
  public static global::u s;
  public static bool t;
  private global::at u;
  public global::i debuggerWindow;
  public static string teacherEmail;
  public static byte syntaxNumber;
  public static int y;
  public static int z;
  public static int aa;
  public static ArrayList ab;
  public static ArrayList ac;
  public static ArrayList ad;
  public static ArrayList ae;
  public static string realPassword;
  public static int ag;
  public static bool authSave;
  public static string authSavePath;
  public static bool aj;
  public static bool ak;
  public static string al;
  private IContainer am;
  private Panel panel1;
  private MenuStrip mainMenu;
  private ToolStripMenuItem fileMenu;
  private Panel panel2;
  private Label label1;
  private Panel panel3;
  private Panel panel4;
  private Button alSysAButton;
  private Button apSysAButton;
  private Button ueSysAButton;
  private Button tlSysAButton;
  private Button slSysAButton;
  private Button plSysAButton;
  private Panel panel8;
  private Panel panel9;
  private Button tlSysBButton;
  private Button slSysBButton;
  private Button plSysBButton;
  private Button alSysBButton;
  private Panel panel10;
  private Button ueSysBButton;
  private Button apSysBButton;
  private Label label3;
  private Panel panel5;
  private Panel panel6;
  private Button tlGuideButton;
  private Button slGuideButton;
  private Button plGuideButton;
  private Button alGuideButton;
  private Label label2;
  private Panel panel7;
  private Button nlSysAButton;
  private Button nlSysBButton;
  private Button nlGuideButton;
  private TextBox logField;
  private Button statisticsButton;
  private Button startEmulationButton;
  private Button exitButton;
  private ToolStripMenuItem exitMenuItem;
  private ToolStripSeparator toolStripSeparator1;
  private ToolStripMenuItem newMenuItem;
  private ToolStripMenuItem openMenuItem;
  private ToolStripMenuItem saveMenuItem;
  private ToolStripMenuItem saveAsMenuItem;
  private Panel panel12;
  private Label label4;
  private ToolStripMenuItem optionsMenu;
  private ToolStripMenuItem optionsMenuItem;
  private ToolStripMenuItem netEmuOptionsMenuItem;
  private ToolStripSeparator toolStripSeparator2;
  private ToolStripMenuItem passwordMenuItem;
  private ToolStripMenuItem debugMenu;
  private ToolStripMenuItem levelsMenu;
  private ToolStripMenuItem helpMenu;
  private SaveFileDialog saveFileDialog;
  private ToolStripSeparator toolStripSeparator3;
  private ToolStripMenuItem allMenuItem;
  private OpenFileDialog openFileDialog;
  private ToolStripMenuItem aboutMenuItem;
  private ToolStripSeparator specialSeparator;
  private ToolStripMenuItem saveLevelMenuItem;
  private ToolStripMenuItem loadLevelMenuItem;
  private ToolStripMenuItem saveAPMenuItem;
  private ToolStripMenuItem saveALMenuItem;
  private ToolStripMenuItem saveUEMenuItem;
  private ToolStripMenuItem savePLMenuItem;
  private ToolStripMenuItem saveSLMenuItem;
  private ToolStripMenuItem saveTLMenuItem;
  private ToolStripMenuItem saveNLMenuItem;
  private ToolStripMenuItem loadPPMenuItem;
  private ToolStripMenuItem loadUEMenuItem;
  private ToolStripMenuItem loadALMenuItem;
  private ToolStripMenuItem loadPLMenuItem;
  private ToolStripMenuItem loadSLMenuItem;
  private ToolStripMenuItem loadTLMenuItem;
  private ToolStripMenuItem loadNLMenuItem;
  private ToolStripMenuItem asymmetricMenuItem;
  private ToolStripMenuItem debuggerMenuItem;
  private ToolStripMenuItem sendByMailMenuItem;
  public Button stopEmulationButton;
  private ToolStripMenuItem lectionsMenuItem;
  private ToolStripMenuItem seminar0MenuItem;
  private ToolStripMenuItem seminar1MenuItem;
  private ToolStripMenuItem seminar2MenuItem;
  private ToolStripMenuItem seminar3MenuItem;
  private ToolStripMenuItem seminar4MenuItem;
  public ToolStripMenuItem apMenuItem;
  public ToolStripMenuItem ueMenuItem;
  public ToolStripMenuItem applicationMenuItem;
  public ToolStripMenuItem presentationMenuItem;
  public ToolStripMenuItem sessionMenuItem;
  public ToolStripMenuItem transportMenuItem;
  public ToolStripMenuItem networkMenuItem;
  private ToolStripMenuItem traceMenu;
  private ToolStripMenuItem traceMenuItem;
  private ToolStripSeparator toolStrippSeparator4;
  private ToolStripMenuItem transportTraceMenuItem;
  private ToolStripMenuItem sessionTraceMenuItem;
  private ToolStripMenuItem presentationTraceStripMenuItem;
  private ToolStripMenuItem applicationTraceStripMenuItem;
  private ToolStripMenuItem ueTraceStripMenuItem;
  private ToolStripMenuItem apTraceStripMenuItem;
  private ToolStripMenuItem openNextLevelMenuItem;
  private ToolStripSeparator toolStripSeparator5;
  private ToolStripMenuItem networkTraceMenuItem;
  private ToolStripMenuItem logMenuItemsGroup;
  public ToolStripMenuItem nLogMenuItem;
  public ToolStripMenuItem tLogMenuItem;
  public ToolStripMenuItem sLogMenuItem;
  public ToolStripMenuItem pLogMenuItem;
  public ToolStripMenuItem aLogMenuItem;
  public ToolStripMenuItem ueLogMenuItem;
  public ToolStripMenuItem apLogMenuItem;
  private Panel panel11;

  [CompilerGenerated]
  [SpecialName]
  public global::an get_an() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void a(global::an A_0) => this.a = A_0;

  public void addToLog(string A_0) => this.logField.AppendText(A_0 + Environment.NewLine);

  static MainWindow() => AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(global::MainWindow.a);

  private static Assembly a(object A_0, ResolveEventArgs A_1) => Assembly.Load(Resources.Ionic_Zip);

  public MainWindow()
  {
    this.Initialize();
    Application.CurrentCulture = new CultureInfo("ru-RU", false);
    global::MainWindow.realPassword = Encoding.Unicode.GetString(Resources.vibration1.GetPropertyItem(40093).Value, 0, 22) + "nv";
    this.a(new global::an(this));
    global::MainWindow.labFileName = "Untitled.lab";
    this.p = new global::LayerWindow(this.get_an());
    this.u = new global::at(this);
    this.debuggerWindow = new global::i(this.get_an());
    global::MainWindow.userInfo.a = "None";
    global::MainWindow.userInfo.variantNumber = 0;
    global::MainWindow.userInfo.b = "None";
    global::MainWindow.f = false;
    global::MainWindow.t = false;
    global::MainWindow.s.transport = true;
    global::MainWindow.helpPath = Application.StartupPath + "\\help\\0.chm";
    global::MainWindow.teacherEmail = "netlab@somewhere.ru";
    global::MainWindow.syntaxNumber = (byte) 0;
    global::MainWindow.z = 0;
    global::MainWindow.y = 0;
    global::MainWindow.ab = new ArrayList();
    global::MainWindow.ac = new ArrayList();
    global::MainWindow.ad = new ArrayList();
    global::MainWindow.ae = new ArrayList();
    global::MainWindow.ae.Add((object) "transmit");
    global::MainWindow.ae.Add((object) "getaddress");
    global::MainWindow.ak = false;
    global::EventsParams.event2params = new SortedList();
    try
    {
      using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\EventsParams.txt"))
      {
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
          string eventName = line.Substring(0, line.IndexOf(";"));
          string eventParams = line.Substring(line.IndexOf(";"));
          global::EventsParams.event2params.Add((object) eventName, (object) eventParams);
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
        global::MainWindow.h = "log.txt";
        global::MainWindow.m = true;
        global::MainWindow.n = false;
        global::MainWindow.i = 100;
        global::MainWindow.j = 100;
        global::MainWindow.k = 600;
        global::MainWindow.l = 800;
        global::MainWindow.o = false;
        global::MainWindow.font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
        global::MainWindow.backColor = System.Drawing.Color.White;
        global::MainWindow.ag = 50;
        global::MainWindow.authSave = false;
        global::MainWindow.authSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\auto.lab";
        global::MainWindow.aj = false;
        global::MainWindow.al = "res1";
        global::MainWindow.checkForUpdates = false;
        global::MainWindow.version = "1000";
      }
      else
      {
        global::MainWindow.h = (string) registryKey.GetValue("LogFileName", (object) "log.txt");
        global::MainWindow.version = (string) registryKey.GetValue("version", (object) "1000");
        global::MainWindow.m = Convert.ToBoolean(registryKey.GetValue("DisplayLog", (object) true));
        global::MainWindow.checkForUpdates = Convert.ToBoolean(registryKey.GetValue("AutoUpdate", (object) false));
        global::MainWindow.n = Convert.ToBoolean(registryKey.GetValue("UseDelay", (object) false));
        global::MainWindow.i = (int) registryKey.GetValue("EditorLeft", (object) 100);
        global::MainWindow.j = (int) registryKey.GetValue("EditorTop", (object) 100);
        global::MainWindow.k = (int) registryKey.GetValue("EditorHeight", (object) 600);
        global::MainWindow.l = (int) registryKey.GetValue("EditorWidth", (object) 800);
        global::MainWindow.o = Convert.ToBoolean(registryKey.GetValue("EditorCommonPlace", (object) false));
        string familyName = (string) registryKey.GetValue("FontName", (object) "Microsoft Sans Serif");
        bool boolean = Convert.ToBoolean(registryKey.GetValue("FontItalic", (object) false));
        double single = (double) Convert.ToSingle(registryKey.GetValue("FontSize", (object) 10));
        int style = boolean ? 2 : 0;
        global::MainWindow.font = new Font(familyName, (float) single, (FontStyle) style);
        global::MainWindow.backColor = System.Drawing.Color.FromArgb(Convert.ToInt32(registryKey.GetValue("BGcolor", (object) -1)));
        global::MainWindow.ag = (int) registryKey.GetValue("DebugDelay", (object) 50);
        global::MainWindow.authSave = Convert.ToBoolean(registryKey.GetValue("autosave", (object) false));
        global::MainWindow.authSavePath = (string) registryKey.GetValue("AutoSaveFile", (object) (Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\auto.lab"));
        global::MainWindow.aj = Convert.ToBoolean(registryKey.GetValue("AskOnOpen", (object) false));
        global::MainWindow.al = (string) registryKey.GetValue("BG", (object) "res1");
        switch (global::MainWindow.al)
        {
          case "res1":
            this.panel11.BackgroundImage = (Image) Resources.dante;
            break;
          case "res2":
            this.panel11.BackgroundImage = (Image) Resources.Rainbow1;
            break;
          default:
            if (System.IO.File.Exists(global::MainWindow.al))
            {
              this.panel11.BackgroundImage = Image.FromFile(global::MainWindow.al);
              break;
            }
            this.panel11.BackgroundImage = (Image) Resources.dante;
            break;
        }
        registryKey.Close();
      }
    }
  }

  private void OnExitButtonClick(object A_0, EventArgs A_1) => this.Close();

  private void OnExitMenuItemClick(object A_0, EventArgs A_1) => this.Close();

  private void OnFormClosing(object A_0, FormClosingEventArgs A_1)
  {
    if (global::MainWindow.ak)
    {
      switch (MessageBox.Show(Resources.SaveChangesQ.Replace("%s", global::MainWindow.labFileName), "NetLab", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Cancel:
          A_1.Cancel = true;
          break;
        case DialogResult.Yes:
          this.saveMenuItem.PerformClick();
          break;
      }
    }
    using (RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\МИФИ\\Netlab1.5"))
    {
      subKey.SetValue("LogFileName", (object) global::MainWindow.h);
      subKey.SetValue("DisplayLog", (object) global::MainWindow.m);
      subKey.SetValue("EditorLeft", (object) global::MainWindow.i);
      subKey.SetValue("EditorTop", (object) global::MainWindow.j);
      subKey.SetValue("EditorHeight", (object) global::MainWindow.k);
      subKey.SetValue("EditorWidth", (object) global::MainWindow.l);
      subKey.SetValue("UseDelay", (object) global::MainWindow.n);
      subKey.SetValue("EditorCommonPlace", (object) global::MainWindow.o);
      subKey.SetValue("BGcolor", (object) global::MainWindow.backColor.ToArgb());
      subKey.SetValue("FontName", (object) global::MainWindow.font.Name);
      subKey.SetValue("FontSize", (object) global::MainWindow.font.SizeInPoints);
      subKey.SetValue("FontItalic", (object) global::MainWindow.font.Italic);
      subKey.SetValue("DebugDelay", (object) global::MainWindow.ag);
      subKey.SetValue("autosave", (object) global::MainWindow.authSave);
      subKey.SetValue("AutoSaveFile", (object) global::MainWindow.authSavePath);
      subKey.SetValue("AskOnOpen", (object) global::MainWindow.aj);
      subKey.SetValue("AutoUpdate", (object) global::MainWindow.checkForUpdates);
      subKey.SetValue("BG", (object) global::MainWindow.al);
      subKey.Close();
    }
  }

  private void OnLayerButtonClick(object A_0, EventArgs A_1)
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
          this.p.a(this.get_an().d());
          string str1 = (A_0 as Button).Name.Substring(0, 2);
          if (str1 != null && str1.Length == 2)
          {
            switch (str1[0])
            {
              case 'A':
                switch (str1)
                {
                  case "AL":
                    this.p.a(this.get_an().d().i());
                    goto label_52;
                  case "AP":
                    this.p.a(this.get_an().d().k());
                    goto label_52;
                }
                break;
              case 'N':
                if (str1 == "NL")
                {
                  this.p.a(this.get_an().d().e());
                  goto label_52;
                }
                else
                  break;
              case 'P':
                if (str1 == "PL")
                {
                  this.p.a(this.get_an().d().h());
                  goto label_52;
                }
                else
                  break;
              case 'S':
                if (str1 == "SL")
                {
                  this.p.a(this.get_an().d().g());
                  goto label_52;
                }
                else
                  break;
              case 'T':
                if (str1 == "TL")
                {
                  this.p.a(this.get_an().d().f());
                  goto label_52;
                }
                else
                  break;
              case 'U':
                if (str1 == "UE")
                {
                  this.p.a(this.get_an().d().j());
                  goto label_52;
                }
                else
                  break;
            }
          }
          throw new InvalidOperationException("Unknown button");
        case "Guid":
          this.p.a(this.get_an().c());
          string str2 = (A_0 as Button).Name.Substring(0, 2);
          if (str2 != null && str2.Length == 2)
          {
            switch (str2[0])
            {
              case 'A':
                switch (str2)
                {
                  case "AL":
                    this.p.a(this.get_an().c().i());
                    goto label_52;
                  case "AP":
                    this.p.a(this.get_an().c().k());
                    goto label_52;
                }
                break;
              case 'N':
                if (str2 == "NL")
                {
                  this.p.a(this.get_an().c().e());
                  goto label_52;
                }
                else
                  break;
              case 'P':
                if (str2 == "PL")
                {
                  this.p.a(this.get_an().c().h());
                  goto label_52;
                }
                else
                  break;
              case 'S':
                if (str2 == "SL")
                {
                  this.p.a(this.get_an().c().g());
                  goto label_52;
                }
                else
                  break;
              case 'T':
                if (str2 == "TL")
                {
                  this.p.a(this.get_an().c().f());
                  goto label_52;
                }
                else
                  break;
              case 'U':
                if (str2 == "UE")
                {
                  this.p.a(this.get_an().c().j());
                  goto label_52;
                }
                else
                  break;
            }
          }
          throw new InvalidOperationException("Unknown button");
        case "SysB":
          this.p.a(this.get_an().b());
          string str3 = (A_0 as Button).Name.Substring(0, 2);
          if (str3 != null && str3.Length == 2)
          {
            switch (str3[0])
            {
              case 'A':
                switch (str3)
                {
                  case "AL":
                    this.p.a(this.get_an().b().i());
                    goto label_52;
                  case "AP":
                    this.p.a(this.get_an().b().k());
                    goto label_52;
                }
                break;
              case 'N':
                if (str3 == "NL")
                {
                  this.p.a(this.get_an().b().e());
                  goto label_52;
                }
                else
                  break;
              case 'P':
                if (str3 == "PL")
                {
                  this.p.a(this.get_an().b().h());
                  goto label_52;
                }
                else
                  break;
              case 'S':
                if (str3 == "SL")
                {
                  this.p.a(this.get_an().b().g());
                  goto label_52;
                }
                else
                  break;
              case 'T':
                if (str3 == "TL")
                {
                  this.p.a(this.get_an().b().f());
                  goto label_52;
                }
                else
                  break;
              case 'U':
                if (str3 == "UE")
                {
                  this.p.a(this.get_an().b().j());
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

  private void saveLab(string A_0)
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      global::ad.a(memoryStream, "User info");
      global::ad.a(memoryStream, global::MainWindow.userInfo.a);
      global::ad.a(memoryStream, global::MainWindow.userInfo.b);
      global::ad.a(memoryStream, global::MainWindow.userInfo.variantNumber.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.e.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.d.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.g.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.f.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.i.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.h.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.k.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.j.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.m.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.l.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.o.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.n.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.q.ToString());
      global::ad.a(memoryStream, global::MainWindow.userInfo.p.ToString());
      global::ad.a(memoryStream, "end User info");
      global::ad.a(memoryStream, "Level access");
      global::ad.a(memoryStream, this.networkMenuItem.Checked.ToString());
      global::ad.a(memoryStream, this.transportMenuItem.Checked.ToString());
      global::ad.a(memoryStream, this.sessionMenuItem.Checked.ToString());
      global::ad.a(memoryStream, this.presentationMenuItem.Checked.ToString());
      global::ad.a(memoryStream, this.applicationMenuItem.Checked.ToString());
      global::ad.a(memoryStream, this.ueMenuItem.Checked.ToString());
      global::ad.a(memoryStream, this.apMenuItem.Checked.ToString());
      global::ad.a(memoryStream, "end Level access");
      this.get_an().d().d(memoryStream);
      this.get_an().c().d(memoryStream);
      this.get_an().b().d(memoryStream);
      global::ad.a(memoryStream, "All netparams");
      global::ad.a(memoryStream, this.get_an().d().d().j().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().i().c().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().i().b().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().g().c().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().g().b().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().f().c().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().f().b().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().h().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().e().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().d().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().c().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().b().c().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().b().b().ToString());
      global::ad.a(memoryStream, this.get_an().d().d().a().ToString());
      this.get_an().d().b(memoryStream);
      this.get_an().c().b(memoryStream);
      this.get_an().b().b(memoryStream);
      memoryStream.Position = 0L;
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
          zipFile.Password = global::MainWindow.realPassword;
          if (zipFile.Entries.Count > 0)
            zipFile.RemoveEntry("1");
          zipFile.AddEntry("1", (Stream) memoryStream);
          zipFile.Save();
          zipFile.Dispose();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
      global::MainWindow.ak = false;
    }
  }

  private void loadSyntax()
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
          zipFile.Password = global::MainWindow.realPassword;
          zipFile["syntax" + (global::MainWindow.userInfo.variantNumber % 10 + 1).ToString() + "desc.txt"].Extract((Stream) memoryStream);
          zipFile.Dispose();
        }
        memoryStream.Position = 0L;
        using (StreamReader streamReader = new StreamReader((Stream) memoryStream))
        {
          global::MainWindow.ab.Clear();
          global::MainWindow.ac.Clear();
          global::MainWindow.ad.Clear();
          string str1;
          while ((str1 = streamReader.ReadLine()) != null)
          {
            string str2 = str1.Substring(0, str1.IndexOf(":"));
            string str3 = str1.Substring(str1.IndexOf(":") + 1);
            string str4 = str3.Substring(0, str3.IndexOf(";"));
            string str5 = str3.Substring(str3.IndexOf(";") + 1);
            global::MainWindow.ab.Add((object) str4);
            global::MainWindow.ac.Add((object) str2);
            global::MainWindow.ad.Add((object) str5.Remove(str5.Length - 1));
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

  private void loadLab(string path)
  {
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(path))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::MainWindow.realPassword;
          zipFile["1"].Extract((Stream) memoryStream);
          zipFile.Dispose();
        }
        memoryStream.Position = 0L;
        global::MainWindow.userInfo.a = !(global::ad.a(memoryStream) != "User info") ? global::ad.a(memoryStream) : throw new InvalidOperationException(Resources.ErrorWrongFormat);
        global::MainWindow.userInfo.b = global::ad.a(memoryStream);
        global::MainWindow.userInfo.variantNumber = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.e = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.d = Convert.ToDateTime(global::ad.a(memoryStream));
        global::MainWindow.userInfo.g = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.f = Convert.ToDateTime(global::ad.a(memoryStream));
        global::MainWindow.userInfo.i = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.h = Convert.ToDateTime(global::ad.a(memoryStream));
        global::MainWindow.userInfo.k = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.j = Convert.ToDateTime(global::ad.a(memoryStream));
        global::MainWindow.userInfo.m = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.l = Convert.ToDateTime(global::ad.a(memoryStream));
        global::MainWindow.userInfo.o = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.n = Convert.ToDateTime(global::ad.a(memoryStream));
        global::MainWindow.userInfo.q = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.userInfo.p = Convert.ToInt32(global::ad.a(memoryStream));
        global::MainWindow.syntaxNumber = (byte) (global::MainWindow.userInfo.variantNumber % 10 + 1);
        global::MainWindow.z = 0;
        global::MainWindow.y = 0;
        global::MainWindow.aa = 0;
        this.loadSyntax();
        global::MainWindow.helpPath = Application.StartupPath + "\\help\\" + global::MainWindow.syntaxNumber.ToString() + ".chm";
        if (global::ad.a(memoryStream) != "end User info")
          throw new InvalidOperationException(Resources.ErrorWrongFormat);
        this.networkMenuItem.Checked = !(global::ad.a(memoryStream) != "Level access") ? Convert.ToBoolean(global::ad.a(memoryStream)) : throw new InvalidOperationException(Resources.ErrorWrongFormat);
        if (this.networkMenuItem.Checked)
        {
          this.get_an().d().e().b(global::MainWindow.syntaxNumber);
          this.get_an().b().e().b(global::MainWindow.syntaxNumber);
          this.get_an().c().e().b(global::MainWindow.syntaxNumber);
        }
        else
        {
          this.get_an().d().e().b((byte) 0);
          this.get_an().b().e().b((byte) 0);
          this.get_an().c().e().b((byte) 0);
        }
        this.transportMenuItem.Checked = Convert.ToBoolean(global::ad.a(memoryStream));
        if (this.transportMenuItem.Checked)
        {
          this.get_an().d().f().b(global::MainWindow.syntaxNumber);
          this.get_an().b().f().b(global::MainWindow.syntaxNumber);
          this.get_an().c().f().b(global::MainWindow.syntaxNumber);
        }
        else
        {
          this.get_an().d().f().b((byte) 0);
          this.get_an().b().f().b((byte) 0);
          this.get_an().c().f().b((byte) 0);
        }
        this.sessionMenuItem.Checked = Convert.ToBoolean(global::ad.a(memoryStream));
        if (this.sessionMenuItem.Checked)
        {
          this.get_an().d().g().b(global::MainWindow.syntaxNumber);
          this.get_an().b().g().b(global::MainWindow.syntaxNumber);
          this.get_an().c().g().b(global::MainWindow.syntaxNumber);
        }
        else
        {
          this.get_an().d().g().b((byte) 0);
          this.get_an().b().g().b((byte) 0);
          this.get_an().c().g().b((byte) 0);
        }
        this.presentationMenuItem.Checked = Convert.ToBoolean(global::ad.a(memoryStream));
        if (this.presentationMenuItem.Checked)
        {
          this.get_an().d().h().b(global::MainWindow.syntaxNumber);
          this.get_an().b().h().b(global::MainWindow.syntaxNumber);
          this.get_an().c().h().b(global::MainWindow.syntaxNumber);
        }
        else
        {
          this.get_an().d().h().b((byte) 0);
          this.get_an().b().h().b((byte) 0);
          this.get_an().c().h().b((byte) 0);
        }
        this.applicationMenuItem.Checked = Convert.ToBoolean(global::ad.a(memoryStream));
        if (this.applicationMenuItem.Checked)
        {
          this.get_an().d().i().b(global::MainWindow.syntaxNumber);
          this.get_an().b().i().b(global::MainWindow.syntaxNumber);
          this.get_an().c().i().b((byte) 0);
        }
        else
        {
          this.get_an().d().i().b((byte) 0);
          this.get_an().b().i().b((byte) 0);
          this.get_an().c().i().b((byte) 0);
        }
        this.ueMenuItem.Checked = Convert.ToBoolean(global::ad.a(memoryStream));
        if (this.ueMenuItem.Checked)
        {
          this.get_an().d().j().b(global::MainWindow.syntaxNumber);
          this.get_an().b().j().b((byte) 0);
          this.get_an().c().j().b(global::MainWindow.syntaxNumber);
        }
        else
        {
          this.get_an().d().j().b((byte) 0);
          this.get_an().b().j().b((byte) 0);
          this.get_an().c().j().b((byte) 0);
        }
        this.apMenuItem.Checked = Convert.ToBoolean(global::ad.a(memoryStream));
        if (this.apMenuItem.Checked)
        {
          this.get_an().d().k().b(global::MainWindow.syntaxNumber);
          this.get_an().b().k().b(global::MainWindow.syntaxNumber);
          this.get_an().c().k().b(global::MainWindow.syntaxNumber);
        }
        else
        {
          this.get_an().d().k().b((byte) 0);
          this.get_an().b().k().b((byte) 0);
          this.get_an().c().k().b((byte) 0);
        }
        if (global::ad.a(memoryStream) != "end Level access")
          throw new InvalidOperationException(Resources.ErrorWrongFormat);
        this.get_an().d().c(memoryStream);
        this.get_an().c().c(memoryStream);
        this.get_an().b().c(memoryStream);
        if (global::ad.a(memoryStream) != "All netparams")
          throw new InvalidOperationException(Resources.ErrorWrongFormat);
        this.get_an().d().d().a(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().i().b(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().i().a(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().g().b(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().g().a(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().f().b(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().f().a(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().e(Convert.ToDouble(global::ad.a(memoryStream)));
        this.get_an().d().d().d(Convert.ToDouble(global::ad.a(memoryStream)));
        this.get_an().d().d().c(Convert.ToDouble(global::ad.a(memoryStream)));
        this.get_an().d().d().b(Convert.ToDouble(global::ad.a(memoryStream)));
        this.get_an().d().d().b().b(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().b().a(Convert.ToInt32(global::ad.a(memoryStream)));
        this.get_an().d().d().a(Convert.ToDouble(global::ad.a(memoryStream)));
        this.get_an().c().d().a(this.get_an().d().d().j());
        this.get_an().c().d().i().b(this.get_an().d().d().i().c());
        this.get_an().c().d().i().a(this.get_an().d().d().i().b());
        this.get_an().c().d().g().b(this.get_an().d().d().g().c());
        this.get_an().c().d().g().a(this.get_an().d().d().g().b());
        this.get_an().c().d().f().b(this.get_an().d().d().f().c());
        this.get_an().c().d().f().a(this.get_an().d().d().f().b());
        this.get_an().c().d().e(this.get_an().d().d().h());
        this.get_an().c().d().d(this.get_an().d().d().e());
        this.get_an().c().d().c(this.get_an().d().d().d());
        this.get_an().c().d().b(this.get_an().d().d().c());
        this.get_an().c().d().b().b(this.get_an().d().d().b().c());
        this.get_an().c().d().b().a(this.get_an().d().d().b().b());
        this.get_an().c().d().a(this.get_an().d().d().a());
        this.get_an().b().d().a(this.get_an().d().d().j());
        this.get_an().b().d().i().b(this.get_an().d().d().i().c());
        this.get_an().b().d().i().a(this.get_an().d().d().i().b());
        this.get_an().b().d().g().b(this.get_an().d().d().g().c());
        this.get_an().b().d().g().a(this.get_an().d().d().g().b());
        this.get_an().b().d().f().b(this.get_an().d().d().f().c());
        this.get_an().b().d().f().a(this.get_an().d().d().f().b());
        this.get_an().b().d().e(this.get_an().d().d().h());
        this.get_an().b().d().d(this.get_an().d().d().e());
        this.get_an().b().d().c(this.get_an().d().d().d());
        this.get_an().b().d().b(this.get_an().d().d().c());
        this.get_an().b().d().b().b(this.get_an().d().d().b().c());
        this.get_an().b().d().b().a(this.get_an().d().d().b().b());
        this.get_an().b().d().a(this.get_an().d().d().a());
        this.get_an().d().a(memoryStream);
        this.get_an().c().a(memoryStream);
        this.get_an().b().a(memoryStream);
        memoryStream.Close();
        global::MainWindow.ak = false;
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
          zipFile.Password = global::MainWindow.realPassword;
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
              if ((int) Convert.ToInt16(str2) == global::MainWindow.userInfo.variantNumber)
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
                      zipFile.Password = global::MainWindow.realPassword;
                      zipFile["Network" + Convert.ToInt16(str3.Substring(0, str3.IndexOf(";"))).ToString() + ".lev"].Extract((Stream) A_0_2);
                      zipFile.Dispose();
                    }
                    A_0_2.Position = 0L;
                    this.get_an().d().e().c(A_0_2);
                    this.get_an().c().e().c(A_0_2);
                    this.get_an().b().e().c(A_0_2);
                    A_0_2.Close();
                  }
                  if (!this.sessionMenuItem.Checked)
                  {
                    using (MemoryStream A_0_3 = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::MainWindow.realPassword;
                        zipFile["session1.lev"].Extract((Stream) A_0_3);
                        zipFile.Dispose();
                      }
                      A_0_3.Position = 0L;
                      this.get_an().d().g().c(A_0_3);
                      this.get_an().c().g().c(A_0_3);
                      this.get_an().b().g().c(A_0_3);
                      A_0_3.Close();
                    }
                  }
                  else if (!this.presentationMenuItem.Checked)
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
                          zipFile.Password = global::MainWindow.realPassword;
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
                              if ((int) Convert.ToInt16(str5) == global::MainWindow.userInfo.variantNumber)
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
                                      zipFile.Password = global::MainWindow.realPassword;
                                      zipFile["presentation" + str7 + ".lev"].Extract((Stream) A_0_4);
                                      zipFile.Dispose();
                                    }
                                    A_0_4.Position = 0L;
                                    this.get_an().d().h().c(A_0_4);
                                    this.get_an().c().h().c(A_0_4);
                                    this.get_an().b().h().c(A_0_4);
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
                  else if (!this.applicationMenuItem.Checked)
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
                          zipFile.Password = global::MainWindow.realPassword;
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
                              if ((int) Convert.ToInt16(str9) == global::MainWindow.userInfo.variantNumber)
                              {
                                string str10 = str8.Substring(str8.IndexOf(";") + 3);
                                string str11 = str10.Substring(0, str10.IndexOf(";"));
                                try
                                {
                                  using (MemoryStream memoryStream = new MemoryStream())
                                  {
                                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                                    {
                                      zipFile.CompressionMethod = (CompressionMethod) 8;
                                      zipFile.CompressionLevel = (CompressionLevel) 6;
                                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                                      zipFile.Password = global::MainWindow.realPassword;
                                      zipFile["application" + str11 + ".lev"].Extract((Stream) memoryStream);
                                      zipFile.Dispose();
                                    }
                                    memoryStream.Position = 0L;
                                    this.get_an().d().i().c(memoryStream);
                                    this.get_an().c().i().c(memoryStream);
                                    this.get_an().b().i().c(memoryStream);
                                    memoryStream.Close();
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
                  else if (!this.ueMenuItem.Checked)
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
                          zipFile.Password = global::MainWindow.realPassword;
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
                              if ((int) Convert.ToInt16(str13) == global::MainWindow.userInfo.variantNumber)
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
                                      zipFile.Password = global::MainWindow.realPassword;
                                      zipFile["ue" + str17 + ".lev"].Extract((Stream) A_0_6);
                                      zipFile.Dispose();
                                    }
                                    A_0_6.Position = 0L;
                                    this.get_an().d().j().c(A_0_6);
                                    this.get_an().c().j().c(A_0_6);
                                    this.get_an().b().j().c(A_0_6);
                                    A_0_6.Close();
                                  }
                                }
                                catch (Exception ex)
                                {
                                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                try
                                {
                                  using (MemoryStream memoryStream = new MemoryStream())
                                  {
                                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                                    {
                                      zipFile.CompressionMethod = (CompressionMethod) 8;
                                      zipFile.CompressionLevel = (CompressionLevel) 6;
                                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                                      zipFile.Password = global::MainWindow.realPassword;
                                      zipFile["g" + str15 + ".lev"].Extract((Stream) memoryStream);
                                      zipFile.Dispose();
                                    }
                                    memoryStream.Position = 0L;
                                    this.get_an().c().i().c(memoryStream);
                                    memoryStream.Close();
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
                this.get_an().d().d().a(Convert.ToInt32(str18.Substring(0, str18.IndexOf(";"))));
                string str19 = str18.Substring(str18.IndexOf(";") + 1);
                this.get_an().d().d().i().b(Convert.ToInt32(str19.Substring(0, str19.IndexOf(";"))));
                string str20 = str19.Substring(str19.IndexOf(";") + 1);
                this.get_an().d().d().i().a(Convert.ToInt32(str20.Substring(0, str20.IndexOf(";"))));
                string str21 = str20.Substring(str20.IndexOf(";") + 1);
                this.get_an().d().d().e(Convert.ToDouble(str21.Substring(0, str21.IndexOf(";"))));
                string str22 = str21.Substring(str21.IndexOf(";") + 1);
                this.get_an().d().d().f().b(Convert.ToInt32(str22.Substring(0, str22.IndexOf(";"))));
                string str23 = str22.Substring(str22.IndexOf(";") + 1);
                this.get_an().d().d().f().a(Convert.ToInt32(str23.Substring(0, str23.IndexOf(";"))));
                string str24 = str23.Substring(str23.IndexOf(";") + 1);
                this.get_an().d().d().g().b(Convert.ToInt32(str24.Substring(0, str24.IndexOf(";"))));
                string str25 = str24.Substring(str24.IndexOf(";") + 1);
                this.get_an().d().d().g().a(Convert.ToInt32(str25.Substring(0, str25.IndexOf(";"))));
                string str26 = str25.Substring(str25.IndexOf(";") + 1);
                this.get_an().d().d().d(Convert.ToDouble(str26.Substring(0, str26.IndexOf(";"))));
                string str27 = str26.Substring(str26.IndexOf(";") + 1);
                this.get_an().d().d().c(Convert.ToDouble(str27.Substring(0, str27.IndexOf(";"))));
                string str28 = str27.Substring(str27.IndexOf(";") + 1);
                this.get_an().d().d().b(Convert.ToDouble(str28.Substring(0, str28.IndexOf(";"))));
                string str29 = str28.Substring(str28.IndexOf(";") + 1);
                this.get_an().d().d().b().b(Convert.ToInt32(str29.Substring(0, str29.IndexOf(";"))));
                string str30 = str29.Substring(str29.IndexOf(";") + 1);
                this.get_an().d().d().b().a(Convert.ToInt32(str30.Substring(0, str30.IndexOf(";"))));
                string str31 = str30.Substring(str30.IndexOf(";") + 1);
                this.get_an().d().d().a(Convert.ToDouble(str31));
                this.get_an().c().d().a(this.get_an().d().d().j());
                this.get_an().c().d().i().b(this.get_an().d().d().i().c());
                this.get_an().c().d().i().a(this.get_an().d().d().i().b());
                this.get_an().c().d().g().b(this.get_an().d().d().g().c());
                this.get_an().c().d().g().a(this.get_an().d().d().g().b());
                this.get_an().c().d().f().b(this.get_an().d().d().f().c());
                this.get_an().c().d().f().a(this.get_an().d().d().f().b());
                this.get_an().c().d().e(this.get_an().d().d().h());
                this.get_an().c().d().d(this.get_an().d().d().e());
                this.get_an().c().d().c(this.get_an().d().d().d());
                this.get_an().c().d().b(this.get_an().d().d().c());
                this.get_an().c().d().b().b(this.get_an().d().d().b().c());
                this.get_an().c().d().b().a(this.get_an().d().d().b().b());
                this.get_an().c().d().a(this.get_an().d().d().a());
                this.get_an().b().d().a(this.get_an().d().d().j());
                this.get_an().b().d().i().b(this.get_an().d().d().i().c());
                this.get_an().b().d().i().a(this.get_an().d().d().i().b());
                this.get_an().b().d().g().b(this.get_an().d().d().g().c());
                this.get_an().b().d().g().a(this.get_an().d().d().g().b());
                this.get_an().b().d().f().b(this.get_an().d().d().f().c());
                this.get_an().b().d().f().a(this.get_an().d().d().f().b());
                this.get_an().b().d().e(this.get_an().d().d().h());
                this.get_an().b().d().d(this.get_an().d().d().e());
                this.get_an().b().d().c(this.get_an().d().d().d());
                this.get_an().b().d().b(this.get_an().d().d().c());
                this.get_an().b().d().b().b(this.get_an().d().d().b().c());
                this.get_an().b().d().b().a(this.get_an().d().d().b().b());
                this.get_an().b().d().a(this.get_an().d().d().a());
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
    this.logField.Text = global::MainWindow.z.ToString() + " " + global::MainWindow.y.ToString() + " " + global::MainWindow.aa.ToString();
  }

  private void OnSaveMenuItemClick(object A_0, EventArgs A_1)
  {
    if (global::MainWindow.labFileName == "Untitled.lab")
      this.saveAsMenuItem.PerformClick();
    else
      this.saveLab(global::MainWindow.labFileName);
  }

  private void OnSaveAsMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    global::MainWindow.labFileName = this.saveFileDialog.FileName;
    this.saveLab(global::MainWindow.labFileName);
    this.Text = "NetLab - " + global::MainWindow.labFileName;
  }

  private void OnOpenMenuItemClick(object A_0, EventArgs A_1)
  {
    if (global::MainWindow.ak && global::MainWindow.aj)
    {
      switch (MessageBox.Show(Resources.SaveChangesQ.Replace("%s", global::MainWindow.labFileName), "NetLab", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Cancel:
          return;
        case DialogResult.Yes:
          this.saveMenuItem.PerformClick();
          break;
      }
    }
    if (this.p.Visible)
      this.p.Close();
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    global::MainWindow.labFileName = this.openFileDialog.FileName;
    this.loadLab(global::MainWindow.labFileName);
    this.Text = "NetLab - " + global::MainWindow.labFileName;
  }

  private void OnAllMenuItemClick(object A_0, EventArgs A_1)
  {
    this.networkMenuItem.Checked = true;
    this.transportMenuItem.Checked = true;
    this.sessionMenuItem.Checked = true;
    this.presentationMenuItem.Checked = true;
    this.applicationMenuItem.Checked = true;
    this.ueMenuItem.Checked = true;
    this.apMenuItem.Checked = true;
  }

  private void OnNetworkMenuItemClick(object A_0, EventArgs A_1)
  {
    this.nlSysAButton.Enabled = this.networkMenuItem.Checked;
    this.nlGuideButton.Enabled = this.networkMenuItem.Checked;
    this.nlSysBButton.Enabled = this.networkMenuItem.Checked;
    global::MainWindow.s.network = this.networkMenuItem.Checked;
  }

  private void OnTransportMenuItemClick(object A_0, EventArgs A_1)
  {
    this.tlSysAButton.Enabled = this.transportMenuItem.Checked;
    this.tlGuideButton.Enabled = this.transportMenuItem.Checked;
    this.tlSysBButton.Enabled = this.transportMenuItem.Checked;
    global::MainWindow.s.transport = this.transportMenuItem.Checked;
  }

  private void OnSessionMenuItemClick(object A_0, EventArgs A_1)
  {
    this.slSysAButton.Enabled = this.sessionMenuItem.Checked;
    this.slGuideButton.Enabled = this.sessionMenuItem.Checked;
    this.slSysBButton.Enabled = this.sessionMenuItem.Checked;
    global::MainWindow.s.session = this.sessionMenuItem.Checked;
  }

  private void OnPresentationMenuItemClick(object A_0, EventArgs A_1)
  {
    this.plSysAButton.Enabled = this.presentationMenuItem.Checked;
    this.plGuideButton.Enabled = this.presentationMenuItem.Checked;
    this.plSysBButton.Enabled = this.presentationMenuItem.Checked;
    global::MainWindow.s.presentation = this.presentationMenuItem.Checked;
  }

  private void OnApplicationMenuItemClick(object A_0, EventArgs A_1)
  {
    this.alSysAButton.Enabled = this.applicationMenuItem.Checked;
    if (this.applicationMenuItem.Enabled)
      this.alGuideButton.Enabled = this.applicationMenuItem.Checked;
    this.alSysBButton.Enabled = this.applicationMenuItem.Checked;
    global::MainWindow.s.application = this.applicationMenuItem.Checked;
  }

  private void OnUEMenuItemClick(object A_0, EventArgs A_1)
  {
    this.ueSysAButton.Enabled = this.ueMenuItem.Checked;
    this.ueSysBButton.Enabled = this.ueMenuItem.Checked;
    global::MainWindow.s.UE = this.ueMenuItem.Checked;
  }

  private void OnAPMenuItemClick(object A_0, EventArgs A_1)
  {
    this.apSysAButton.Enabled = this.apMenuItem.Checked;
    this.apSysBButton.Enabled = this.apMenuItem.Checked;
    global::MainWindow.s.AP = this.apMenuItem.Checked;
  }

  private void OnNetEmuOptionsMenuItemClick(object A_0, EventArgs A_1)
  {
    global::o o = new global::o(this);
    int num = (int) o.ShowDialog();
    o.Dispose();
  }

  private void OnAboutMenuItemClick(object A_0, EventArgs A_1)
  {
    global::c c = new global::c();
    int num = (int) c.ShowDialog();
    c.Dispose();
  }

  private void StartEmulation(object A_0, EventArgs A_1)
  {
    this.logField.Clear();
    if (global::MainWindow.authSave)
      this.saveLab(global::MainWindow.authSavePath);
    global::an.e = 0;
    this.stopEmulationButton.Enabled = true;
    this.startEmulationButton.Enabled = false;
    this.statisticsButton.Enabled = false;
    ++global::MainWindow.userInfo.q;
    this.get_an().startEmulation(global::MainWindow.h);
    this.stopEmulationButton.Enabled = false;
    this.startEmulationButton.Enabled = true;
    this.statisticsButton.Enabled = true;
    if (global::MainWindow.m)
      return;
    this.logField.Text = System.IO.File.ReadAllText(global::MainWindow.h);
    this.logField.Select(this.logField.TextLength - 1, 0);
    this.logField.ScrollToCaret();
  }

  private void OnPasswordMenuItemClick(object A_0, EventArgs A_1)
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
      this.allMenuItem.Enabled = true;
      this.networkMenuItem.Enabled = true;
      this.transportMenuItem.Enabled = true;
      this.sessionMenuItem.Enabled = true;
      this.presentationMenuItem.Enabled = true;
      this.applicationMenuItem.Enabled = true;
      this.ueMenuItem.Enabled = true;
      this.apMenuItem.Enabled = true;
      this.networkMenuItem.Checked = true;
      this.transportMenuItem.Checked = true;
      this.sessionMenuItem.Checked = true;
      this.presentationMenuItem.Checked = true;
      this.applicationMenuItem.Checked = true;
      this.ueMenuItem.Checked = true;
      this.apMenuItem.Checked = true;
      this.specialSeparator.Visible = true;
      this.saveLevelMenuItem.Visible = true;
      this.loadLevelMenuItem.Visible = true;
      this.asymmetricMenuItem.Visible = true;
      this.asymmetricMenuItem.Checked = global::MainWindow.t;
      global::MainWindow.f = true;
    }
    p.Dispose();
  }

  private void OnSaveAPMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().k().g(memoryStream);
      this.get_an().c().k().g(memoryStream);
      this.get_an().b().k().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnSaveUEMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().j().g(memoryStream);
      this.get_an().c().j().g(memoryStream);
      this.get_an().b().j().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnSaveALMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().i().g(memoryStream);
      this.get_an().c().i().g(memoryStream);
      this.get_an().b().i().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnSavePLMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().h().g(memoryStream);
      this.get_an().c().h().g(memoryStream);
      this.get_an().b().h().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnSaveSLMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().g().g(memoryStream);
      this.get_an().c().g().g(memoryStream);
      this.get_an().b().g().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnSaveTLMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().f().g(memoryStream);
      this.get_an().c().f().g(memoryStream);
      this.get_an().b().f().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnSaveNLMenuItem(object A_0, EventArgs A_1)
  {
    if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    using (MemoryStream memoryStream = new MemoryStream())
    {
      this.get_an().d().e().g(memoryStream);
      this.get_an().c().e().g(memoryStream);
      this.get_an().b().e().g(memoryStream);
      memoryStream.Position = 0L;
      try
      {
        FileInfo fileInfo = new FileInfo(this.saveFileDialog.FileName);
        if (fileInfo.Exists)
          fileInfo.CopyTo(Path.ChangeExtension(this.saveFileDialog.FileName, "bak"), true);
        using (FileStream fileStream = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
        {
          for (int index = 0; (long) index < memoryStream.Length; ++index)
            fileStream.WriteByte((byte) memoryStream.ReadByte());
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      memoryStream.Close();
    }
  }

  private void OnLoadPPMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().k().c(memoryStream);
        this.get_an().c().k().c(memoryStream);
        this.get_an().b().k().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnLoadUEMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().j().c(memoryStream);
        this.get_an().c().j().c(memoryStream);
        this.get_an().b().j().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnLoadALMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().i().c(memoryStream);
        this.get_an().c().i().c(memoryStream);
        this.get_an().b().i().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnLoadPLMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().h().c(memoryStream);
        this.get_an().c().h().c(memoryStream);
        this.get_an().b().h().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnLoadSLMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().g().c(memoryStream);
        this.get_an().c().g().c(memoryStream);
        this.get_an().b().g().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnLoadTLMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().f().c(memoryStream);
        this.get_an().c().f().c(memoryStream);
        this.get_an().b().f().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnLoadNLMenuItemClick(object A_0, EventArgs A_1)
  {
    if (this.openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
        {
          for (int index = 0; (long) index < fileStream.Length; ++index)
            memoryStream.WriteByte((byte) fileStream.ReadByte());
          fileStream.Close();
        }
        memoryStream.Position = 0L;
        this.get_an().d().e().c(memoryStream);
        this.get_an().c().e().c(memoryStream);
        this.get_an().b().e().c(memoryStream);
        memoryStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnStatisticsButtonClick(object A_0, EventArgs A_1)
  {
    int num = (int) this.u.ShowDialog();
  }

  private void OnNewMenuItemClick(object A_0, EventArgs A_1)
  {
    if (new global::NewLabDialog().ShowDialog() != DialogResult.OK)
      return;
    global::MainWindow.labFileName = "Untitled.lab";
    this.Text = "NetLab - Untitled.lab";
    this.get_an().d().a();
    this.get_an().b().a();
    this.get_an().c().a();
    global::MainWindow.syntaxNumber = (byte) (global::MainWindow.userInfo.variantNumber % 10 + 1);
    global::MainWindow.z = 0;
    global::MainWindow.y = 0;
    global::MainWindow.aa = 0;
    this.loadSyntax();
    global::MainWindow.helpPath = Application.StartupPath + "\\help\\" + global::MainWindow.syntaxNumber.ToString() + ".chm";
    this.networkMenuItem.Checked = false;
    this.get_an().d().e().b((byte) 0);
    this.get_an().b().e().b((byte) 0);
    this.get_an().c().e().b((byte) 0);
    this.transportMenuItem.Checked = true;
    this.get_an().d().f().b(global::MainWindow.syntaxNumber);
    this.get_an().b().f().b(global::MainWindow.syntaxNumber);
    this.get_an().c().f().b(global::MainWindow.syntaxNumber);
    this.sessionMenuItem.Checked = false;
    this.get_an().d().g().b((byte) 0);
    this.get_an().b().g().b((byte) 0);
    this.get_an().c().g().b((byte) 0);
    this.presentationMenuItem.Checked = false;
    this.get_an().d().h().b((byte) 0);
    this.get_an().b().h().b((byte) 0);
    this.get_an().c().h().b((byte) 0);
    this.applicationMenuItem.Checked = false;
    this.get_an().d().i().b((byte) 0);
    this.get_an().b().i().b((byte) 0);
    this.get_an().c().i().b((byte) 0);
    this.ueMenuItem.Checked = false;
    this.get_an().d().j().b((byte) 0);
    this.get_an().b().j().b((byte) 0);
    this.get_an().c().j().b((byte) 0);
    this.apMenuItem.Checked = false;
    this.get_an().d().k().b((byte) 0);
    this.get_an().b().k().b((byte) 0);
    this.get_an().c().k().b((byte) 0);
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = global::MainWindow.realPassword;
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
              if ((int) Convert.ToInt16(str2) == global::MainWindow.userInfo.variantNumber)
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
                      zipFile.Password = global::MainWindow.realPassword;
                      zipFile["Network" + Convert.ToInt16(str3.Substring(0, str3.IndexOf(";"))).ToString() + ".lev"].Extract((Stream) A_0_1);
                      zipFile.Dispose();
                    }
                    A_0_1.Position = 0L;
                    this.get_an().d().e().c(A_0_1);
                    this.get_an().c().e().c(A_0_1);
                    this.get_an().b().e().c(A_0_1);
                    A_0_1.Close();
                  }
                  using (MemoryStream A_0_2 = new MemoryStream())
                  {
                    using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                    {
                      zipFile.CompressionMethod = (CompressionMethod) 8;
                      zipFile.CompressionLevel = (CompressionLevel) 6;
                      zipFile.Encryption = (EncryptionAlgorithm) 3;
                      zipFile.Password = global::MainWindow.realPassword;
                      zipFile["session1.lev"].Extract((Stream) A_0_2);
                      zipFile.Dispose();
                    }
                    A_0_2.Position = 0L;
                    this.get_an().d().g().c(A_0_2);
                    this.get_an().c().g().c(A_0_2);
                    this.get_an().b().g().c(A_0_2);
                    A_0_2.Close();
                  }
                }
                catch (Exception ex)
                {
                  int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                string str4 = str3.Substring(str3.IndexOf(";") + 1);
                this.get_an().d().d().a(Convert.ToInt32(str4.Substring(0, str4.IndexOf(";"))));
                string str5 = str4.Substring(str4.IndexOf(";") + 1);
                this.get_an().d().d().i().b(Convert.ToInt32(str5.Substring(0, str5.IndexOf(";"))));
                string str6 = str5.Substring(str5.IndexOf(";") + 1);
                this.get_an().d().d().i().a(Convert.ToInt32(str6.Substring(0, str6.IndexOf(";"))));
                string str7 = str6.Substring(str6.IndexOf(";") + 1);
                this.get_an().d().d().e(Convert.ToDouble(str7.Substring(0, str7.IndexOf(";"))));
                string str8 = str7.Substring(str7.IndexOf(";") + 1);
                this.get_an().d().d().f().b(Convert.ToInt32(str8.Substring(0, str8.IndexOf(";"))));
                string str9 = str8.Substring(str8.IndexOf(";") + 1);
                this.get_an().d().d().f().a(Convert.ToInt32(str9.Substring(0, str9.IndexOf(";"))));
                string str10 = str9.Substring(str9.IndexOf(";") + 1);
                this.get_an().d().d().g().b(Convert.ToInt32(str10.Substring(0, str10.IndexOf(";"))));
                string str11 = str10.Substring(str10.IndexOf(";") + 1);
                this.get_an().d().d().g().a(Convert.ToInt32(str11.Substring(0, str11.IndexOf(";"))));
                string str12 = str11.Substring(str11.IndexOf(";") + 1);
                this.get_an().d().d().d(Convert.ToDouble(str12.Substring(0, str12.IndexOf(";"))));
                string str13 = str12.Substring(str12.IndexOf(";") + 1);
                this.get_an().d().d().c(Convert.ToDouble(str13.Substring(0, str13.IndexOf(";"))));
                string str14 = str13.Substring(str13.IndexOf(";") + 1);
                this.get_an().d().d().b(Convert.ToDouble(str14.Substring(0, str14.IndexOf(";"))));
                string str15 = str14.Substring(str14.IndexOf(";") + 1);
                this.get_an().d().d().b().b(Convert.ToInt32(str15.Substring(0, str15.IndexOf(";"))));
                string str16 = str15.Substring(str15.IndexOf(";") + 1);
                this.get_an().d().d().b().a(Convert.ToInt32(str16.Substring(0, str16.IndexOf(";"))));
                string str17 = str16.Substring(str16.IndexOf(";") + 1);
                this.get_an().d().d().a(Convert.ToDouble(str17));
                this.get_an().c().d().a(this.get_an().d().d().j());
                this.get_an().c().d().i().b(this.get_an().d().d().i().c());
                this.get_an().c().d().i().a(this.get_an().d().d().i().b());
                this.get_an().c().d().g().b(this.get_an().d().d().g().c());
                this.get_an().c().d().g().a(this.get_an().d().d().g().b());
                this.get_an().c().d().f().b(this.get_an().d().d().f().c());
                this.get_an().c().d().f().a(this.get_an().d().d().f().b());
                this.get_an().c().d().e(this.get_an().d().d().h());
                this.get_an().c().d().d(this.get_an().d().d().e());
                this.get_an().c().d().c(this.get_an().d().d().d());
                this.get_an().c().d().b(this.get_an().d().d().c());
                this.get_an().c().d().b().b(this.get_an().d().d().b().c());
                this.get_an().c().d().b().a(this.get_an().d().d().b().b());
                this.get_an().c().d().a(this.get_an().d().d().a());
                this.get_an().b().d().a(this.get_an().d().d().j());
                this.get_an().b().d().i().b(this.get_an().d().d().i().c());
                this.get_an().b().d().i().a(this.get_an().d().d().i().b());
                this.get_an().b().d().g().b(this.get_an().d().d().g().c());
                this.get_an().b().d().g().a(this.get_an().d().d().g().b());
                this.get_an().b().d().f().b(this.get_an().d().d().f().c());
                this.get_an().b().d().f().a(this.get_an().d().d().f().b());
                this.get_an().b().d().e(this.get_an().d().d().h());
                this.get_an().b().d().d(this.get_an().d().d().e());
                this.get_an().b().d().c(this.get_an().d().d().d());
                this.get_an().b().d().b(this.get_an().d().d().c());
                this.get_an().b().d().b().b(this.get_an().d().d().b().c());
                this.get_an().b().d().b().a(this.get_an().d().d().b().b());
                this.get_an().b().d().a(this.get_an().d().d().a());
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

  private void OnAsymmetricMenuItemClick(object A_0, EventArgs A_1) => global::MainWindow.t = this.asymmetricMenuItem.Checked;

  private void OnDebuggerMenuItemClick(object A_0, EventArgs A_1)
  {
    this.logField.Clear();
    int num = (int) this.debuggerWindow.ShowDialog();
  }

  private void OnSendByMailMenuItemClick(object A_0, EventArgs A_1)
  {
    this.saveLab(Path.GetTempPath() + "\\" + global::MainWindow.userInfo.a + ".lab");
    global::w w = new global::w();
    w.a(Path.GetTempPath() + "\\" + global::MainWindow.userInfo.a + ".lab");
    w.d(global::MainWindow.teacherEmail);
    w.b("task from " + global::MainWindow.userInfo.a, "ready");
  }

  private void StopEmulation(object A_0, EventArgs A_1) => global::an.e = 6;

  private void OnLoadLevelMenuItemClick(object A_0, EventArgs A_1)
  {
  }

  private void OnOptionsMenuItemClick(object A_0, EventArgs A_1)
  {
    global::ap ap = new global::ap();
    int num = (int) ap.ShowDialog();
    ap.Dispose();
    switch (global::MainWindow.al)
    {
      case "res1":
        this.panel11.BackgroundImage = (Image) Resources.dante;
        break;
      case "res2":
        this.panel11.BackgroundImage = (Image) Resources.Rainbow1;
        break;
      default:
        if (System.IO.File.Exists(global::MainWindow.al))
        {
          this.panel11.BackgroundImage = Image.FromFile(global::MainWindow.al);
          break;
        }
        this.panel11.BackgroundImage = (Image) Resources.dante;
        break;
    }
  }

  private void OnLectionsMenuItemClick(object A_0, EventArgs A_1) => new global::n(0, "lec.rtf").Show();

  private void OnSeminar0MenuItemClick(object A_0, EventArgs A_1) => new global::n(1, "sem11.rtf").Show();

  private void OnSeminar1MenuItemClick(object A_0, EventArgs A_1) => new global::n(2, "sem12.rtf").Show();

  private void OnSeminar2MenuItemClick(object A_0, EventArgs A_1) => new global::n(3, "sem2.rtf").Show();

  private void OnSeminar3MenuItemClick(object A_0, EventArgs A_1) => new global::n(4, "sem3.rtf").Show();

  private void OnSeminar4MenuItemClick(object A_0, EventArgs A_1) => new global::n(5, "sem4.rtf").Show();

  private void OnTraceMenuClick(object A_0, EventArgs A_1)
  {
  }

  private void OnTraceMenuItemClick(object A_0, EventArgs A_1) => global::ab.a = this.traceMenuItem.Checked;

  private void OnTransportTraceMenuItemClick(object A_0, EventArgs A_1)
  {
    global::ab.layers[(object) "Transport"] = (object) this.transportTraceMenuItem.Checked;
  }

  private void OnSessionTraceMenuItemClick(object A_0, EventArgs A_1) => global::ab.layers[(object) "Session"] = (object) this.sessionTraceMenuItem.Checked;

  private void OnPresentationTraceStripMenuItemClick(object A_0, EventArgs A_1)
  {
    global::ab.layers[(object) "Presentation"] = (object) this.presentationTraceStripMenuItem.Checked;
  }

  private void OnApplicationTraceStripMenuItemClick(object A_0, EventArgs A_1)
  {
    global::ab.layers[(object) "Application"] = (object) this.applicationTraceStripMenuItem.Checked;
  }

  private void OnUETraceStripMenuItemClick(object A_0, EventArgs A_1) => global::ab.layers[(object) "UE"] = (object) this.ueTraceStripMenuItem.Checked;

  private void OnAPTraceStripMenuItemClick(object A_0, EventArgs A_1) => global::ab.layers[(object) "Process"] = (object) this.apTraceStripMenuItem.Checked;

  private void OnOpenNextLevelMenuItemClick(object A_0, EventArgs A_1)
  {
    if (MessageBox.Show(Resources.NewLevelWarning, Resources.Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
      return;
    if (!this.sessionMenuItem.Checked)
    {
      this.get_an().d().g().b();
      this.get_an().b().g().b();
      this.get_an().c().g().b();
      this.get_an().d().g().b(global::MainWindow.syntaxNumber);
      this.get_an().b().g().b(global::MainWindow.syntaxNumber);
      this.get_an().c().g().b(global::MainWindow.syntaxNumber);
      this.sessionMenuItem.Checked = true;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
          {
            zipFile.CompressionMethod = (CompressionMethod) 8;
            zipFile.CompressionLevel = (CompressionLevel) 6;
            zipFile.Encryption = (EncryptionAlgorithm) 3;
            zipFile.Password = global::MainWindow.realPassword;
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
                if ((int) Convert.ToInt16(str2) == global::MainWindow.userInfo.variantNumber)
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
                        zipFile.Password = global::MainWindow.realPassword;
                        zipFile["presentation" + str4 + ".lev"].Extract((Stream) A_0_1);
                        zipFile.Dispose();
                      }
                      A_0_1.Position = 0L;
                      this.get_an().d().h().c(A_0_1);
                      this.get_an().c().h().c(A_0_1);
                      this.get_an().b().h().c(A_0_1);
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
    else if (!this.presentationMenuItem.Checked)
    {
      this.get_an().d().h().b();
      this.get_an().b().h().b();
      this.get_an().c().h().b();
      this.get_an().d().h().b(global::MainWindow.syntaxNumber);
      this.get_an().b().h().b(global::MainWindow.syntaxNumber);
      this.get_an().c().h().b(global::MainWindow.syntaxNumber);
      this.presentationMenuItem.Checked = true;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
          {
            zipFile.CompressionMethod = (CompressionMethod) 8;
            zipFile.CompressionLevel = (CompressionLevel) 6;
            zipFile.Encryption = (EncryptionAlgorithm) 3;
            zipFile.Password = global::MainWindow.realPassword;
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
                if ((int) Convert.ToInt16(str6) == global::MainWindow.userInfo.variantNumber)
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
                        zipFile.Password = global::MainWindow.realPassword;
                        zipFile["application" + str8 + ".lev"].Extract((Stream) A_0_2);
                        zipFile.Dispose();
                      }
                      A_0_2.Position = 0L;
                      this.get_an().d().i().c(A_0_2);
                      this.get_an().c().i().c(A_0_2);
                      this.get_an().b().i().c(A_0_2);
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
      if (this.applicationMenuItem.Checked)
        return;
      this.get_an().d().i().b();
      this.get_an().b().i().b();
      this.get_an().c().i().b();
      this.get_an().d().i().b(global::MainWindow.syntaxNumber);
      this.get_an().b().i().b(global::MainWindow.syntaxNumber);
      this.applicationMenuItem.Checked = true;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\levels.dsc"))
          {
            zipFile.CompressionMethod = (CompressionMethod) 8;
            zipFile.CompressionLevel = (CompressionLevel) 6;
            zipFile.Encryption = (EncryptionAlgorithm) 3;
            zipFile.Password = global::MainWindow.realPassword;
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
                if ((int) Convert.ToInt16(str10) == global::MainWindow.userInfo.variantNumber)
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
                        zipFile.Password = global::MainWindow.realPassword;
                        zipFile["ue" + str14 + ".lev"].Extract((Stream) A_0_3);
                        zipFile.Dispose();
                      }
                      A_0_3.Position = 0L;
                      this.get_an().d().j().c(A_0_3);
                      this.get_an().c().j().c(A_0_3);
                      this.get_an().b().j().c(A_0_3);
                      A_0_3.Close();
                    }
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  }
                  try
                  {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                      using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\basetest.dsc"))
                      {
                        zipFile.CompressionMethod = (CompressionMethod) 8;
                        zipFile.CompressionLevel = (CompressionLevel) 6;
                        zipFile.Encryption = (EncryptionAlgorithm) 3;
                        zipFile.Password = global::MainWindow.realPassword;
                        zipFile["g" + str12 + ".lev"].Extract((Stream) memoryStream);
                        zipFile.Dispose();
                      }
                      memoryStream.Position = 0L;
                      this.get_an().c().i().c(memoryStream);
                      memoryStream.Close();
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

  private void OnNetworkTraceMenuItemClick(object A_0, EventArgs A_1) => global::ab.layers[(object) "Network"] = (object) this.networkTraceMenuItem.Checked;

  private void updateProgram(object A_0, EventArgs A_1)
  {
    if (!global::MainWindow.checkForUpdates)
      return;
    WebClient webClient = new WebClient();
    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    Stream stream = webClient.OpenRead("http://netlab.front.ru/update.txt");
    StreamReader streamReader = new StreamReader(stream);
    string str = streamReader.ReadLine();
    streamReader.Close();
    stream.Close();
    if (!(str != global::MainWindow.version) || MessageBox.Show("Обновить?", "Обнаружено обновление", MessageBoxButtons.YesNo) != DialogResult.Yes)
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

  private void Initialize()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (global::MainWindow));
    this.panel1 = new Panel();
    this.panel7 = new Panel();
    this.nlSysBButton = new Button();
    this.nlGuideButton = new Button();
    this.nlSysAButton = new Button();
    this.panel8 = new Panel();
    this.panel9 = new Panel();
    this.tlSysBButton = new Button();
    this.slSysBButton = new Button();
    this.plSysBButton = new Button();
    this.alSysBButton = new Button();
    this.panel10 = new Panel();
    this.ueSysBButton = new Button();
    this.apSysBButton = new Button();
    this.label3 = new Label();
    this.panel2 = new Panel();
    this.panel4 = new Panel();
    this.tlSysAButton = new Button();
    this.slSysAButton = new Button();
    this.plSysAButton = new Button();
    this.alSysAButton = new Button();
    this.panel3 = new Panel();
    this.ueSysAButton = new Button();
    this.apSysAButton = new Button();
    this.label1 = new Label();
    this.panel5 = new Panel();
    this.panel6 = new Panel();
    this.tlGuideButton = new Button();
    this.slGuideButton = new Button();
    this.plGuideButton = new Button();
    this.alGuideButton = new Button();
    this.label2 = new Label();
    this.mainMenu = new MenuStrip();
    this.fileMenu = new ToolStripMenuItem();
    this.newMenuItem = new ToolStripMenuItem();
    this.openMenuItem = new ToolStripMenuItem();
    this.saveMenuItem = new ToolStripMenuItem();
    this.saveAsMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator5 = new ToolStripSeparator();
    this.openNextLevelMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator1 = new ToolStripSeparator();
    this.exitMenuItem = new ToolStripMenuItem();
    this.specialSeparator = new ToolStripSeparator();
    this.saveLevelMenuItem = new ToolStripMenuItem();
    this.saveAPMenuItem = new ToolStripMenuItem();
    this.saveUEMenuItem = new ToolStripMenuItem();
    this.saveALMenuItem = new ToolStripMenuItem();
    this.savePLMenuItem = new ToolStripMenuItem();
    this.saveSLMenuItem = new ToolStripMenuItem();
    this.saveTLMenuItem = new ToolStripMenuItem();
    this.saveNLMenuItem = new ToolStripMenuItem();
    this.loadLevelMenuItem = new ToolStripMenuItem();
    this.loadPPMenuItem = new ToolStripMenuItem();
    this.loadUEMenuItem = new ToolStripMenuItem();
    this.loadALMenuItem = new ToolStripMenuItem();
    this.loadPLMenuItem = new ToolStripMenuItem();
    this.loadSLMenuItem = new ToolStripMenuItem();
    this.loadTLMenuItem = new ToolStripMenuItem();
    this.loadNLMenuItem = new ToolStripMenuItem();
    this.sendByMailMenuItem = new ToolStripMenuItem();
    this.optionsMenu = new ToolStripMenuItem();
    this.optionsMenuItem = new ToolStripMenuItem();
    this.netEmuOptionsMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator2 = new ToolStripSeparator();
    this.passwordMenuItem = new ToolStripMenuItem();
    this.debugMenu = new ToolStripMenuItem();
    this.debuggerMenuItem = new ToolStripMenuItem();
    this.traceMenu = new ToolStripMenuItem();
    this.traceMenuItem = new ToolStripMenuItem();
    this.toolStrippSeparator4 = new ToolStripSeparator();
    this.networkTraceMenuItem = new ToolStripMenuItem();
    this.transportTraceMenuItem = new ToolStripMenuItem();
    this.sessionTraceMenuItem = new ToolStripMenuItem();
    this.presentationTraceStripMenuItem = new ToolStripMenuItem();
    this.applicationTraceStripMenuItem = new ToolStripMenuItem();
    this.ueTraceStripMenuItem = new ToolStripMenuItem();
    this.apTraceStripMenuItem = new ToolStripMenuItem();
    this.logMenuItemsGroup = new ToolStripMenuItem();
    this.nLogMenuItem = new ToolStripMenuItem();
    this.tLogMenuItem = new ToolStripMenuItem();
    this.sLogMenuItem = new ToolStripMenuItem();
    this.pLogMenuItem = new ToolStripMenuItem();
    this.aLogMenuItem = new ToolStripMenuItem();
    this.ueLogMenuItem = new ToolStripMenuItem();
    this.apLogMenuItem = new ToolStripMenuItem();
    this.levelsMenu = new ToolStripMenuItem();
    this.apMenuItem = new ToolStripMenuItem();
    this.ueMenuItem = new ToolStripMenuItem();
    this.applicationMenuItem = new ToolStripMenuItem();
    this.presentationMenuItem = new ToolStripMenuItem();
    this.sessionMenuItem = new ToolStripMenuItem();
    this.transportMenuItem = new ToolStripMenuItem();
    this.networkMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator3 = new ToolStripSeparator();
    this.allMenuItem = new ToolStripMenuItem();
    this.asymmetricMenuItem = new ToolStripMenuItem();
    this.helpMenu = new ToolStripMenuItem();
    this.aboutMenuItem = new ToolStripMenuItem();
    this.lectionsMenuItem = new ToolStripMenuItem();
    this.seminar0MenuItem = new ToolStripMenuItem();
    this.seminar1MenuItem = new ToolStripMenuItem();
    this.seminar2MenuItem = new ToolStripMenuItem();
    this.seminar3MenuItem = new ToolStripMenuItem();
    this.seminar4MenuItem = new ToolStripMenuItem();
    this.logField = new TextBox();
    this.panel11 = new Panel();
    this.panel12 = new Panel();
    this.label4 = new Label();
    this.exitButton = new Button();
    this.statisticsButton = new Button();
    this.stopEmulationButton = new Button();
    this.startEmulationButton = new Button();
    this.saveFileDialog = new SaveFileDialog();
    this.openFileDialog = new OpenFileDialog();
    this.panel1.SuspendLayout();
    this.panel7.SuspendLayout();
    this.panel8.SuspendLayout();
    this.panel9.SuspendLayout();
    this.panel10.SuspendLayout();
    this.panel2.SuspendLayout();
    this.panel4.SuspendLayout();
    this.panel3.SuspendLayout();
    this.panel5.SuspendLayout();
    this.panel6.SuspendLayout();
    this.mainMenu.SuspendLayout();
    this.panel11.SuspendLayout();
    this.panel12.SuspendLayout();
    this.SuspendLayout();
    this.panel1.BorderStyle = BorderStyle.Fixed3D;
    this.panel1.Controls.Add((Control) this.panel7);
    this.panel1.Controls.Add((Control) this.panel8);
    this.panel1.Controls.Add((Control) this.panel2);
    this.panel1.Controls.Add((Control) this.panel5);
    this.panel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.panel1.Location = new Point(0, 24);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(482, 335);
    this.panel1.TabIndex = 1;
    this.panel7.BorderStyle = BorderStyle.FixedSingle;
    this.panel7.Controls.Add((Control) this.nlSysBButton);
    this.panel7.Controls.Add((Control) this.nlGuideButton);
    this.panel7.Controls.Add((Control) this.nlSysAButton);
    this.panel7.Cursor = Cursors.SizeWE;
    this.panel7.Location = new Point(18, 268);
    this.panel7.Name = "panel7";
    this.panel7.Size = new Size(443, 37);
    this.panel7.TabIndex = 3;
    this.nlSysBButton.Cursor = Cursors.SizeWE;
    this.nlSysBButton.Enabled = false;
    this.nlSysBButton.FlatStyle = FlatStyle.Flat;
    this.nlSysBButton.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.nlSysBButton.Location = new Point(321, 3);
    this.nlSysBButton.Name = "NLSysBButton";
    this.nlSysBButton.Size = new Size(115, 28);
    this.nlSysBButton.TabIndex = 6;
    this.nlSysBButton.Text = "Сетевой";
    this.nlSysBButton.UseVisualStyleBackColor = true;
    this.nlSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.nlGuideButton.Cursor = Cursors.SizeWE;
    this.nlGuideButton.Enabled = false;
    this.nlGuideButton.FlatStyle = FlatStyle.Flat;
    this.nlGuideButton.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.nlGuideButton.Location = new Point(162, 3);
    this.nlGuideButton.Name = "NLGuideButton";
    this.nlGuideButton.Size = new Size(115, 28);
    this.nlGuideButton.TabIndex = 5;
    this.nlGuideButton.Text = "Сетевой";
    this.nlGuideButton.UseVisualStyleBackColor = true;
    this.nlGuideButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.nlSysAButton.Cursor = Cursors.SizeWE;
    this.nlSysAButton.Enabled = false;
    this.nlSysAButton.FlatStyle = FlatStyle.Flat;
    this.nlSysAButton.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.nlSysAButton.Location = new Point(3, 3);
    this.nlSysAButton.Name = "NLSysAButton";
    this.nlSysAButton.Size = new Size(115, 28);
    this.nlSysAButton.TabIndex = 4;
    this.nlSysAButton.Text = "Сетевой";
    this.nlSysAButton.UseVisualStyleBackColor = true;
    this.nlSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.panel8.BorderStyle = BorderStyle.FixedSingle;
    this.panel8.Controls.Add((Control) this.panel9);
    this.panel8.Controls.Add((Control) this.panel10);
    this.panel8.Controls.Add((Control) this.label3);
    this.panel8.Location = new Point(328, 12);
    this.panel8.Name = "panel8";
    this.panel8.Size = new Size(142, 310);
    this.panel8.TabIndex = 2;
    this.panel9.BorderStyle = BorderStyle.FixedSingle;
    this.panel9.Controls.Add((Control) this.tlSysBButton);
    this.panel9.Controls.Add((Control) this.slSysBButton);
    this.panel9.Controls.Add((Control) this.plSysBButton);
    this.panel9.Controls.Add((Control) this.alSysBButton);
    this.panel9.Cursor = Cursors.SizeNS;
    this.panel9.Location = new Point(3, 96);
    this.panel9.Name = "panel9";
    this.panel9.Size = new Size(133, 206);
    this.panel9.TabIndex = 2;
    this.tlSysBButton.BackColor = SystemColors.Control;
    this.tlSysBButton.Cursor = Cursors.Default;
    this.tlSysBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.tlSysBButton.FlatStyle = FlatStyle.Flat;
    this.tlSysBButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.tlSysBButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.tlSysBButton.Location = new Point(4, 105);
    this.tlSysBButton.Name = "TLSysBButton";
    this.tlSysBButton.Size = new Size(123, 28);
    this.tlSysBButton.TabIndex = 3;
    this.tlSysBButton.Text = "Транспортный";
    this.tlSysBButton.UseVisualStyleBackColor = false;
    this.tlSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.slSysBButton.BackColor = SystemColors.Control;
    this.slSysBButton.Cursor = Cursors.Default;
    this.slSysBButton.Enabled = false;
    this.slSysBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.slSysBButton.FlatStyle = FlatStyle.Flat;
    this.slSysBButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.slSysBButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.slSysBButton.Location = new Point(4, 71);
    this.slSysBButton.Name = "SLSysBButton";
    this.slSysBButton.Size = new Size(123, 28);
    this.slSysBButton.TabIndex = 2;
    this.slSysBButton.Text = "Сеансовый";
    this.slSysBButton.UseVisualStyleBackColor = false;
    this.slSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.plSysBButton.BackColor = SystemColors.Control;
    this.plSysBButton.Cursor = Cursors.Default;
    this.plSysBButton.Enabled = false;
    this.plSysBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.plSysBButton.FlatStyle = FlatStyle.Flat;
    this.plSysBButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.plSysBButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.plSysBButton.Location = new Point(4, 37);
    this.plSysBButton.Name = "PLSysBButton";
    this.plSysBButton.Size = new Size(123, 28);
    this.plSysBButton.TabIndex = 1;
    this.plSysBButton.Text = "Представления";
    this.plSysBButton.UseVisualStyleBackColor = false;
    this.plSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.alSysBButton.BackColor = SystemColors.Control;
    this.alSysBButton.Cursor = Cursors.Default;
    this.alSysBButton.Enabled = false;
    this.alSysBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.alSysBButton.FlatStyle = FlatStyle.Flat;
    this.alSysBButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.alSysBButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.alSysBButton.Location = new Point(4, 3);
    this.alSysBButton.Name = "ALSysBButton";
    this.alSysBButton.Size = new Size(123, 28);
    this.alSysBButton.TabIndex = 0;
    this.alSysBButton.Text = "Прикладной";
    this.alSysBButton.UseVisualStyleBackColor = false;
    this.alSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.panel10.BorderStyle = BorderStyle.FixedSingle;
    this.panel10.Controls.Add((Control) this.ueSysBButton);
    this.panel10.Controls.Add((Control) this.apSysBButton);
    this.panel10.Cursor = Cursors.SizeNS;
    this.panel10.Location = new Point(3, 19);
    this.panel10.Name = "panel10";
    this.panel10.Size = new Size(133, 71);
    this.panel10.TabIndex = 1;
    this.ueSysBButton.BackColor = SystemColors.Control;
    this.ueSysBButton.Cursor = Cursors.Default;
    this.ueSysBButton.Enabled = false;
    this.ueSysBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.ueSysBButton.FlatStyle = FlatStyle.Flat;
    this.ueSysBButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.ueSysBButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.ueSysBButton.Location = new Point(4, 37);
    this.ueSysBButton.Name = "UESysBButton";
    this.ueSysBButton.Size = new Size(123, 28);
    this.ueSysBButton.TabIndex = 2;
    this.ueSysBButton.Text = "ЭП";
    this.ueSysBButton.UseVisualStyleBackColor = false;
    this.ueSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.apSysBButton.BackColor = SystemColors.Control;
    this.apSysBButton.Cursor = Cursors.Default;
    this.apSysBButton.Enabled = false;
    this.apSysBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.apSysBButton.FlatStyle = FlatStyle.Flat;
    this.apSysBButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.apSysBButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.apSysBButton.Location = new Point(4, 3);
    this.apSysBButton.Name = "APSysBButton";
    this.apSysBButton.Size = new Size(123, 28);
    this.apSysBButton.TabIndex = 1;
    this.apSysBButton.Text = "ПП";
    this.apSysBButton.UseVisualStyleBackColor = false;
    this.apSysBButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.label3.Anchor = AnchorStyles.None;
    this.label3.AutoSize = true;
    this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.label3.Location = new Point(20, 3);
    this.label3.Name = "label3";
    this.label3.Size = new Size(84, 16);
    this.label3.TabIndex = 0;
    this.label3.Text = "Система В";
    this.panel2.BorderStyle = BorderStyle.FixedSingle;
    this.panel2.Controls.Add((Control) this.panel4);
    this.panel2.Controls.Add((Control) this.panel3);
    this.panel2.Controls.Add((Control) this.label1);
    this.panel2.Location = new Point(10, 12);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(142, 310);
    this.panel2.TabIndex = 0;
    this.panel4.BorderStyle = BorderStyle.FixedSingle;
    this.panel4.Controls.Add((Control) this.tlSysAButton);
    this.panel4.Controls.Add((Control) this.slSysAButton);
    this.panel4.Controls.Add((Control) this.plSysAButton);
    this.panel4.Controls.Add((Control) this.alSysAButton);
    this.panel4.Cursor = Cursors.SizeNS;
    this.panel4.Location = new Point(3, 96);
    this.panel4.Name = "panel4";
    this.panel4.Size = new Size(133, 206);
    this.panel4.TabIndex = 2;
    this.tlSysAButton.BackColor = SystemColors.Control;
    this.tlSysAButton.Cursor = Cursors.Default;
    this.tlSysAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.tlSysAButton.FlatStyle = FlatStyle.Flat;
    this.tlSysAButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.tlSysAButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.tlSysAButton.Location = new Point(4, 105);
    this.tlSysAButton.Name = "TLSysAButton";
    this.tlSysAButton.Size = new Size(123, 28);
    this.tlSysAButton.TabIndex = 3;
    this.tlSysAButton.Text = "Транспортный";
    this.tlSysAButton.UseVisualStyleBackColor = false;
    this.tlSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.slSysAButton.BackColor = SystemColors.Control;
    this.slSysAButton.Cursor = Cursors.Default;
    this.slSysAButton.Enabled = false;
    this.slSysAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.slSysAButton.FlatStyle = FlatStyle.Flat;
    this.slSysAButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.slSysAButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.slSysAButton.Location = new Point(4, 71);
    this.slSysAButton.Name = "SLSysAButton";
    this.slSysAButton.Size = new Size(123, 28);
    this.slSysAButton.TabIndex = 2;
    this.slSysAButton.Text = "Сеансовый";
    this.slSysAButton.UseVisualStyleBackColor = false;
    this.slSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.plSysAButton.BackColor = SystemColors.Control;
    this.plSysAButton.Cursor = Cursors.Default;
    this.plSysAButton.Enabled = false;
    this.plSysAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.plSysAButton.FlatStyle = FlatStyle.Flat;
    this.plSysAButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.plSysAButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.plSysAButton.Location = new Point(4, 37);
    this.plSysAButton.Name = "PLSysAButton";
    this.plSysAButton.Size = new Size(123, 28);
    this.plSysAButton.TabIndex = 1;
    this.plSysAButton.Text = "Представления";
    this.plSysAButton.UseVisualStyleBackColor = false;
    this.plSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.alSysAButton.BackColor = SystemColors.Control;
    this.alSysAButton.Cursor = Cursors.Default;
    this.alSysAButton.Enabled = false;
    this.alSysAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.alSysAButton.FlatStyle = FlatStyle.Flat;
    this.alSysAButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.alSysAButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.alSysAButton.Location = new Point(4, 3);
    this.alSysAButton.Name = "ALSysAButton";
    this.alSysAButton.Size = new Size(123, 28);
    this.alSysAButton.TabIndex = 0;
    this.alSysAButton.Text = "Прикладной";
    this.alSysAButton.UseVisualStyleBackColor = false;
    this.alSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.panel3.BorderStyle = BorderStyle.FixedSingle;
    this.panel3.Controls.Add((Control) this.ueSysAButton);
    this.panel3.Controls.Add((Control) this.apSysAButton);
    this.panel3.Location = new Point(3, 19);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(133, 71);
    this.panel3.TabIndex = 1;
    this.ueSysAButton.BackColor = SystemColors.Control;
    this.ueSysAButton.Enabled = false;
    this.ueSysAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.ueSysAButton.FlatStyle = FlatStyle.Flat;
    this.ueSysAButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.ueSysAButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.ueSysAButton.Location = new Point(4, 37);
    this.ueSysAButton.Name = "UESysAButton";
    this.ueSysAButton.Size = new Size(123, 28);
    this.ueSysAButton.TabIndex = 2;
    this.ueSysAButton.Text = "ЭП";
    this.ueSysAButton.UseVisualStyleBackColor = false;
    this.ueSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.apSysAButton.BackColor = SystemColors.Control;
    this.apSysAButton.Enabled = false;
    this.apSysAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.apSysAButton.FlatStyle = FlatStyle.Flat;
    this.apSysAButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.apSysAButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.apSysAButton.Location = new Point(4, 3);
    this.apSysAButton.Name = "APSysAButton";
    this.apSysAButton.Size = new Size(123, 28);
    this.apSysAButton.TabIndex = 1;
    this.apSysAButton.Text = "ПП";
    this.apSysAButton.UseVisualStyleBackColor = false;
    this.apSysAButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.label1.Anchor = AnchorStyles.None;
    this.label1.AutoSize = true;
    this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.label1.Location = new Point(20, 3);
    this.label1.Name = "label1";
    this.label1.Size = new Size(84, 16);
    this.label1.TabIndex = 0;
    this.label1.Text = "Система А";
    this.panel5.BorderStyle = BorderStyle.FixedSingle;
    this.panel5.Controls.Add((Control) this.panel6);
    this.panel5.Controls.Add((Control) this.label2);
    this.panel5.Location = new Point(169, 12);
    this.panel5.Name = "panel5";
    this.panel5.Size = new Size(142, 310);
    this.panel5.TabIndex = 1;
    this.panel6.BorderStyle = BorderStyle.FixedSingle;
    this.panel6.Controls.Add((Control) this.tlGuideButton);
    this.panel6.Controls.Add((Control) this.slGuideButton);
    this.panel6.Controls.Add((Control) this.plGuideButton);
    this.panel6.Controls.Add((Control) this.alGuideButton);
    this.panel6.Cursor = Cursors.SizeNS;
    this.panel6.Location = new Point(3, 96);
    this.panel6.Name = "panel6";
    this.panel6.Size = new Size(133, 206);
    this.panel6.TabIndex = 2;
    this.tlGuideButton.BackColor = SystemColors.Control;
    this.tlGuideButton.Cursor = Cursors.Default;
    this.tlGuideButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.tlGuideButton.FlatStyle = FlatStyle.Flat;
    this.tlGuideButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.tlGuideButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.tlGuideButton.Location = new Point(4, 105);
    this.tlGuideButton.Name = "TLGuideButton";
    this.tlGuideButton.Size = new Size(123, 28);
    this.tlGuideButton.TabIndex = 3;
    this.tlGuideButton.Text = "Транспортный";
    this.tlGuideButton.UseVisualStyleBackColor = false;
    this.tlGuideButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.slGuideButton.BackColor = SystemColors.Control;
    this.slGuideButton.Cursor = Cursors.Default;
    this.slGuideButton.Enabled = false;
    this.slGuideButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.slGuideButton.FlatStyle = FlatStyle.Flat;
    this.slGuideButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.slGuideButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.slGuideButton.Location = new Point(4, 71);
    this.slGuideButton.Name = "SLGuideButton";
    this.slGuideButton.Size = new Size(123, 28);
    this.slGuideButton.TabIndex = 2;
    this.slGuideButton.Text = "Сеансовый";
    this.slGuideButton.UseVisualStyleBackColor = false;
    this.slGuideButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.plGuideButton.BackColor = SystemColors.Control;
    this.plGuideButton.Cursor = Cursors.Default;
    this.plGuideButton.Enabled = false;
    this.plGuideButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.plGuideButton.FlatStyle = FlatStyle.Flat;
    this.plGuideButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.plGuideButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.plGuideButton.Location = new Point(4, 37);
    this.plGuideButton.Name = "PLGuideButton";
    this.plGuideButton.Size = new Size(123, 28);
    this.plGuideButton.TabIndex = 1;
    this.plGuideButton.Text = "Представления";
    this.plGuideButton.UseVisualStyleBackColor = false;
    this.plGuideButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.alGuideButton.BackColor = SystemColors.Control;
    this.alGuideButton.Cursor = Cursors.Default;
    this.alGuideButton.Enabled = false;
    this.alGuideButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
    this.alGuideButton.FlatStyle = FlatStyle.Flat;
    this.alGuideButton.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
    this.alGuideButton.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
    this.alGuideButton.Location = new Point(4, 3);
    this.alGuideButton.Name = "ALGuideButton";
    this.alGuideButton.Size = new Size(123, 28);
    this.alGuideButton.TabIndex = 0;
    this.alGuideButton.Text = "Прикладной";
    this.alGuideButton.UseVisualStyleBackColor = false;
    this.alGuideButton.Click += new EventHandler(this.OnLayerButtonClick);
    this.label2.Anchor = AnchorStyles.None;
    this.label2.AutoSize = true;
    this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.label2.Location = new Point(20, 3);
    this.label2.Name = "label2";
    this.label2.Size = new Size(97, 16);
    this.label2.TabIndex = 0;
    this.label2.Text = "Справочник";
    this.mainMenu.Items.AddRange(new ToolStripItem[5]
    {
      (ToolStripItem) this.fileMenu,
      (ToolStripItem) this.optionsMenu,
      (ToolStripItem) this.debugMenu,
      (ToolStripItem) this.levelsMenu,
      (ToolStripItem) this.helpMenu
    });
    this.mainMenu.Location = new Point(0, 0);
    this.mainMenu.Name = "MainMenu";
    this.mainMenu.Size = new Size(616, 24);
    this.mainMenu.TabIndex = 1;
    this.fileMenu.DropDownItems.AddRange(new ToolStripItem[12]
    {
      (ToolStripItem) this.newMenuItem,
      (ToolStripItem) this.openMenuItem,
      (ToolStripItem) this.saveMenuItem,
      (ToolStripItem) this.saveAsMenuItem,
      (ToolStripItem) this.toolStripSeparator5,
      (ToolStripItem) this.openNextLevelMenuItem,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.exitMenuItem,
      (ToolStripItem) this.specialSeparator,
      (ToolStripItem) this.saveLevelMenuItem,
      (ToolStripItem) this.loadLevelMenuItem,
      (ToolStripItem) this.sendByMailMenuItem
    });
    this.fileMenu.Name = "FileMenu";
    this.fileMenu.Size = new Size(48, 20);
    this.fileMenu.Text = "Файл";
    this.newMenuItem.Image = (Image) componentResourceManager.GetObject("NewMenuItem.Image");
    this.newMenuItem.Name = "NewMenuItem";
    this.newMenuItem.ShortcutKeys = Keys.N | Keys.Control;
    this.newMenuItem.Size = new Size(234, 22);
    this.newMenuItem.Text = "Создать";
    this.newMenuItem.Click += new EventHandler(this.OnNewMenuItemClick);
    this.openMenuItem.Image = (Image) componentResourceManager.GetObject("OpenMenuItem.Image");
    this.openMenuItem.Name = "OpenMenuItem";
    this.openMenuItem.ShortcutKeys = Keys.O | Keys.Control;
    this.openMenuItem.Size = new Size(234, 22);
    this.openMenuItem.Text = "Открыть";
    this.openMenuItem.Click += new EventHandler(this.OnOpenMenuItemClick);
    this.saveMenuItem.Image = (Image) componentResourceManager.GetObject("SaveMenuItem.Image");
    this.saveMenuItem.Name = "SaveMenuItem";
    this.saveMenuItem.ShortcutKeys = Keys.S | Keys.Control;
    this.saveMenuItem.Size = new Size(234, 22);
    this.saveMenuItem.Text = "Сохранить";
    this.saveMenuItem.Click += new EventHandler(this.OnSaveMenuItemClick);
    this.saveAsMenuItem.Name = "SaveAsMenuItem";
    this.saveAsMenuItem.Size = new Size(234, 22);
    this.saveAsMenuItem.Text = "Сохранить как ...";
    this.saveAsMenuItem.Click += new EventHandler(this.OnSaveAsMenuItemClick);
    this.toolStripSeparator5.Name = "toolStripSeparator5";
    this.toolStripSeparator5.Size = new Size(231, 6);
    this.openNextLevelMenuItem.Name = "OpenNextLevelMenuItem";
    this.openNextLevelMenuItem.Size = new Size(234, 22);
    this.openNextLevelMenuItem.Text = "Открыть следующее задание";
    this.openNextLevelMenuItem.Click += new EventHandler(this.OnOpenNextLevelMenuItemClick);
    this.toolStripSeparator1.Name = "toolStripSeparator1";
    this.toolStripSeparator1.Size = new Size(231, 6);
    this.exitMenuItem.Name = "ExitMenuItem";
    this.exitMenuItem.ShortcutKeys = Keys.X | Keys.Alt;
    this.exitMenuItem.Size = new Size(234, 22);
    this.exitMenuItem.Text = "Выход";
    this.exitMenuItem.Click += new EventHandler(this.OnExitMenuItemClick);
    this.specialSeparator.Name = "SpecialSeparator";
    this.specialSeparator.Size = new Size(231, 6);
    this.specialSeparator.Visible = false;
    this.saveLevelMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.saveAPMenuItem,
      (ToolStripItem) this.saveUEMenuItem,
      (ToolStripItem) this.saveALMenuItem,
      (ToolStripItem) this.savePLMenuItem,
      (ToolStripItem) this.saveSLMenuItem,
      (ToolStripItem) this.saveTLMenuItem,
      (ToolStripItem) this.saveNLMenuItem
    });
    this.saveLevelMenuItem.Name = "SaveLevelMenuItem";
    this.saveLevelMenuItem.Size = new Size(234, 22);
    this.saveLevelMenuItem.Text = "Сохранить уровень";
    this.saveLevelMenuItem.Visible = false;
    this.saveAPMenuItem.Name = "SaveAPMenuItem";
    this.saveAPMenuItem.Size = new Size(205, 22);
    this.saveAPMenuItem.Text = "Прикладной процесс";
    this.saveAPMenuItem.Click += new EventHandler(this.OnSaveAPMenuItem);
    this.saveUEMenuItem.Name = "SaveUEMenuItem";
    this.saveUEMenuItem.Size = new Size(205, 22);
    this.saveUEMenuItem.Text = "Элемент пользователя";
    this.saveUEMenuItem.Click += new EventHandler(this.OnSaveUEMenuItem);
    this.saveALMenuItem.Name = "SaveALMenuItem";
    this.saveALMenuItem.Size = new Size(205, 22);
    this.saveALMenuItem.Text = "Прикладной уровень";
    this.saveALMenuItem.Click += new EventHandler(this.OnSaveALMenuItem);
    this.savePLMenuItem.Name = "SavePLMenuItem";
    this.savePLMenuItem.Size = new Size(205, 22);
    this.savePLMenuItem.Text = "Уровень представления";
    this.savePLMenuItem.Click += new EventHandler(this.OnSavePLMenuItem);
    this.saveSLMenuItem.Name = "SaveSLMenuItem";
    this.saveSLMenuItem.Size = new Size(205, 22);
    this.saveSLMenuItem.Text = "Сеансовый уровень";
    this.saveSLMenuItem.Click += new EventHandler(this.OnSaveSLMenuItem);
    this.saveTLMenuItem.Name = "SaveTLMenuItem";
    this.saveTLMenuItem.Size = new Size(205, 22);
    this.saveTLMenuItem.Text = "Транспортный уровень";
    this.saveTLMenuItem.Click += new EventHandler(this.OnSaveTLMenuItem);
    this.saveNLMenuItem.Name = "SaveNLMenuItem";
    this.saveNLMenuItem.Size = new Size(205, 22);
    this.saveNLMenuItem.Text = "Сетевой уровень";
    this.saveNLMenuItem.Click += new EventHandler(this.OnSaveNLMenuItem);
    this.loadLevelMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.loadPPMenuItem,
      (ToolStripItem) this.loadUEMenuItem,
      (ToolStripItem) this.loadALMenuItem,
      (ToolStripItem) this.loadPLMenuItem,
      (ToolStripItem) this.loadSLMenuItem,
      (ToolStripItem) this.loadTLMenuItem,
      (ToolStripItem) this.loadNLMenuItem
    });
    this.loadLevelMenuItem.Name = "LoadLevelMenuItem";
    this.loadLevelMenuItem.Size = new Size(234, 22);
    this.loadLevelMenuItem.Text = "Загрузить уровень";
    this.loadLevelMenuItem.Visible = false;
    this.loadLevelMenuItem.Click += new EventHandler(this.OnLoadLevelMenuItemClick);
    this.loadPPMenuItem.Name = "LoadPPMenuItem";
    this.loadPPMenuItem.Size = new Size(205, 22);
    this.loadPPMenuItem.Text = "Прикладной процесс";
    this.loadPPMenuItem.Click += new EventHandler(this.OnLoadPPMenuItemClick);
    this.loadUEMenuItem.Name = "LoadUEMenuItem";
    this.loadUEMenuItem.Size = new Size(205, 22);
    this.loadUEMenuItem.Text = "Элемент пользователя";
    this.loadUEMenuItem.Click += new EventHandler(this.OnLoadUEMenuItemClick);
    this.loadALMenuItem.Name = "LoadALMenuItem";
    this.loadALMenuItem.Size = new Size(205, 22);
    this.loadALMenuItem.Text = "Прикладной уровень";
    this.loadALMenuItem.Click += new EventHandler(this.OnLoadALMenuItemClick);
    this.loadPLMenuItem.Name = "LoadPLMenuItem";
    this.loadPLMenuItem.Size = new Size(205, 22);
    this.loadPLMenuItem.Text = "Уровень представления";
    this.loadPLMenuItem.Click += new EventHandler(this.OnLoadPLMenuItemClick);
    this.loadSLMenuItem.Name = "LoadSLMenuItem";
    this.loadSLMenuItem.Size = new Size(205, 22);
    this.loadSLMenuItem.Text = "Сеансовый уровень";
    this.loadSLMenuItem.Click += new EventHandler(this.OnLoadSLMenuItemClick);
    this.loadTLMenuItem.Name = "LoadTLMenuItem";
    this.loadTLMenuItem.Size = new Size(205, 22);
    this.loadTLMenuItem.Text = "Транспортный уровень";
    this.loadTLMenuItem.Click += new EventHandler(this.OnLoadTLMenuItemClick);
    this.loadNLMenuItem.Name = "LoadNLMenuItem";
    this.loadNLMenuItem.Size = new Size(205, 22);
    this.loadNLMenuItem.Text = "Сетевой уровень";
    this.loadNLMenuItem.Click += new EventHandler(this.OnLoadNLMenuItemClick);
    this.sendByMailMenuItem.Name = "SendByMailMenuItem";
    this.sendByMailMenuItem.Size = new Size(234, 22);
    this.sendByMailMenuItem.Text = "Переслать по почте";
    this.sendByMailMenuItem.Visible = false;
    this.sendByMailMenuItem.Click += new EventHandler(this.OnSendByMailMenuItemClick);
    this.optionsMenu.DropDownItems.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.optionsMenuItem,
      (ToolStripItem) this.netEmuOptionsMenuItem,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.passwordMenuItem
    });
    this.optionsMenu.Name = "OptionsMenu";
    this.optionsMenu.Size = new Size(83, 20);
    this.optionsMenu.Text = "Параметры";
    this.optionsMenuItem.Name = "OptionsMenuItem";
    this.optionsMenuItem.Size = new Size(213, 22);
    this.optionsMenuItem.Text = "Параметры комплекса ...";
    this.optionsMenuItem.Click += new EventHandler(this.OnOptionsMenuItemClick);
    this.netEmuOptionsMenuItem.Name = "NetEmuOptionsMenuItem";
    this.netEmuOptionsMenuItem.Size = new Size(213, 22);
    this.netEmuOptionsMenuItem.Text = "Параметры эмулятора ...";
    this.netEmuOptionsMenuItem.Click += new EventHandler(this.OnNetEmuOptionsMenuItemClick);
    this.toolStripSeparator2.Name = "toolStripSeparator2";
    this.toolStripSeparator2.Size = new Size(210, 6);
    this.passwordMenuItem.Name = "PasswordMenuItem";
    this.passwordMenuItem.Size = new Size(213, 22);
    this.passwordMenuItem.Text = "Пароль";
    this.passwordMenuItem.Click += new EventHandler(this.OnPasswordMenuItemClick);
    this.debugMenu.DropDownItems.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.debuggerMenuItem,
      (ToolStripItem) this.traceMenu,
      (ToolStripItem) this.logMenuItemsGroup
    });
    this.debugMenu.Name = "DebugMenu";
    this.debugMenu.Size = new Size(64, 20);
    this.debugMenu.Text = "Отладка";
    this.debuggerMenuItem.Name = "DebuggerMenuItem";
    this.debuggerMenuItem.Size = new Size(157, 22);
    this.debuggerMenuItem.Text = "Отладчик";
    this.debuggerMenuItem.Click += new EventHandler(this.OnDebuggerMenuItemClick);
    this.traceMenu.DropDownItems.AddRange(new ToolStripItem[9]
    {
      (ToolStripItem) this.traceMenuItem,
      (ToolStripItem) this.toolStrippSeparator4,
      (ToolStripItem) this.networkTraceMenuItem,
      (ToolStripItem) this.transportTraceMenuItem,
      (ToolStripItem) this.sessionTraceMenuItem,
      (ToolStripItem) this.presentationTraceStripMenuItem,
      (ToolStripItem) this.applicationTraceStripMenuItem,
      (ToolStripItem) this.ueTraceStripMenuItem,
      (ToolStripItem) this.apTraceStripMenuItem
    });
    this.traceMenu.Name = "TraceMenu";
    this.traceMenu.Size = new Size(157, 22);
    this.traceMenu.Text = "Трассировка";
    this.traceMenu.Click += new EventHandler(this.OnTraceMenuClick);
    this.traceMenuItem.CheckOnClick = true;
    this.traceMenuItem.Name = "TraceMenuItem";
    this.traceMenuItem.Size = new Size(199, 22);
    this.traceMenuItem.Text = "Включить";
    this.traceMenuItem.Click += new EventHandler(this.OnTraceMenuItemClick);
    this.toolStrippSeparator4.Name = "toolStripSeparator4";
    this.toolStrippSeparator4.Size = new Size(196, 6);
    this.networkTraceMenuItem.CheckOnClick = true;
    this.networkTraceMenuItem.Name = "NetworkTraceMenuItem";
    this.networkTraceMenuItem.Size = new Size(199, 22);
    this.networkTraceMenuItem.Text = "Сетевой";
    this.networkTraceMenuItem.Click += new EventHandler(this.OnNetworkTraceMenuItemClick);
    this.transportTraceMenuItem.CheckOnClick = true;
    this.transportTraceMenuItem.Name = "TransportTraceMenuItem";
    this.transportTraceMenuItem.Size = new Size(199, 22);
    this.transportTraceMenuItem.Text = "Транспортный";
    this.transportTraceMenuItem.Click += new EventHandler(this.OnTransportTraceMenuItemClick);
    this.sessionTraceMenuItem.CheckOnClick = true;
    this.sessionTraceMenuItem.Name = "SessionTraceMenuItem";
    this.sessionTraceMenuItem.Size = new Size(199, 22);
    this.sessionTraceMenuItem.Text = "Сеансовый";
    this.sessionTraceMenuItem.Click += new EventHandler(this.OnSessionTraceMenuItemClick);
    this.presentationTraceStripMenuItem.CheckOnClick = true;
    this.presentationTraceStripMenuItem.Name = "PresentationTraceStripMenuItem";
    this.presentationTraceStripMenuItem.Size = new Size(199, 22);
    this.presentationTraceStripMenuItem.Text = "Представления";
    this.presentationTraceStripMenuItem.Click += new EventHandler(this.OnPresentationTraceStripMenuItemClick);
    this.applicationTraceStripMenuItem.CheckOnClick = true;
    this.applicationTraceStripMenuItem.Name = "ApplicationTraceStripMenuItem";
    this.applicationTraceStripMenuItem.Size = new Size(199, 22);
    this.applicationTraceStripMenuItem.Text = "Прикладной";
    this.applicationTraceStripMenuItem.Click += new EventHandler(this.OnApplicationTraceStripMenuItemClick);
    this.ueTraceStripMenuItem.CheckOnClick = true;
    this.ueTraceStripMenuItem.Name = "UETraceStripMenuItem";
    this.ueTraceStripMenuItem.Size = new Size(199, 22);
    this.ueTraceStripMenuItem.Text = "Элемент пользователя";
    this.ueTraceStripMenuItem.Click += new EventHandler(this.OnUETraceStripMenuItemClick);
    this.apTraceStripMenuItem.CheckOnClick = true;
    this.apTraceStripMenuItem.Name = "APTraceStripMenuItem";
    this.apTraceStripMenuItem.Size = new Size(199, 22);
    this.apTraceStripMenuItem.Text = "Прикладной процесс";
    this.apTraceStripMenuItem.Click += new EventHandler(this.OnAPTraceStripMenuItemClick);
    this.logMenuItemsGroup.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.nLogMenuItem,
      (ToolStripItem) this.tLogMenuItem,
      (ToolStripItem) this.sLogMenuItem,
      (ToolStripItem) this.pLogMenuItem,
      (ToolStripItem) this.aLogMenuItem,
      (ToolStripItem) this.ueLogMenuItem,
      (ToolStripItem) this.apLogMenuItem
    });
    this.logMenuItemsGroup.Name = "журналированиеToolStripMenuItem";
    this.logMenuItemsGroup.Size = new Size(157, 22);
    this.logMenuItemsGroup.Text = "Отключить out";
    this.nLogMenuItem.CheckOnClick = true;
    this.nLogMenuItem.Name = "NLogMenuItem";
    this.nLogMenuItem.Size = new Size(199, 22);
    this.nLogMenuItem.Text = "Сетевой";
    this.tLogMenuItem.CheckOnClick = true;
    this.tLogMenuItem.Name = "TLogMenuItem";
    this.tLogMenuItem.Size = new Size(199, 22);
    this.tLogMenuItem.Text = "Транспортный";
    this.sLogMenuItem.CheckOnClick = true;
    this.sLogMenuItem.Name = "SLogMenuItem";
    this.sLogMenuItem.Size = new Size(199, 22);
    this.sLogMenuItem.Text = "Сеансовый";
    this.pLogMenuItem.CheckOnClick = true;
    this.pLogMenuItem.Name = "PLogMenuItem";
    this.pLogMenuItem.Size = new Size(199, 22);
    this.pLogMenuItem.Text = "Представления";
    this.aLogMenuItem.CheckOnClick = true;
    this.aLogMenuItem.Name = "ALogMenuItem";
    this.aLogMenuItem.Size = new Size(199, 22);
    this.aLogMenuItem.Text = "Прикладной";
    this.ueLogMenuItem.CheckOnClick = true;
    this.ueLogMenuItem.Name = "UELogMenuItem";
    this.ueLogMenuItem.Size = new Size(199, 22);
    this.ueLogMenuItem.Text = "Элемент пользователя";
    this.apLogMenuItem.CheckOnClick = true;
    this.apLogMenuItem.Name = "APLogMenuItem";
    this.apLogMenuItem.Size = new Size(199, 22);
    this.apLogMenuItem.Text = "Прикладной процесс";
    this.levelsMenu.DropDownItems.AddRange(new ToolStripItem[10]
    {
      (ToolStripItem) this.apMenuItem,
      (ToolStripItem) this.ueMenuItem,
      (ToolStripItem) this.applicationMenuItem,
      (ToolStripItem) this.presentationMenuItem,
      (ToolStripItem) this.sessionMenuItem,
      (ToolStripItem) this.transportMenuItem,
      (ToolStripItem) this.networkMenuItem,
      (ToolStripItem) this.toolStripSeparator3,
      (ToolStripItem) this.allMenuItem,
      (ToolStripItem) this.asymmetricMenuItem
    });
    this.levelsMenu.Name = "LevelsMenu";
    this.levelsMenu.Size = new Size(60, 20);
    this.levelsMenu.Text = "Уровни";
    this.apMenuItem.CheckOnClick = true;
    this.apMenuItem.Enabled = false;
    this.apMenuItem.Name = "APMenuItem";
    this.apMenuItem.Size = new Size(231, 22);
    this.apMenuItem.Text = "Прикладной процесс";
    this.apMenuItem.CheckedChanged += new EventHandler(this.OnAPMenuItemClick);
    this.ueMenuItem.CheckOnClick = true;
    this.ueMenuItem.Enabled = false;
    this.ueMenuItem.Name = "UEMenuItem";
    this.ueMenuItem.Size = new Size(231, 22);
    this.ueMenuItem.Text = "Элемент пользователя";
    this.ueMenuItem.CheckedChanged += new EventHandler(this.OnUEMenuItemClick);
    this.applicationMenuItem.CheckOnClick = true;
    this.applicationMenuItem.Enabled = false;
    this.applicationMenuItem.Name = "ApplicationMenuItem";
    this.applicationMenuItem.Size = new Size(231, 22);
    this.applicationMenuItem.Text = "Прикладной";
    this.applicationMenuItem.CheckedChanged += new EventHandler(this.OnApplicationMenuItemClick);
    this.presentationMenuItem.CheckOnClick = true;
    this.presentationMenuItem.Enabled = false;
    this.presentationMenuItem.Name = "PresentationMenuItem";
    this.presentationMenuItem.Size = new Size(231, 22);
    this.presentationMenuItem.Text = "Представления";
    this.presentationMenuItem.CheckedChanged += new EventHandler(this.OnPresentationMenuItemClick);
    this.sessionMenuItem.CheckOnClick = true;
    this.sessionMenuItem.Enabled = false;
    this.sessionMenuItem.Name = "SessionMenuItem";
    this.sessionMenuItem.Size = new Size(231, 22);
    this.sessionMenuItem.Text = "Сеансовый";
    this.sessionMenuItem.CheckedChanged += new EventHandler(this.OnSessionMenuItemClick);
    this.transportMenuItem.Checked = true;
    this.transportMenuItem.CheckOnClick = true;
    this.transportMenuItem.CheckState = CheckState.Checked;
    this.transportMenuItem.Enabled = false;
    this.transportMenuItem.Name = "TransportMenuItem";
    this.transportMenuItem.Size = new Size(231, 22);
    this.transportMenuItem.Text = "Транспортный";
    this.transportMenuItem.CheckedChanged += new EventHandler(this.OnTransportMenuItemClick);
    this.networkMenuItem.CheckOnClick = true;
    this.networkMenuItem.Enabled = false;
    this.networkMenuItem.Name = "NetworkMenuItem";
    this.networkMenuItem.Size = new Size(231, 22);
    this.networkMenuItem.Text = "Сетевой";
    this.networkMenuItem.CheckedChanged += new EventHandler(this.OnNetworkMenuItemClick);
    this.toolStripSeparator3.Name = "toolStripSeparator3";
    this.toolStripSeparator3.Size = new Size(228, 6);
    this.allMenuItem.Enabled = false;
    this.allMenuItem.Name = "AllMenuItem";
    this.allMenuItem.Size = new Size(231, 22);
    this.allMenuItem.Text = "Все";
    this.allMenuItem.Click += new EventHandler(this.OnAllMenuItemClick);
    this.asymmetricMenuItem.CheckOnClick = true;
    this.asymmetricMenuItem.Name = "asymmetricMenuItem";
    this.asymmetricMenuItem.Size = new Size(231, 22);
    this.asymmetricMenuItem.Text = "Несимметричный протокол";
    this.asymmetricMenuItem.Visible = false;
    this.asymmetricMenuItem.CheckedChanged += new EventHandler(this.OnAsymmetricMenuItemClick);
    this.helpMenu.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.aboutMenuItem,
      (ToolStripItem) this.lectionsMenuItem,
      (ToolStripItem) this.seminar0MenuItem,
      (ToolStripItem) this.seminar1MenuItem,
      (ToolStripItem) this.seminar2MenuItem,
      (ToolStripItem) this.seminar3MenuItem,
      (ToolStripItem) this.seminar4MenuItem
    });
    this.helpMenu.Name = "HelpMenu";
    this.helpMenu.Size = new Size(122, 20);
    this.helpMenu.Text = "Справка";
    this.aboutMenuItem.Name = "AboutMenuItem";
    this.aboutMenuItem.Size = new Size(330, 22);
    this.aboutMenuItem.Text = "О программе...";
    this.aboutMenuItem.Click += new EventHandler(this.OnAboutMenuItemClick);
    this.lectionsMenuItem.Name = "LectionsMenuItem";
    this.lectionsMenuItem.Size = new Size(330, 22);
    this.lectionsMenuItem.Text = "Лекции";
    this.lectionsMenuItem.Click += new EventHandler(this.OnLectionsMenuItemClick);
    this.seminar0MenuItem.Name = "Seminar0MenuItem";
    this.seminar0MenuItem.Size = new Size(330, 22);
    this.seminar0MenuItem.Text = "Вводный семинар";
    this.seminar0MenuItem.Click += new EventHandler(this.OnSeminar0MenuItemClick);
    this.seminar1MenuItem.Name = "Seminar1MenuItem";
    this.seminar1MenuItem.Size = new Size(330, 22);
    this.seminar1MenuItem.Text = "Транспортный уровень";
    this.seminar1MenuItem.Click += new EventHandler(this.OnSeminar1MenuItemClick);
    this.seminar2MenuItem.Name = "Seminar2MenuItem";
    this.seminar2MenuItem.Size = new Size(330, 22);
    this.seminar2MenuItem.Text = "Сеансовый уровень";
    this.seminar2MenuItem.Click += new EventHandler(this.OnSeminar2MenuItemClick);
    this.seminar3MenuItem.Name = "Seminar3MenuItem";
    this.seminar3MenuItem.Size = new Size(330, 22);
    this.seminar3MenuItem.Text = "Уровень представления";
    this.seminar3MenuItem.Click += new EventHandler(this.OnSeminar3MenuItemClick);
    this.seminar4MenuItem.Name = "Seminar4MenuItem";
    this.seminar4MenuItem.Size = new Size(330, 22);
    this.seminar4MenuItem.Text = "Прикладной уровень и прикладные процессы";
    this.seminar4MenuItem.Click += new EventHandler(this.OnSeminar4MenuItemClick);
    this.logField.AcceptsReturn = true;
    this.logField.AcceptsTab = true;
    this.logField.Location = new Point(0, 365);
    this.logField.Multiline = true;
    this.logField.Name = "Log";
    this.logField.ReadOnly = true;
    this.logField.ScrollBars = ScrollBars.Vertical;
    this.logField.Size = new Size(482, 142);
    this.logField.TabIndex = 2;
    this.panel11.BackgroundImage = (Image) Resources.dante;
    this.panel11.BorderStyle = BorderStyle.Fixed3D;
    this.panel11.Controls.Add((Control) this.panel12);
    this.panel11.Controls.Add((Control) this.exitButton);
    this.panel11.Controls.Add((Control) this.statisticsButton);
    this.panel11.Controls.Add((Control) this.stopEmulationButton);
    this.panel11.Controls.Add((Control) this.startEmulationButton);
    this.panel11.Dock = DockStyle.Right;
    this.panel11.Location = new Point(484, 24);
    this.panel11.Name = "panel11";
    this.panel11.Size = new Size(132, 485);
    this.panel11.TabIndex = 0;
    this.panel12.BorderStyle = BorderStyle.FixedSingle;
    this.panel12.Controls.Add((Control) this.label4);
    this.panel12.Location = new Point(13, 378);
    this.panel12.Name = "panel12";
    this.panel12.Size = new Size(104, 93);
    this.panel12.TabIndex = 5;
    this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.label4.BorderStyle = BorderStyle.Fixed3D;
    this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.label4.Location = new Point(3, 3);
    this.label4.Margin = new Padding(3);
    this.label4.Name = "label4";
    this.label4.Size = new Size(96, 85);
    this.label4.TabIndex = 0;
    this.label4.Text = "NetLab 1.8.6.24";
    this.label4.TextAlign = ContentAlignment.MiddleCenter;
    this.exitButton.Location = new Point(13, 333);
    this.exitButton.Name = "ExitButton";
    this.exitButton.Size = new Size(104, 30);
    this.exitButton.TabIndex = 4;
    this.exitButton.Text = "Выход";
    this.exitButton.UseVisualStyleBackColor = true;
    this.exitButton.Click += new EventHandler(this.OnExitButtonClick);
    this.statisticsButton.Location = new Point(13, 140);
    this.statisticsButton.Name = "button22";
    this.statisticsButton.Size = new Size(104, 30);
    this.statisticsButton.TabIndex = 2;
    this.statisticsButton.Text = "Статистика";
    this.statisticsButton.UseVisualStyleBackColor = true;
    this.statisticsButton.Click += new EventHandler(this.OnStatisticsButtonClick);
    this.stopEmulationButton.Enabled = false;
    this.stopEmulationButton.Location = new Point(13, 52);
    this.stopEmulationButton.Name = "button21";
    this.stopEmulationButton.Size = new Size(104, 30);
    this.stopEmulationButton.TabIndex = 1;
    this.stopEmulationButton.Text = "Остановить";
    this.stopEmulationButton.UseVisualStyleBackColor = true;
    this.stopEmulationButton.Click += new EventHandler(this.StopEmulation);
    this.startEmulationButton.Location = new Point(13, 16);
    this.startEmulationButton.Name = "button20";
    this.startEmulationButton.Size = new Size(104, 30);
    this.startEmulationButton.TabIndex = 0;
    this.startEmulationButton.Text = "Запуск эмуляции";
    this.startEmulationButton.UseVisualStyleBackColor = true;
    this.startEmulationButton.Click += new EventHandler(this.StartEmulation);
    this.saveFileDialog.DefaultExt = "lab";
    this.saveFileDialog.Filter = "Файлы NetLab|*.lab";
    this.saveFileDialog.Title = "Сохранить работу как ";
    this.openFileDialog.DefaultExt = "lab";
    this.openFileDialog.Filter = "Файлы NelLab|*.lab";
    this.openFileDialog.Title = "Открыть файл";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(616, 509);
    this.Controls.Add((Control) this.panel11);
    this.Controls.Add((Control) this.logField);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.mainMenu);
    this.FormBorderStyle = FormBorderStyle.Fixed3D;
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.MainMenuStrip = this.mainMenu;
    this.MaximizeBox = false;
    this.Name = "MainForm";
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "NetLab";
    this.FormClosing += new FormClosingEventHandler(this.OnFormClosing);
    this.Shown += new EventHandler(this.updateProgram);
    this.panel1.ResumeLayout(false);
    this.panel7.ResumeLayout(false);
    this.panel8.ResumeLayout(false);
    this.panel8.PerformLayout();
    this.panel9.ResumeLayout(false);
    this.panel10.ResumeLayout(false);
    this.panel2.ResumeLayout(false);
    this.panel2.PerformLayout();
    this.panel4.ResumeLayout(false);
    this.panel3.ResumeLayout(false);
    this.panel5.ResumeLayout(false);
    this.panel5.PerformLayout();
    this.panel6.ResumeLayout(false);
    this.mainMenu.ResumeLayout(false);
    this.mainMenu.PerformLayout();
    this.panel11.ResumeLayout(false);
    this.panel12.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
