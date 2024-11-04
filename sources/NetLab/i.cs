// Decompiled with JetBrains decompiler
// Type: i
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class i : Form
{
  private global::an a;
  public ArrayList b;
  private IContainer c;
  private SplitContainer d;
  private SplitContainer e;
  private Panel f;
  private Button g;
  private ListBox h;
  private ListBox i;
  private MenuStrip j;
  private ToolStripMenuItem k;
  private ToolStripMenuItem l;
  private ToolStripMenuItem m;
  private ToolStripMenuItem n;
  private Button o;
  private Button p;
  private Button q;
  private Button r;
  private Button s;
  private Button t;
  private Button u;
  private Button v;
  private Button w;
  private Button x;
  private Button y;
  private Button z;
  private Button aa;
  private Button ab;
  private Button ac;
  private Button ad;
  private Button ae;
  private Button af;
  private StatusStrip ag;
  private ToolStripStatusLabel ah;
  private ToolStripStatusLabel ai;
  private ToolStripStatusLabel aj;
  private ToolStripStatusLabel ak;
  private ToolStripMenuItem al;
  private ToolStripMenuItem am;
  private ToolStripMenuItem an;
  private ToolStripMenuItem ao;
  public Label ap;
  private ToolStripMenuItem aq;
  private ToolStripMenuItem ar;

  public i(global::an A_0)
  {
    this.a();
    this.a = A_0;
    this.b = new ArrayList();
  }

  private void n(object A_0, EventArgs A_1)
  {
  }

  private void m(object A_0, EventArgs A_1)
  {
  }

  private void l(object A_0, EventArgs A_1)
  {
  }

  private void k(object A_0, EventArgs A_1)
  {
    global::an.e = 6;
    this.Close();
  }

  private void j(object A_0, EventArgs A_1) => global::an.e = 5;

  private void i(object A_0, EventArgs A_1)
  {
    if (global::an.e == 5)
    {
      global::an.e = 1;
      ++global::MainWindow.userInfo.p;
      this.a.a(global::MainWindow.h);
    }
    else
      global::an.e = 1;
  }

  private void h(object A_0, EventArgs A_1)
  {
    if (global::an.e == 5)
    {
      global::an.e = 2;
      ++global::MainWindow.userInfo.p;
      this.a.a(global::MainWindow.h);
    }
    else
      global::an.e = 2;
  }

  private void g(object A_0, EventArgs A_1)
  {
    if (global::an.e == 5)
    {
      global::an.e = 3;
      ++global::MainWindow.userInfo.p;
      this.a.a(global::MainWindow.h);
    }
    else
      global::an.e = 3;
  }

  private void a(object A_0, FormClosedEventArgs A_1)
  {
    if (global::an.e != 5)
      global::an.e = 6;
    this.i.Items.Clear();
    this.ah.Text = "";
    this.ai.Text = "";
    this.aj.Text = "";
    this.ak.Text = "";
  }

  public void a(object[] A_0, string A_1, string A_2)
  {
    this.i.Items.Clear();
    this.i.Items.AddRange(A_0);
    this.ah.Text = A_1;
    this.ai.Text = A_2;
  }

  public void a(object[] A_0)
  {
    this.h.Items.Clear();
    this.h.Items.AddRange(A_0);
  }

  public void a(string A_0, int A_1)
  {
    if (global::MainWindow.ab.Contains((object) A_0))
      this.ak.Text = (string) global::MainWindow.ac[global::MainWindow.ab.IndexOf((object) A_0)];
    else
      this.ak.Text = "Something";
    this.aj.Text = A_1.ToString();
    if (this.i.Items.Count <= A_1)
      return;
    this.i.SelectedIndex = A_1;
  }

  private void f(object A_0, EventArgs A_1)
  {
    global::f f = new global::f();
    if (f.ShowDialog() == DialogResult.OK && f.a != "")
    {
      this.b.Add((object) f.a);
      this.h.Items.Add((object) (f.a + ":  Недоступное значение."));
    }
    f.Dispose();
  }

  private void e(object A_0, EventArgs A_1)
  {
    if (global::an.e != 2 && global::an.e != 3)
      return;
    global::an.e = 1;
  }

  private void d(object A_0, EventArgs A_1)
  {
  }

  private void c(object A_0, EventArgs A_1)
  {
    if (global::an.e == 5)
    {
      global::an.e = -1;
      this.a.a(global::MainWindow.h);
    }
    else
      global::an.e = -1;
  }

  private void a(object A_0, KeyEventArgs A_1)
  {
    if (A_1.KeyCode != Keys.Delete || this.h.Items.Count <= 0)
      return;
    this.b.RemoveAt(this.h.SelectedIndex);
    this.h.Items.RemoveAt(this.h.SelectedIndex);
  }

  private void a(object A_0, EventArgs A_1)
  {
    this.h.Items.Clear();
    this.b.Clear();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.c != null)
      this.c.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.d = new SplitContainer();
    this.e = new SplitContainer();
    this.f = new Panel();
    this.o = new Button();
    this.p = new Button();
    this.q = new Button();
    this.r = new Button();
    this.s = new Button();
    this.t = new Button();
    this.u = new Button();
    this.v = new Button();
    this.w = new Button();
    this.x = new Button();
    this.y = new Button();
    this.z = new Button();
    this.aa = new Button();
    this.ab = new Button();
    this.ac = new Button();
    this.ad = new Button();
    this.ae = new Button();
    this.af = new Button();
    this.g = new Button();
    this.ap = new Label();
    this.h = new ListBox();
    this.i = new ListBox();
    this.j = new MenuStrip();
    this.k = new ToolStripMenuItem();
    this.al = new ToolStripMenuItem();
    this.am = new ToolStripMenuItem();
    this.an = new ToolStripMenuItem();
    this.aq = new ToolStripMenuItem();
    this.l = new ToolStripMenuItem();
    this.ao = new ToolStripMenuItem();
    this.m = new ToolStripMenuItem();
    this.n = new ToolStripMenuItem();
    this.ag = new StatusStrip();
    this.ah = new ToolStripStatusLabel();
    this.ai = new ToolStripStatusLabel();
    this.aj = new ToolStripStatusLabel();
    this.ak = new ToolStripStatusLabel();
    this.ar = new ToolStripMenuItem();
    this.d.Panel1.SuspendLayout();
    this.d.Panel2.SuspendLayout();
    this.d.SuspendLayout();
    this.e.Panel1.SuspendLayout();
    this.e.Panel2.SuspendLayout();
    this.e.SuspendLayout();
    this.f.SuspendLayout();
    this.j.SuspendLayout();
    this.ag.SuspendLayout();
    this.SuspendLayout();
    this.d.Dock = DockStyle.Fill;
    this.d.FixedPanel = FixedPanel.Panel1;
    this.d.Location = new Point(0, 24);
    this.d.Name = "splitContainer1";
    this.d.Orientation = Orientation.Horizontal;
    this.d.Panel1.Controls.Add((Control) this.e);
    this.d.Panel1.RightToLeft = RightToLeft.No;
    this.d.Panel2.Controls.Add((Control) this.i);
    this.d.Panel2.RightToLeft = RightToLeft.No;
    this.d.Size = new Size(527, 421);
    this.d.SplitterDistance = 288;
    this.d.TabIndex = 0;
    this.e.Dock = DockStyle.Fill;
    this.e.FixedPanel = FixedPanel.Panel1;
    this.e.Location = new Point(0, 0);
    this.e.Name = "splitContainer2";
    this.e.Panel1.Controls.Add((Control) this.f);
    this.e.Panel2.Controls.Add((Control) this.h);
    this.e.Size = new Size(527, 288);
    this.e.SplitterDistance = 355;
    this.e.TabIndex = 0;
    this.f.BorderStyle = BorderStyle.FixedSingle;
    this.f.Controls.Add((Control) this.o);
    this.f.Controls.Add((Control) this.p);
    this.f.Controls.Add((Control) this.q);
    this.f.Controls.Add((Control) this.r);
    this.f.Controls.Add((Control) this.s);
    this.f.Controls.Add((Control) this.t);
    this.f.Controls.Add((Control) this.u);
    this.f.Controls.Add((Control) this.v);
    this.f.Controls.Add((Control) this.w);
    this.f.Controls.Add((Control) this.x);
    this.f.Controls.Add((Control) this.y);
    this.f.Controls.Add((Control) this.z);
    this.f.Controls.Add((Control) this.aa);
    this.f.Controls.Add((Control) this.ab);
    this.f.Controls.Add((Control) this.ac);
    this.f.Controls.Add((Control) this.ad);
    this.f.Controls.Add((Control) this.ae);
    this.f.Controls.Add((Control) this.af);
    this.f.Controls.Add((Control) this.g);
    this.f.Controls.Add((Control) this.ap);
    this.f.Dock = DockStyle.Fill;
    this.f.Location = new Point(0, 0);
    this.f.Name = "panel1";
    this.f.Size = new Size(355, 288);
    this.f.TabIndex = 0;
    this.o.FlatStyle = FlatStyle.Flat;
    this.o.Location = new Point(240, 245);
    this.o.Name = "button15";
    this.o.Size = new Size(100, 25);
    this.o.TabIndex = 22;
    this.o.Text = "Сетевой";
    this.o.UseVisualStyleBackColor = true;
    this.p.FlatStyle = FlatStyle.Flat;
    this.p.Location = new Point(240, 205);
    this.p.Name = "button16";
    this.p.Size = new Size(100, 25);
    this.p.TabIndex = 21;
    this.p.Text = "Транспортный";
    this.p.UseVisualStyleBackColor = true;
    this.q.FlatStyle = FlatStyle.Flat;
    this.q.Location = new Point(240, 165);
    this.q.Name = "button17";
    this.q.Size = new Size(100, 25);
    this.q.TabIndex = 20;
    this.q.Text = "Сеансовый";
    this.q.UseVisualStyleBackColor = true;
    this.r.FlatStyle = FlatStyle.Flat;
    this.r.Location = new Point(240, 125);
    this.r.Name = "button18";
    this.r.Size = new Size(100, 25);
    this.r.TabIndex = 19;
    this.r.Text = "Представления";
    this.r.UseVisualStyleBackColor = true;
    this.s.FlatStyle = FlatStyle.Flat;
    this.s.Location = new Point(240, 85);
    this.s.Name = "button19";
    this.s.Size = new Size(100, 25);
    this.s.TabIndex = 18;
    this.s.Text = "Прикладной";
    this.s.UseVisualStyleBackColor = true;
    this.t.FlatStyle = FlatStyle.Flat;
    this.t.Location = new Point(240, 45);
    this.t.Name = "button20";
    this.t.Size = new Size(100, 25);
    this.t.TabIndex = 17;
    this.t.Text = "ЭП";
    this.t.UseVisualStyleBackColor = true;
    this.u.FlatStyle = FlatStyle.Flat;
    this.u.Location = new Point(240, 5);
    this.u.Name = "button21";
    this.u.Size = new Size(100, 25);
    this.u.TabIndex = 16;
    this.u.Text = "Система А";
    this.u.UseVisualStyleBackColor = true;
    this.v.FlatStyle = FlatStyle.Flat;
    this.v.Location = new Point(125, 245);
    this.v.Name = "button3";
    this.v.Size = new Size(100, 25);
    this.v.TabIndex = 15;
    this.v.Text = "Сетевой";
    this.v.UseVisualStyleBackColor = true;
    this.w.FlatStyle = FlatStyle.Flat;
    this.w.Location = new Point(125, 205);
    this.w.Name = "button9";
    this.w.Size = new Size(100, 25);
    this.w.TabIndex = 14;
    this.w.Text = "Транспортный";
    this.w.UseVisualStyleBackColor = true;
    this.x.FlatStyle = FlatStyle.Flat;
    this.x.Location = new Point(125, 165);
    this.x.Name = "button10";
    this.x.Size = new Size(100, 25);
    this.x.TabIndex = 13;
    this.x.Text = "Сеансовый";
    this.x.UseVisualStyleBackColor = true;
    this.y.FlatStyle = FlatStyle.Flat;
    this.y.Location = new Point(125, 125);
    this.y.Name = "button11";
    this.y.Size = new Size(100, 25);
    this.y.TabIndex = 12;
    this.y.Text = "Представления";
    this.y.UseVisualStyleBackColor = true;
    this.z.FlatStyle = FlatStyle.Flat;
    this.z.Location = new Point(125, 85);
    this.z.Name = "button12";
    this.z.Size = new Size(100, 25);
    this.z.TabIndex = 11;
    this.z.Text = "Справочник";
    this.z.UseVisualStyleBackColor = true;
    this.z.Click += new EventHandler(this.l);
    this.aa.FlatStyle = FlatStyle.Flat;
    this.aa.Location = new Point(10, 245);
    this.aa.Name = "button8";
    this.aa.Size = new Size(100, 25);
    this.aa.TabIndex = 8;
    this.aa.Text = "Сетевой";
    this.aa.UseVisualStyleBackColor = true;
    this.ab.FlatStyle = FlatStyle.Flat;
    this.ab.Location = new Point(10, 205);
    this.ab.Name = "button6";
    this.ab.Size = new Size(100, 25);
    this.ab.TabIndex = 7;
    this.ab.Text = "Транспортный";
    this.ab.UseVisualStyleBackColor = true;
    this.ac.FlatStyle = FlatStyle.Flat;
    this.ac.Location = new Point(10, 165);
    this.ac.Name = "button7";
    this.ac.Size = new Size(100, 25);
    this.ac.TabIndex = 6;
    this.ac.Text = "Сеансовый";
    this.ac.UseVisualStyleBackColor = true;
    this.ad.FlatStyle = FlatStyle.Flat;
    this.ad.Location = new Point(10, 125);
    this.ad.Name = "button5";
    this.ad.Size = new Size(100, 25);
    this.ad.TabIndex = 5;
    this.ad.Text = "Представления";
    this.ad.UseVisualStyleBackColor = true;
    this.ae.FlatStyle = FlatStyle.Flat;
    this.ae.Location = new Point(10, 85);
    this.ae.Name = "button4";
    this.ae.Size = new Size(100, 25);
    this.ae.TabIndex = 4;
    this.ae.Text = "Прикладной";
    this.ae.UseVisualStyleBackColor = true;
    this.af.FlatStyle = FlatStyle.Flat;
    this.af.Location = new Point(10, 45);
    this.af.Name = "button2";
    this.af.Size = new Size(100, 25);
    this.af.TabIndex = 3;
    this.af.Text = "ЭП";
    this.af.UseVisualStyleBackColor = true;
    this.g.FlatStyle = FlatStyle.Flat;
    this.g.Location = new Point(10, 5);
    this.g.Name = "button1";
    this.g.Size = new Size(100, 25);
    this.g.TabIndex = 0;
    this.g.Text = "Система А";
    this.g.UseVisualStyleBackColor = true;
    this.g.Click += new EventHandler(this.m);
    this.ap.AutoSize = true;
    this.ap.Location = new Point(164, 28);
    this.ap.Name = "PrimitiveLabel";
    this.ap.Size = new Size(10, 13);
    this.ap.TabIndex = 3;
    this.ap.Text = " ";
    this.ap.TextAlign = ContentAlignment.MiddleCenter;
    this.h.BorderStyle = BorderStyle.FixedSingle;
    this.h.Dock = DockStyle.Fill;
    this.h.FormattingEnabled = true;
    this.h.Location = new Point(0, 0);
    this.h.Name = "VariablesListBox";
    this.h.Size = new Size(168, 288);
    this.h.TabIndex = 0;
    this.h.KeyDown += new KeyEventHandler(this.a);
    this.i.BorderStyle = BorderStyle.FixedSingle;
    this.i.Dock = DockStyle.Fill;
    this.i.FormattingEnabled = true;
    this.i.Location = new Point(0, 0);
    this.i.Name = "CodeListBox";
    this.i.Size = new Size(527, 129);
    this.i.TabIndex = 0;
    this.j.Items.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.k,
      (ToolStripItem) this.l,
      (ToolStripItem) this.m,
      (ToolStripItem) this.n
    });
    this.j.Location = new Point(0, 0);
    this.j.Name = "menuStrip";
    this.j.Size = new Size(527, 24);
    this.j.TabIndex = 1;
    this.j.Text = "menuStrip1";
    this.k.DropDownItems.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.al,
      (ToolStripItem) this.am,
      (ToolStripItem) this.an,
      (ToolStripItem) this.aq
    });
    this.k.Name = "выполнятьДоToolStripMenuItem";
    this.k.Size = new Size(108, 20);
    this.k.Text = "Выполнять до ...";
    this.al.Name = "NextLineMenuItem";
    this.al.ShortcutKeys = Keys.F7;
    this.al.Size = new Size(250, 22);
    this.al.Text = "следующей строки";
    this.al.Click += new EventHandler(this.i);
    this.am.Name = "NextEventMenuItem";
    this.am.ShortcutKeys = Keys.F8;
    this.am.Size = new Size(250, 22);
    this.am.Text = "следующего события";
    this.am.Click += new EventHandler(this.h);
    this.an.Name = "UntilBreakMenuItem";
    this.an.ShortcutKeys = Keys.F9;
    this.an.Size = new Size(250, 22);
    this.an.Text = "оператора break";
    this.an.Click += new EventHandler(this.g);
    this.aq.Name = "UntileBreakNoAnimeToolStripMenuItem";
    this.aq.ShortcutKeys = Keys.F10;
    this.aq.Size = new Size(250, 22);
    this.aq.Text = "оператора break без показа";
    this.aq.Click += new EventHandler(this.c);
    this.l.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.ao,
      (ToolStripItem) this.ar
    });
    this.l.Name = "переменныеToolStripMenuItem";
    this.l.Size = new Size(91, 20);
    this.l.Text = "Переменные";
    this.ao.Name = "AddVariableMenuItem";
    this.ao.Size = new Size(200, 22);
    this.ao.Text = "Добавить переменную";
    this.ao.Click += new EventHandler(this.f);
    this.m.Name = "остановкаToolStripMenuItem";
    this.m.Size = new Size(77, 20);
    this.m.Text = "Остановка";
    this.m.Click += new EventHandler(this.e);
    this.n.Name = "выходToolStripMenuItem";
    this.n.Size = new Size(54, 20);
    this.n.Text = "Выход";
    this.n.Click += new EventHandler(this.k);
    this.ag.Items.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.ah,
      (ToolStripItem) this.ai,
      (ToolStripItem) this.aj,
      (ToolStripItem) this.ak
    });
    this.ag.Location = new Point(0, 420);
    this.ag.Name = "statusStrip";
    this.ag.Size = new Size(527, 25);
    this.ag.TabIndex = 2;
    this.ag.Text = "statusStrip1";
    this.ah.AutoSize = false;
    this.ah.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.ah.Name = "SystemStripStatusLabel";
    this.ah.Size = new Size(75, 20);
    this.ai.AutoSize = false;
    this.ai.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.ai.Name = "EventStripStatusLabel";
    this.ai.Size = new Size(150, 20);
    this.ai.Click += new EventHandler(this.d);
    this.aj.AutoSize = false;
    this.aj.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.aj.Name = "LineStripStatusLabel";
    this.aj.Size = new Size(50, 20);
    this.ak.AutoSize = false;
    this.ak.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.ak.Name = "OperatorStripStatusLabel";
    this.ak.Size = new Size(100, 20);
    this.ar.Name = "ClearVarListMenuItem";
    this.ar.Size = new Size(200, 22);
    this.ar.Text = "Очистить список";
    this.ar.Click += new EventHandler(this.a);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(527, 445);
    this.Controls.Add((Control) this.ag);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.j);
    this.Name = "DebuggerForm";
    this.Text = "Отладчик";
    this.FormClosed += new FormClosedEventHandler(this.a);
    this.Shown += new EventHandler(this.j);
    this.d.Panel1.ResumeLayout(false);
    this.d.Panel2.ResumeLayout(false);
    this.d.ResumeLayout(false);
    this.e.Panel1.ResumeLayout(false);
    this.e.Panel2.ResumeLayout(false);
    this.e.ResumeLayout(false);
    this.f.ResumeLayout(false);
    this.f.PerformLayout();
    this.j.ResumeLayout(false);
    this.j.PerformLayout();
    this.ag.ResumeLayout(false);
    this.ag.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
