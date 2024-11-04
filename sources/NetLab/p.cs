// Decompiled with JetBrains decompiler
// Type: p
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class p : Form
{
  public string a;
  private IContainer b;
  private Button c;
  private Button d;
  private TextBox e;

  public p() => this.b();

  private void b(object A_0, FormClosedEventArgs A_1) => this.a = this.e.Text;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.b != null)
      this.b.Dispose();
    base.Dispose(disposing);
  }

  private void b()
  {
    this.c = new Button();
    this.d = new Button();
    this.e = new TextBox();
    this.SuspendLayout();
    this.c.DialogResult = DialogResult.OK;
    this.c.Location = new Point(125, 38);
    this.c.Name = "OKbutton";
    this.c.Size = new Size(75, 23);
    this.c.TabIndex = 1;
    this.c.Text = "ОК";
    this.c.UseVisualStyleBackColor = true;
    this.d.DialogResult = DialogResult.Cancel;
    this.d.Location = new Point(12, 38);
    this.d.Name = "Cancelbutton";
    this.d.Size = new Size(75, 23);
    this.d.TabIndex = 2;
    this.d.Text = "Отмена";
    this.d.UseVisualStyleBackColor = true;
    this.e.Location = new Point(12, 12);
    this.e.Name = "textBox";
    this.e.PasswordChar = '*';
    this.e.Size = new Size(188, 20);
    this.e.TabIndex = 0;
    this.AcceptButton = (IButtonControl) this.c;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.d;
    this.ClientSize = new Size(212, 71);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.c);
    this.Name = "PasswordForm";
    this.Text = "Введите пароль";
    this.FormClosed += new FormClosedEventHandler(this.b);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
