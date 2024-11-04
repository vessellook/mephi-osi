// Decompiled with JetBrains decompiler
// Type: f
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class f : Form
{
  public string a;
  private IContainer b;
  private TextBox c;
  private Label d;
  private Button e;
  private Button f;

  public f() => this.b();

  private void c(object A_0, EventArgs A_1)
  {
    this.a = this.c.Text;
    this.DialogResult = DialogResult.OK;
    this.Close();
  }

  private void b(object A_0, EventArgs A_1) => this.Close();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.b != null)
      this.b.Dispose();
    base.Dispose(disposing);
  }

  private void b()
  {
    this.c = new TextBox();
    this.d = new Label();
    this.e = new Button();
    this.f = new Button();
    this.SuspendLayout();
    this.c.Location = new Point(115, 12);
    this.c.Name = "NametextBox";
    this.c.Size = new Size(100, 20);
    this.c.TabIndex = 0;
    this.d.AutoSize = true;
    this.d.Location = new Point(12, 15);
    this.d.Name = "label1";
    this.d.Size = new Size(97, 13);
    this.d.TabIndex = 1;
    this.d.Text = "Имя переменной:";
    this.e.FlatStyle = FlatStyle.Flat;
    this.e.Location = new Point(145, 38);
    this.e.Name = "OKbutton";
    this.e.Size = new Size(75, 23);
    this.e.TabIndex = 2;
    this.e.Text = "Добавить";
    this.e.UseVisualStyleBackColor = true;
    this.e.Click += new EventHandler(this.c);
    this.f.DialogResult = DialogResult.Cancel;
    this.f.FlatStyle = FlatStyle.Flat;
    this.f.Location = new Point(12, 38);
    this.f.Name = "Cancel_button";
    this.f.Size = new Size(75, 23);
    this.f.TabIndex = 3;
    this.f.Text = "Отмена";
    this.f.UseVisualStyleBackColor = true;
    this.f.Click += new EventHandler(this.b);
    this.AcceptButton = (IButtonControl) this.e;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.f;
    this.ClientSize = new Size(232, 73);
    this.Controls.Add((Control) this.f);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.c);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.Name = "AddVariableForm";
    this.Text = "Добавить переменную";
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
