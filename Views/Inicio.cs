using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

public class Inicio : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblLogin;

        Button btnCategorias;
        Button btnTags;
        Button btnSenhas;
        Button btnUsuario;
        Button btnCancel;
        public Inicio()
        {
            this.lblLogin = new Label();
            this.lblLogin.Text = "Olá Matheus";
            this.lblLogin.Location = new Point(117, 20);

            this.btnCategorias = new Button();
            this.btnCategorias = new Button();
            this.btnCategorias = new Button();
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.Location = new Point(40, 60);
            this.btnCategorias.Size = new Size(100, 30);
            this.btnCategorias.Click += new EventHandler(this.handleCategoriasClick);

            this.btnTags = new Button();
            this.btnTags.Text = "Tags";
            this.btnTags.Location = new Point(160, 60);
            this.btnTags.Size = new Size(100, 30);
            this.btnTags.Click += new EventHandler(this.handleTagsClick);

            this.btnSenhas = new Button();
            this.btnSenhas.Text = "Senhas";
            this.btnSenhas.Location = new Point(40, 100);
            this.btnSenhas.Size = new Size(100, 30);
            this.btnSenhas.Click += new EventHandler(this.handleSenhasClick);

            this.btnUsuario = new Button();
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.Location = new Point(160, 100);
            this.btnUsuario.Size = new Size(100, 30);
            this.btnUsuario.Click += new EventHandler(this.handleUsuarioClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Sair";
            this.btnCancel.Location = new Point(110, 200);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblLogin);

            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnSenhas);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnCancel);

        }
        private void handleCategoriasClick(object sender, EventArgs e)
        {
            Categorias menu = new Categorias();
            menu.ShowDialog();
        }
        private void handleTagsClick(object sender, EventArgs e)
        {
            Tags menu = new Tags();
            menu.ShowDialog();
        }
        private void handleSenhasClick(object sender, EventArgs e)
        {
            Senhas menu = new Senhas();
            menu.ShowDialog();
        }
        private void handleUsuarioClick(object sender, EventArgs e)
        {
            Usuarios menu = new Usuarios();
            menu.ShowDialog();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }