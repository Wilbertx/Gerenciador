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

public class Tags : Form //Tags
{
    Label lblTags;

    Button btnCancel;
    Button btnInsert;
    Button btnDeletar;
    Button btnUpdate;

    ListView listView;
    ListViewItem newLine;
    public Tags()
    {
        this.ClientSize = new System.Drawing.Size(500, 450);
 
        lblTags = new Label();       
        lblTags.Text = "Tags";       
        lblTags.Location = new Point(220, 25);
     
        listView = new ListView();     
        listView.Location = new Point(45, 70);     
        listView.Size = new Size(410, 300);     
        listView.View = View.Details;    

        listView.Columns.Add("ID", -2, HorizontalAlignment.Left);  
        listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);  
        listView.FullRowSelect = true; 
        listView.GridLines = true; 
        listView.AllowColumnReorder = true; 
        listView.Sorting = SortOrder.Ascending;

        foreach (Tag item in TagController.VisualizarTag())
        {
            newLine = new ListViewItem(item.Id.ToString());
            newLine.SubItems.Add(item.Descricao);
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
        btnInsert.Click += new EventHandler(this.btnTagsInserir);
   
        btnDeletar = new Button();       
        btnDeletar.Text = "Deletar";        
        btnDeletar.Location = new Point(160, 400);       
        btnDeletar.Size = new Size(80, 30);        
        btnDeletar.Click += new EventHandler(this.btnTagsDeletar);
        
        btnUpdate = new Button();       
        btnUpdate.Text = "Atualizar";       
        btnUpdate.Location = new Point(260, 400);       
        btnUpdate.Size = new Size(80, 30);       
        btnUpdate.Click += new EventHandler(this.btnTagsAtualizar);
       
        this.Controls.Add(listView);        
        this.Controls.Add(this.lblTags);        
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnInsert);
        this.Controls.Add(this.btnDeletar);
        this.Controls.Add(this.btnUpdate);
    }
    private void btnTagsInserir(object sender, EventArgs e)
    {
        TagsInserir form = new TagsInserir();
        form.Show();
    }
    private void btnTagsDeletar(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count > 0)
        {
            ListViewItem itemSelecionado = listView.SelectedItems[0];
            new TagsDeletar(Convert.ToInt32(itemSelecionado.Text)).Show();
        }
        else
        {
            MessageBox.Show("Não há itens selecionados");
        }
    }
    private void btnTagsAtualizar(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count > 0)
        {
            ListViewItem itemSelecionado = listView.SelectedItems[0];
            new TagsInserir(Convert.ToInt32(itemSelecionado.Text)).Show();
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