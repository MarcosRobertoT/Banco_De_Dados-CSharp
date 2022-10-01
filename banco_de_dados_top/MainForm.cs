/*
 * Criado por SharpDevelop.
 * Usuário: José Roberto
 * Data: 31/08/2022
 * Hora: 20:56
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO; //Permite gravar qual o código do erro

namespace banco_de_dados_top
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		void Limpar()
		{

			textBox2.Clear();
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			label1.Text = richTextBox1.Lines.Length.ToString();
		}
		void Button1Click(object sender, EventArgs e)
		{
			//Salva um arquivo
			richTextBox1.SaveFile(textBox1.Text, RichTextBoxStreamType.PlainText);
			MessageBox.Show("Arquivo salvo com sucesso!");//Mostra uma mensagem na tela
			label1.Text = richTextBox1.Lines.Length.ToString();
		}
		void Button2Click(object sender, EventArgs e)
		{
			//Carrega um arquivo já salvo
			richTextBox1.LoadFile(textBox1.Text, RichTextBoxStreamType.PlainText);
		}
		void Button3Click(object sender, EventArgs e)
		{
			string linhaNova = textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text;
			
			if (textBox2.Text == ""  || textBox3.Text == "" || textBox4.Text == "")
			{
				MessageBox.Show("Preencha todos os campos");
			}
			else
			{
				if (int.Parse(label1.Text) == richTextBox1.Lines.Length)
				{
					//Manda os dados das textBox.Text para a richTextBox.Text
					richTextBox1.Text = richTextBox1.Text + "\n" + linhaNova;
					richTextBox1.SaveFile("lista", RichTextBoxStreamType.PlainText);
					MessageBox.Show("Arquivos salvos co sucesso");
				}
				else
				{
					//Modifica um registro
					string linhaVelha = richTextBox1.Lines[int.Parse(label1.Text)];
					richTextBox1.Text = richTextBox1.Text.Replace(linhaVelha, linhaNova);
					richTextBox1.SaveFile("lista", RichTextBoxStreamType.PlainText);
					MessageBox.Show("Arquivos salvos com sucesso");
				}
			}
			Limpar();
			label1.Text = richTextBox1.Lines.Length.ToString();
		}
		void Button4Click(object sender, EventArgs e)
		{
			string linha;
			string[] dados;
			int numLinha;
			//Buscar a linha
			try
			{
				numLinha = int.Parse(textBox5.Text);
				linha = richTextBox1.Lines[numLinha];
				dados = linha.Split('|');
				textBox2.Text = dados[0];
				textBox3.Text = dados[1];
				textBox4.Text = dados[2];
				label1.Text = textBox5.Text;
			}
			catch
			{
				MessageBox.Show("Arquivo não existe/inválido.");
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			try
			{
				richTextBox1.LoadFile("lista", RichTextBoxStreamType.PlainText); //Deixa a "lista" aberta
			}
			catch
			{
				richTextBox1.SaveFile("lista", RichTextBoxStreamType.PlainText);
				MessageBox.Show("Primeira vez iniciando o programa. \n Criando arquivo lista");
			}
			//Inserir número do registro no label
			label1.Text = richTextBox1.Lines.Length.ToString();
		}
		void Button5Click(object sender, EventArgs e)
		{
			Limpar();
		}
	}
}
