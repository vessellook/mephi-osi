// Decompiled with JetBrains decompiler
// Type: q
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

#nullable disable
public class q : Form
{
  private IContainer a;
  private TextBox b;
  private ComboBox c;
  private TextBox d;
  private Label e;
  private Label f;
  private NumericUpDown g;
  private Label h;
  private Button i;
  private Button j;

  public q() => this.a();

  private void c(object A_0, EventArgs A_1)
  {
    this.c.SelectedIndex = 0;
    try
    {
      using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\memo.txt", Encoding.Default))
      {
        this.b.Text = streamReader.ReadToEnd();
        streamReader.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(Resources.ErrorFileRead + "\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void b(object A_0, EventArgs A_1)
  {
    if (this.d.Text == "" || this.c.Text == "")
    {
      int num = (int) MessageBox.Show("Вы должны заполнить форму", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else
    {
      v.q = new t();
      v.q.a = this.d.Text;
      v.q.c = (int) this.g.Value;
      v.q.b = this.c.Text;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }

  private void a(object A_0, EventArgs A_1) => this.Close();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.a != null)
      this.a.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.b = new TextBox();
    this.c = new ComboBox();
    this.d = new TextBox();
    this.e = new Label();
    this.f = new Label();
    this.g = new NumericUpDown();
    this.h = new Label();
    this.i = new Button();
    this.j = new Button();
    this.g.BeginInit();
    this.SuspendLayout();
    this.b.BorderStyle = BorderStyle.FixedSingle;
    this.b.Enabled = false;
    this.b.Location = new Point(12, 12);
    this.b.Multiline = true;
    this.b.Name = "MemoTextBox";
    this.b.Size = new Size(260, 125);
    this.b.TabIndex = 0;
    this.c.DropDownStyle = ComboBoxStyle.DropDownList;
    this.c.FlatStyle = FlatStyle.Flat;
    this.c.FormattingEnabled = true;
    this.c.Items.AddRange(new object[4]
    {
      (object) "М23-504",
      (object) "М23-514",
      (object) "М23-524",
      (object) "М23-534"
    });
    this.c.Location = new Point(99, 175);
    this.c.Name = "GroupComboBox";
    this.c.Size = new Size(173, 21);
    this.c.TabIndex = 1;
    this.d.BorderStyle = BorderStyle.FixedSingle;
    this.d.Location = new Point(99, 143);
    this.d.Name = "FIOTextBox";
    this.d.Size = new Size(173, 20);
    this.d.TabIndex = 2;
    this.e.AutoSize = true;
    this.e.Location = new Point(12, 145);
    this.e.Name = "label1";
    this.e.Size = new Size(81, 13);
    this.e.TabIndex = 3;
    this.e.Text = "Фамилия И.О.";
    this.f.AutoSize = true;
    this.f.Location = new Point(9, 178);
    this.f.Name = "label2";
    this.f.Size = new Size(42, 13);
    this.f.TabIndex = 4;
    this.f.Text = "Группа";
    this.g.Location = new Point(99, 203);
    this.g.Minimum = new Decimal(new int[4]{ 1, 0, 0, 0 });
    this.g.Name = "VariantEdit";
    this.g.Size = new Size(173, 20);
    this.g.TabIndex = 5;
    this.g.Value = new Decimal(new int[4]{ 1, 0, 0, 0 });
    this.h.AutoSize = true;
    this.h.Location = new Point(12, 205);
    this.h.Name = "label3";
    this.h.Size = new Size(49, 13);
    this.h.TabIndex = 6;
    this.h.Text = "Вариант";
    this.i.FlatStyle = FlatStyle.Flat;
    this.i.Location = new Point(163, 229);
    this.i.Name = "OKbutton";
    this.i.Size = new Size(109, 23);
    this.i.TabIndex = 7;
    this.i.Text = "Продолжить";
    this.i.UseVisualStyleBackColor = true;
    this.i.Click += new EventHandler(this.b);
    this.j.DialogResult = DialogResult.Cancel;
    this.j.FlatStyle = FlatStyle.Flat;
    this.j.Location = new Point(12, 229);
    this.j.Name = "Cancel_Button";
    this.j.Size = new Size(111, 23);
    this.j.TabIndex = 8;
    this.j.Text = "Отмена";
    this.j.UseVisualStyleBackColor = true;
    this.j.Click += new EventHandler(this.a);
    this.AcceptButton = (IButtonControl) this.i;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.j;
    this.ClientSize = new Size(284, 258);
    this.Controls.Add((Control) this.j);
    this.Controls.Add((Control) this.i);
    this.Controls.Add((Control) this.h);
    this.Controls.Add((Control) this.g);
    this.Controls.Add((Control) this.f);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.c);
    this.Controls.Add((Control) this.b);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.Name = "RegistrForm";
    this.Text = "Регистрация";
    this.Shown += new EventHandler(this.c);
    this.g.EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
