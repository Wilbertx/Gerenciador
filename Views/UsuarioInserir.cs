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
using Controllers;

public class UsuarioInserir : Form
{
    private System.ComponentModel.IContainer components = null;

    Usuario usuario;

    Label lblNome;
    Label lblEmail;
    Label lblSenha;

    TextBox txtNome;
    TextBox txtEmail;
    TextBox txtSenha;

    Button btnConfirm;
    Button btnCancel;

    public UsuarioInserir(int id = 0)
    {
        this.ClientSize = new System.Drawing.Size(300, 285);

        this.lblNome = new Label();
        this.lblNome.Text = "Nome";
        this.lblNome.Location = new Point(20, 20);

        this.lblEmail = new Label();
        this.lblEmail.Text = "Email";
        this.lblEmail.Location = new Point(20, 80);
        this.lblEmail.Size = new Size(300, 30);

        this.lblSenha = new Label();
        this.lblSenha.Text = "Senha";
        this.lblSenha.Location = new Point(20, 140);
        this.lblSenha.Size = new Size(300, 30);

        this.txtNome = new TextBox();
        this.txtNome.Location = new Point(10, 50);
        this.txtNome.Size = new Size(280, 30);

        this.txtEmail = new TextBox();
        this.txtEmail.Location = new Point(10, 110);
        this.txtEmail.Size = new Size(280, 30);

        this.txtSenha = new TextBox();
        this.txtSenha.Location = new Point(10, 170);
        this.txtSenha.Size = new Size(280, 30);
        this.txtSenha.PasswordChar = '*'; 

        btnConfirm = new Button();
        btnConfirm.Text = "Confirmar";
        btnConfirm.Location = new Point(65, 215);
        btnConfirm.Size = new Size(80, 30);
        btnConfirm.Click += new EventHandler(this.btnConfirmClick);

        btnCancel = new Button();
        btnCancel.Text = "Cancelar";
        btnCancel.Location = new Point(155, 215);
        btnCancel.Size = new Size(80, 30);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        if (id > 0) {
            this.usuario = UsuarioController.GetUsuario(id);
            this.txtNome.Text = this.usuario.Nome;
        }

        this.Controls.Add(this.lblNome);
        this.Controls.Add(this.lblEmail);
        this.Controls.Add(this.lblSenha);

        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.txtEmail);
        this.Controls.Add(this.txtSenha);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = id > 0 ? "Alterar Usuário " : "Inserir Usuário ";
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void btnConfirmClick(object sender, EventArgs e)
    {
        bool isUpdate = this.usuario != null;
        try
        {
            if (isUpdate) 
            {
                UsuarioController.AlterarUsuario(
                    this.usuario.Id,
                    txtNome.Text,
                    txtEmail.Text,
                    txtSenha.Text
                );
            } else {
                UsuarioController.IncluirUsuario(
                    txtNome.Text,
                    txtEmail.Text,
                    txtSenha.Text
                );
            }

            MessageBox.Show($"Dados {(isUpdate ? "alterados" : "incluídos")} com sucesso.");
            this.Close();
        }
        catch (Exception err)
        {
            MessageBox.Show($"Não foi possível {(isUpdate ? "alterar" : "incluir")} os dados. {err.Message}");
        }
    }
    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
}