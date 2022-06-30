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

public class TagsInserir : Form
{
    private System.ComponentModel.IContainer components = null;

    Tag tag;

    Label lblDescricao;

    TextBox txtDescricao;

    Button btnConfirm;
    Button btnCancel;

    public TagsInserir(int id = 0)
    {
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        
        this.ClientSize = new System.Drawing.Size(300, 215);

        lblDescricao = new Label();
        lblDescricao.Text = "Descrição";
        lblDescricao.Location = new Point(20, 20);

        txtDescricao = new TextBox();
        txtDescricao.Location = new Point(10, 50);
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

        if (id > 0) {
            this.tag = TagController.GetTag(id);
            this.txtDescricao.Text = this.tag.Descricao;
        }

        this.Controls.Add(this.lblDescricao);

        this.Controls.Add(this.txtDescricao);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = id > 0 ? "Alterar Tag " : "Inserir Tag ";
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void btnConfirmClick(object sender, EventArgs e)
    {
        bool isUpdate = this.tag != null;
        try
        {
            if (isUpdate) 
            {
                TagController.AlterarTag(
                    this.tag.Id,
                    txtDescricao.Text
                );
            } else {
                TagController.IncluirTag(
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