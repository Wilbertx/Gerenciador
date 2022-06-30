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

public class CategoriaInserir : Form
{
    private System.ComponentModel.IContainer components = null;

    Categoria categoria;
    Label lblNome;
    Label lblDescricao;

    TextBox txtNome;
    TextBox txtDescricao;

    Button btnConfirm;
    Button btnCancel;

    public CategoriaInserir()
    {
        this.ClientSize = new System.Drawing.Size(300, 215);

        lblNome = new Label();
        lblNome.Text = "Nome";
        lblNome.Location = new Point(20, 20);

        lblDescricao = new Label();
        lblDescricao.Text = "Descrição";
        lblDescricao.Location = new Point(20, 80);

        txtNome = new TextBox();
        txtNome.Location = new Point(10, 50);
        txtNome.Size = new Size(280, 30);

        txtDescricao = new TextBox();
        txtDescricao.Location = new Point(10, 110);
        txtDescricao.Size = new Size(280, 30);

        btnConfirm = new Button();
        btnConfirm.Text = "Confirmar";
        btnConfirm.Location = new Point(65, 165);
        btnConfirm.Size = new Size(80, 30);
        btnConfirm.Click += new EventHandler(this.btnConfirmClick);

        btnCancel = new Button();
        btnCancel.Text = "Cancelar";
        btnCancel.Location = new Point(155, 165);
        btnCancel.Size = new Size(80, 30);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        this.Controls.Add(this.lblNome);
        this.Controls.Add(this.lblDescricao);

        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.txtDescricao);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Inserir Categoria ";
        this.StartPosition = FormStartPosition.CenterScreen;
    }
    private void btnConfirmClick(object sender, EventArgs e)
    {
        try
        {
            CategoriaController.IncluirCategoria(
                txtNome.Text,
                txtDescricao.Text
            );

            MessageBox.Show("Dados inseridos com sucesso.");
            this.Close();
        }
        catch (System.Exception)
        {
            MessageBox.Show("Não foi possível inserir os dados.");
        }
    }

    public CategoriaInserir(int id)
    {
        this.ClientSize = new System.Drawing.Size(300, 215);

        lblNome = new Label();
        lblNome.Text = "Nome";
        lblNome.Location = new Point(20, 20);

        lblDescricao = new Label();
        lblDescricao.Text = "Descrição";
        lblDescricao.Location = new Point(20, 80);

        txtNome = new TextBox();
        txtNome.Location = new Point(10, 50);
        txtNome.Size = new Size(280, 30);

        txtDescricao = new TextBox();
        txtDescricao.Location = new Point(10, 110);
        txtDescricao.Size = new Size(280, 30);

        btnConfirm = new Button();
        btnConfirm.Text = "Confirmar";
        btnConfirm.Location = new Point(65, 165);
        btnConfirm.Size = new Size(80, 30);
        btnConfirm.Click += new EventHandler(this.btConfirmClick);

        btnCancel = new Button();
        btnCancel.Text = "Cancelar";
        btnCancel.Location = new Point(155, 165);
        btnCancel.Size = new Size(80, 30);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        if (id > 0) {
            this.categoria = CategoriaController.GetCategoria(id);
            this.txtNome.Text = this.categoria.Nome;
        }

        this.Controls.Add(this.lblNome);
        this.Controls.Add(this.lblDescricao);

        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.txtDescricao);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Atualizar Categoria ";
        this.StartPosition = FormStartPosition.CenterScreen;
    }
    private void btConfirmClick(object sender, EventArgs e)
    {
        bool isUpdate = this.categoria != null;
        try
        {
            if (isUpdate) 
            {
                CategoriaController.AlterarCategoria(
                    this.categoria.Id,
                    txtNome.Text,
                    txtDescricao.Text
                );
            } else {
                CategoriaController.IncluirCategoria(
                    txtNome.Text,
                    txtDescricao.Text
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