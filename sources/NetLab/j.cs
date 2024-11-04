// Decompiled with JetBrains decompiler
// Type: j
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

#nullable disable
public class j : Form
{
  private global::aj[] a;
  private DateTime b;
  private global::an c;
  private bool d;
  private global::k e;
  private ArrayList f = new ArrayList();
  private Stack g = new Stack();
  private bool h;
  private global::j.a i = new global::j.a("", 0);
  private int j = 50;
  private IContainer k;
  private MenuStrip l;
  private StatusStrip m;
  private ToolStrip n;
  private RichTextBox o;
  private ToolStripStatusLabel p;
  private ToolStripMenuItem q;
  private ToolStripMenuItem r;
  private ToolStripMenuItem s;
  private ToolStripSeparator t;
  private ToolStripMenuItem u;
  private ToolStripMenuItem v;
  private ToolStripMenuItem w;
  private ToolStripMenuItem x;
  private ToolStripButton y;
  private ToolStripButton z;
  private ToolStripSeparator aa;
  private ToolStripButton ab;
  private ToolStripButton ac;
  private ToolStripButton ad;
  private ToolStripSeparator ae;
  private ToolStripStatusLabel af;
  private ToolStripStatusLabel ag;
  private ToolStripStatusLabel ah;
  private ToolStripStatusLabel ai;
  private ToolStripStatusLabel aj;
  private Timer ak;
  private ToolStripMenuItem al;
  private ToolStripMenuItem am;
  private ToolStripMenuItem an;
  private ToolStripMenuItem ao;
  private ToolStripButton ap;

  [SpecialName]
  private bool g() => this.f.Count > 0;

  [SpecialName]
  private bool f() => this.g.Count > 0;

  private void e()
  {
    while (this.f.Count > this.j)
      this.f.RemoveAt(this.j);
  }

  private void d()
  {
    if (!this.g())
      return;
    this.h = true;
    this.g.Push((object) new global::j.a(this.o.Text, this.o.SelectionStart));
    global::j.a a = (global::j.a) this.f[0];
    this.f.RemoveAt(0);
    this.o.Text = a.b;
    this.o.SelectionStart = a.a;
    this.i = a;
    this.h = false;
  }

  private void c()
  {
    if (!this.f())
      return;
    this.h = true;
    this.f.Insert(0, (object) new global::j.a(this.o.Text, this.o.SelectionStart));
    this.e();
    global::j.a a = (global::j.a) this.g.Pop();
    this.o.Text = a.b;
    this.o.SelectionStart = a.a;
    this.h = false;
  }

  public j(global::aj[] A_0, global::an A_1)
  {
    this.a();
    this.b = new DateTime();
    this.a = A_0;
    this.Text = this.a[0].o();
    string[] strArray = new string[this.a[0].k().Count];
    this.a[0].k().CopyTo((Array) strArray);
    this.o.Lines = strArray;
    this.o.SelectionStart = this.a[0].f();
    this.c = A_1;
    this.d = false;
    this.e = new global::k(this.o);
    string[] array = new string[22]
    {
      "buffer",
      "copy",
      "delete",
      "dequeue",
      "peek",
      "down",
      "up",
      "goto",
      "if",
      "out",
      "pos",
      "qcount",
      "queue",
      "clearqueue",
      "sizeof",
      "timer",
      "unbuffer",
      "untimer",
      "crc",
      "set",
      "declare",
      "random"
    };
    for (int index = 0; index < global::v.ab.Count; ++index)
      array[Array.IndexOf<object>((object[]) array, global::v.ab[index])] = (string) global::v.ac[index];
    try
    {
      using (XmlReader xmlReader = XmlReader.Create(Application.StartupPath + "\\highlightrules.xml"))
      {
        TypeConverter converter1 = TypeDescriptor.GetConverter(typeof (Font));
        TypeConverter converter2 = TypeDescriptor.GetConverter(typeof (Color));
        xmlReader.ReadStartElement("rules");
        xmlReader.ReadStartElement("forbiddenoperators");
        string pattern1 = xmlReader.ReadElementString("Regex").Replace("operators", string.Join("|", (string[]) global::v.ab.ToArray(typeof (string))) + "|" + string.Join("|", (string[]) global::v.ae.ToArray(typeof (string))));
        string text1 = xmlReader.ReadElementString("font");
        Font A_1_1 = (Font) converter1.ConvertFromString(text1);
        string text2 = xmlReader.ReadElementString("color");
        Color A_2_1 = (Color) converter2.ConvertFromString(text2);
        string text3 = xmlReader.ReadElementString("BGcolor");
        Color A_3_1 = (Color) converter2.ConvertFromString(text3);
        this.e.e.Add(new global::k.a(new Regex(pattern1, RegexOptions.Multiline), A_1_1, A_2_1, A_3_1));
        xmlReader.ReadEndElement();
        xmlReader.ReadStartElement("operators");
        string pattern2 = xmlReader.ReadElementString("Regex").Replace("operators", string.Join("|", array));
        string text4 = xmlReader.ReadElementString("font");
        Font A_1_2 = (Font) converter1.ConvertFromString(text4);
        string text5 = xmlReader.ReadElementString("color");
        Color A_2_2 = (Color) converter2.ConvertFromString(text5);
        string text6 = xmlReader.ReadElementString("BGcolor");
        Color A_3_2 = (Color) converter2.ConvertFromString(text6);
        this.e.e.Add(new global::k.a(new Regex(pattern2, RegexOptions.Multiline), A_1_2, A_2_2, A_3_2));
        xmlReader.ReadEndElement();
        while (xmlReader.IsStartElement())
        {
          xmlReader.ReadStartElement();
          string pattern3 = xmlReader.ReadElementString("Regex");
          string text7 = xmlReader.ReadElementString("font");
          Font A_1_3 = (Font) converter1.ConvertFromString(text7);
          string text8 = xmlReader.ReadElementString("color");
          Color A_2_3 = (Color) converter2.ConvertFromString(text8);
          string text9 = xmlReader.ReadElementString("BGcolor");
          Color A_3_3 = (Color) converter2.ConvertFromString(text9);
          this.e.e.Add(new global::k.a(new Regex(pattern3, RegexOptions.Multiline), A_1_3, A_2_3, A_3_3));
          xmlReader.ReadEndElement();
        }
        xmlReader.ReadEndElement();
        xmlReader.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadSyntaxHighlight, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void s(object A_0, EventArgs A_1)
  {
    this.b = DateTime.Now;
    if (!global::v.o && this.a[0].g() + this.a[0].i() + this.a[0].j() + this.a[0].h() > 0)
    {
      this.Height = this.a[0].g();
      this.Left = this.a[0].i();
      this.Top = this.a[0].j();
      this.Width = this.a[0].h();
    }
    else
    {
      this.Height = global::v.k;
      this.Width = global::v.l;
      this.Left = global::v.i;
      this.Top = global::v.j;
    }
    this.ak.Enabled = true;
    this.o.BackColor = global::v.b;
    this.h = true;
    this.o.Font = global::v.e;
    this.i = new global::j.a(this.o.Text, this.o.SelectionStart);
    this.h = false;
    this.ao.Checked = this.m.Visible;
    this.an.Checked = this.n.Visible;
    this.e.d();
    this.e.b();
    this.e.c();
  }

  private void b()
  {
    for (int index1 = 0; index1 < this.a.Length; ++index1)
    {
      this.a[index1].c(this.o.SelectionStart);
      this.a[index1].k().Clear();
      this.a[index1].l().Clear();
      for (int index2 = 0; index2 < this.o.Lines.Length; ++index2)
      {
        this.a[index1].k().Add((object) this.o.Lines[index2]);
        global::v.z = 0;
        global::v.y = 0;
        global::v.aa = 0;
        this.a[index1].l().Add((object) global::ad.a(this.o.Lines[index2], (int) this.a[0].b()));
        if (global::v.y > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorBaseSyntax + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
        if (global::v.aa > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorForbiddenWord + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
        if (global::v.z > 0 && MessageBox.Show(Resources.ErrorPossibleSyntaxError + (index2 + 1).ToString() + Resources.MsgIgnore, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
      }
      global::aj aj = this.a[index1];
      aj.b(aj.d() + 1);
      if (this.f.Count > 0)
        global::v.ak = true;
    }
  }

  private void a(object A_0, FormClosingEventArgs A_1)
  {
    for (int index1 = 0; index1 < this.a.Length; ++index1)
    {
      this.a[index1].c(this.o.SelectionStart);
      this.a[index1].k().Clear();
      this.a[index1].l().Clear();
      for (int index2 = 0; index2 < this.o.Lines.Length; ++index2)
      {
        this.a[index1].k().Add((object) this.o.Lines[index2]);
        global::v.z = 0;
        global::v.y = 0;
        global::v.aa = 0;
        this.a[index1].l().Add((object) global::ad.a(this.o.Lines[index2], (int) this.a[0].b()));
        if (global::v.y > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorBaseSyntax + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          A_1.Cancel = true;
          return;
        }
        if (global::v.aa > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorForbiddenWord + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          A_1.Cancel = true;
          return;
        }
        if (global::v.z > 0 && MessageBox.Show(Resources.ErrorPossibleSyntaxError + (index2 + 1).ToString() + Resources.MsgIgnore, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
          A_1.Cancel = true;
          return;
        }
      }
      this.a[index1].a(DateTime.Now);
      global::aj aj1 = this.a[index1];
      aj1.b(aj1.d() + 1);
      global::aj aj2 = this.a[index1];
      aj2.a(aj2.c() + (DateTime.Now - this.b).Seconds);
      string A_0_1 = "";
      for (int index3 = 0; index3 < this.a[index1].l().Count; ++index3)
      {
        string A_0_2 = (string) this.a[index1].l()[index3];
        global::ad.e(ref A_0_2);
        string str = global::ad.d(ref A_0_2);
        if (str.Length > 0 && str[str.Length - 1] == ':')
          str = global::ad.d(ref A_0_2);
        A_0_1 += str;
      }
      this.a[index1].m = global::l.a(A_0_1);
      if (this.WindowState != FormWindowState.Normal)
        this.WindowState = FormWindowState.Normal;
      this.a[index1].d(this.Height);
      this.a[index1].f(this.Left);
      this.a[index1].g(this.Top);
      this.a[index1].e(this.Width);
      this.ak.Enabled = false;
      if (this.f.Count > 0)
        global::v.ak = true;
    }
  }

  private void a(object A_0, KeyEventArgs A_1)
  {
    switch (A_1.KeyCode)
    {
      case Keys.Escape:
        this.Close();
        break;
      case Keys.Insert:
        this.d = !this.d;
        break;
      case Keys.S:
        if (A_1.Modifiers != Keys.Control)
          break;
        this.b();
        break;
    }
  }

  private void r(object A_0, EventArgs A_1)
  {
    ToolStripStatusLabel p = this.p;
    int num = this.o.GetLineFromCharIndex(this.o.SelectionStart) + 1;
    string str1 = num.ToString();
    num = this.o.SelectionStart - this.o.GetFirstCharIndexFromLine(this.o.GetLineFromCharIndex(this.o.SelectionStart)) + 1;
    string str2 = num.ToString();
    string str3 = "c: " + str1 + " к: " + str2;
    p.Text = str3;
    this.aj.Text = DateTime.Now.ToString();
    this.ah.Enabled = Control.IsKeyLocked(Keys.Capital);
    this.ag.Enabled = Control.IsKeyLocked(Keys.NumLock);
    this.ai.Enabled = this.d;
  }

  private void q(object A_0, EventArgs A_1) => Help.ShowHelp((Control) this, global::v.r);

  private void p(object A_0, EventArgs A_1) => this.al.PerformClick();

  private void o(object A_0, EventArgs A_1) => this.n.Visible = this.an.Checked;

  private void n(object A_0, EventArgs A_1) => this.m.Visible = this.ao.Checked;

  private void m(object A_0, EventArgs A_1) => this.o.SelectAll();

  private void l(object A_0, EventArgs A_1) => this.d();

  private void k(object A_0, EventArgs A_1) => this.c();

  private void j(object A_0, EventArgs A_1) => this.o.Copy();

  private void i(object A_0, EventArgs A_1) => this.o.Paste();

  private void h(object A_0, EventArgs A_1) => this.o.Cut();

  private void g(object A_0, EventArgs A_1)
  {
    if (!this.h)
    {
      this.g.Clear();
      this.f.Insert(0, (object) this.i);
      this.e();
      this.i = new global::j.a(this.o.Text, this.o.SelectionStart);
    }
    this.e.d();
    this.e.b();
    this.e.c();
  }

  private void f(object A_0, EventArgs A_1)
  {
  }

  private void e(object A_0, EventArgs A_1) => this.w.PerformClick();

  private void d(object A_0, EventArgs A_1) => this.v.PerformClick();

  private void c(object A_0, EventArgs A_1) => this.u.PerformClick();

  private void b(object A_0, EventArgs A_1) => this.r.PerformClick();

  private void a(object A_0, EventArgs A_1) => this.s.PerformClick();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.k != null)
      this.k.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.k = (IContainer) new System.ComponentModel.Container();
    this.l = new MenuStrip();
    this.q = new ToolStripMenuItem();
    this.r = new ToolStripMenuItem();
    this.s = new ToolStripMenuItem();
    this.t = new ToolStripSeparator();
    this.u = new ToolStripMenuItem();
    this.v = new ToolStripMenuItem();
    this.w = new ToolStripMenuItem();
    this.x = new ToolStripMenuItem();
    this.am = new ToolStripMenuItem();
    this.an = new ToolStripMenuItem();
    this.ao = new ToolStripMenuItem();
    this.al = new ToolStripMenuItem();
    this.m = new StatusStrip();
    this.p = new ToolStripStatusLabel();
    this.af = new ToolStripStatusLabel();
    this.ag = new ToolStripStatusLabel();
    this.ah = new ToolStripStatusLabel();
    this.ai = new ToolStripStatusLabel();
    this.aj = new ToolStripStatusLabel();
    this.n = new ToolStrip();
    this.y = new ToolStripButton();
    this.z = new ToolStripButton();
    this.aa = new ToolStripSeparator();
    this.ab = new ToolStripButton();
    this.ac = new ToolStripButton();
    this.ad = new ToolStripButton();
    this.ae = new ToolStripSeparator();
    this.ap = new ToolStripButton();
    this.o = new RichTextBox();
    this.ak = new Timer(this.k);
    this.l.SuspendLayout();
    this.m.SuspendLayout();
    this.n.SuspendLayout();
    this.SuspendLayout();
    this.l.Items.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.q,
      (ToolStripItem) this.am,
      (ToolStripItem) this.al
    });
    this.l.Location = new Point(0, 0);
    this.l.Name = "MainMenu";
    this.l.Size = new Size(661, 24);
    this.l.TabIndex = 0;
    this.q.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.r,
      (ToolStripItem) this.s,
      (ToolStripItem) this.t,
      (ToolStripItem) this.u,
      (ToolStripItem) this.v,
      (ToolStripItem) this.w,
      (ToolStripItem) this.x
    });
    this.q.Name = "EditMenu";
    this.q.Size = new Size(59, 20);
    this.q.Text = "Правка";
    this.r.Image = (Image) Resources.Undo;
    this.r.Name = "UndoMenuItem";
    this.r.ShortcutKeys = Keys.Z | Keys.Control;
    this.r.Size = new Size(190, 22);
    this.r.Text = "Отменить";
    this.r.Click += new EventHandler(this.l);
    this.s.Image = (Image) Resources.Redo;
    this.s.Name = "RedoMenuItem";
    this.s.ShortcutKeys = Keys.Y | Keys.Control;
    this.s.Size = new Size(190, 22);
    this.s.Text = "Повторить";
    this.s.Click += new EventHandler(this.k);
    this.t.Name = "toolStripSeparator1";
    this.t.Size = new Size(187, 6);
    this.u.Image = (Image) Resources.Cut;
    this.u.Name = "CutMenuItem";
    this.u.ShortcutKeys = Keys.X | Keys.Control;
    this.u.Size = new Size(190, 22);
    this.u.Text = "Вырезать";
    this.u.Click += new EventHandler(this.h);
    this.v.Image = (Image) Resources.Copy;
    this.v.Name = "CopyMenuItem";
    this.v.ShortcutKeys = Keys.C | Keys.Control;
    this.v.Size = new Size(190, 22);
    this.v.Text = "Копировать";
    this.v.Click += new EventHandler(this.j);
    this.w.Image = (Image) Resources.Paste;
    this.w.Name = "PasteMenuItem";
    this.w.ShortcutKeys = Keys.V | Keys.Control;
    this.w.Size = new Size(190, 22);
    this.w.Text = "Вставить";
    this.w.Click += new EventHandler(this.i);
    this.x.Name = "SelectAllMenuItem";
    this.x.ShortcutKeys = Keys.A | Keys.Control;
    this.x.Size = new Size(190, 22);
    this.x.Text = "Выделить все";
    this.x.Click += new EventHandler(this.m);
    this.am.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.an,
      (ToolStripItem) this.ao
    });
    this.am.Name = "панельИнструментовToolStripMenuItem";
    this.am.Size = new Size(141, 20);
    this.am.Text = "Панель инструментов";
    this.an.CheckOnClick = true;
    this.an.Name = "UpToolStripMenuItem";
    this.an.Size = new Size(118, 22);
    this.an.Text = "Верхняя";
    this.an.Click += new EventHandler(this.o);
    this.ao.CheckOnClick = true;
    this.ao.Name = "DownToolStripMenuItem";
    this.ao.Size = new Size(118, 22);
    this.ao.Text = "Нижняя";
    this.ao.Click += new EventHandler(this.n);
    this.al.Name = "HelpMenu";
    this.al.ShortcutKeys = Keys.F1;
    this.al.Size = new Size(65, 20);
    this.al.Text = "Справка";
    this.al.Click += new EventHandler(this.q);
    this.m.Items.AddRange(new ToolStripItem[6]
    {
      (ToolStripItem) this.p,
      (ToolStripItem) this.af,
      (ToolStripItem) this.ag,
      (ToolStripItem) this.ah,
      (ToolStripItem) this.ai,
      (ToolStripItem) this.aj
    });
    this.m.Location = new Point(0, 425);
    this.m.Name = "StatusBar";
    this.m.Size = new Size(661, 25);
    this.m.TabIndex = 1;
    this.p.AutoSize = false;
    this.p.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.p.BorderStyle = Border3DStyle.Bump;
    this.p.Name = "LineColumnPanel";
    this.p.Size = new Size(75, 20);
    this.p.Text = "c: 0 к: 0";
    this.af.AutoSize = false;
    this.af.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.af.BorderStyle = Border3DStyle.Bump;
    this.af.Enabled = false;
    this.af.Name = "StatusPanel";
    this.af.Size = new Size(55, 20);
    this.af.Text = "Изменен";
    this.ag.AutoSize = false;
    this.ag.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.ag.BorderStyle = Border3DStyle.Bump;
    this.ag.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
    this.ag.Name = "NUMLOCKStatusPanel";
    this.ag.Size = new Size(50, 20);
    this.ag.Text = "NUM";
    this.ah.AutoSize = false;
    this.ah.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.ah.BorderStyle = Border3DStyle.Bump;
    this.ah.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
    this.ah.Name = "CAPSLOCKStatusPanel";
    this.ah.Size = new Size(50, 20);
    this.ah.Text = "CAPS";
    this.ai.AutoSize = false;
    this.ai.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.ai.BorderStyle = Border3DStyle.Bump;
    this.ai.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
    this.ai.Name = "INSStatusPanel";
    this.ai.Size = new Size(50, 20);
    this.ai.Text = "INS";
    this.aj.AutoSize = false;
    this.aj.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.aj.BorderStyle = Border3DStyle.Bump;
    this.aj.Name = "TimeStatusPanel";
    this.aj.Size = new Size(120, 20);
    this.n.GripStyle = ToolStripGripStyle.Hidden;
    this.n.Items.AddRange(new ToolStripItem[8]
    {
      (ToolStripItem) this.y,
      (ToolStripItem) this.z,
      (ToolStripItem) this.aa,
      (ToolStripItem) this.ab,
      (ToolStripItem) this.ac,
      (ToolStripItem) this.ad,
      (ToolStripItem) this.ae,
      (ToolStripItem) this.ap
    });
    this.n.Location = new Point(0, 24);
    this.n.Name = "ToolBar";
    this.n.Size = new Size(661, 25);
    this.n.TabIndex = 2;
    this.y.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.y.Image = (Image) Resources.Undo;
    this.y.ImageScaling = ToolStripItemImageScaling.None;
    this.y.ImageTransparentColor = Color.Magenta;
    this.y.Margin = new Padding(0, 1, 5, 2);
    this.y.Name = "UndoToolButton";
    this.y.Size = new Size(23, 22);
    this.y.ToolTipText = "Отменить";
    this.y.Click += new EventHandler(this.b);
    this.z.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.z.Image = (Image) Resources.Redo;
    this.z.ImageScaling = ToolStripItemImageScaling.None;
    this.z.ImageTransparentColor = Color.Magenta;
    this.z.Margin = new Padding(0, 1, 5, 2);
    this.z.Name = "RedoButton";
    this.z.Size = new Size(23, 22);
    this.z.ToolTipText = "Повторить";
    this.z.Click += new EventHandler(this.a);
    this.aa.Margin = new Padding(0, 0, 5, 0);
    this.aa.Name = "toolStripSeparator2";
    this.aa.Size = new Size(6, 25);
    this.ab.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.ab.Image = (Image) Resources.Cut;
    this.ab.ImageScaling = ToolStripItemImageScaling.None;
    this.ab.ImageTransparentColor = Color.Magenta;
    this.ab.Margin = new Padding(0, 1, 5, 2);
    this.ab.Name = "CutToolButton";
    this.ab.Size = new Size(23, 22);
    this.ab.ToolTipText = "Вырезать";
    this.ab.Click += new EventHandler(this.c);
    this.ac.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.ac.Image = (Image) Resources.Copy;
    this.ac.ImageScaling = ToolStripItemImageScaling.None;
    this.ac.ImageTransparentColor = Color.Magenta;
    this.ac.Margin = new Padding(0, 1, 5, 2);
    this.ac.Name = "CopyToolButton";
    this.ac.Size = new Size(23, 22);
    this.ac.ToolTipText = "Копировать";
    this.ac.Click += new EventHandler(this.d);
    this.ad.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.ad.Image = (Image) Resources.Paste;
    this.ad.ImageScaling = ToolStripItemImageScaling.None;
    this.ad.ImageTransparentColor = Color.Magenta;
    this.ad.Margin = new Padding(0, 1, 5, 2);
    this.ad.Name = "PasteToolButton";
    this.ad.Size = new Size(23, 22);
    this.ad.ToolTipText = "Вставить";
    this.ad.Click += new EventHandler(this.e);
    this.ae.Margin = new Padding(0, 0, 5, 0);
    this.ae.Name = "toolStripSeparator3";
    this.ae.Size = new Size(6, 25);
    this.ap.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.ap.Image = (Image) Resources.help;
    this.ap.ImageTransparentColor = Color.Teal;
    this.ap.Name = "HelptoolStripButton";
    this.ap.Size = new Size(23, 22);
    this.ap.Text = "Справка";
    this.ap.Click += new EventHandler(this.p);
    this.o.AcceptsTab = true;
    this.o.AutoWordSelection = true;
    this.o.Dock = DockStyle.Fill;
    this.o.ForeColor = SystemColors.WindowText;
    this.o.Location = new Point(0, 49);
    this.o.Name = "CodeEditor";
    this.o.Size = new Size(661, 376);
    this.o.TabIndex = 0;
    this.o.Text = "Ошибка загрузки файла синтаксиса";
    this.o.WordWrap = false;
    this.o.TextChanged += new EventHandler(this.g);
    this.o.KeyDown += new KeyEventHandler(this.a);
    this.ak.Interval = 500;
    this.ak.Tick += new EventHandler(this.r);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(661, 450);
    this.Controls.Add((Control) this.o);
    this.Controls.Add((Control) this.n);
    this.Controls.Add((Control) this.m);
    this.Controls.Add((Control) this.l);
    this.MainMenuStrip = this.l;
    this.Name = "EventEditor";
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.FormClosing += new FormClosingEventHandler(this.a);
    this.Load += new EventHandler(this.f);
    this.Shown += new EventHandler(this.s);
    this.l.ResumeLayout(false);
    this.l.PerformLayout();
    this.m.ResumeLayout(false);
    this.m.PerformLayout();
    this.n.ResumeLayout(false);
    this.n.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

  private class a
  {
    public readonly int a;
    public readonly string b;

    public a(string A_0, int A_1)
    {
      this.b = A_0;
      this.a = A_1;
    }
  }
}
