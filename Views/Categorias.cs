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

public class Categorias : Form 
{
    Label lblCategorias;

    Button btnCancel;
    Button btnInsert;
    Button btnDeletar;
    Button btnUpdate;

    ListView listView;
    ListViewItem newLine;
    public Categorias()
    {
            this.ClientSize = new System.Drawing.Size(500, 450);

            lblCategorias = new Label();
            lblCategorias.Text = "Categorias";
            lblCategorias.Location = new Point(220, 25);

            listView = new ListView();
            listView.Location = new Point(45, 70);
            listView.Size = new Size(410, 300);
            listView.View = View.Details;

            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new Point(360, 400);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Click += new EventHandler(this.btnCancelClick);

            btnInsert = new Button();
            btnInsert.Text = "Inserir";
            btnInsert.Location = new Point(60, 400);
            btnInsert.Size = new Size(80, 30);
            btnInsert.Click += new EventHandler(this.btnCategoriasInserir);

            btnDeletar = new Button();
            btnDeletar.Text = "Deletar";
            btnDeletar.Location = new Point(160, 400);
            btnDeletar.Size = new Size(80, 30);
            btnDeletar.Click += new EventHandler(this.btnCategoriasDeletar);

            btnUpdate = new Button();
            btnUpdate.Text = "Atualizar";
            btnUpdate.Location = new Point(260, 400);
            btnUpdate.Size = new Size(80, 30);
            btnUpdate.Click += new EventHandler(this.btnCategoriasAtualizar);

            this.Controls.Add(listView);
            this.Controls.Add(this.lblCategorias);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnUpdate);
    }
    private void btnCategoriasInserir(object sender, EventArgs e)
    {
        CategoriaInserir form = new CategoriaInserir();
        form.Show();
    }
    private void btnCategoriasDeletar(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count > 0)
        {
            ListViewItem itemSelecionado = listView.SelectedItems[0];
            new CategoriaDeletar(Convert.ToInt32(itemSelecionado.Text)).Show();
        }
        else
        {
            MessageBox.Show("Não há itens selecionados");
        }
    }
    private void btnCategoriasAtualizar(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count > 0)
        {
            ListViewItem itemSelecionado = listView.SelectedItems[0];
            new CategoriaInserir(Convert.ToInt32(itemSelecionado.Text)).Show();
        }
        else
        {
            MessageBox.Show("Não há itens selecionados");
        }
    }

    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
}