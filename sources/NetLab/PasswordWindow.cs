// Decompiled with JetBrains decompiler
// Type: p
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class PasswordWindow : Form
{
  public string answer;
  private IContainer uselessField;
  private Button okButton;
  private Button cancelButton;
  private TextBox textBox;

  public PasswordWindow() => this.Init();

  private void OnFormClose(object A_0, FormClosedEventArgs A_1) => this.answer = this.textBox.Text;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.uselessField != null)
      this.uselessField.Dispose();
    base.Dispose(disposing);
  }

  private void Init()
  {
    this.okButton = new Button();
    this.cancelButton = new Button();
    this.textBox = new TextBox();
    this.SuspendLayout();
    this.okButton.DialogResult = DialogResult.OK;
    this.okButton.Location = new Point(125, 38);
    this.okButton.Name = "OKbutton";
    this.okButton.Size = new Size(75, 23);
    this.okButton.TabIndex = 1;
    this.okButton.Text = "ОК";
    this.okButton.UseVisualStyleBackColor = true;
    this.cancelButton.DialogResult = DialogResult.Cancel;
    this.cancelButton.Location = new Point(12, 38);
    this.cancelButton.Name = "Cancelbutton";
    this.cancelButton.Size = new Size(75, 23);
    this.cancelButton.TabIndex = 2;
    this.cancelButton.Text = "Отмена";
    this.cancelButton.UseVisualStyleBackColor = true;
    this.textBox.Location = new Point(12, 12);
    this.textBox.Name = "textBox";
    this.textBox.PasswordChar = '*';
    this.textBox.Size = new Size(188, 20);
    this.textBox.TabIndex = 0;
    this.AcceptButton = (IButtonControl) this.okButton;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.cancelButton;
    this.ClientSize = new Size(212, 71);
    this.Controls.Add((Control) this.textBox);
    this.Controls.Add((Control) this.cancelButton);
    this.Controls.Add((Control) this.okButton);
    this.Name = "PasswordForm";
    this.Text = "Введите пароль";
    this.FormClosed += new FormClosedEventHandler(this.OnFormClose);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
