// Decompiled with JetBrains decompiler
// Type: ap
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class OptionsWindow : Form
{
  private Color a;
  private Font b;
  private IContainer c;
  private GroupBox d;
  private RadioButton e;
  private RadioButton f;
  private GroupBox g;
  private NumericUpDown h;
  private Label i;
  private NumericUpDown j;
  private NumericUpDown k;
  private NumericUpDown l;
  private Label m;
  private Label n;
  private Label o;
  private GroupBox p;
  private Label q;
  private CheckBox r;
  private TextBox s;
  private GroupBox t;
  private Button u;
  private Button v;
  private CheckBox w;
  private Button x;
  private Button y;
  private ColorDialog z;
  private FontDialog aa;
  private OpenFileDialog ab;
  private NumericUpDown ac;
  private Label ad;
  private GroupBox ae;
  private CheckBox af;
  private TextBox ag;
  private Label ah;
  private CheckBox ai;
  private CheckBox aj;
  private GroupBox ak;
  private TextBox al;
  private RadioButton am;
  private RadioButton an;
  private RadioButton ao;
  private OpenFileDialog ap;

  public OptionsWindow() => this.a();

  private void g(object A_0, EventArgs A_1)
  {
    global::MainWindow.o = this.e.Checked;
    global::MainWindow.k = (int) this.k.Value;
    global::MainWindow.i = (int) this.h.Value;
    global::MainWindow.j = (int) this.l.Value;
    global::MainWindow.l = (int) this.j.Value;
    global::MainWindow.m = this.r.Checked;
    global::MainWindow.n = this.w.Checked;
    global::MainWindow.h = this.s.Text;
    global::MainWindow.backColor = this.a;
    global::MainWindow.font = this.b;
    global::MainWindow.ag = (int) this.ac.Value;
    global::MainWindow.authSavePath = this.ag.Text;
    global::MainWindow.authSave = this.af.Checked;
    global::MainWindow.aj = this.ai.Checked;
    global::MainWindow.checkForUpdates = this.aj.Checked;
    if (this.ao.Checked)
      global::MainWindow.al = "res1";
    if (this.an.Checked)
      global::MainWindow.al = "res2";
    if (!this.am.Checked)
      return;
    global::MainWindow.al = this.al.Text;
  }

  private void f(object A_0, EventArgs A_1)
  {
    this.s.Text = global::MainWindow.h;
    this.h.Value = (Decimal) global::MainWindow.i;
    this.l.Value = (Decimal) global::MainWindow.j;
    this.j.Value = (Decimal) global::MainWindow.l;
    this.k.Value = (Decimal) global::MainWindow.k;
    this.r.Checked = global::MainWindow.m;
    this.w.Checked = global::MainWindow.n;
    this.e.Checked = global::MainWindow.o;
    this.f.Checked = !global::MainWindow.o;
    this.b = global::MainWindow.font;
    this.a = global::MainWindow.backColor;
    this.ac.Value = (Decimal) global::MainWindow.ag;
    this.ag.Text = global::MainWindow.authSavePath;
    this.af.Checked = global::MainWindow.authSave;
    this.ai.Checked = global::MainWindow.aj;
    this.aj.Checked = global::MainWindow.checkForUpdates;
    switch (global::MainWindow.al)
    {
      case "res1":
        this.ao.Checked = true;
        break;
      case "res2":
        this.an.Checked = true;
        break;
      default:
        this.am.Checked = true;
        this.al.Text = global::MainWindow.al;
        break;
    }
  }

  private void e(object A_0, EventArgs A_1)
  {
    if (this.z.ShowDialog() != DialogResult.OK)
      return;
    this.a = this.z.Color;
  }

  private void d(object A_0, EventArgs A_1)
  {
    if (this.aa.ShowDialog() != DialogResult.OK)
      return;
    this.b = this.aa.Font;
  }

  private void c(object A_0, EventArgs A_1)
  {
    this.ab.FileName = this.s.Text;
    this.ab.Filter = "Текстовые файлы (*.txt)|*.txt";
    this.ab.Title = "Файл журнала";
    this.ab.InitialDirectory = Path.GetDirectoryName(this.s.Text);
    if (this.ab.ShowDialog() != DialogResult.OK)
      return;
    this.s.Text = this.ab.FileName;
  }

  private void b(object A_0, EventArgs A_1)
  {
    this.ab.FileName = this.ag.Text;
    this.ab.Filter = "Файлы комплекса (*.lab)|*.lab";
    this.ab.Title = "Файл автосохранения";
    this.ab.InitialDirectory = Path.GetDirectoryName(this.ag.Text);
    if (this.ab.ShowDialog() != DialogResult.OK)
      return;
    this.ag.Text = this.ab.FileName;
  }

  private void a(object A_0, EventArgs A_1)
  {
    if (!this.am.Checked)
      return;
    if (this.ap.ShowDialog() == DialogResult.OK)
      this.al.Text = this.ap.FileName;
    else
      this.ao.Checked = true;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.c != null)
      this.c.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.d = new GroupBox();
    this.f = new RadioButton();
    this.e = new RadioButton();
    this.g = new GroupBox();
    this.i = new Label();
    this.j = new NumericUpDown();
    this.k = new NumericUpDown();
    this.l = new NumericUpDown();
    this.m = new Label();
    this.n = new Label();
    this.o = new Label();
    this.h = new NumericUpDown();
    this.p = new GroupBox();
    this.r = new CheckBox();
    this.s = new TextBox();
    this.q = new Label();
    this.t = new GroupBox();
    this.u = new Button();
    this.v = new Button();
    this.w = new CheckBox();
    this.x = new Button();
    this.y = new Button();
    this.z = new ColorDialog();
    this.aa = new FontDialog();
    this.ab = new OpenFileDialog();
    this.ac = new NumericUpDown();
    this.ad = new Label();
    this.ae = new GroupBox();
    this.af = new CheckBox();
    this.ag = new TextBox();
    this.ah = new Label();
    this.ai = new CheckBox();
    this.aj = new CheckBox();
    this.ak = new GroupBox();
    this.ao = new RadioButton();
    this.an = new RadioButton();
    this.am = new RadioButton();
    this.al = new TextBox();
    this.ap = new OpenFileDialog();
    this.d.SuspendLayout();
    this.g.SuspendLayout();
    this.j.BeginInit();
    this.k.BeginInit();
    this.l.BeginInit();
    this.h.BeginInit();
    this.p.SuspendLayout();
    this.t.SuspendLayout();
    this.ac.BeginInit();
    this.ae.SuspendLayout();
    this.ak.SuspendLayout();
    this.SuspendLayout();
    this.d.Controls.Add((Control) this.f);
    this.d.Controls.Add((Control) this.e);
    this.d.FlatStyle = FlatStyle.Flat;
    this.d.Location = new Point(12, 12);
    this.d.Name = "groupBox1";
    this.d.Size = new Size(256, 81);
    this.d.TabIndex = 0;
    this.d.TabStop = false;
    this.d.Text = "Сохранять размер/положение окна редактора событий";
    this.f.AutoSize = true;
    this.f.Location = new Point(6, 54);
    this.f.Name = "PersonalradioButton";
    this.f.Size = new Size(138, 17);
    this.f.TabIndex = 1;
    this.f.Text = "Для каждого события";
    this.f.UseVisualStyleBackColor = true;
    this.e.AutoSize = true;
    this.e.Checked = true;
    this.e.Location = new Point(6, 31);
    this.e.Name = "CommonradioButton";
    this.e.Size = new Size(107, 17);
    this.e.TabIndex = 0;
    this.e.TabStop = true;
    this.e.Text = "Общее для всех";
    this.e.UseVisualStyleBackColor = true;
    this.g.Controls.Add((Control) this.i);
    this.g.Controls.Add((Control) this.j);
    this.g.Controls.Add((Control) this.k);
    this.g.Controls.Add((Control) this.l);
    this.g.Controls.Add((Control) this.m);
    this.g.Controls.Add((Control) this.n);
    this.g.Controls.Add((Control) this.o);
    this.g.Controls.Add((Control) this.h);
    this.g.FlatStyle = FlatStyle.Flat;
    this.g.Location = new Point(12, 99);
    this.g.Name = "groupBox2";
    this.g.Size = new Size(256, 126);
    this.g.TabIndex = 1;
    this.g.TabStop = false;
    this.g.Text = "Размер/положение окна редактора событий";
    this.i.AutoSize = true;
    this.i.Location = new Point(6, 101);
    this.i.Name = "label5";
    this.i.Size = new Size(46, 13);
    this.i.TabIndex = 7;
    this.i.Text = "Ширина";
    this.j.Location = new Point(174, 99);
    this.j.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.j.Name = "WidthUpDown";
    this.j.Size = new Size(76, 20);
    this.j.TabIndex = 6;
    this.k.Location = new Point(174, 72);
    this.k.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.k.Name = "HeightUpDown";
    this.k.Size = new Size(76, 20);
    this.k.TabIndex = 5;
    this.l.Location = new Point(174, 45);
    this.l.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.l.Name = "TopUpDown";
    this.l.Size = new Size(76, 20);
    this.l.TabIndex = 4;
    this.m.AutoSize = true;
    this.m.Location = new Point(6, 74);
    this.m.Name = "label3";
    this.m.Size = new Size(45, 13);
    this.m.TabIndex = 3;
    this.m.Text = "Высота";
    this.n.AutoSize = true;
    this.n.Location = new Point(6, 47);
    this.n.Name = "label2";
    this.n.Size = new Size(76, 13);
    this.n.TabIndex = 2;
    this.n.Text = "Верхний край";
    this.o.AutoSize = true;
    this.o.Location = new Point(6, 20);
    this.o.Name = "label1";
    this.o.Size = new Size(68, 13);
    this.o.TabIndex = 1;
    this.o.Text = "Левый край";
    this.h.Location = new Point(174, 18);
    this.h.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.h.Name = "LeftUpDown";
    this.h.Size = new Size(76, 20);
    this.h.TabIndex = 0;
    this.p.Controls.Add((Control) this.r);
    this.p.Controls.Add((Control) this.s);
    this.p.Controls.Add((Control) this.q);
    this.p.FlatStyle = FlatStyle.Flat;
    this.p.Location = new Point(13, 232);
    this.p.Name = "groupBox3";
    this.p.Size = new Size((int) byte.MaxValue, 67);
    this.p.TabIndex = 2;
    this.p.TabStop = false;
    this.p.Text = "Журнал";
    this.r.AutoSize = true;
    this.r.Location = new Point(8, 39);
    this.r.Name = "DisplaycheckBox";
    this.r.Size = new Size(124, 17);
    this.r.TabIndex = 2;
    this.r.Text = "Выводить на экран";
    this.r.UseVisualStyleBackColor = true;
    this.s.Location = new Point(75, 13);
    this.s.Name = "LogFileNametextBox";
    this.s.Size = new Size(174, 20);
    this.s.TabIndex = 1;
    this.s.Click += new EventHandler(this.c);
    this.q.AutoSize = true;
    this.q.Location = new Point(5, 16);
    this.q.Name = "label4";
    this.q.Size = new Size(64, 13);
    this.q.TabIndex = 0;
    this.q.Text = "Имя файла";
    this.t.Controls.Add((Control) this.u);
    this.t.Controls.Add((Control) this.v);
    this.t.FlatStyle = FlatStyle.Flat;
    this.t.Location = new Point(274, 12);
    this.t.Name = "groupBox4";
    this.t.Size = new Size(256, 54);
    this.t.TabIndex = 3;
    this.t.TabStop = false;
    this.t.Text = "Настройки редактора";
    this.u.FlatStyle = FlatStyle.Flat;
    this.u.Location = new Point(146, 20);
    this.u.Name = "Backgroundbutton";
    this.u.Size = new Size(104, 23);
    this.u.TabIndex = 4;
    this.u.Text = "Фон";
    this.u.UseVisualStyleBackColor = true;
    this.u.Click += new EventHandler(this.e);
    this.v.FlatStyle = FlatStyle.Flat;
    this.v.Location = new Point(9, 20);
    this.v.Name = "Fontbutton";
    this.v.Size = new Size(104, 23);
    this.v.TabIndex = 0;
    this.v.Text = "Шрифт";
    this.v.UseVisualStyleBackColor = true;
    this.v.Click += new EventHandler(this.d);
    this.w.AutoSize = true;
    this.w.Location = new Point(283, 72);
    this.w.Name = "DelaycheckBox";
    this.w.Size = new Size(179, 17);
    this.w.TabIndex = 4;
    this.w.Text = "Задержка во время эмуляции";
    this.w.UseVisualStyleBackColor = true;
    this.x.DialogResult = DialogResult.OK;
    this.x.FlatStyle = FlatStyle.Flat;
    this.x.Location = new Point(426, 346);
    this.x.Name = "OKbutton";
    this.x.Size = new Size(104, 23);
    this.x.TabIndex = 5;
    this.x.Text = "Сохранить";
    this.x.UseVisualStyleBackColor = true;
    this.x.Click += new EventHandler(this.g);
    this.y.DialogResult = DialogResult.Cancel;
    this.y.FlatStyle = FlatStyle.Flat;
    this.y.Location = new Point(12, 346);
    this.y.Name = "Cancelbutton";
    this.y.Size = new Size(104, 23);
    this.y.TabIndex = 6;
    this.y.Text = "Отмена";
    this.y.UseVisualStyleBackColor = true;
    this.ab.CheckFileExists = false;
    this.ab.DefaultExt = "txt";
    this.ab.FileName = "log.txt";
    this.ab.Filter = "Текстовые файлы (*.txt)|*.txt";
    this.ab.RestoreDirectory = true;
    this.ab.Title = "Файл журнала";
    this.ac.Location = new Point(462, 97);
    this.ac.Name = "DebugDelaynumericUpDown";
    this.ac.Size = new Size(62, 20);
    this.ac.TabIndex = 7;
    this.ad.AutoSize = true;
    this.ad.Location = new Point(280, 99);
    this.ad.Name = "label6";
    this.ad.Size = new Size(166, 13);
    this.ad.TabIndex = 8;
    this.ad.Text = "Задержка анимации отладчика";
    this.ae.Controls.Add((Control) this.af);
    this.ae.Controls.Add((Control) this.ag);
    this.ae.Controls.Add((Control) this.ah);
    this.ae.FlatStyle = FlatStyle.Flat;
    this.ae.Location = new Point(275, 123);
    this.ae.Name = "groupBox5";
    this.ae.Size = new Size((int) byte.MaxValue, 67);
    this.ae.TabIndex = 9;
    this.ae.TabStop = false;
    this.ae.Text = "Автосохранене";
    this.af.AutoSize = true;
    this.af.Location = new Point(8, 39);
    this.af.Name = "AutoSavecheckBox";
    this.af.Size = new Size(160, 17);
    this.af.TabIndex = 2;
    this.af.Text = "Включить автосохранение";
    this.af.UseVisualStyleBackColor = true;
    this.ag.Location = new Point(75, 13);
    this.ag.Name = "AutoSavetextBox";
    this.ag.Size = new Size(174, 20);
    this.ag.TabIndex = 1;
    this.ag.Click += new EventHandler(this.b);
    this.ah.AutoSize = true;
    this.ah.Location = new Point(5, 16);
    this.ah.Name = "label7";
    this.ah.Size = new Size(64, 13);
    this.ah.TabIndex = 0;
    this.ah.Text = "Имя файла";
    this.ai.AutoSize = true;
    this.ai.Location = new Point(12, 305);
    this.ai.Name = "AskOnOpenCheckBox";
    this.ai.Size = new Size(212, 17);
    this.ai.TabIndex = 10;
    this.ai.Text = "Запрос на сохранение при открытии";
    this.ai.UseVisualStyleBackColor = true;
    this.aj.AutoSize = true;
    this.aj.Location = new Point(12, 323);
    this.aj.Name = "updatecheckBox";
    this.aj.Size = new Size(139, 17);
    this.aj.TabIndex = 11;
    this.aj.Text = "Проверка обновлений";
    this.aj.UseVisualStyleBackColor = true;
    this.ak.Controls.Add((Control) this.al);
    this.ak.Controls.Add((Control) this.am);
    this.ak.Controls.Add((Control) this.an);
    this.ak.Controls.Add((Control) this.ao);
    this.ak.Location = new Point(275, 199);
    this.ak.Name = "groupBox6";
    this.ak.Size = new Size((int) byte.MaxValue, 100);
    this.ak.TabIndex = 12;
    this.ak.TabStop = false;
    this.ak.Text = "Фон";
    this.ao.AutoSize = true;
    this.ao.Location = new Point(6, 20);
    this.ao.Name = "BGButton1";
    this.ao.Size = new Size(57, 17);
    this.ao.TabIndex = 0;
    this.ao.TabStop = true;
    this.ao.Text = "Фон 1";
    this.ao.UseVisualStyleBackColor = true;
    this.an.AutoSize = true;
    this.an.Location = new Point(145, 20);
    this.an.Name = "BGButton2";
    this.an.Size = new Size(57, 17);
    this.an.TabIndex = 1;
    this.an.TabStop = true;
    this.an.Text = "Фон 2";
    this.an.UseVisualStyleBackColor = true;
    this.am.AutoSize = true;
    this.am.Location = new Point(6, 47);
    this.am.Name = "BGButtonCustom";
    this.am.Size = new Size(77, 17);
    this.am.TabIndex = 2;
    this.am.TabStop = true;
    this.am.Text = "Из файла:";
    this.am.UseVisualStyleBackColor = true;
    this.am.CheckedChanged += new EventHandler(this.a);
    this.al.Location = new Point(90, 46);
    this.al.Name = "BGFiletextBox";
    this.al.ReadOnly = true;
    this.al.Size = new Size(159, 20);
    this.al.TabIndex = 3;
    this.ap.DefaultExt = "bmp";
    this.ap.Filter = "Изображения (*.bmp)|*.bmp";
    this.AcceptButton = (IButtonControl) this.x;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.y;
    this.ClientSize = new Size(543, 377);
    this.Controls.Add((Control) this.ak);
    this.Controls.Add((Control) this.aj);
    this.Controls.Add((Control) this.ai);
    this.Controls.Add((Control) this.ad);
    this.Controls.Add((Control) this.ac);
    this.Controls.Add((Control) this.y);
    this.Controls.Add((Control) this.x);
    this.Controls.Add((Control) this.w);
    this.Controls.Add((Control) this.t);
    this.Controls.Add((Control) this.p);
    this.Controls.Add((Control) this.g);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.ae);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.Name = "SettingsForm";
    this.Text = "Настройки";
    this.Shown += new EventHandler(this.f);
    this.d.ResumeLayout(false);
    this.d.PerformLayout();
    this.g.ResumeLayout(false);
    this.g.PerformLayout();
    this.j.EndInit();
    this.k.EndInit();
    this.l.EndInit();
    this.h.EndInit();
    this.p.ResumeLayout(false);
    this.p.PerformLayout();
    this.t.ResumeLayout(false);
    this.ac.EndInit();
    this.ae.ResumeLayout(false);
    this.ae.PerformLayout();
    this.ak.ResumeLayout(false);
    this.ak.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
