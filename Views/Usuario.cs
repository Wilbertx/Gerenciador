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

public class Usuarios : Form 
{
    Label lblUsuario;
    Button btnCancel;
    Button btnInsert;
    Button btnDeletar;
    Button btnUpdate;
    ListView listView;
    ListViewItem newLine;

    public Usuarios()
    {
        this.ClientSize = new System.Drawing.Size(500, 450);

        lblUsuario = new Label();
        lblUsuario.Text = "Usuario";
        lblUsuario.Location = new Point(220, 25);

        listView = new ListView();
        listView.Location = new Point(45, 70);
        listView.Size = new Size(410, 300);
        listView.View = View.Details;

        listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
        listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
        listView.Columns.Add("Email", -2, HorizontalAlignment.Left);
        listView.FullRowSelect = true;
        listView.GridLines = true;
        listView.AllowColumnReorder = true;
        listView.Sorting = SortOrder.Ascending;

        foreach (Usuario item in UsuarioController.VisualizarUsuario())
        {
            newLine = new ListViewItem(item.Id.ToString());
            newLine.SubItems.Add(item.Nome);
            newLine.SubItems.Add(item.Email);
            newLine.SubItems.Add(item.Senha);
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
        btnInsert.Click += new EventHandler(this.btnUsuarioInserir);

        btnDeletar = new Button();
        btnDeletar.Text = "Deletar";
        btnDeletar.Location = new Point(160, 400);
        btnDeletar.Size = new Size(80, 30);
        btnDeletar.Click += new EventHandler(this.btnUsuarioDeletar);

        btnUpdate = new Button();
        btnUpdate.Text = "Atualizar";
        btnUpdate.Location = new Point(260, 400);
        btnUpdate.Size = new Size(80, 30);
        btnUpdate.Click += new EventHandler(this.btnUsuarioAtualizar);

        this.Controls.Add(listView);
        this.Controls.Add(this.lblUsuario);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnInsert);
        this.Controls.Add(this.btnDeletar);
        this.Controls.Add(this.btnUpdate);
    }

    private void btnUsuarioInserir(object sender, EventArgs e)
    {
        UsuarioInserir form = new UsuarioInserir();
        form.Show();
    }
    private void btnUsuarioDeletar(object sender, EventArgs e)
    {
        ListViewItem itemSelecionado = listView.SelectedItems[0];
        new UsuarioDeletar(Convert.ToInt32(itemSelecionado.Text)).Show();
    }
    private void btnUsuarioAtualizar(object sender, EventArgs e)
    {
        ListViewItem itemSelecionado = listView.SelectedItems[0];
        new UsuarioInserir(Convert.ToInt32(itemSelecionado.Text)).Show();
    }

    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
}