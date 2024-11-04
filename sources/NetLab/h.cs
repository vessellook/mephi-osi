// Decompiled with JetBrains decompiler
// Type: h
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
public class h : Form
{
  private IContainer b;
  private Button c;
  private Button d;
  private Label e;
  private ComboBox f;

  [CompilerGenerated]
  [SpecialName]
  public string b() => this.a;

  public h(string A_0, string[] A_1)
  {
    this.a();
    this.e.Text = A_0;
    this.f.Items.AddRange((object[]) A_1);
  }

  private void b(object A_0, EventArgs A_1) => this.Close();

  private void a(object A_0, EventArgs A_1)
  {
    // ISSUE: reference to a compiler-generated method
    this.a(this.f.Text);
    this.DialogResult = DialogResult.OK;
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
    this.c = new Button();
    this.d = new Button();
    this.e = new Label();
    this.f = new ComboBox();
    this.SuspendLayout();
    this.c.FlatStyle = FlatStyle.Flat;
    this.c.Location = new Point(130, 79);
    this.c.Name = "CopyButton";
    this.c.Size = new Size(95, 23);
    this.c.TabIndex = 0;
    this.c.Text = "Копировать";
    this.c.UseVisualStyleBackColor = true;
    this.c.Click += new EventHandler(this.a);
    this.d.DialogResult = DialogResult.Cancel;
    this.d.FlatStyle = FlatStyle.Flat;
    this.d.Location = new Point(12, 79);
    this.d.Name = "Cancel_Button";
    this.d.Size = new Size(95, 23);
    this.d.TabIndex = 1;
    this.d.Text = "Отмена";
    this.d.UseVisualStyleBackColor = true;
    this.d.Click += new EventHandler(this.b);
    this.e.Location = new Point(9, 9);
    this.e.Name = "label";
    this.e.Size = new Size(216, 40);
    this.e.TabIndex = 2;
    this.e.Text = "Копировать событие";
    this.e.TextAlign = ContentAlignment.MiddleCenter;
    this.f.FlatStyle = FlatStyle.Flat;
    this.f.FormattingEnabled = true;
    this.f.Location = new Point(12, 52);
    this.f.Name = "SystemComboBox";
    this.f.Size = new Size(213, 21);
    this.f.TabIndex = 3;
    this.AcceptButton = (IButtonControl) this.c;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.d;
    this.ClientSize = new Size(242, 110);
    this.Controls.Add((Control) this.f);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.c);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = "CopyEventForm";
    this.Text = "Копирование события";
    this.ResumeLayout(false);
  }
}
