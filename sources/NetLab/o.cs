// Decompiled with JetBrains decompiler
// Type: o
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class o : Form
{
  private global::v a;
  private IContainer b;
  private NumericUpDown c;
  private NumericUpDown d;
  private NumericUpDown e;
  private NumericUpDown f;
  private NumericUpDown g;
  private NumericUpDown h;
  private NumericUpDown i;
  private NumericUpDown j;
  private NumericUpDown k;
  private NumericUpDown l;
  private NumericUpDown m;
  private NumericUpDown n;
  private NumericUpDown o;
  private NumericUpDown p;
  private Label q;
  private Label r;
  private Label s;
  private Label t;
  private Label u;
  private Label v;
  private Label w;
  private Label x;
  private Label y;
  private Label z;
  private Label aa;
  private Label ab;
  private Label ac;
  private Label ad;
  private Label ae;
  private Label af;
  private Label ag;
  private Label ah;
  private Label ai;
  private Label aj;
  private Button ak;
  private Button al;
  private Label am;
  private Label an;

  public o(global::v A_0)
  {
    this.a();
    this.a = A_0;
  }

  private void b(object A_0, EventArgs A_1)
  {
    this.c.Value = (Decimal) this.a.c().d().d().j();
    this.d.Value = (Decimal) this.a.c().d().d().i().c();
    this.m.Value = (Decimal) this.a.c().d().d().i().b();
    this.e.Value = (Decimal) (int) (this.a.c().d().d().h() * 10000.0);
    this.f.Value = (Decimal) this.a.c().d().d().f().c();
    this.n.Value = (Decimal) this.a.c().d().d().f().b();
    this.g.Value = (Decimal) this.a.c().d().d().g().c();
    this.o.Value = (Decimal) this.a.c().d().d().g().b();
    this.h.Value = (Decimal) (int) (this.a.c().d().d().e() * 10000.0);
    this.i.Value = (Decimal) (int) (this.a.c().d().d().d() * 10000.0);
    this.j.Value = (Decimal) (int) (this.a.c().d().d().a() * 10000.0);
    this.k.Value = (Decimal) (int) (this.a.c().d().d().c() * 10000.0);
    this.l.Value = (Decimal) this.a.c().d().d().b().c();
    this.p.Value = (Decimal) this.a.c().d().d().b().b();
    this.c.Enabled = global::v.f;
    this.d.Enabled = global::v.f;
    this.m.Enabled = global::v.f;
    this.e.Enabled = global::v.f;
    this.f.Enabled = global::v.f;
    this.n.Enabled = global::v.f;
    this.g.Enabled = global::v.f;
    this.o.Enabled = global::v.f;
    this.h.Enabled = global::v.f;
    this.i.Enabled = global::v.f;
    this.j.Enabled = global::v.f;
    this.k.Enabled = global::v.f;
    this.l.Enabled = global::v.f;
    this.p.Enabled = global::v.f;
  }

  private void a(object A_0, EventArgs A_1)
  {
    if (global::v.f)
    {
      this.a.c().d().d().a((int) this.c.Value);
      this.a.c().d().d().i().b((int) this.d.Value);
      this.a.c().d().d().i().a((int) this.m.Value);
      this.a.c().d().d().e((double) this.e.Value / 10000.0);
      this.a.c().d().d().f().b((int) this.f.Value);
      this.a.c().d().d().f().a((int) this.n.Value);
      this.a.c().d().d().g().b((int) this.g.Value);
      this.a.c().d().d().g().a((int) this.o.Value);
      this.a.c().d().d().d((double) this.h.Value / 10000.0);
      this.a.c().d().d().c((double) this.i.Value / 10000.0);
      this.a.c().d().d().a((double) this.i.Value / 10000.0);
      this.a.c().d().d().b((double) this.k.Value / 10000.0);
      this.a.c().d().d().b().b((int) this.l.Value);
      this.a.c().d().d().b().a((int) this.p.Value);
      this.a.c().c().d().a((int) this.c.Value);
      this.a.c().c().d().i().b((int) this.d.Value);
      this.a.c().c().d().i().a((int) this.m.Value);
      this.a.c().c().d().e((double) this.e.Value / 10000.0);
      this.a.c().c().d().f().b((int) this.f.Value);
      this.a.c().c().d().f().a((int) this.n.Value);
      this.a.c().c().d().g().b((int) this.g.Value);
      this.a.c().c().d().g().a((int) this.o.Value);
      this.a.c().c().d().d((double) this.h.Value / 10000.0);
      this.a.c().c().d().c((double) this.i.Value / 10000.0);
      this.a.c().c().d().a((double) this.i.Value / 10000.0);
      this.a.c().c().d().b((double) this.k.Value / 10000.0);
      this.a.c().c().d().b().b((int) this.l.Value);
      this.a.c().c().d().b().a((int) this.p.Value);
      this.a.c().b().d().a((int) this.c.Value);
      this.a.c().b().d().i().b((int) this.d.Value);
      this.a.c().b().d().i().a((int) this.m.Value);
      this.a.c().b().d().e((double) this.e.Value / 10000.0);
      this.a.c().b().d().f().b((int) this.f.Value);
      this.a.c().b().d().f().a((int) this.n.Value);
      this.a.c().b().d().g().b((int) this.g.Value);
      this.a.c().b().d().g().a((int) this.o.Value);
      this.a.c().b().d().d((double) this.h.Value / 10000.0);
      this.a.c().b().d().c((double) this.i.Value / 10000.0);
      this.a.c().b().d().a((double) this.i.Value / 10000.0);
      this.a.c().b().d().b((double) this.k.Value / 10000.0);
      this.a.c().b().d().b().b((int) this.l.Value);
      this.a.c().b().d().b().a((int) this.p.Value);
    }
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.b != null)
      this.b.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.c = new NumericUpDown();
    this.d = new NumericUpDown();
    this.e = new NumericUpDown();
    this.f = new NumericUpDown();
    this.g = new NumericUpDown();
    this.h = new NumericUpDown();
    this.i = new NumericUpDown();
    this.j = new NumericUpDown();
    this.k = new NumericUpDown();
    this.l = new NumericUpDown();
    this.m = new NumericUpDown();
    this.n = new NumericUpDown();
    this.o = new NumericUpDown();
    this.p = new NumericUpDown();
    this.q = new Label();
    this.r = new Label();
    this.s = new Label();
    this.t = new Label();
    this.u = new Label();
    this.v = new Label();
    this.w = new Label();
    this.x = new Label();
    this.y = new Label();
    this.z = new Label();
    this.aa = new Label();
    this.ab = new Label();
    this.ac = new Label();
    this.ad = new Label();
    this.ae = new Label();
    this.af = new Label();
    this.ag = new Label();
    this.ah = new Label();
    this.ai = new Label();
    this.aj = new Label();
    this.ak = new Button();
    this.al = new Button();
    this.am = new Label();
    this.an = new Label();
    this.c.BeginInit();
    this.d.BeginInit();
    this.e.BeginInit();
    this.f.BeginInit();
    this.g.BeginInit();
    this.h.BeginInit();
    this.i.BeginInit();
    this.j.BeginInit();
    this.k.BeginInit();
    this.l.BeginInit();
    this.m.BeginInit();
    this.n.BeginInit();
    this.o.BeginInit();
    this.p.BeginInit();
    this.SuspendLayout();
    this.c.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.c.Location = new Point(263, 31);
    this.c.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.c.Name = "MaxPacSizeEdit";
    this.c.Size = new Size(73, 21);
    this.c.TabIndex = 0;
    this.d.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.d.Location = new Point(263, 58);
    this.d.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.d.Name = "ConnectDelayBaseEdit";
    this.d.Size = new Size(73, 21);
    this.d.TabIndex = 1;
    this.e.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.e.Location = new Point(263, 85);
    this.e.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.e.Name = "ConnErrorProbEdit";
    this.e.Size = new Size(73, 21);
    this.e.TabIndex = 2;
    this.f.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.f.Location = new Point(263, 112);
    this.f.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.f.Name = "TransitDelayBaseEdit";
    this.f.Size = new Size(73, 21);
    this.f.TabIndex = 3;
    this.g.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.g.Location = new Point(263, 139);
    this.g.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.g.Name = "TransferRateBaseEdit";
    this.g.Size = new Size(73, 21);
    this.g.TabIndex = 4;
    this.h.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.h.Location = new Point(263, 166);
    this.h.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.h.Name = "CorrupProbEdit";
    this.h.Size = new Size(73, 21);
    this.h.TabIndex = 5;
    this.i.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.i.Location = new Point(263, 193);
    this.i.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.i.Name = "LoseProbEdit";
    this.i.Size = new Size(73, 21);
    this.i.TabIndex = 6;
    this.j.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.j.Location = new Point(263, 220);
    this.j.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.j.Name = "DuplProbEdit";
    this.j.Size = new Size(73, 21);
    this.j.TabIndex = 7;
    this.k.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.k.Location = new Point(263, 247);
    this.k.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.k.Name = "DisconnProbEdit";
    this.k.Size = new Size(73, 21);
    this.k.TabIndex = 8;
    this.l.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.l.Location = new Point(263, 274);
    this.l.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.l.Name = "DisconnDelayBaseEdit";
    this.l.Size = new Size(73, 21);
    this.l.TabIndex = 9;
    this.m.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.m.Location = new Point(342, 58);
    this.m.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.m.Name = "ConnectDelayDispEdit";
    this.m.Size = new Size(73, 21);
    this.m.TabIndex = 10;
    this.n.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.n.Location = new Point(342, 112);
    this.n.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.n.Name = "TransitDelayDispEdit";
    this.n.Size = new Size(73, 21);
    this.n.TabIndex = 11;
    this.o.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.o.Location = new Point(342, 139);
    this.o.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.o.Name = "TransferRateDispEdit";
    this.o.Size = new Size(73, 21);
    this.o.TabIndex = 12;
    this.p.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.p.Location = new Point(342, 274);
    this.p.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.p.Name = "DisconnDelayDispEdit";
    this.p.Size = new Size(73, 21);
    this.p.TabIndex = 13;
    this.q.AutoSize = true;
    this.q.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.q.Location = new Point(12, 33);
    this.q.Name = "label1";
    this.q.Size = new Size(190, 15);
    this.q.TabIndex = 14;
    this.q.Text = "Максимальный размер пакета:";
    this.r.AutoSize = true;
    this.r.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.r.Location = new Point(12, 60);
    this.r.Name = "label2";
    this.r.Size = new Size(248, 15);
    this.r.TabIndex = 15;
    this.r.Text = "Задержка при установлении соединения:";
    this.s.AutoSize = true;
    this.s.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.s.Location = new Point(12, 87);
    this.s.Name = "label3";
    this.s.Size = new Size(201, 15);
    this.s.TabIndex = 16;
    this.s.Text = "Вер. ошибки при уст. соединения:";
    this.t.AutoSize = true;
    this.t.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.t.Location = new Point(12, 114);
    this.t.Name = "label4";
    this.t.Size = new Size(138, 15);
    this.t.TabIndex = 17;
    this.t.Text = "Транзитная задержка:";
    this.u.AutoSize = true;
    this.u.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.u.Location = new Point(12, 141);
    this.u.Name = "label5";
    this.u.Size = new Size(169, 15);
    this.u.TabIndex = 18;
    this.u.Text = "Скорость передачи данных:";
    this.v.AutoSize = true;
    this.v.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.v.Location = new Point(12, 168);
    this.v.Name = "label6";
    this.v.Size = new Size(197, 15);
    this.v.TabIndex = 19;
    this.v.Text = "Вероятность искажения пакета:";
    this.w.AutoSize = true;
    this.w.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.w.Location = new Point(12, 195);
    this.w.Name = "label7";
    this.w.Size = new Size(222, 15);
    this.w.TabIndex = 20;
    this.w.Text = "Вероятность потери пакета данных:";
    this.x.AutoSize = true;
    this.x.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.x.Location = new Point(12, 249);
    this.x.Name = "label8";
    this.x.Size = new Size(227, 15);
    this.x.TabIndex = 21;
    this.x.Text = "Вер. случайного разрыва соединения:";
    this.y.AutoSize = true;
    this.y.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.y.Location = new Point(12, 276);
    this.y.Name = "label9";
    this.y.Size = new Size(217, 15);
    this.y.TabIndex = 22;
    this.y.Text = "Задержка при разрыве соединения:";
    this.z.AutoSize = true;
    this.z.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.z.Location = new Point(12, 222);
    this.z.Name = "label10";
    this.z.Size = new Size(216, 15);
    this.z.TabIndex = 23;
    this.z.Text = "Вероятность появления дубликата:";
    this.aa.AutoSize = true;
    this.aa.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.aa.Location = new Point(342, 168);
    this.aa.Name = "label11";
    this.aa.Size = new Size(27, 15);
    this.aa.TabIndex = 24;
    this.aa.Text = "x10";
    this.ab.AutoSize = true;
    this.ab.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.ab.Location = new Point(366, 168);
    this.ab.Name = "label12";
    this.ab.Size = new Size(12, 9);
    this.ab.TabIndex = 25;
    this.ab.Text = "-4";
    this.ac.AutoSize = true;
    this.ac.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.ac.Location = new Point(366, 195);
    this.ac.Name = "label13";
    this.ac.Size = new Size(12, 9);
    this.ac.TabIndex = 27;
    this.ac.Text = "-4";
    this.ad.AutoSize = true;
    this.ad.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.ad.Location = new Point(342, 195);
    this.ad.Name = "label14";
    this.ad.Size = new Size(27, 15);
    this.ad.TabIndex = 26;
    this.ad.Text = "x10";
    this.ae.AutoSize = true;
    this.ae.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.ae.Location = new Point(366, 222);
    this.ae.Name = "label15";
    this.ae.Size = new Size(12, 9);
    this.ae.TabIndex = 29;
    this.ae.Text = "-4";
    this.af.AutoSize = true;
    this.af.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.af.Location = new Point(342, 222);
    this.af.Name = "label16";
    this.af.Size = new Size(27, 15);
    this.af.TabIndex = 28;
    this.af.Text = "x10";
    this.ag.AutoSize = true;
    this.ag.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.ag.Location = new Point(366, 249);
    this.ag.Name = "label17";
    this.ag.Size = new Size(12, 9);
    this.ag.TabIndex = 31;
    this.ag.Text = "-4";
    this.ah.AutoSize = true;
    this.ah.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.ah.Location = new Point(342, 249);
    this.ah.Name = "label18";
    this.ah.Size = new Size(27, 15);
    this.ah.TabIndex = 30;
    this.ah.Text = "x10";
    this.ai.AutoSize = true;
    this.ai.Location = new Point(269, 9);
    this.ai.Name = "label19";
    this.ai.Size = new Size(53, 13);
    this.ai.TabIndex = 32;
    this.ai.Text = "Среднее:";
    this.aj.AutoSize = true;
    this.aj.Location = new Point(342, 9);
    this.aj.Name = "label20";
    this.aj.Size = new Size(53, 13);
    this.aj.TabIndex = 33;
    this.aj.Text = "Разброс:";
    this.ak.Location = new Point(261, 305);
    this.ak.Name = "SaveButton";
    this.ak.Size = new Size(75, 23);
    this.ak.TabIndex = 0;
    this.ak.Text = "Сохранить";
    this.ak.UseVisualStyleBackColor = true;
    this.ak.Click += new EventHandler(this.a);
    this.al.DialogResult = DialogResult.Cancel;
    this.al.Location = new Point(340, 305);
    this.al.Name = "Cancel_Button";
    this.al.Size = new Size(75, 23);
    this.al.TabIndex = 35;
    this.al.Text = "Отмена";
    this.al.UseVisualStyleBackColor = true;
    this.am.AutoSize = true;
    this.am.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.am.Location = new Point(366, 87);
    this.am.Name = "label21";
    this.am.Size = new Size(12, 9);
    this.am.TabIndex = 37;
    this.am.Text = "-4";
    this.an.AutoSize = true;
    this.an.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.an.Location = new Point(342, 87);
    this.an.Name = "label22";
    this.an.Size = new Size(27, 15);
    this.an.TabIndex = 36;
    this.an.Text = "x10";
    this.AcceptButton = (IButtonControl) this.ak;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.al;
    this.ClientSize = new Size(424, 337);
    this.Controls.Add((Control) this.am);
    this.Controls.Add((Control) this.an);
    this.Controls.Add((Control) this.al);
    this.Controls.Add((Control) this.ak);
    this.Controls.Add((Control) this.aj);
    this.Controls.Add((Control) this.ai);
    this.Controls.Add((Control) this.ag);
    this.Controls.Add((Control) this.ah);
    this.Controls.Add((Control) this.ae);
    this.Controls.Add((Control) this.af);
    this.Controls.Add((Control) this.ac);
    this.Controls.Add((Control) this.ad);
    this.Controls.Add((Control) this.ab);
    this.Controls.Add((Control) this.aa);
    this.Controls.Add((Control) this.z);
    this.Controls.Add((Control) this.y);
    this.Controls.Add((Control) this.x);
    this.Controls.Add((Control) this.w);
    this.Controls.Add((Control) this.v);
    this.Controls.Add((Control) this.u);
    this.Controls.Add((Control) this.t);
    this.Controls.Add((Control) this.s);
    this.Controls.Add((Control) this.r);
    this.Controls.Add((Control) this.q);
    this.Controls.Add((Control) this.p);
    this.Controls.Add((Control) this.o);
    this.Controls.Add((Control) this.n);
    this.Controls.Add((Control) this.m);
    this.Controls.Add((Control) this.l);
    this.Controls.Add((Control) this.k);
    this.Controls.Add((Control) this.j);
    this.Controls.Add((Control) this.i);
    this.Controls.Add((Control) this.h);
    this.Controls.Add((Control) this.g);
    this.Controls.Add((Control) this.f);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.c);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.Name = "NetEmuSetup";
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.Text = "Настройка сетевого эмулятора";
    this.Shown += new EventHandler(this.b);
    this.c.EndInit();
    this.d.EndInit();
    this.e.EndInit();
    this.f.EndInit();
    this.g.EndInit();
    this.h.EndInit();
    this.i.EndInit();
    this.j.EndInit();
    this.k.EndInit();
    this.l.EndInit();
    this.m.EndInit();
    this.n.EndInit();
    this.o.EndInit();
    this.p.EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
