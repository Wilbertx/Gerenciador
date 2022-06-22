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

public class SenhaInserir : Form //Inserir e Atualizar Senha
{
    private System.ComponentModel.IContainer components = null;

    int id;

    Label lblNome;
    Label lblCategoria;
    Label lblUrl;
    Label lblUsuario;
    Label lblSenha;
    Label lblProcedimento;
    Label lblTags;

    TextBox txtNome;
    TextBox txtCategoria;
    TextBox txtUrl;
    TextBox txtUsuario;
    TextBox txtSenha;
    TextBox txtProcedimento;

    CheckedListBox clbTags;

    ComboBox cbCategoria;

    Button btnConfirm;
    Button btnCancel;

    public SenhaInserir()
    {
        this.ClientSize = new System.Drawing.Size(300, 680);

        this.lblNome = new Label();
        this.lblNome.Text = "Nome";
        this.lblNome.Location = new Point(20, 20);
        this.lblNome.Size = new Size(300, 30);

        this.lblCategoria = new Label();
        this.lblCategoria.Text = "Categoria";
        this.lblCategoria.Location = new Point(20, 80);
        this.lblCategoria.Size = new Size(300, 30);

        this.lblUrl = new Label();
        this.lblUrl.Text = "Url";
        this.lblUrl.Location = new Point(20, 140);
        this.lblUrl.Size = new Size(300, 30);

        this.lblUsuario = new Label();
        this.lblUsuario.Text = "Usuário";
        this.lblUsuario.Location = new Point(20, 200);
        this.lblUsuario.Size = new Size(300, 30);

        this.lblSenha = new Label();
        this.lblSenha.Text = "Senha";
        this.lblSenha.Location = new Point(20, 260);
        this.lblSenha.Size = new Size(300, 30);

        this.lblProcedimento = new Label();
        this.lblProcedimento.Text = "Procedimento";
        this.lblProcedimento.Location = new Point(20, 320);
        this.lblProcedimento.Size = new Size(300, 30);

        this.lblTags = new Label();
        this.lblTags.Text = "Tags";
        this.lblTags.Location = new Point(20, 453);
        this.lblTags.Size = new Size(300, 30);

        this.txtNome = new TextBox();
        this.txtNome.Location = new Point(10, 50);
        this.txtNome.Size = new Size(280, 30);

        string[] categoria = { };
        cbCategoria = new ComboBox();
        foreach (var categorias in categoria)
        {
            cbCategoria.Items.Add(categorias);
        }
        cbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cbCategoria.Location = new Point(10, 110);
        cbCategoria.Size = new Size(280, 30);
        cbCategoria.Sorted = true;

        this.txtUrl = new TextBox();
        this.txtUrl.Location = new Point(10, 170);
        this.txtUrl.Size = new Size(280, 30);

        this.txtUsuario = new TextBox();
        this.txtUsuario.Location = new Point(10, 230);
        this.txtUsuario.Size = new Size(280, 30);

        this.txtSenha = new TextBox();
        this.txtSenha.Location = new Point(10, 290);
        this.txtSenha.Size = new Size(280, 30);
        this.txtSenha.PasswordChar = '*';

        this.txtProcedimento = new TextBox();
        this.txtProcedimento.Multiline = true;
        this.txtProcedimento.ScrollBars = ScrollBars.Vertical;
        this.txtProcedimento.AcceptsReturn = true;
        this.txtProcedimento.WordWrap = true;
        this.txtProcedimento.Location = new Point(10, 350);
        this.txtProcedimento.Size = new Size(280, 30);

        this.clbTags = new CheckedListBox();
        this.clbTags.Location = new Point(10, 483);
        this.clbTags.Size = new Size(280, 100);
        clbTags.SelectionMode = SelectionMode.One;
        clbTags.CheckOnClick = true;

        btnConfirm = new Button();
        btnConfirm.Text = "Confirmar";
        btnConfirm.Location = new Point(60, 620);
        btnConfirm.Size = new Size(80, 30);
        btnConfirm.Click += new EventHandler(this.btConfirmClick);

        btnCancel = new Button();
        btnCancel.Text = "Cancelar";
        btnCancel.Location = new Point(150, 620);
        btnCancel.Size = new Size(80, 30);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        this.Controls.Add(this.lblNome);
        this.Controls.Add(this.lblCategoria);
        this.Controls.Add(this.lblUrl);
        this.Controls.Add(this.lblUsuario);
        this.Controls.Add(this.lblSenha);
        this.Controls.Add(this.lblProcedimento);
        this.Controls.Add(this.lblTags);

        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.cbCategoria);
        this.Controls.Add(this.txtUrl);
        this.Controls.Add(this.txtUsuario);
        this.Controls.Add(this.txtSenha);
        this.Controls.Add(this.txtProcedimento);
        this.Controls.Add(this.clbTags);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Inserir Senhas ";
        this.StartPosition = FormStartPosition.CenterScreen;
    }
    private void btConfirmClick(object sender, EventArgs e)
    {
        try
        {
            SenhaController.IncluirSenha(
                txtNome.Text,
                Convert.ToInt32(txtCategoria),
                txtUrl.Text,
                txtUsuario.Text,
                txtSenha.Text,
                txtProcedimento.Text
            );

            MessageBox.Show("Dados inseridos com sucesso.");
            this.Close();
        }
        catch (System.Exception)
        {
            MessageBox.Show("Não foi possível inserir os dados.");
        }
    }

    public SenhaInserir(int id)
    {
        this.ClientSize = new System.Drawing.Size(300, 680);

        this.lblNome = new Label();
        this.lblNome.Text = "Nome";
        this.lblNome.Location = new Point(20, 20);
        this.lblNome.Size = new Size(300, 30);

        this.lblCategoria = new Label();
        this.lblCategoria.Text = "Categoria";
        this.lblCategoria.Location = new Point(20, 80);
        this.lblCategoria.Size = new Size(300, 30);

        this.lblUrl = new Label();
        this.lblUrl.Text = "Url";
        this.lblUrl.Location = new Point(20, 140);
        this.lblUrl.Size = new Size(300, 30);

        this.lblUsuario = new Label();
        this.lblUsuario.Text = "Usuário";
        this.lblUsuario.Location = new Point(20, 200);
        this.lblUsuario.Size = new Size(300, 30);

        this.lblSenha = new Label();
        this.lblSenha.Text = "Senha";
        this.lblSenha.Location = new Point(20, 260);
        this.lblSenha.Size = new Size(300, 30);

        this.lblProcedimento = new Label();
        this.lblProcedimento.Text = "Procedimento";
        this.lblProcedimento.Location = new Point(20, 320);
        this.lblProcedimento.Size = new Size(300, 30);

        this.lblTags = new Label();
        this.lblTags.Text = "Tags";
        this.lblTags.Location = new Point(20, 453);
        this.lblTags.Size = new Size(300, 30);

        this.txtNome = new TextBox();
        this.txtNome.Location = new Point(10, 50);
        this.txtNome.Size = new Size(280, 30);

        string[] categoria = { };
        cbCategoria = new ComboBox();
        foreach (var categorias in categoria)
        {
            cbCategoria.Items.Add(categorias);
        }
        cbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cbCategoria.Location = new Point(10, 110);
        cbCategoria.Size = new Size(280, 30);
        cbCategoria.Sorted = true;

        this.txtUrl = new TextBox();
        this.txtUrl.Location = new Point(10, 170);
        this.txtUrl.Size = new Size(280, 30);

        this.txtUsuario = new TextBox();
        this.txtUsuario.Location = new Point(10, 230);
        this.txtUsuario.Size = new Size(280, 30);

        this.txtSenha = new TextBox();
        this.txtSenha.Location = new Point(10, 290);
        this.txtSenha.Size = new Size(280, 30);
        this.txtSenha.PasswordChar = '*';

        this.txtProcedimento = new TextBox();
        this.txtProcedimento.Multiline = true;
        this.txtProcedimento.ScrollBars = ScrollBars.Vertical;
        this.txtProcedimento.AcceptsReturn = true;
        this.txtProcedimento.WordWrap = true;
        this.txtProcedimento.Location = new Point(10, 350);
        this.txtProcedimento.Size = new Size(280, 30);

        this.clbTags = new CheckedListBox();
        this.clbTags.Location = new Point(10, 483);
        this.clbTags.Size = new Size(280, 100);
        clbTags.SelectionMode = SelectionMode.One;
        clbTags.CheckOnClick = true;

        btnConfirm = new Button();
        btnConfirm.Text = "Confirmar";
        btnConfirm.Location = new Point(60, 620);
        btnConfirm.Size = new Size(80, 30);
        btnConfirm.Click += new EventHandler(this.btnConfirmClick);

        btnCancel = new Button();
        btnCancel.Text = "Cancelar";
        btnCancel.Location = new Point(150, 620);
        btnCancel.Size = new Size(80, 30);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        this.Controls.Add(this.lblNome);
        this.Controls.Add(this.lblCategoria);
        this.Controls.Add(this.lblUrl);
        this.Controls.Add(this.lblUsuario);
        this.Controls.Add(this.lblSenha);
        this.Controls.Add(this.lblProcedimento);
        this.Controls.Add(this.lblTags);

        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.cbCategoria);
        this.Controls.Add(this.txtUrl);
        this.Controls.Add(this.txtUsuario);
        this.Controls.Add(this.txtSenha);
        this.Controls.Add(this.txtProcedimento);
        this.Controls.Add(this.clbTags);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Atualizar Senhas ";
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void btnConfirmClick(object sender, EventArgs e)
    {            
        Senha senha = SenhaController.GetSenha(id);

        try
        {
            SenhaController.AlterarSenha(
                this.id,
                txtNome.Text,
                Convert.ToInt32(txtCategoria),
                txtUrl.Text,
                txtUsuario.Text,
                txtSenha.Text,
                txtProcedimento.Text
            );

            MessageBox.Show("Dados alterados com sucesso.");
            this.Close();
        }
        catch (System.Exception)
        {
            MessageBox.Show("Não foi possível alterar os dados.");
        }
    }

    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
}