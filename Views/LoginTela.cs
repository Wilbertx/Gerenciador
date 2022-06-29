using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
    
public class Login : Form
{
    private System.ComponentModel.IContainer components = null;

    Label lblUser;
    Label lblPass;

    TextBox txtUser;
    TextBox txtPass;

    Button btnConfirm;
    Button btnCancel;
    Button btnCadastrar;

    public Login()
    {
        this.ClientSize = new System.Drawing.Size(300, 300);

        this.lblUser = new Label();
        this.lblUser.Text = "Usuário";
        this.lblUser.Location = new Point(10, 20);

        this.lblPass = new Label();
        this.lblPass.Text = "Senha";
        this.lblPass.Location = new Point(10, 83);

        this.txtUser = new TextBox();
        this.txtUser.Location = new Point(10, 50);
        this.txtUser.Size = new Size(280, 30);  

        this.txtPass = new TextBox();
        this.txtPass.Location = new Point(10, 110);
        this.txtPass.Size = new Size(280, 30);
        this.txtPass.PasswordChar = '*'; 

        this.btnConfirm = new Button();
        this.btnConfirm.Text = "Confirmar";
        this.btnConfirm.Location = new Point(106, 180);
        this.btnConfirm.Size = new Size(80, 30);
        this.btnConfirm.Click += new EventHandler(this.btnConfirmClick); 

        this.btnCancel = new Button();
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Location = new Point(106, 220);
        this.btnCancel.Size = new Size(80, 30);
        this.btnCancel.Click += new EventHandler(this.btnCancelClick); 

        this.btnCadastrar = new Button();
        this.btnCadastrar.Text = "Cadastrar";
        this.btnCadastrar.Location = new Point(106, 260);
        this.btnCadastrar.Size = new Size(80, 30);
        this.btnCadastrar.Click += new EventHandler(this.btnCadastrarClick);   

        this.Controls.Add(this.lblUser);
        this.Controls.Add(this.lblPass);        
        this.Controls.Add(this.txtUser);
        this.Controls.Add(this.txtPass);        
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);
        this.Controls.Add(this.btnCadastrar);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Login";
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void btnConfirmClick(object sender, EventArgs e)
    {
        try
        {
            Usuario.Auth(this.txtUser.Text, this.txtPass.Text);
            (new Inicio()).Show();
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message);
        }
    }

    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnCadastrarClick(object sender, EventArgs e)
    {
        UsuarioInserir form = new UsuarioInserir();
        form.Show();
    }
}    