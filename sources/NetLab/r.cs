// Decompiled with JetBrains decompiler
// Type: r
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class r : Form
{
  private string a;
  private ak[] b;
  private IContainer c;
  private TextBox d;
  private Label e;
  private Button f;
  private Button g;

  public r(string A_0, ak[] A_1)
  {
    this.a();
    this.a = A_0;
    this.b = A_1;
    this.d.Text = A_0;
  }

  private void b(object A_0, EventArgs A_1) => this.Close();

  private void a(object A_0, EventArgs A_1)
  {
    for (int index1 = 0; index1 < this.b.Length; ++index1)
    {
      if (this.d.Text != "")
      {
        if (this.b[index1].h().IndexOfKey((object) this.d.Text) == -1)
        {
          int index2 = this.b[index1].h().IndexOfKey((object) this.a);
          aj byIndex = (aj) this.b[index1].h().GetByIndex(index2);
          this.b[index1].h().RemoveAt(index2);
          byIndex.a(this.d.Text);
          this.b[index1].h().Add((object) byIndex.o(), (object) byIndex);
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.c != null)
      this.c.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.d = new TextBox();
    this.e = new Label();
    this.f = new Button();
    this.g = new Button();
    this.SuspendLayout();
    this.d.Location = new Point(12, 29);
    this.d.Name = "NewNameTextBox";
    this.d.Size = new Size(217, 20);
    this.d.TabIndex = 0;
    this.e.AutoSize = true;
    this.e.Location = new Point(13, 13);
    this.e.Name = "label1";
    this.e.Size = new Size(157, 13);
    this.e.TabIndex = 1;
    this.e.Text = "Введите новое имя события :";
    this.f.Location = new Point(12, 55);
    this.f.Name = "RenameButton";
    this.f.Size = new Size(100, 25);
    this.f.TabIndex = 2;
    this.f.Text = "Переименовать";
    this.f.UseVisualStyleBackColor = true;
    this.f.Click += new EventHandler(this.a);
    this.g.DialogResult = DialogResult.Cancel;
    this.g.Location = new Point(129, 55);
    this.g.Name = "Cancel_Button";
    this.g.Size = new Size(100, 25);
    this.g.TabIndex = 3;
    this.g.Text = "Отмена";
    this.g.UseVisualStyleBackColor = true;
    this.g.Click += new EventHandler(this.b);
    this.AcceptButton = (IButtonControl) this.f;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.g;
    this.ClientSize = new Size(241, 88);
    this.Controls.Add((Control) this.g);
    this.Controls.Add((Control) this.f);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "RenameEventDlg";
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Переименовать событие";
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
