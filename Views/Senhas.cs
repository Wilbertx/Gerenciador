using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Controllers;
using Models;

public class Senhas : Form
{
    Label lblSenha;

    Button btnCancel;
    Button btnInsert;
    Button btnDeletar;
    Button btnUpdate;

    ListView listView;
    ListViewItem newLine;

    public Senhas()
    {
        this.ClientSize = new System.Drawing.Size(500, 450);

        lblSenha = new Label();
        lblSenha.Text = "Senhas";
        lblSenha.Location = new Point(220, 25);

        listView = new ListView();
        listView.Location = new Point(45, 70);
        listView.Size = new Size(410, 300);
        listView.View = View.Details;

        listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
        listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
        listView.Columns.Add("Categoria", -2, HorizontalAlignment.Left);
        listView.Columns.Add("Url", -2, HorizontalAlignment.Left);
        listView.FullRowSelect = true;
        listView.GridLines = true;
        listView.AllowColumnReorder = true;
        listView.Sorting = SortOrder.Ascending;

        foreach (Senha item in SenhaController.VisualizarSenha())
        {
            newLine = new ListViewItem(item.Id.ToString());
            newLine.SubItems.Add(item.Nome);
            //newLine.SubItems.Add(item.CategoriaId);
            newLine.SubItems.Add(item.Url);
            listView.Items.Add(newLine);
        }

        btnCancel = new Button();
        btnCancel.Text = "Cancelar";
        btnCancel.Location = new Point(360, 400);
        btnCancel.Size = new Size(80, 30);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        btnInsert = new Button();
        btnInsert.Text = "Inserir";
        btnInsert.Location = new Point(60, 400);
        btnInsert.Size = new Size(80, 30);
        btnInsert.Click += new EventHandler(this.btnSenhaInserir);

        btnDeletar = new Button();
        btnDeletar.Text = "Deletar";
        btnDeletar.Location = new Point(160, 400);
        btnDeletar.Size = new Size(80, 30);
        btnDeletar.Click += new EventHandler(this.btnSenhaDeletar);

        btnUpdate = new Button();
        btnUpdate.Text = "Atualizar";
        btnUpdate.Location = new Point(260, 400);
        btnUpdate.Size = new Size(80, 30);
        btnUpdate.Click += new EventHandler(this.btnSenhaAtualizar);

        this.Controls.Add(listView);
        this.Controls.Add(this.lblSenha);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnInsert);
        this.Controls.Add(this.btnDeletar);
        this.Controls.Add(this.btnUpdate);
    }
    
    private void btnSenhaInserir(object sender, EventArgs e)
    {
        SenhaInserir form = new SenhaInserir();
        form.Show();
    }
    private void btnSenhaDeletar(object sender, EventArgs e)
    {
        ListViewItem itemSelecionado = listView.SelectedItems[0];
        new SenhaDeletar(Convert.ToInt32(itemSelecionado.Text)).Show();
    }
    private void btnSenhaAtualizar(object sender, EventArgs e)
    {
        ListViewItem itemSelecionado = listView.SelectedItems[0];
        new SenhaInserir(Convert.ToInt32(itemSelecionado.Text)).Show();
    }

    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
}